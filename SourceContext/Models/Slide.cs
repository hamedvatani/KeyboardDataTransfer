namespace Infrastructure.Entities;

public class Slide : BaseModel
{
    public int SlideType { get; set; }
    public double Order { get; set; }
    public string Title { get; set; } = "";
    public string PosterLink { get; set; } = "";
    public string Link { get; set; } = "";
}