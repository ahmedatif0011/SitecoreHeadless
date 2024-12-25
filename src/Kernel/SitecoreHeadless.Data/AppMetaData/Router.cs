namespace SitecoreHeadless.Data.AppMetaData
{
    public static class Router
    {
        public const string projectTitle = "Sitecore Headless Services";
        public const string Root = "Api";
        public const string Version = "v1";
        public const string Rule = $"{Root}/{Version}/";

        public static class SitecoreItemServices
        {
            public const string Prefix = $"{Rule}SitecoreServices/";

            public const string ChildrenOfAnItem = $"{Prefix}Children";
            public const string RetrieveAnItem = $"{Prefix}RetrieveAnItem";
            public const string EditAnItem = $"{Prefix}EditAnItem";
        }
    }
}
