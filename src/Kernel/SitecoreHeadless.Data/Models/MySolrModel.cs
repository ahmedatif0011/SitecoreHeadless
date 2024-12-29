using SolrNet.Attributes;

namespace SitecoreHeadless.Data.Models
{
    public class MySolrModel
    {
        [SolrField("_fullpath")]
        public string FullPath { get; set; }

        [SolrField("advertcategorytitle_s")]
        public string CategoryTitle { get; set; }

        [SolrField("advertcategorydeprecated_b")]
        public bool Deprecated { get; set; }
    }
}
