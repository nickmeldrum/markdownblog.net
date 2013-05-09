using System;
using System.IO;
using System.Linq;
using System.Web;
using MarkdownSharp;

namespace MarkdownBlog.Net.Web.Models {
    public class Post : SiteViewModel {
        private readonly string _postExtension = ".md";

        private readonly string _postName;

        private string _body;
        public PostMetadata Metadata { get; private set; }

        public Post(string postName, HttpContextWrapper httpContext) : base(httpContext)
        {
            _postName = postName;

            if (!File.Exists(PostBodyPath) || !Posts.List.Any(p => p.Title == _postName))
            {
                throw new FileNotFoundException();
            }

            Metadata = Posts.List.Single(p => p.Title == _postName);
        }

        private string PostBodyPath { get { return HttpContext.Server.MapPath(Posts.PostsRoot + _postName + _postExtension); } }

        public string Body {
            get {
                if (string.IsNullOrWhiteSpace(_body)) {

                    if (!File.Exists(PostBodyPath))
                        throw new Exception("404!"); // TODO: do this as a proper 404!

                    using (var reader = new StreamReader(PostBodyPath)) {
                        _body = new Markdown().Transform(reader.ReadToEnd());
                    }
                }
                return _body;
            }
        }
    }
}