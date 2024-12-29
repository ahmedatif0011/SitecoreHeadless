using SitecoreHeadless.Data.Requests;

namespace SitecoreHeadless.SitecoreHelper.Abstracts.ContactUsForm;

public interface IContactUsService
{
    Task SaveFormDataAsync(ContactUsFormData formData);
}
