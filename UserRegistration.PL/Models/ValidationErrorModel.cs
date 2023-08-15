using System.Text.Json.Serialization;

namespace UserRegistration.BLL.Models
{
    public class ValidationErrorModel
    {
        [JsonPropertyName("field")]
        public string Field { get; set; }

        [JsonPropertyName("message")]
        public string Message { get; set; }
    }
}
