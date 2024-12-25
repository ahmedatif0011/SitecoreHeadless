using SitecoreHeadless.Data.Models;
using static SitecoreHeadless.Helper.Services.API.ResponseEnum;

namespace SitecoreHeadless.Helper.Services.API
{
    public interface IAPIService
    {
        /// <summary>
        /// Returns the status of the endpoint along with the response as a string.
        /// </summary>
        /// <description>
        /// This method sends a request to the specified API endpoint and retrieves the status of the response, 
        /// as well as the body of the response as a string. The response is typically in JSON format, 
        /// and you should deserialize the JSON string into the appropriate object model as needed.
        /// </description>
        public Task<APIResponse> Call(APIModel request);
    }
}
