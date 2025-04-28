using BookingApp.Entity;
using Newtonsoft.Json;

namespace BookingApp.Models
{
    public class Register : CustomActionRequest
    {
        [JsonProperty("userName")]
        public string UserName { get; set; }
        [JsonProperty("email")]
        public string Email { get; set; }
        [JsonProperty("password")]
        public string Password { get; set; }
        [JsonProperty("confirmPassword")]
        public string ConfirmPassword { get; set; }
        [JsonIgnore]
        public ICollection<Role> Roles { get; set; }
    }
}
