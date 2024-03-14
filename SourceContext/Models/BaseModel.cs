using System.ComponentModel.DataAnnotations;

namespace Infrastructure.Entities;

public abstract class BaseModel
{
    [Key] public int Id { get; set; }
}