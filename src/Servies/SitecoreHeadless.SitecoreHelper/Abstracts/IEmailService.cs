using SitecoreHeadless.Data.Requests;

namespace SitecoreHeadless.SitecoreHelper.Abstracts;

public interface IEmailService
{
    void SendMail(ContactUsFormData contactUsInfo, string clientIP);
}
