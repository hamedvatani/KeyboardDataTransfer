namespace Entities.Models;

public class Faq : BaseModel
{
    public string Question { get; set; } = "";
    public string Answer { get; set; } = "";
}