using System;
using System.IO;
using System.Web;
using MarkdownSharp;

namespace MarkdownBlog.Net.Web.Models {
    public class Post {
        private readonly string _pageExtension = ".md";
        private readonly string _pagesRoot = "~/pages";
        private readonly string _homePagename = "home";

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

        private string GetMarkdownPathFromUrl(Uri url)
        {
            var pagePath = string.Empty;

            if (File.Exists(_httpContext.Server.MapPath(_pagesRoot + url.LocalPath.TrimEnd(new[] { '/' }) + _pageExtension))) {
                // then it's a file
                pagePath += url.LocalPath.TrimEnd(new[] {'/'});
            }
            else if (File.Exists(_httpContext.Server.MapPath(_pagesRoot + url.LocalPath + _homePagename + _pageExtension))) {
                // then it's a folder
                pagePath += url.LocalPath + _homePagename;
            }
            else if (File.Exists(_httpContext.Server.MapPath(_pagesRoot + url.LocalPath + "/" + _homePagename + _pageExtension))) {
                // then it's a folder
                pagePath += url.LocalPath + "/" + _homePagename; 
            }
            else {
                // it's a 404
                throw new Exception("404!");
            }

            return _httpContext.Server.MapPath(string.Format("{0}{1}{2}", _pagesRoot, pagePath, _pageExtension));
        }
    }
}