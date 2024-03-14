using Infrastructure.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace SourceContext;

public class SourceKeyboardContext : IdentityDbContext<ApplicationUser>
{
    public DbSet<MobileVerificationCode> MobileVerificationCodes { get; set; } = null!;
    public DbSet<AppSetting> AppSettings { get; set; } = null!;
    public DbSet<Professor> Professors { get; set; } = null!;
    public DbSet<AiLandingFaq> AiLandingFaqs { get; set; } = null!;
    public DbSet<State> States { get; set; } = null!;
    public DbSet<City> Cities { get; set; } = null!;
    public DbSet<RegisteredStudent> RegisteredStudents { get; set; } = null!;
    public DbSet<StudentPayment> StudentPayments { get; set; } = null!;
    public DbSet<Slide> Slides { get; set; } = null!;
    public DbSet<News> News { get; set; } = null!;
    public DbSet<ValidatedPhoneToken> ValidatedPhoneTokens { get; set; } = null!;
    public DbSet<TicketSubject> TicketSubjects { get; set; } = null!;
    public DbSet<ContactUsMessage> ContactUsMessages { get; set; } = null!;
    public DbSet<Faq> Faqs { get; set; } = null!;
    public DbSet<SupportedPhoneNumber> SupportedPhoneNumbers { get; set; } = null!;
    public DbSet<DiscountCode> DiscountCodes { get; set; } = null!;

    public SourceKeyboardContext(DbContextOptions options) : base(options)
    {
    }
}