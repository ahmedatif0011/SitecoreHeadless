using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.Json.Nodes;
using System.Threading.Tasks;

namespace SitecoreHeadless.Helper.Services
{
    internal static class JsonCleaner
    {
        public static object CleanJson(string jsonArrayString)
        {
            var res = JsonObject.Parse(jsonArrayString).AsArray();
            return res;
        }
    }
}
