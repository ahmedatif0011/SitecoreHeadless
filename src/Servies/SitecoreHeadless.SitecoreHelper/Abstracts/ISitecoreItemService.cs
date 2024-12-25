using SitecoreHeadless.Helper.Services.API;
using static SitecoreHeadless.Data.Models.SitecoreModels.SitecoreItemsServices;
using static SitecoreHeadless.Helper.Services.API.ResponseEnum;

namespace SitecoreHeadless.SitecoreHelper.Abstracts
{
    public interface ISitecoreItemService
    {
        /// <summary>
        /// Asynchronously retrieves the child items of a Sitecore item.
        /// </summary>
        /// <description>
        /// This method makes an asynchronous call to the Sitecore service to fetch the child 
        /// items of a specified parent item. It processes the response and returns the child items, 
        /// allowing further actions to be taken on the retrieved data. The method ensures that 
        /// the retrieval is performed efficiently without blocking the main thread.
        /// </description>
        public Task<APIResponse> RetrieveTheChildrenOfAnItemAsync(RetrieveTheChildrenOfAnItem request);
        /// <summary>
        /// Asynchronously retrieves a Sitecore item by its ID or path.
        /// </summary>
        /// <description>
        /// This method makes an asynchronous call to the Sitecore service to retrieve a specific 
        /// item based on its unique ID or path. It processes the response and returns the item, 
        /// allowing further actions to be performed on the retrieved data. The method ensures 
        /// efficient data retrieval without blocking the main thread.
        /// </description>

        public Task<APIResponse> RetrieveAnItemAsync(RetrieveAnItem request);
        /// <summary>
        /// Asynchronously edits a Sitecore item.
        /// </summary>
        /// <description>
        /// This method makes an asynchronous call to the Sitecore service to edit an existing 
        /// item. It allows updates to be made to the item’s fields, templates, or other properties. 
        /// The method ensures that changes are saved efficiently without blocking the main thread, 
        /// and it returns a response indicating the success or failure of the operation.
        /// </description>

        public Task<APIResponse> EditAnItemAsync(EditAnItemAsync request);
    }
}
