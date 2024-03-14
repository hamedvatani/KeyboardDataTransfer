using System.ComponentModel.DataAnnotations.Schema;

namespace Entities.Models;

public class ContactUsMessage : BaseModel
{
    [ForeignKey(nameof(TicketSubject))] public int TicketSubjectId { get; set; }
    public string FirstName { get; set; } = "";
    public string LastName { get; set; } = "";
    public string Email { get; set; } = "";
    public string MobileNumber { get; set; } = "";
    public string Description { get; set; } = "";
    public DateTime TimeStamp { get; set; } = DateTime.Now;
    public int Status { get; set; }
    public virtual TicketSubject TicketSubject { get; set; } = null!;
}