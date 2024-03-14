namespace Entities.Models;

public class DiscountCode : BaseModel
{
    public string Code { get; set; } = "";
    public int Amount { get; set; }
    public int MaxUsageCount { get; set; }
    public int UsageCount { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public DateTime CreateDate { get; set; } = DateTime.Now;
}