using SitecoreHeadless.Data.Models;

namespace SitecoreHeadless.Helper.Services.API
{
    public interface IMySolrRepository
    {
        public Task<MySolrModel> AdvancedSearch();
        public Task<IEnumerable<MySolrModel>> Search(string searchString);
    }
}
