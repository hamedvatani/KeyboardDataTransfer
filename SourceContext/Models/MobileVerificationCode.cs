namespace Infrastructure.Entities;

public class MobileVerificationCode : BaseModel
{
    public string PhoneNumber { get; set; } = "";
    public string Code { get; set; } = "";
    public DateTime SendDateTime { get; set; } = DateTime.Now;
}