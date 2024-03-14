using System.ComponentModel.DataAnnotations.Schema;

namespace Infrastructure.Entities;

public class News : BaseModel
{
    public DateTime NewsDate { get; set; } = DateTime.Now;
    public string PosterLink { get; set; } = "";
    // public int PosterFileType { get; set; }
    public string Title { get; set; } = "";
    public string Abstract { get; set; } = "";
    public string Text { get; set; } = "";
    public string Writer { get; set; } = "";
    public bool Hot { get; set; }
    public string ThumbnailLink { get; set; } = "";
    public string HtmlText { get; set; } = "";
}