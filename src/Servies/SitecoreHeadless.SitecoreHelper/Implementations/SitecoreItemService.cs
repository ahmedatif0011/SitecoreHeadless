using SitecoreHeadless.Data.Models;
using SitecoreHeadless.Helper.Services.API;
using SitecoreHeadless.SitecoreHelper.Abstracts;
using static SitecoreHeadless.Data.Models.SitecoreModels.SitecoreItemsServices;
using static SitecoreHeadless.Helper.Services.API.ResponseEnum;

namespace SitecoreHeadless.SitecoreHelper.Implementations
{
    internal class SitecoreItemService : ISitecoreItemService
    {
        private readonly IAPIService _APIService;

        public SitecoreItemService(IAPIService aPIService)
        {
            _APIService = aPIService;
        }

        public async Task<APIResponse> RetrieveAnItemAsync(RetrieveAnItem request)
        {
            Guid itemId;
            var isGuid = Guid.TryParse(request.ItemId, out itemId);
            var uri = isGuid ? APIUris.RetrieveAnItemWithId(itemId) : APIUris.RetrieveAnItem;

            return await _APIService.Call(new APIModel
            {
                APIPath = uri,
                Method = HttpMethod.Get,
                queryParams = !isGuid ? new (string key, string value)[] {("path",request.ItemId)}: null
            });
        }

        public async Task<APIResponse> RetrieveTheChildrenOfAnItemAsync(RetrieveTheChildrenOfAnItem request)
        {
            return await _APIService.Call(new APIModel
            {
                APIPath = APIUris.RetrieveTheChildrenOfAnItem(request.ItemId),
                Method = HttpMethod.Get
            });
        }
    }
}
