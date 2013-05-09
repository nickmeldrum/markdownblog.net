using System;
using System.Collections.Generic;
using System.ServiceModel.Syndication;
using System.Web;
using System.Web.Mvc;
using MarkdownBlog.Net.Web.Models;

namespace MarkdownBlog.Net.Web.Controllers {
    public class BlogController : BlogControllerBase {
        public ActionResult Index() {
            return View(new Posts(HttpContextWrapper));
        }

        public ActionResult Post(string postName) {
            return string.IsNullOrWhiteSpace(postName)
                ? View("Index")
                : View("Post", new Post(postName, HttpContextWrapper));
        }

        public ActionResult Archive(Archive archive) {
            archive.GetPosts(HttpContextWrapper);
            return View(archive);
        }

        public ActionResult Feed(string type) {
            var feedType = FeedType.unknown;

            if (!Enum.TryParse(type.ToLower(), out feedType)) {
                SendHttpStatusResponse(404);
            }

            var feed = new SyndicationFeed {
                Title = SyndicationContent.CreatePlaintextContent(Site.SiteData.Name),
                Description = SyndicationContent.CreatePlaintextContent(Site.SiteData.Description),
                Copyright = SyndicationContent.CreatePlaintextContent("Copyright " + Site.SiteData.Owner),
                Language = "en-gb"
            };

            feed.Links.Add(SyndicationLink.CreateAlternateLink(Site.GetAbsoluteUrl("~/blog")));
            feed.Links.Add(SyndicationLink.CreateSelfLink(new Uri(Request.Url.AbsoluteUri)));

            var posts = new Posts(HttpContextWrapper);
            var feedItems = new List<SyndicationItem>();

            foreach (var post in posts.List) {
                var item = new SyndicationItem {
                    Title = SyndicationContent.CreatePlaintextContent(post.Title),
                    Summary = SyndicationContent.CreatePlaintextContent(post.ShortDescription),
                    PublishDate = post.PublishDate,
                    LastUpdatedTime = post.PublishDate
                };
                item.Links.Add(SyndicationLink.CreateSelfLink(Site.GetAbsoluteUrl("~/blog/" + post.Title)));
                item.Authors.Add(new SyndicationPerson { Name = post.Author });

                feedItems.Add(item);
            }
            feed.Items = feedItems;

            switch (feedType) {
                case FeedType.atom:
                    return new FeedResult(new Atom10FeedFormatter(feed));
                case FeedType.rss:
                    return new FeedResult(new Rss20FeedFormatter(feed));
            }

            return View("Index");
        }
    }
}