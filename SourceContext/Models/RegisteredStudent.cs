using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Infrastructure.Entities;

public class RegisteredStudent : BaseModel
{
    public string PhoneNumber { get; set; } = "";
    public string FirstName { get; set; } = "";
    public string LastName { get; set; } = "";
    public string NationalCode { get; set; } = "";
    public DateTime BirthDate { get; set; }
    public int CityId { get; set; }
    public int Grade { get; set; }
    public int Gender { get; set; }
    public string Password { get; set; } = "";
    public bool IsRegistered { get; set; }
    public bool IsPayed { get; set; }
    public bool IsSupported { get; set; }
    public DateTime? CreateDate { get; set; }
    public DateTime? PaymentDate { get; set; }
    public DateTime? RegisterDate { get; set; }
}