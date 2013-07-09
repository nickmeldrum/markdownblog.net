using System.Configuration;

namespace MarkdownBlog.Net.Web.Models {
    public class Site {
        public static readonly Site SiteData = new Site();

        public string Name { get { return ConfigurationManager.AppSettings["Name"] ?? "Default Site Name"; } }
        public string Description { get { return ConfigurationManager.AppSettings["Description"] ?? "Default Site Description"; } }
        public string Owner { get { return ConfigurationManager.AppSettings["Owner"] ?? "Default Site Owner Name"; } }

        public string DisqusShortName { get { return ConfigurationManager.AppSettings["DisqusShortName"] ?? "DefaultDisqusShortName"; } }
        
        public StackOverflowFlair StackOverflowFlair {
            get {
                return new StackOverflowFlair {
                    Id = int.Parse(ConfigurationManager.AppSettings["StackOverflowFlairId"] ?? "-1"),
                    UserName = ConfigurationManager.AppSettings["StackOverflowFlairUserName"] ?? "DefaultStackOverflowUserName",
                    DisplayName = ConfigurationManager.AppSettings["StackOverflowFlairDisplayName"] ?? "Default Stack Overflow Display Name"
                };
            }
        }

        public TwitterTimeline TwitterTimeline {
            get {
                return new TwitterTimeline {
                    Query = ConfigurationManager.AppSettings["TwitterTimelineQuery"] ?? "@DefaultTwitterQuery",
                    Url = ConfigurationManager.AppSettings["TwitterTimelineUrl"] ?? "https://twitter.com/DefaultTwitterTimelineUrl",
                    WidgetId = long.Parse(ConfigurationManager.AppSettings["TwitterTimelineWidgetId"] ?? "-1")
                };
            }
        }

        private Site() {
        }
    }
}