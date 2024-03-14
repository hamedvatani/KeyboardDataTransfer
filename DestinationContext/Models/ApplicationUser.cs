using Microsoft.AspNetCore.Identity;

namespace Entities.Models;

public class ApplicationUser : IdentityUser
{
    public string FirstName { get; set; } = "";
    public string LastName { get; set; } = "";
    public bool IsActive { get; set; } = true;
    public bool IsStudent { get; set; } = false;
}