using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SitecoreHeadless.Data.Models
{
    public class SitecoreConfig
    {
        public string Scheme { get; set; }
        public string URLBase { get; set; }
        public string domain { get; set; }
        public string username { get; set; }
        public string password { get; set; }
    }
}
