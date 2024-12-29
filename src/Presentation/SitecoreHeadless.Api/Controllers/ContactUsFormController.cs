using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SitecoreHeadless.Core.Features.ContactUsServices.Command;
using SitecoreHeadless.Data.Requests;
using SitecoreHeadless.Helper.Services;
using System.ComponentModel.DataAnnotations;
using System.Text.Json;

namespace SitecoreHeadless.Api.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ContactUsFormController : ControllerBase
    {
    //    private readonly IMediator _mediator;
    //    public ContactUsFormController(IMediator mediator)
    //    {
    //        _mediator = mediator;
    //    }
    //    [HttpPost("SaveFormDataAsync")]
    //    public async Task<IActionResult> SaveFormDataAsync([FromForm] ContactUsFormData formData)
    //    {
    //        try
    //        {
    //            var form = new ContactUsFormData(
    //                formData.Name, formData.Phone, formData.Email, formData.NationalId, formData.Age,
    //                formData.Gender, formData.Country, formData.Occupation, formData.MessageType,
    //                formData.Subject, formData.SuggestionSummary, formData.Attachment);

    //            var command = new SaveContactUsFormCommand(form, formData.CaptchaResponse);
    //            await _mediator.Send(command);

    //            return Ok(new { message = "Form data saved successfully." });
    //        }
    //        catch (ValidationException ex)
    //        {
    //            return BadRequest(new { message = ex.Message });
    //        }
    //        catch (Exception ex)
    //        {
    //            return StatusCode(500, new { message = $"Internal server error: {ex.Message}" });
    //        }
    //    }
      }
}
