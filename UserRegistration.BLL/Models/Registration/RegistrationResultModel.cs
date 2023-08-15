using System.Text.Json.Serialization;

namespace UserRegistration.BLL.Models.Registration
{
    public class RegistrationResultModel
    {
        [JsonPropertyName("id")]
        public string Id { get; set; }

        [JsonPropertyName("login")]
        public string Login { get; set; }

        [JsonPropertyName("email")]
        public string Email { get; set; }
    }
}
