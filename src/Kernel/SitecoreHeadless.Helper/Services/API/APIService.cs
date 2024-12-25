using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using SitecoreHeadless.Data.Models;
using System.Data;
using System.Net;
using System.Text;
using System.Text.Json;
using System.Text.Json.Nodes;
using System.Web;
using static SitecoreHeadless.Helper.Services.API.ResponseEnum;

namespace SitecoreHeadless.Helper.Services.API
{

    public class APIService : IAPIService
    {
        private readonly SitecoreConfig _sitecoreConfig;
        private readonly HttpClient _httpClient;
        public APIService(IOptions<SitecoreConfig> SitecoreConfig, HttpClient httpClient)
        {
            _sitecoreConfig = SitecoreConfig.Value;
            _httpClient = httpClient;
        }

        public async Task<APIResponse> Call(APIModel request)
        {
            if (string.IsNullOrEmpty(request.BaseUrl))
                request.BaseUrl = _sitecoreConfig.URLBase;

            string apiUrl = BuildUrl(_sitecoreConfig.Scheme, request.BaseUrl, request.APIPath, request.queryParams);

            var httpRequestMessage = new HttpRequestMessage
            {
                RequestUri = new Uri(apiUrl),
                Method = request.Method,

            };
            if (request.Method != HttpMethod.Get && !string.IsNullOrEmpty(request.Body))
                httpRequestMessage.Content = new StringContent(request.Body, Encoding.UTF8, "application/json");

            if (!string.IsNullOrEmpty(APISettings.CookiesValue) /*&& Convert.ToDateTime(APISettings.CookiesExpireValue) > DateTime.Now*/)
                httpRequestMessage.Headers.Add(APISettings.CookiesKey, APISettings.CookiesValue);
            else if (!request.isLogin)
            {
                var requestBody = new
                {
                    domain = _sitecoreConfig.domain,
                    username = _sitecoreConfig.username,
                    password = _sitecoreConfig.password
                };
                var cookies = await Call(new APIModel
                {
                    APIPath = APIUris.LoginURI,
                    Body = JsonConvert.SerializeObject(requestBody),
                    isLogin = true,
                    Method = HttpMethod.Post
                });
                if (cookies.Response == Response.Failed) return cookies;
                if (string.IsNullOrEmpty(cookies.Data)) return new APIResponse { Response = Response.Unauthorized };
                var obj = JsonObject.Parse(cookies.Data);
                APISettings.CookiesExpireValue = Convert.ToDateTime(JsonObject.Parse(cookies.Data)[0].ToString().Split(';')[1].Split('=')[1]);
                APISettings.CookiesValue = JsonObject.Parse(cookies.Data)[1].ToString().Split('=')[1];

                httpRequestMessage.Headers.Add(APISettings.CookiesKey, APISettings.CookiesValue);
            }



            if (request.Headers != null && request.Headers.Any())
            {
                foreach (var item in request.Headers)
                {
                    // Ensure you're not trying to add the Authorization header again here
                    if (!item.key.Equals("Authorization", StringComparison.OrdinalIgnoreCase))
                    {
                        httpRequestMessage.Headers.Add(item.key, item.value);
                    }
                }
            }

            HttpResponseMessage res = new HttpResponseMessage();
            try
            {
                res = await _httpClient.SendAsync(httpRequestMessage);
            }
            catch (Exception ex)
            {

                return new APIResponse { Response = Response.Failed,Data = ex.Message };
            }
            if (request.isLogin)
            {
                var cookies = JsonConvert.SerializeObject(res.Headers.GetValues("Set-Cookie"));
                return new APIResponse { Response = Response.Success ,Data = cookies};
            }
            // Read and return the response content
            if (res.StatusCode == HttpStatusCode.OK)
                return new APIResponse { Response = Response.Success, Data = await res.Content.ReadAsStringAsync() };
            else if (res.StatusCode == HttpStatusCode.Forbidden)
            {
                APISettings.CookiesValue = string.Empty;
                return await Call(request);
            }
            return new APIResponse { Response = Response.Failed};
        }

        private string BuildUrl(string Scheme, string baseAddress, string path, params (string key, string value)[] queryParams)
        {
            // Initialize the UriBuilder with the base address
            UriBuilder builder = new UriBuilder
            {
                Scheme = Scheme,
                Host = baseAddress,
                Path = path
            };

            // Initialize a NameValueCollection for the query string parameters
            var query = HttpUtility.ParseQueryString(builder.Query);

            // Add each query string parameter to the collection
            if (queryParams != null)
            {
                foreach (var param in queryParams)
                {
                    query[param.key] = param.value;
                }
            }

            // Assign the constructed query string to the UriBuilder
            builder.Query = query.ToString();

            // Return the resulting URL as a string
            return builder.ToString();
        }
    }
}

