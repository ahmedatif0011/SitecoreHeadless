using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SitecoreHeadless.Services.Abstracts
{
    public interface ITestInterface
    {
        ValueTask<string> Name();
    }
}
