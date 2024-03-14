using Entities.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace DestinationContext;

public class DestinationKeyboardContext : IdentityDbContext<ApplicationUser>
{
    public DbSet<AppSetting> AppSettings { get; set; } = null!;
    public DbSet<UserToken> Tokens { get; set; } = null!;
    public DbSet<Professor> Professors { get; set; } = null!;
    public DbSet<LandingFaq> LandingFaqs { get; set; } = null!;
    public DbSet<State> States { get; set; } = null!;
    public DbSet<City> Cities { get; set; } = null!;
    public DbSet<Slide> Slides { get; set; } = null!;
    public DbSet<News> News { get; set; } = null!;
    public DbSet<VerificationCode> VerificationCodes { get; set; } = null!;
    public DbSet<Student> Students { get; set; } = null!;
    public DbSet<SupportedPhoneNumber> SupportedPhoneNumbers { get; set; } = null!;
    public DbSet<ValidatedPhoneToken> ValidatedPhoneTokens { get; set; } = null!;
    public DbSet<StudentPayment> StudentPayments { get; set; } = null!;
    public DbSet<DiscountCode> DiscountCodes { get; set; } = null!;
    public DbSet<TicketSubject> TicketSubjects { get; set; } = null!;
    public DbSet<ContactUsMessage> ContactUsMessages { get; set; } = null!;
    public DbSet<PlacementExamQuestion> PlacementExamQuestions { get; set; } = null!;
    public DbSet<Faq> Faqs { get; set; } = null!;

    public DestinationKeyboardContext(DbContextOptions options) : base(options)
    {
    }
}