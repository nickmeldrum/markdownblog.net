using MarkdownBlog.Net.Web.Models;
using System;
using System.IO;
using System.Web.Mvc;

namespace MarkdownBlog.Net.Web.Controllers {
    public class BlogController : BlogControllerBase {
        public ActionResult Index() {
            return View(new Posts(HttpContextWrapper));
        }

        public ActionResult Post(string postName)
        {
            try
            {
                return string.IsNullOrWhiteSpace(postName)
                    ? View("Index")
                    : View("Post", new Post(postName, HttpContextWrapper));
            }
            catch (FileNotFoundException ex)
            {
                HttpContextWrapper.SendHttpStatusResponse(404);
            }

            return View("Index");
        }

        public ActionResult Archive(Archive archive) {
            archive.GetPosts(HttpContextWrapper);
            return View(archive);
        }

        public ActionResult Feed(string type) {
            var feedType = FeedType.unknown;

            if (!Enum.TryParse(type.ToLower(), out feedType)) {
                HttpContextWrapper.SendHttpStatusResponse(404);
            }

            var posts = new Posts(HttpContextWrapper);
            var feed = new Feed(posts, HttpContextWrapper);

            return feed.GetFeedXml(feedType);
        }
    }
}