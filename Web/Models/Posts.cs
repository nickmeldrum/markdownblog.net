using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace MarkdownBlog.Net.Web.Models {
    public class Posts {
        public static readonly string PostsRoot = "~/Posts/";

        public IList<PostMetadata> List { get; set; }
        public PostMetadata Latest { get { return List.OrderByDescending(p => p.PublishDate).Take(1).Single(); } }

        public IList<ArchiveItemGrouping> MonthlyArchiveLinks {
            get {
            return List.GroupBy(p => new ArchiveItem(p))
                .Select(ps => new ArchiveItemGrouping{ ArchiveItem = ps.Key, Count = ps.Count()})
            .ToList();
        }}

        private readonly string _metadataFile = "metadata.json";
        private readonly HttpContextWrapper _httpContext;

        public Posts(HttpContextWrapper httpContext)
        {
            _httpContext = httpContext;

            using (var reader = new StreamReader(MetaDataFilePath))
            {
                List = JsonConvert.DeserializeObject<List<PostMetadata>>(reader.ReadToEnd(), new IsoDateTimeConverter());
            }
        }

        private string MetaDataFilePath { get { return _httpContext.Server.MapPath(PostsRoot + _metadataFile); } }
    }
}