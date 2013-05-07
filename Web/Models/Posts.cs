using System.Collections.Generic;
using System.IO;
using System.Web;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace MarkdownBlog.Net.Web.Models {
    public class Posts {
        public static readonly string PostsRoot = "~/Posts/";

        public List<PostMetadata> List { get; set; }

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