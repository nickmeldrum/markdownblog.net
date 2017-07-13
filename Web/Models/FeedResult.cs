using System;
using System.ServiceModel.Syndication;
using System.Text;
using System.Web.Mvc;
using System.Xml;

namespace MarkdownBlog.Net.Web.Models {
    public class FeedResult : ActionResult {
        public Encoding ContentEncoding { get; set; }
        public SyndicationFeedFormatter FeedFormat { get; private set; }

        public FeedResult(SyndicationFeedFormatter feedFormat) {
            FeedFormat = feedFormat;
        }

        public override void ExecuteResult(ControllerContext context) {
            if (context == null)
                throw new ArgumentNullException("context");

            if (FeedFormat == null)
                FeedFormat = new Atom10FeedFormatter();

            context.HttpContext.Response.ContentType = (FeedFormat.GetType() == typeof(Rss20FeedFormatter))
                ? "application/rss+xml" : "application/atom+xml";

            if (ContentEncoding != null)
                context.HttpContext.Response.ContentEncoding = ContentEncoding;

            using (var xmlWriter = new XmlTextWriter(context.HttpContext.Response.Output)) {
                xmlWriter.Formatting = Formatting.Indented;
                FeedFormat.WriteTo(xmlWriter);
            }
        }
    }
}