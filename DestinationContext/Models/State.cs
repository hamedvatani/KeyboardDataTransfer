namespace Entities.Models;

public class State : BaseModel
{
    public string PersianTitle { get; set; } = "";
    public string EnglishTitle { get; set; } = "";

    public virtual ICollection<City> Cities { get; set; } = null!;
}