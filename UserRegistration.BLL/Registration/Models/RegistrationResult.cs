using System.Text.Json.Serialization;

namespace UserRegistration.BLL.Registration.Models
{
    public class RegistrationResult
    {
        [JsonPropertyName("id")]
        public string Id { get; set; }

        [JsonPropertyName("login")]
        public string Login { get; set; }

        [JsonPropertyName("email")]
        public string Email { get; set; }
    }
}
