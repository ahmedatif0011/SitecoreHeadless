using MediatR;
using SitecoreHeadless.Core.Bases;
using static SitecoreHeadless.Data.Models.SitecoreModels.SitecoreItemsServices;

namespace SitecoreHeadless.Core.Features.SitecoreItemsServices.Models
{
    public class EditAnItemRequest : EditAnItemAsync,IRequest<Response<object>>
    {
    }
}
