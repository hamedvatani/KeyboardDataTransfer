namespace Entities.Models;

public class StudentPayment : BaseModel
{
    public string PhoneNumber { get; set; } = "";
    public long Amount { get; set; }
    public DateTime RequestTime { get; set; }
    public int RequestResult { get; set; }
    public string ReferenceId { get; set; } = "";
    public DateTime VerifyTime { get; set; }
    public long SaleReferenceId { get; set; }
    public string CardHolderInfo { get; set; } = "";
    public string CardHolderPan { get; set; } = "";
    public int VerifyResult { get; set; }
    public int SettleResult { get; set; }
    public string DiscountCode { get; set; } = "";
}