using Microsoft.AspNetCore.Identity;

namespace Infrastructure.Entities;

public class ApplicationUser : IdentityUser
{
    public static ApplicationUser CreateDefaultAdmin()
    {
        return new ApplicationUser
        {
            Id = "de094074-3c84-4c50-8f3d-61fd438f1b4f",
            UserName = "admin",
            NormalizedUserName = "ADMIN",
            Email = "admin@keyboard.com",
            NormalizedEmail = "ADMIN@KEYBOARD.COM",
            EmailConfirmed = true,
            PasswordHash = "AQAAAAEAACcQAAAAEBFa75sHWN90ghexbrHdymodDOtLzGSGZZkO3LoA1Kyb7bPMDFxuYlQ7FvlyBoPihw==",
            SecurityStamp = "J7SOQLQT4QYOY5TYABOEX3J2D54SWOJB",
            ConcurrencyStamp = "60487427-fb30-4808-8ed1-1fcc5f92e7e8",
            PhoneNumber = "admin",
            PhoneNumberConfirmed = true,
            TwoFactorEnabled = false,
            LockoutEnd = null,
            LockoutEnabled = true,
            AccessFailedCount = 0
        };
    }
}