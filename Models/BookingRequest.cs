using BookingApp.Enums;
using Newtonsoft.Json;

public class BookingRequest
{
    [JsonProperty("roomId")]
    public int RoomID { get; set; }
    [JsonProperty("userId")]
    public int UserID { get; set; }
    [JsonProperty("from")]
    public DateTime From { get; set; }
    [JsonProperty("to")]
    public DateTime To { get; set; }
    [JsonProperty("childrenCount")]
    public int ChildrenCount { get; set; }
    [JsonProperty("price")]
    public decimal Price { get; set; }
    [JsonProperty("typeOfPayment")]
    public int TypeOfPayment { get; set; }
}
