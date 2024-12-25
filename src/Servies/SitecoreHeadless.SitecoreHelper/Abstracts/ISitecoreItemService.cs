using SitecoreHeadless.Helper.Services.API;
using static SitecoreHeadless.Data.Models.SitecoreModels.SitecoreItemsServices;
using static SitecoreHeadless.Helper.Services.API.ResponseEnum;

namespace SitecoreHeadless.SitecoreHelper.Abstracts
{
    public interface ISitecoreItemService
    {
        public Task<APIResponse> RetrieveTheChildrenOfAnItemAsync(RetrieveTheChildrenOfAnItem request);
        public Task<APIResponse> RetrieveAnItemAsync(RetrieveAnItem request);
    }
}
