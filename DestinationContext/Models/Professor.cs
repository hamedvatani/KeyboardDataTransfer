namespace Entities.Models;

public class Professor : BaseModel
{
    public string Name { get; set; } = "";
    public string Description { get; set; } = "";
    public string PictureLink { get; set; } = "";
}