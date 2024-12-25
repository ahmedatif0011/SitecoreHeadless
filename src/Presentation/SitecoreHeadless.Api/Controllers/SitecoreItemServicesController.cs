using Microsoft.AspNetCore.Mvc;
using SitecoreHeadless.Api.Bases;
using SitecoreHeadless.Core.Features.SitecoreItemsServices.Models;
using SitecoreHeadless.Data.AppMetaData;
using Swashbuckle.AspNetCore.Annotations;

namespace SitecoreHeadless.Api.Controllers
{
    public class SitecoreItemServicesController : AppControllerBase
    {
        [HttpGet]
        [Route(Router.SitecoreItemServices.ChildrenOfAnItem)]
        [SwaggerOperation(summary: "Get list of sitecore item childrens")]
        public async Task<IActionResult> ChildrenOfAnItem([FromQuery] RetrieveTheChildrenOfAnItemRequest request) => NewResult(await mediator.Send(request));


        [HttpGet]
        [Route(Router.SitecoreItemServices.RetrieveAnItem)]
        [SwaggerOperation(summary: "Get An Sitecore Item with the path or item GUID")]
        public async Task<IActionResult> RetrieveAnItem([FromQuery] RetrieveAnItemRequest request) => NewResult(await mediator.Send(request));

    }
}
