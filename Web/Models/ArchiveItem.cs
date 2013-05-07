namespace MarkdownBlog.Net.Web.Models
{
    public class ArchiveItem {
        public int Year { get; set; }
        public string Month { get; set; }

        public ArchiveItem(PostMetadata postMetadata) {
            Year = postMetadata.PublishDate.Year;
            Month = postMetadata.PublishDate.ToString("MMM");
        }
    }
}
