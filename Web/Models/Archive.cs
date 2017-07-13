using System.Collections.Generic;
using System.Web;

namespace MarkdownBlog.Net.Web.Models {
    public class Archive : SiteViewModel {
        public string Month { get; set; }
        public int Year { get; set; }

        public IEnumerable<PostMetadata> ArchivePosts { get {return Posts.PostsByMonth(Month, Year); } }

        public Archive(HttpContextWrapper httpContext) : base(httpContext) {
        }
    }
}