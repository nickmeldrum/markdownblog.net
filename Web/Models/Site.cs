using System;
using System.Web;

namespace MarkdownBlog.Net.Web.Models {
    public class Site {
        public static readonly Site SiteData = new Site();

        public string Name { get { return "Blog"; } }
        public string Description { get { return "Blog Description"; } }
        public string Owner { get { return "Blog Owner"; } }

        public string DisqusShortName { get { return "ForumShortName"; } }

        private Site() {
        }
    }
}