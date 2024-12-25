using Newtonsoft.Json;
using SitecoreHeadless.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Text.Json.Nodes;
using System.Threading.Tasks;
using System.Web;
using static SitecoreHeadless.Helper.Services.API.ResponseEnum;

namespace SitecoreHeadless.Helper.Services.API
{
    public static class HttpRequestMessageExtensions
    {
        /// <summary>
        /// Sets the headers for the HTTP request.
        /// </summary>
        /// <description>
        /// This method configures the necessary headers for an HTTP request, ensuring that the request 
        /// includes the required authentication, content type, or any other custom headers 
        /// needed for proper communication with the API endpoint.
        /// </description>
        public static void SetHeader(this HttpRequestMessage request, (string key, string value)[] Headers)
        {
            if (Headers != null && Headers.Any())
            {
                foreach (var item in Headers)
                {
                    // Ensure you're not trying to add the Authorization header again here
                    if (!item.key.Equals("Authorization", StringComparison.OrdinalIgnoreCase))
                    {
                        request.Headers.Add(item.key, item.value);
                    }
                }
            }
        }
        /// <summary>
        /// Sets the body content for the HTTP request.
        /// </summary>
        /// <description>
        /// This method configures the body of the HTTP request, typically used for sending data in 
        /// POST, PUT, or PATCH requests. It ensures that the request body is properly formatted, 
        /// often as JSON or another required format, before sending it to the API endpoint.
        /// </description>
        public static void SetBody(this HttpRequestMessage request, HttpMethod method, string body)
        {
            if (method != HttpMethod.Get && !string.IsNullOrEmpty(body))
                request.Content = new StringContent(body, Encoding.UTF8, "application/json");
        }
        /// <summary>
        /// Sets the authentication details for the HTTP request.
        /// </summary>
        /// <description>
        /// This method configures the authentication credentials (Cookies) required for the HTTP request. It ensures that the request 
        /// includes the necessary authorization headers for secure access to the API endpoint.
        /// </description>
        public static void SetAuth(this HttpRequestMessage request, SitecoreConfig _sitecoreConfig)
        {
            if (!string.IsNullOrEmpty(APISettings.CookiesValue))
                request.Headers.Add(APISettings.CookiesKey, APISettings.CookiesValue);
        }
        /// <summary>
        /// Sets the URL for the HTTP request.
        /// </summary>
        /// <description>
        /// This method configures the URL (endpoint) for the HTTP request, ensuring that the 
        /// request is directed to the correct API endpoint. It typically includes the base URL 
        /// and any additional route or query parameters required for the specific request.
        /// </description>
        public static void SetURL(this HttpRequestMessage request, string Scheme, string BaseUrl, string APIPath, (string key, string value)[] queryParams)
        {
            request.RequestUri = new Uri(BuildUrl(Scheme, BaseUrl, APIPath, queryParams));
        }
        /// <summary>
        /// Sets the HTTP method for the request (e.g., GET, POST, PUT, DELETE).
        /// </summary>
        /// <description>
        /// This method configures the HTTP method for the request, specifying the type of 
        /// operation to be performed on the API endpoint. It ensures that the correct method 
        /// (such as GET, POST, PUT, or DELETE) is used based on the intended action for the request.
        /// </description>
        public static void SetHttpMethod(this HttpRequestMessage request, HttpMethod method)
        {
            request.Method = method;
        }

        //Helper
        /// <summary>
        /// Authenticates the user and initiates a login session.
        /// </summary>
        /// <description>
        /// This method handles the user authentication process by sending the necessary 
        /// credentials to the authentication endpoint. If the credentials are valid, 
        /// it initiates a login session and returns a token, cookies, or other relevant 
        /// information required to maintain the user's session for subsequent requests.
        /// </description>
        public static async Task<APIResponse> Login(bool isLogin, SitecoreConfig _sitecoreConfig, APIService api)
        {
            if (!isLogin && string.IsNullOrEmpty(APISettings.CookiesValue))
            {
                var requestBody = new
                {
                    domain = _sitecoreConfig.domain,
                    username = _sitecoreConfig.username,
                    password = _sitecoreConfig.password
                };
                var cookies = await api.Call(new APIModel
                {
                    APIPath = APIUris.LoginURI,
                    Body = JsonConvert.SerializeObject(requestBody),
                    isLogin = true,
                    Method = HttpMethod.Post
                });

                if (cookies.Response == Response.Failed) return cookies;
                if (string.IsNullOrEmpty(cookies.cookies)) return new APIResponse { Response = Response.Unauthorized };
                var obj = JsonObject.Parse(cookies.cookies);
                APISettings.CookiesExpireValue = Convert.ToDateTime(JsonObject.Parse(cookies.cookies)[0].ToString().Split(';')[1].Split('=')[1]);
                APISettings.CookiesValue = JsonObject.Parse(cookies.cookies)[1].ToString().Split('=')[1];

                return new APIResponse { Response = Response.Success };
            }
            return new APIResponse { Response = Response.Success };
        }
        /// <summary>
        /// Constructs the full URL for the API request.
        /// </summary>
        /// <description>
        /// This method combines the base URL with any additional route, query parameters, 
        /// or path segments to form the complete URL for the API request. It ensures that 
        /// the final URL is correctly formatted and ready to be used in an HTTP request.
        /// </description>
        private static string BuildUrl(string Scheme, string baseAddress, string path, params (string key, string value)[] queryParams)
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
                    if (param.value.Any())
                        query[param.key] = param.value;
                }
            }

            // Assign the constructed query string to the UriBuilder
            builder.Query = query.ToString();

            // Return the resulting URL as a string
            return builder.ToString();
        }
        /// <summary>
        /// Builds and returns the response object based on the API response and handles the status code.
        /// </summary>
        /// <description>
        /// This method processes the API response, constructs the appropriate return object, 
        /// and handles the status code. It ensures that different status codes (e.g., success, error) 
        /// are properly managed, and the response is formatted for easy use in the application, 
        /// either returning the relevant data or handling errors appropriately based on the status code.
        /// </description>

        public static async Task<APIResponse> ReturnBuilder(HttpResponseMessage res, APIModel request, APIService api)
        {
            switch (res.StatusCode)
            {
                case HttpStatusCode.OK:
                    return new APIResponse { Response = Response.Success, Data = JsonCleaner.CleanJson(await res.Content.ReadAsStringAsync()) };
                case HttpStatusCode.Created:
                    return new APIResponse { Response = Response.NoContent };
                case HttpStatusCode.Accepted:
                    return new APIResponse { Response = Response.NoContent };
                case HttpStatusCode.NoContent:
                    return new APIResponse { Response = Response.NoContent };
                case HttpStatusCode.BadRequest:
                    return new APIResponse { Response = Response.Failed };
                case HttpStatusCode.Forbidden:
                    APISettings.CookiesValue = string.Empty;
                    return await api.Call(request);
                case HttpStatusCode.TooManyRequests:
                    return new APIResponse { Response = Response.Failed };
                case HttpStatusCode.NotFound:
                    return new APIResponse { Response = Response.NotFound };
                case HttpStatusCode.InternalServerError:
                    return new APIResponse { Response = Response.InternalServerError };
                default:
                    break;
            }
            return null;
        }
    }
}
