using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace SitecoreHeadless.Api.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class LookupsController : ControllerBase
    {
        [HttpGet]
        public IActionResult GetCountry()
        {
            var cities = new List<object>
                        {
                            new { Id = 1, Name = "Egypt"},
                            new { Id = 2, Name = "Qatr" },
                            new { Id = 3, Name = "Palestine"},
                            new { Id = 4, Name = "Suria"},
                            new { Id = 5, Name = "Tunes"},
                            new { Id = 6, Name = "Saudi Arabia"},
                            new { Id = 7, Name = "United Arab Emirates"},
                            new { Id = 8, Name = "Oman"},
                            new { Id = 9, Name = "Bahrain" },
                            new { Id = 10, Name = "Kuwait"}
                        };
            return Ok(cities);
        }
        [HttpGet]
        public IActionResult GetOCCUPATIONS()
        {
            var cities = new List<object>
                        {
                            new { Id = 1, Name = "Manager"},
                            new { Id = 2, Name = "Physician, Lawyer, etc..." },
                            new { Id = 3, Name = "Professor"},
                            new { Id = 4, Name = "Computer Specialist"},
                            new { Id = 5, Name = "Engineer"}
                        };
            return Ok(cities);
        }
        [HttpGet]
        public IActionResult GetMessageType()
        {
            var cities = new List<object>
                        {
                            new { Id = 1, Name = "Complaints"},
                            new { Id = 2, Name = "Suggestions" }
                        };
            return Ok(cities);
        }
        [HttpGet]
        public IActionResult GetSubject()
        {
            var cities = new List<object>
                        {
                            new { Id = 1, Name = "General"},
                            new { Id = 2, Name = "Investments Projects" },
                            new { Id = 3, Name = "Banking Services"},
                            new { Id = 4, Name = "Cards"},
                            new { Id = 5, Name = "Bank Assurance"}
                        };
            return Ok(cities);
        }
    }
}
