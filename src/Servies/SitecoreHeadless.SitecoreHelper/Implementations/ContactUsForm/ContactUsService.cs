using Microsoft.AspNetCore.Http;
using SitecoreHeadless.Data.Requests;
using SitecoreHeadless.SitecoreHelper.Abstracts;
using SitecoreHeadless.SitecoreHelper.Abstracts.ContactUsForm;

namespace SitecoreHeadless.SitecoreHelper.Implementations.ContactUsForm;

public class ContactUsService : IContactUsService
{
    private readonly IEmailService emailService;
    public ContactUsService(IEmailService emailService)
    {
        this.emailService = emailService;
    }
    public async Task SaveFormDataAsync(ContactUsFormData formData, string clientIp)
    {
        string filePath = Path.Combine(Directory.GetCurrentDirectory(), "ContactUsData.txt");
        using var writer = new StreamWriter(filePath, append: true);

        await writer.WriteLineAsync("---- Contact Us Form Submission ----");
        await writer.WriteLineAsync($"Name: {formData.Name}");
        await writer.WriteLineAsync($"Phone: {formData.Phone}");
        await writer.WriteLineAsync($"Email: {formData.Email}");
        await writer.WriteLineAsync($"National ID: {formData.NationalId}");
        await writer.WriteLineAsync($"Age: {formData.Age}");
        await writer.WriteLineAsync($"Gender: {formData.Gender}");
        await writer.WriteLineAsync($"Country: {formData.Country}");
        await writer.WriteLineAsync($"Occupation: {formData.Occupation}");
        await writer.WriteLineAsync($"Message Type: {formData.MessageType}");
        await writer.WriteLineAsync($"Subject: {formData.Subject}");
        await writer.WriteLineAsync($"Suggestion Summary: {formData.SuggestionSummary}");
        await writer.WriteLineAsync($"Attachment: {formData.Attachment}");
        await writer.WriteLineAsync($"Submitted At: {DateTime.Now}");
        await writer.WriteLineAsync("------------------------------------");

        // emailService.SendMail(formData, clientIp);
    }
}