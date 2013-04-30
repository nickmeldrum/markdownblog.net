using System;
using System.IO;
using System.Web;
using MarkdownSharp;

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
                    var markdown = new Markdown();
                    using (var reader = new StreamReader(GetMarkdownPathFromUrl(_httpContext.Request.Url))) {
                        _body = markdown.Transform(reader.ReadToEnd());
                    }
                }
                return _body;
            }
        }

        private string GetMarkdownPathFromUrl(Uri url) {
            var markdownPath = "~/pages";

            if (File.Exists(_httpContext.Server.MapPath("~/pages" + url.LocalPath.TrimEnd(new[] { '/' }) + ".markdown"))) {
                // then it's a file
                markdownPath += url.LocalPath.TrimEnd(new[] {'/'});
            }
            else if (File.Exists(_httpContext.Server.MapPath("~/pages" + url.LocalPath + "home.markdown"))) {
                // then it's a folder
                markdownPath += url.LocalPath + "home";
            }
            else if (File.Exists(_httpContext.Server.MapPath("~/pages" + url.LocalPath + "/home.markdown"))) {
                // then it's a folder
                markdownPath += url.LocalPath + "/home";
            }
            else {
                // it's a 404
                throw new Exception("404!");
            }

            markdownPath = markdownPath + ".markdown";

            return _httpContext.Server.MapPath(markdownPath);
        }
    }
}