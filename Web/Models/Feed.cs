using System;
using System.Collections.Generic;
using System.ServiceModel.Syndication;
using System.Web;

namespace MarkdownBlog.Net.Web.Models {
    public class Feed {

        public FeedResult GetFeedXml(FeedType feedType) {
            switch (feedType) {
                case FeedType.atom:
                    return new FeedResult(new Atom10FeedFormatter(_feed));
                case FeedType.rss:
                    return new FeedResult(new Rss20FeedFormatter(_feed));
            }

            throw new Exception("Unknown feed type");
        }

        public Feed(Posts posts, HttpContextWrapper contextWrapper) {
            _contextWrapper = contextWrapper;

            SetupFeed();

            AddPostsToFeed(posts);
        }

        private HttpContextWrapper _contextWrapper;
        private SyndicationFeed _feed;

        private void SetupFeed() {
            _feed = new SyndicationFeed {
                Title = SyndicationContent.CreatePlaintextContent(Site.SiteData.Name),
                Description = SyndicationContent.CreatePlaintextContent(Site.SiteData.Description),
                Copyright = SyndicationContent.CreatePlaintextContent("Copyright " + Site.SiteData.Owner),
                Language = "en-gb"
            };

            _feed.Links.Add(SyndicationLink.CreateAlternateLink(Site.GetAbsoluteUrl("~/blog")));
            _feed.Links.Add(SyndicationLink.CreateSelfLink(new Uri(_contextWrapper.Request.Url.AbsoluteUri)));
        }

        private void AddPostsToFeed(Posts posts) {
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
            _feed.Items = feedItems;
        }
    }
}