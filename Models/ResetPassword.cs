using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace BookingApp.Models
{
    public class ResetPassword : CustomActionRequest
    {
        [JsonProperty("email")]
        public string Email { get; set; }
        [JsonProperty("newPassword")]
        public string NewPassword { get; set; }
    }
}
