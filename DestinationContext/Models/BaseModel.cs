using System.ComponentModel.DataAnnotations;

namespace Entities;

public class BaseModel
{
    [Key] public int Id { get; set; }
}