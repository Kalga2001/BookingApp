public class PaymentCardInfo
{
    public int PaymentCardInfoID { get; set; }
    public string CardNumber { get; set; }
    public string CardHolderName { get; set; }

    public string ExpirationDate { get; set; }
    public string CVV { get; set; }

    public int PaymentID { get; set; }
    public Payment Payment { get; set; }
}