using MediatR;
using SitecoreHeadless.Core.Bases;
using SitecoreHeadless.Core.Features.SitecoreItemsServices.Models;
using SitecoreHeadless.SitecoreHelper.Abstracts;

namespace SitecoreHeadless.Core.Features.SitecoreItemsServices.Query
{
    internal class SitecoreItemsServicesHandler : ResponseHandler,
        IRequestHandler<RetrieveTheChildrenOfAnItemRequest, Response<object>>,
        IRequestHandler<RetrieveAnItemRequest,Response<object>>,
        IRequestHandler<EditAnItemRequest, Response<object>>
    {
        private readonly ISitecoreItemService _SitecoreItemService;

        public SitecoreItemsServicesHandler(ISitecoreItemService sitecoreItemService)
        {
            _SitecoreItemService = sitecoreItemService;
        }

        public async Task<Response<object>> Handle(RetrieveTheChildrenOfAnItemRequest request, CancellationToken cancellationToken)
        {
            var res = await _SitecoreItemService.RetrieveTheChildrenOfAnItemAsync(request);
            return Build(res.Data,res.Response);
        }

        public async Task<Response<object>> Handle(RetrieveAnItemRequest request, CancellationToken cancellationToken)
        {
            
            var res = await _SitecoreItemService.RetrieveAnItemAsync(request);
            return Build(res.Data, res.Response);
        }

        public async Task<Response<object>> Handle(EditAnItemRequest request, CancellationToken cancellationToken)
        {
            var res = await _SitecoreItemService.EditAnItemAsync(request);
            return Build(res.Data, res.Response);
        }
    }
}
