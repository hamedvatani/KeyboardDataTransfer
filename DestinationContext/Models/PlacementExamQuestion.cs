namespace Entities.Models;

public class PlacementExamQuestion : BaseModel
{
    public int Order { get; set; }
    public string Question { get; set; } = "";
    public string Option1 { get; set; } = "";
    public string Option2 { get; set; } = "";
    public string Option3 { get; set; } = "";
    public string Option4 { get; set; } = "";
    public int Answer { get; set; }
}