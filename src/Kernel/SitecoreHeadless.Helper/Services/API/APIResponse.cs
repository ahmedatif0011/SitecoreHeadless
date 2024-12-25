using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SitecoreHeadless.Helper.Services.API
{
    public class APIResponse
    {
        public ResponseEnum.Response Response { get; set; }
        public string Data { get; set; }
    }
}
