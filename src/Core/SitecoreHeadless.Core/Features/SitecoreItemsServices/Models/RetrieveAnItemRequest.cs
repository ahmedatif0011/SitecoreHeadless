using MediatR;
using SitecoreHeadless.Core.Bases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static SitecoreHeadless.Data.Models.SitecoreModels.SitecoreItemsServices;

namespace SitecoreHeadless.Core.Features.SitecoreItemsServices.Models
{
    public class RetrieveAnItemRequest : RetrieveAnItem,IRequest<Response<object>>
    {
    }
}
