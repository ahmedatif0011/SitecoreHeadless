using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SitecoreHeadless.Helper.Services.API
{
    public class APIUris
    {
        internal static string LoginURI = "/sitecore/api/ssc/auth/login";
        public static string RetrieveTheChildrenOfAnItem(string itemId) => $"/sitecore/api/ssc/item/{itemId}/children";
        public static string RetrieveAnItem = $"/sitecore/api/ssc/item";
        public static string RetrieveAnItemWithId(Guid itemId) => $"{RetrieveAnItem}/{itemId.ToString()}";
    }
}
