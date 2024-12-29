using MediatR;
using SitecoreHeadless.Data.Requests;

namespace SitecoreHeadless.Core.Features.ContactUsServices.Command;

public record SaveContactUsFormCommand(ContactUsFormData FormData, string CaptchaResponse,string ClientIp) : IRequest<bool>;
