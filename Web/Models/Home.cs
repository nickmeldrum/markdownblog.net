using System.Web;

namespace MarkdownBlog.Net.Web.Models
{
    public class Home
    {
        public Posts Posts { get; set; }

        private readonly HttpContextWrapper _httpContext;

        public Home(HttpContextWrapper httpContext)
        {
            _httpContext = httpContext;

            Posts = new Posts(_httpContext);
        }
    }
}