using Entities.Enums;

namespace Entities.Models;

public class News : BaseModel
{
    public DateTime NewsDate { get; set; }
    public string PosterLink { get; set; } = "";
    public FileTypeEnum PosterFileType { get; set; }
    public string Title { get; set; } = "";
    public string Abstract { get; set; } = "";
    public string Text { get; set; } = "";
    public string Writer { get; set; } = "";
    public bool Hot { get; set; }
    public string ThumbnailLink { get; set; } = "";
    public string HtmlText { get; set; } = "";
}