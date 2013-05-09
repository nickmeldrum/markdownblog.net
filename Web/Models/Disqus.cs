using System;
using System.Web.WebPages;
using System.Web.WebPages.Scope;

namespace MarkdownBlog.Net.Web.Models {
    public class Disqus {
        private const string InitializedExceptionMessage = "The Disqus Helper has not been initialized.";
        private const string ArgumentNullExceptionMessage = "Argument cannot be null or empty.";

        private static readonly object _apiKey = new object();
        private static readonly object _initializedKey = new object();

        public static string ForumShortName {
            get {
                if (!Initialized) {
                    throw new InvalidOperationException(InitializedExceptionMessage);
                }
                return (string)(ScopeStorage.CurrentScope[_apiKey] ?? "");
            }

            private set {
                if (value == null) {
                    throw new ArgumentNullException("ApiKey");
                }

                ScopeStorage.CurrentScope[_apiKey] = value;
            }
        }

        private static bool Initialized {
            get {
                return (bool)(ScopeStorage.CurrentScope[_initializedKey] ?? false);
            }
            set {
                ScopeStorage.CurrentScope[_initializedKey] = value;
            }
        }

       public static void Initialize(string forumShortName) {
            if (forumShortName.IsEmpty()) {
                throw new ArgumentException(ArgumentNullExceptionMessage, "forumShortName");
            }

            ForumShortName = forumShortName;

            Initialized = true;
        }

    }
}