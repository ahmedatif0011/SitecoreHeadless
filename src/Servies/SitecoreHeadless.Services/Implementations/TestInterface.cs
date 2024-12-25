using SitecoreHeadless.Services.Abstracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SitecoreHeadless.Services.Implementations
{
    internal class TestInterface : ITestInterface
    {
        public async ValueTask<string> Name()
        {
            int num = int.Parse("asd");
            return "Ahmed";
        }
    }
}
