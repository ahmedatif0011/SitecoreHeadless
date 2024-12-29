using Microsoft.Extensions.Configuration;
using SitecoreHeadless.Data.Responses;


namespace SitecoreHeadless.Helper.Services;

public class RecaptchaService
{
    private readonly string _secretKey;

    public RecaptchaService(IConfiguration configuration)
    {
        _secretKey = configuration["Recaptcha:SecretKey"];
    }

    public async Task<bool> VerifyCaptchaAsync(string captchaResponse)
    {
        var client = new HttpClient();
        var response = client.PostAsync($"https://www.google.com/recaptcha/api/siteverify?secret={_secretKey}&response={captchaResponse}", null).Result;
        var responseString = response.Content.ReadAsStringAsync().Result;
        var result = System.Text.Json.JsonSerializer.Deserialize<RecaptchaResponse>(await response.Content.ReadAsStringAsync());
        return result?.Success ?? false;
    }
}
