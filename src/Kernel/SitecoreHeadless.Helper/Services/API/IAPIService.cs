using SitecoreHeadless.Data.Models;
using static SitecoreHeadless.Helper.Services.API.ResponseEnum;

namespace SitecoreHeadless.Helper.Services.API
{
    public interface IAPIService
    {
        public Task<APIResponse> Call(APIModel request);
    }
}
