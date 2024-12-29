using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using SitecoreHeadless.Data.Models;
using SitecoreHeadless.Data.Requests;
using SitecoreHeadless.SitecoreHelper.Abstracts;
using System.Net.Mail;
using System.Text;
using System.Web;

namespace SitecoreHeadless.SitecoreHelper.Implementations
{
    public class EmailService : IEmailService
    {
        private readonly IConfiguration configuration;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public EmailService(IConfiguration configuration, IHttpContextAccessor httpContextAccessor)
        {
            this.configuration = configuration;
            _httpContextAccessor = httpContextAccessor;
        }
        public void SendMail(ContactUsFormData contactUsInfo, string clientIP)
        {
            try
            {
                // Prepare email content
                string emailContent = BuildEmailContent(contactUsInfo, clientIP);
                var sClient = new SmtpClient("10.24.4.7", 25)  // Changed port to 25025
                {
                    DeliveryMethod = SmtpDeliveryMethod.Network
                };

                var message = new MailMessage
                {
                    From = new MailAddress("xxxxx@linkdev.com"),
                    Subject = "BM Feedback",
                    Body = PrepareMail(configuration["EmailConfig:Title"], emailContent),
                    IsBodyHtml = true
                };
                // Check if there is an attachment and add it to the email if it's not null
                //if (contactUsInfo.Attachment != null)
                //{
                //    using (var memoryStream = new MemoryStream())
                //    {
                //        contactUsInfo.Attachment.CopyTo(memoryStream);
                //        memoryStream.Seek(0, SeekOrigin.Begin);
                //        var attachment = new Attachment(
                //            memoryStream,
                //            contactUsInfo.Attachment.FileName ?? "default_filename.txt",
                //            contactUsInfo.Attachment.ContentType ?? "application/octet-stream"
                //        );
                //        message.Attachments.Add(attachment);
                //    }
                //}

                message.To.Add("xxxx@gmail.com");

                sClient.Send(message);
            }
            catch (SmtpException ex)
            {
                Console.WriteLine($"SMTP Error: {ex.Message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"General Error: {ex.Message}");
            }
        }
        private string BuildEmailContent(ContactUsFormData contactUsInfo, string clientIP)
        {
            StringBuilder emailContent = new StringBuilder();

            emailContent.AppendFormat("<p><b>{0}: </b> <span>{1}</span></p>",
                configuration["EmailConfig:MailLabel:Name"].Split(';')[0], contactUsInfo.Name);

            emailContent.AppendFormat("<p><b>{0}: </b> <span>{1}</span></p>",
                configuration["EmailConfig:MailLabel:Email"].Split(';')[0], contactUsInfo.Email);

            emailContent.AppendFormat("<p><b>{0}: </b> <span>{1}</span></p>",
                configuration["EmailConfig:MailLabel:Age"].Split(';')[0], contactUsInfo.Age);

            emailContent.AppendFormat("<p><b>{0}: </b> <span>{1}</span></p>",
                configuration["EmailConfig:MailLabel:NationalId"].Split(';')[0], contactUsInfo.NationalId);

            emailContent.AppendFormat("<p><b>{0}: </b> <span>{1}</span></p>",
                configuration["EmailConfig:MailLabel:Gender"].Split(';')[0], contactUsInfo.Gender);

            emailContent.AppendFormat("<p><b>{0}: </b> <span>{1}</span></p>",
                configuration["EmailConfig:MailLabel:Country"].Split(';')[0], contactUsInfo.Country);

            emailContent.AppendFormat("<p><b>{0}: </b> <span>{1}</span></p>",
                configuration["EmailConfig:MailLabel:Occupation"].Split(';')[0], contactUsInfo.Occupation);

            emailContent.AppendFormat("<p><b>{0}: </b> <span>{1}</span></p>",
                configuration["EmailConfig:MailLabel:PhoneNumber"].Split(';')[0], contactUsInfo.Phone);

            emailContent.AppendFormat("<p><b>{0}: </b> <span>{1}</span></p>",
                configuration["EmailConfig:MailLabel:Subject"].Split(';')[0], contactUsInfo.Subject);

            emailContent.AppendFormat("<p><b>{0}: </b> <span>{1}</span></p>",
                configuration["EmailConfig:MailLabel:CommentType"].Split(';')[0], contactUsInfo.MessageType);

            emailContent.AppendFormat("<p><b>{0}: </b> <span>{1}</span></p>",
                configuration["EmailConfig:MailLabel:IP"].Split(';')[0], clientIP);

            emailContent.AppendFormat("<p><b>{0}: </b> <span>{1}</span></p>",
                configuration["EmailConfig:MailLabel:Comments"].Split(';')[0], contactUsInfo.SuggestionSummary);

            return emailContent.ToString();
        }
        private string PrepareMail(string title, string body)
        {
            var emailTemplateModel = GetEmailTemplateModel();

            //var mailTemplate = @"~/ContactusEmailTemplate.html";
            var mailTemplateString = "";

            //// Use IHttpContextAccessor to get the current HttpContext
            //var webRootPath = _httpContextAccessor.HttpContext?.Request?.PathBase ?? "";
            //var fullPath = Path.Combine(webRootPath, mailTemplate.TrimStart('~'));  // Handle path properly
            string fullPath = Path.Combine(Directory.GetCurrentDirectory(), "ContactusEmailTemplate.html");

            using (FileStream fs = File.Open(fullPath, FileMode.Open, FileAccess.ReadWrite))
            {
                using (StreamReader sr = new StreamReader(fs))
                {
                    mailTemplateString = sr.ReadToEnd();
                    mailTemplateString = HttpUtility.UrlDecode(mailTemplateString);
                    mailTemplateString = mailTemplateString
                        .Replace("###title###", title)
                        .Replace("###body###", body)
                        .Replace("###dir###", "ltr")
                        .Replace("###caption###", emailTemplateModel.MailCaption)
                        .Replace("###facebookLink###", emailTemplateModel.FacebookLink)
                        .Replace("###twitterLink###", emailTemplateModel.TwitterLink)
                        .Replace("###instagramLink###", emailTemplateModel.InstagramLink)
                        .Replace("###logo###", emailTemplateModel.Logo);
                }
            }

            return mailTemplateString;
        }
        private EmailTemplateVM GetEmailTemplateModel()
        {
            var emailTemplateModel = new EmailTemplateVM
            {
                FacebookLink = configuration["SocialMediaLinks:FacebookLink"],
                TwitterLink = configuration["SocialMediaLinks:TwitterLink"],
                InstagramLink = configuration["SocialMediaLinks:InstagramLink"],
                MailCaption = configuration["EmailConfig:Caption"],
                Logo = configuration["EmailConfig:Logo"]
            };

            return emailTemplateModel;
        }

    }
}
