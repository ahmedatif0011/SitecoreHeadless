using Microsoft.AspNetCore.Http;

namespace SitecoreHeadless.Data.Requests;

public class ContactUsFormData
{
    public string Name { get; set; }
    public string Phone { get; set; }
    public string Email { get; set; }
    public string NationalId { get; set; }
    public string Age { get; set; }
    public string Gender { get; set; }
    public string Country { get; set; }
    public string Occupation { get; set; }
    public string MessageType { get; set; }
    public string Subject { get; set; }
    public IFormFile? Attachment { get; set; } // Path or base64 encoded file string
    public string SuggestionSummary { get; set; }
    public string CaptchaResponse { get; set; } // Add the CaptchaResponse property here
    public ContactUsFormData(string name, string phone, string email, string nationalId, string age, string gender,
                         string country, string occupation, string messageType, string subject,
                         string suggestionSummary, IFormFile? attachment)
    {
        Name = name;
        Phone = phone;
        Email = email;
        NationalId = nationalId;
        Age = age;
        Gender = gender;
        Country = country;
        Occupation = occupation;
        MessageType = messageType;
        Subject = subject;
        SuggestionSummary = suggestionSummary;
        Attachment = attachment;
    }
}
