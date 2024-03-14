using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Entities.Enums;

namespace Entities.Models;

public class Student
{
    [Key] [ForeignKey(nameof(User))] public string Id { get; set; } = "";
    public string NationalCode { get; set; } = "";
    public DateTime BirthDate { get; set; }
    [ForeignKey(nameof(City))] public int? CityId { get; set; }
    public StudentGradeEnum Grade { get; set; }
    public StudentLevelEnum Level { get; set; }
    public GenderEnum Gender { get; set; }
    public DateTime? CreateDate { get; set; }
    public bool IsRegistered { get; set; }
    public DateTime? RegisterDate { get; set; }
    public bool IsPayed { get; set; }
    public DateTime? PaymentDate { get; set; }

    public virtual ApplicationUser User { get; set; } = null!;
    public virtual City? City { get; set; } = null!;
}