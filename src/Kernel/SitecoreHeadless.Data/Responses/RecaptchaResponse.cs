using System.Text.Json.Serialization;

namespace SitecoreHeadless.Data.Responses;

public class RecaptchaResponse
{
    [JsonPropertyName("success")]
    public bool Success { get; set; }

    [JsonPropertyName("challenge_ts")]
    public string ChallengeTimestamp { get; set; }

    [JsonPropertyName("hostname")]
    public string Hostname { get; set; }

    [JsonPropertyName("error-codes")]
    public List<string> ErrorCodes { get; set; }
}
