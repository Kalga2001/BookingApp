using Newtonsoft.Json;

namespace BookingApp.Models
{
    public class Login : CustomActionRequest
    {
        [JsonProperty("email")]
        public string Email { get; set; }
        [JsonProperty("password")]
        public string Password { get; set; }
        [JsonProperty("rememberMe")]
        public bool RememberMe { get; set; }
    }
}
