using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace BookingApp.Models
{
    public class PaymentRequest
    {
        [JsonProperty("cardNumber")]
        public string CardNumber { get; set; }
        [JsonProperty("cardHolderName")]
        public string CardHolderName { get; set; }
        [JsonProperty("expirationDate")]
        public string ExpirationDate { get; set; }
        [JsonProperty("cvv")]
        public string CVV { get; set; }
    }
}
