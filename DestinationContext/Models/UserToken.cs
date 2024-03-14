using System.ComponentModel.DataAnnotations.Schema;

namespace Entities.Models;

public class UserToken : BaseModel
{
    [ForeignKey(nameof(User))] public string UserId { get; set; } = "";
    public string Token { get; set; } = "";
    public string RefreshToken { get; set; } = "";
    public DateTime CreateDate { get; set; }

    public virtual ApplicationUser User { get; set; } = null!;
}