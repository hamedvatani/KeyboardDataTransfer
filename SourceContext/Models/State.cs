using System.ComponentModel.DataAnnotations.Schema;

namespace Infrastructure.Entities;

public class State : BaseModel
{
    public string PersianTitle { get; set; } = "";
    public string EnglishTitle { get; set; } = "";

    [InverseProperty(nameof(City.State))]
    public virtual ICollection<City> Cities { get; set; } = null!;
}