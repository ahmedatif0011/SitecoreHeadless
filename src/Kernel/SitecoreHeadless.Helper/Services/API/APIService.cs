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
            //check if the user not set a url base will set the url from the appsettings
            if (string.IsNullOrEmpty(request.BaseUrl))
                request.BaseUrl = _sitecoreConfig.URLBase;

            // Check the login status and perform login if necessary.
            var login = await HttpRequestMessageExtensions.Login(request.isLogin,_sitecoreConfig,this);
            if (login.Response != Response.Success)
                return login;

            // Create the HTTP request message and set the essential values.
            HttpRequestMessage httpRequestMessage = new HttpRequestMessage();
            httpRequestMessage.SetHeader(request.Headers);
            httpRequestMessage.SetBody(request.Method,request.Body);
            httpRequestMessage.SetURL(_sitecoreConfig.Scheme,request.BaseUrl,request.APIPath,request.queryParams);
            httpRequestMessage.SetHttpMethod(request.Method);
            httpRequestMessage.SetAuth(_sitecoreConfig);

            // Object to hold the RESTful response.
            HttpResponseMessage res = new HttpResponseMessage();
            try
            {
                // Calling the RESTful API.
                res = await _httpClient.SendAsync(httpRequestMessage);

                // If the request is for login, return the cookies.
                if (request.isLogin)
                {
                    // Retrieve the cookies from the header.
                    var cookies = JsonConvert.SerializeObject(res.Headers.GetValues("Set-Cookie"));
                    // Return the cookies.
                    return new APIResponse { Response = Response.Success, cookies = cookies }; 
                }
                // Build the return object and handle the status code.
                return await HttpRequestMessageExtensions.ReturnBuilder(res,request,this);
            }
            catch (Exception ex)
            {
                // Return an exception if caught.
                return new APIResponse { Response = Response.Failed,Data = ex.Message };
            }
        }
    }
}

