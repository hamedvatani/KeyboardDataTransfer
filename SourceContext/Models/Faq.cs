namespace Infrastructure.Entities;

public class Faq : BaseModel
{
    public string Question { get; set; } = "";
    public string Answer { get; set; } = "";
}