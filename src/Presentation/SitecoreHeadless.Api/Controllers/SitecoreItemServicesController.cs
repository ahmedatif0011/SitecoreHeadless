using Microsoft.AspNetCore.Mvc;
using SitecoreHeadless.Api.Bases;
using SitecoreHeadless.Core.Features.SitecoreItemsServices.Models;
using SitecoreHeadless.Data.AppMetaData;
using SitecoreHeadless.Data.Models;
using SitecoreHeadless.Helper.Services.API;
using Swashbuckle.AspNetCore.Annotations;
using System.ComponentModel.Design;
using System.IO;
using System.Text.RegularExpressions;

namespace SitecoreHeadless.Api.Controllers
{
    [Route("/api")]
    [Controller]
    public class SitecoreItemServicesController : AppControllerBase
    {
        private readonly IMySolrRepository _repo;
        public SitecoreItemServicesController(IMySolrRepository repo)
        {
            _repo = repo;
        }

        [HttpGet("GetSearchResult")]
        public async IAsyncEnumerable<MySolrModel> GetSearchResult()
        {
            yield return await _repo.AdvancedSearch();
        }

        [HttpGet]
        [Route(Router.SitecoreItemServices.ChildrenOfAnItem)]
        [SwaggerOperation(summary: "Retrieves the children of a specified Sitecore item.",description: "This endpoint allows you to retrieve the child items of a given Sitecore item. It accepts the ID of the parent item and returns a list of its child items. The endpoint is designed to efficiently fetch child items for further processing.")]
        public async Task<IActionResult> ChildrenOfAnItem([FromQuery] RetrieveTheChildrenOfAnItemRequest request) => NewResult(await mediator.Send(request));


        [HttpGet]
        [Route(Router.SitecoreItemServices.RetrieveAnItem)]
        [SwaggerOperation(summary: "Retrieves a specific Sitecore item by its ID or path.",description: "This endpoint allows you to retrieve a Sitecore item using its unique ID or path.It provides access to the item’s fields, templates, and other associated data.This method is designed to fetch the item efficiently, enabling operations on the item's content within the Sitecore environment.")]
        public async Task<IActionResult> RetrieveAnItem([FromQuery] RetrieveAnItemRequest request) => NewResult(await mediator.Send(request));
        
        [HttpPatch]
        [Route(Router.SitecoreItemServices.EditAnItem)]
        [SwaggerOperation(summary: "Edits an existing Sitecore item.",description: "This endpoint allows you to modify an existing Sitecore item by updating its fields, template, or other properties. It accepts the item's ID or path along with the new values to be applied. The endpoint ensures that the changes are saved to the Sitecore content tree, allowing for real-time content management and updates.")]
        public async Task<IActionResult> EditAnItem([FromQuery] EditAnItemRequest request) => NewResult(await mediator.Send(request));

    }
}
