﻿using System.Text.Json.Serialization;

namespace UserRegistration.BLL.Registration.Models
{
    public class RegistrationCommand
    {
        [JsonPropertyName("login")]
        public string Login { get; set; }

        [JsonPropertyName("email")]
        public string Email { get; set; }

        [JsonPropertyName("password")]
        public string Password { get; set; }

        [JsonPropertyName("password_confirmation")]
        public string PasswordConfirmation { get; set; }
    }
}
