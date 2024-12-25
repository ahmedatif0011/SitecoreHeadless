namespace SitecoreHeadless.Helper.Services.API
{
    public class APIResponse
    {
        public ResponseEnum.Response Response { get; set; }
        public object Data { get; set; }
        public string cookies { get; set; }
    }
}
