
using SitecoreHeadless.Data.Models;
using SolrNet;
using SolrNet.Commands.Parameters;

namespace SitecoreHeadless.Helper.Services.API
{
    public class MySolrRepository:IMySolrRepository
    {
        private readonly ISolrReadOnlyOperations<MySolrModel> _solr;

        public MySolrRepository(ISolrReadOnlyOperations<MySolrModel> solr)
        {
            _solr = solr;
        }

        public async Task<IEnumerable<MySolrModel>> Search(string searchString)
        {
            var results = await _solr.QueryAsync(searchString);

            return results;
        }

        public async Task<MySolrModel> AdvancedSearch()
        {
            var solrResult = (await _solr.QueryAsync(new SolrMultipleCriteriaQuery(new ISolrQuery[]
              {
      new SolrQueryByField("_template", "a87a00b1e6db45ab8b54636fec3b5523"),
      new SolrQueryByField("_language", "en"),
      new SolrQueryByField("_latestversion", "true")
              }, SolrMultipleCriteriaQuery.Operator.OR), new QueryOptions { Rows = 1 }))
              .FirstOrDefault();

            if (solrResult != null)
                return solrResult;

            return null;
        }
    }
}