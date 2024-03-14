namespace Entities.Models;

public class ValidatedPhoneToken : BaseModel
{
    public string PhoneNumber { get; set; } = "";
    public string Token { get; set; } = "";
}