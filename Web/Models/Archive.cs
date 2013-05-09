using System.Collections.Generic;
using System.Web;

namespace MarkdownBlog.Net.Web.Models {
    public class Archive {
        public string Month { get; set; }
        public int Year { get; set; }

        public IEnumerable<PostMetadata> Posts { get; private set; }

        public void GetPosts(HttpContextWrapper httpContextWrapper) {
            Posts = new Posts(httpContextWrapper).PostsByMonth(Month, Year);
        }
    }
}