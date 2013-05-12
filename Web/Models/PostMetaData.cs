using System;

namespace MarkdownBlog.Net.Web.Models
{
    public class PostMetadata
    {
        public string Title { get; set; }
        public DateTime PublishDate { get; set; }
        public DateTime LastUpdatedDate { get; set; }
        public string Author { get; set; }
        public string ShortDescription { get; set; }
    }
}