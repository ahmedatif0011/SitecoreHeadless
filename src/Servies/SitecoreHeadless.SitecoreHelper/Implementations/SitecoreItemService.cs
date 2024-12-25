using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using SitecoreHeadless.Data.Models;
using SitecoreHeadless.Helper.Services.API;
using SitecoreHeadless.SitecoreHelper.Abstracts;
using System;
using System.Text.Json.Nodes;
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

        public async Task<APIResponse> EditAnItemAsync(EditAnItemAsync request)
        {
            var Database = ("database", request.database ?? string.Empty);
            var language = ("language", request.language ?? string.Empty);
            var version = ("version", request.version ?? string.Empty);
            return await _APIService.Call(new APIModel
            {
                APIPath = APIUris.EditAnItem(request.ItemId),
                Method = HttpMethod.Patch,
                Body = JsonObject.Parse(request.RequestBody).ToString(),
                queryParams = new (string key, string value)[] { Database, language, version }
            });
        }

        public async Task<APIResponse> RetrieveAnItemAsync(RetrieveAnItem request)
        {
            Guid itemId;
            var isGuid = Guid.TryParse(request.ItemId, out itemId);
            var uri = isGuid ? APIUris.RetrieveAnItemWithId(itemId) : APIUris.RetrieveAnItem;

            var itemPath = ("path", isGuid ? request.ItemId : string.Empty);
            var Database = ("database", request.database ?? string.Empty);
            var language = ("language", request.language ?? string.Empty);
            var version = ("version", request.version ?? string.Empty);
            var includeStandardTemplateFields = ("includeStandardTemplateFields", request.includeStandardTemplateFields.ToString() ?? string.Empty);
            var includeMetadata = ("includeMetadata", request.includeMetadata.ToString() ?? string.Empty);
            var fields = ("fields", request.fields ?? string.Empty);

            return await _APIService.Call(new APIModel
            {
                APIPath = uri,
                Method = HttpMethod.Get,
                queryParams = new (string key, string value)[] { itemPath, Database, language, version, includeStandardTemplateFields, includeMetadata, fields }
            });
        }

        public async Task<APIResponse> RetrieveTheChildrenOfAnItemAsync(RetrieveTheChildrenOfAnItem request)
        {
            var Database = ("database", request.database ?? string.Empty);
            var language = ("language", request.language ?? string.Empty);
            var version = ("version", request.version ?? string.Empty);
            var includeStandardTemplateFields = ("includeStandardTemplateFields", request.includeStandardTemplateFields.ToString() ?? string.Empty);
            var includeMetadata = ("includeMetadata", request.includeMetadata.ToString() ?? string.Empty);
            var fields = ("fields", request.fields ?? string.Empty);

            return await _APIService.Call(new APIModel
            {
                APIPath = APIUris.RetrieveTheChildrenOfAnItem(request.ItemId),
                Method = HttpMethod.Get,
                queryParams = new (string key, string value)[] { Database, language, version, includeStandardTemplateFields, includeMetadata, fields }

            });
        }
    }
}
