using System;
using System.IO;
using System.Web;

namespace Web.Models {
    public class Post {
        private readonly HttpContextWrapper _httpContext;
        private string _body;

        public Post(HttpContextWrapper httpContext) {
            _httpContext = httpContext;
        }

        public string Body {
            get {
                if (string.IsNullOrWhiteSpace(_body)) {
                    var markdown = new MarkdownSharp.Markdown();
                    using (var reader = new StreamReader(_httpContext.Server.MapPath("~/pages/home.markdown"))) {
                        _body = markdown.Transform(reader.ReadToEnd());
                    }
                }
                return _body;
            }
        }
    }
}