namespace Entities.Models;

public class AppSetting : BaseModel
{
    public string Key { get; set; } = "";
    public string Value { get; set; } = "";
}