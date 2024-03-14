using System.ComponentModel.DataAnnotations.Schema;

namespace Entities.Models;

public class City : BaseModel
{
    [ForeignKey(nameof(State))] public int StateId { get; set; }
    public string PersianTitle { get; set; } = "";
    public string EnglishTitle { get; set; } = "";

    public virtual State State { get; set; } = null!;
}