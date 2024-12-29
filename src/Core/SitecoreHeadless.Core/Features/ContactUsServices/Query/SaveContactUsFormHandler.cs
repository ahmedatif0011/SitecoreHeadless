using MediatR;
using SitecoreHeadless.Core.Features.ContactUsServices.Command;
using SitecoreHeadless.Helper.Services;
using SitecoreHeadless.SitecoreHelper.Abstracts.ContactUsForm;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SitecoreHeadless.Core.Features.ContactUsServices.Query
{
    public class SaveContactUsFormHandler : IRequestHandler<SaveContactUsFormCommand, bool>
    {
        private readonly RecaptchaService _recaptchaService;
        private readonly IContactUsService _contactUsService;

        public SaveContactUsFormHandler(RecaptchaService recaptchaService, IContactUsService contactUsService)
        {
            _recaptchaService = recaptchaService;
            _contactUsService = contactUsService;
        }

        public async Task<bool> Handle(SaveContactUsFormCommand request, CancellationToken cancellationToken)
        {
            if (string.IsNullOrWhiteSpace(request.CaptchaResponse))
                throw new ValidationException("Captcha response is required.");

            if (!await _recaptchaService.VerifyCaptchaAsync(request.CaptchaResponse))
                throw new ValidationException("Invalid captcha.");

            await _contactUsService.SaveFormDataAsync(request.FormData);
            return true;
        }
    }

}
