using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SitecoreHeadless.Helper.Services.API
{
    internal class APISettings
    {
        public static string CookiesKey = ".AspNet.Cookies";
        public static string CookiesValue = string.Empty;
        public static string CookiesExpireKey = string.Empty;
        public static DateTime CookiesExpireValue = DateTime.Now;
    }
}
