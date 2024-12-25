namespace SitecoreHeadless.Data.Models
{
    public class APIModel
    {
        public HttpMethod Method { get; set; }
        public string? BaseUrl { get; set; }
        public string APIPath { get; set; }
        public (string key, string value)[] queryParams { get; set; }
        public (string key, string value)[] Headers { get; set; }
        public string? Body { get; set; }
        public bool isLogin { get; set; } = false;

    }
}
