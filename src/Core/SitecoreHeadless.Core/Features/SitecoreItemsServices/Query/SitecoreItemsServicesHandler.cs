using MediatR;
using Microsoft.Extensions.Localization;
using SitecoreHeadless.Core.Bases;
using SitecoreHeadless.Core.Features.SitecoreItemsServices.Models;
using SitecoreHeadless.Data.Resources;
using SitecoreHeadless.Helper.Services.API;
using SitecoreHeadless.SitecoreHelper.Abstracts;
using static SitecoreHeadless.Helper.Services.API.ResponseEnum;

namespace SitecoreHeadless.Core.Features.SitecoreItemsServices.Query
{
    internal class SitecoreItemsServicesHandler : ResponseHandler,
        IRequestHandler<RetrieveTheChildrenOfAnItemRequest, Response<string>>,
        IRequestHandler<RetrieveAnItemRequest,Response<string>>
    {
        private readonly ISitecoreItemService _SitecoreItemService;

        public SitecoreItemsServicesHandler(ISitecoreItemService sitecoreItemService)
        {
            _SitecoreItemService = sitecoreItemService;
        }

        public async Task<Response<string>> Handle(RetrieveTheChildrenOfAnItemRequest request, CancellationToken cancellationToken)
        {
            var res = await _SitecoreItemService.RetrieveTheChildrenOfAnItemAsync(request);
            return Build(res.Data,res.Response);
        }

        public async Task<Response<string>> Handle(RetrieveAnItemRequest request, CancellationToken cancellationToken)
        {
            
            var res = await _SitecoreItemService.RetrieveAnItemAsync(request);
            return Build(res.Data, res.Response);
        }
    }
}
