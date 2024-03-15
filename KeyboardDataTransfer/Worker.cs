using DestinationContext;
using Entities.Enums;
using Entities.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using SourceContext;

namespace KeyboardDataTransfer
{
    public class Worker : BackgroundService
    {
        private readonly ILogger<Worker> _logger;
        private readonly IServiceProvider _serviceProvider;

        public Worker(ILogger<Worker> logger, IServiceProvider serviceProvider)
        {
            _logger = logger;
            _serviceProvider = serviceProvider;
        }

        protected async override Task ExecuteAsync(CancellationToken stoppingToken)
        {
            var scope = _serviceProvider.CreateScope();
            var sContext = scope.ServiceProvider.GetRequiredKeyedService<SourceKeyboardContext>(null);
            var dContext = scope.ServiceProvider.GetRequiredKeyedService<DestinationKeyboardContext>(null);
            var dUserManager = scope.ServiceProvider.GetRequiredKeyedService<UserManager<Entities.Models.ApplicationUser>>(null);

            ConvertAiLandingFaqs(sContext, dContext);
            ConvertAppSettings(sContext, dContext);
            ConvertTicketSubjects(sContext, dContext);
            ConvertContactUsMessages(sContext, dContext);
            ConvertDiscountCodes(sContext, dContext);
            ConvertFaqs(sContext, dContext);
            ConvertMobileVerificationCodes(sContext, dContext);
            ConvertNews(sContext, dContext);
            ConvertProfessors(sContext, dContext);
            ConvertSlides(sContext, dContext);
            ConvertStudentPayments(sContext, dContext);
            ConvertSupportedPhoneNumbers(sContext, dContext);
            ConvertValidatedPhoneTokens(sContext, dContext);
            ConvertRegisteredStudents(sContext, dContext, dUserManager);


            while (!stoppingToken.IsCancellationRequested)
            {
                Console.WriteLine("All Done!");
                await Task.Delay(1000, stoppingToken);
            }
        }

        private void ConvertRegisteredStudents(SourceKeyboardContext sContext, DestinationKeyboardContext dContext, UserManager<Entities.Models.ApplicationUser> dUserManager)
        {
            var sList = sContext.RegisteredStudents.ToList();
            foreach (var s in sList)
            {
                var user = new Entities.Models.ApplicationUser
                {
                    Id = Guid.NewGuid().ToString(),
                    FirstName = s.FirstName,
                    LastName = s.LastName,
                    IsActive = true,
                    UserName = s.PhoneNumber,
                    NormalizedUserName = s.PhoneNumber.ToUpper(),
                    PhoneNumber = s.PhoneNumber,
                    PhoneNumberConfirmed = true,
                    IsStudent = true
                };
                dUserManager.CreateAsync(user, string.IsNullOrEmpty(s.Password) ? "Aa@123456" : s.Password).Wait();
            }

            var users = dContext.Users.Where(x => x.NormalizedUserName != "ADMIN").ToList();
            var roleId = dContext.Roles.FirstOrDefault(x => x.NormalizedName == "STUDENT")?.Id ?? "";
            foreach (var user in users)
                dContext.UserRoles.Add(new IdentityUserRole<string>
                {
                    UserId = user.Id,
                    RoleId = roleId
                });

            foreach (var s in sList)
            {
                var id = users.FirstOrDefault(x => x.UserName == s.PhoneNumber)?.Id ?? "";
                if (id != "")
                    dContext.Students.Add(new Student
                    {
                        Id = id,
                        NationalCode = s.NationalCode,
                        BirthDate = s.BirthDate,
                        CityId = s.CityId==0?null:s.CityId,
                        Grade = (StudentGradeEnum)s.Grade,
                        Level = ConvertToLevelEnum((StudentGradeEnum)s.Grade),
                        Gender = (GenderEnum)s.Gender,
                        CreateDate = s.CreateDate,
                        IsRegistered = s.IsRegistered,
                        RegisterDate = s.RegisterDate,
                        IsPayed = s.IsPayed,
                        PaymentDate = s.PaymentDate
                    });
            }
            dContext.SaveChanges();
        }

        private StudentLevelEnum ConvertToLevelEnum(StudentGradeEnum grade)
        {
            return grade switch
            {
                StudentGradeEnum.Seventh => StudentLevelEnum.FirstHighSchool,
                StudentGradeEnum.Eighth => StudentLevelEnum.FirstHighSchool,
                StudentGradeEnum.Ninth => StudentLevelEnum.FirstHighSchool,
                StudentGradeEnum.Tenth => StudentLevelEnum.SecondHighSchool,
                StudentGradeEnum.Eleventh => StudentLevelEnum.SecondHighSchool,
                StudentGradeEnum.Twelfth => StudentLevelEnum.SecondHighSchool,
                _ => StudentLevelEnum.Null
            };
        }

        private void ConvertValidatedPhoneTokens(SourceKeyboardContext sContext, DestinationKeyboardContext dContext)
        {
            var sList = sContext.ValidatedPhoneTokens.ToList();
            foreach (var s in sList)
                dContext.ValidatedPhoneTokens.Add(new ValidatedPhoneToken
                {
                    PhoneNumber = s.PhoneNumber,
                    Token = s.Token
                });
            dContext.SaveChanges();
        }

        private void ConvertSupportedPhoneNumbers(SourceKeyboardContext sContext, DestinationKeyboardContext dContext)
        {
            var sList = sContext.SupportedPhoneNumbers.ToList();
            foreach (var s in sList)
                dContext.SupportedPhoneNumbers.Add(new SupportedPhoneNumber
                {
                    PhoneNumber = s.PhoneNumber
                });
            dContext.SaveChanges();
        }

        private void ConvertStudentPayments(SourceKeyboardContext sContext, DestinationKeyboardContext dContext)
        {
            var sList = sContext.StudentPayments.ToList();
            foreach (var s in sList)
                dContext.StudentPayments.Add(new StudentPayment
                {
                    PhoneNumber = s.PhoneNumber,
                    Amount = s.Amount,
                    RequestTime = s.RequestTime,
                    RequestResult = s.RequestResult,
                    ReferenceId = s.ReferenceId,
                    VerifyTime = s.VerifyTime,
                    SaleReferenceId = s.SaleReferenceId,
                    CardHolderInfo = s.CardHolderInfo,
                    CardHolderPan = s.CardHolderPan,
                    VerifyResult = s.VerifyResult,
                    SettleResult = s.SettleResult,
                    DiscountCode = s.DiscountCode,
                });
            dContext.SaveChanges();
        }

        private void ConvertSlides(SourceKeyboardContext sContext, DestinationKeyboardContext dContext)
        {
            var sList = sContext.Slides.ToList();
            foreach (var s in sList)
                dContext.Slides.Add(new Slide
                {
                    SlideType = (SlideTypeEnum)s.SlideType,
                    Order = s.Order,
                    Title = s.Title,
                    PosterLink = s.PosterLink,
                    Link = s.Link
                });
            dContext.SaveChanges();
        }

        private void ConvertProfessors(SourceKeyboardContext sContext, DestinationKeyboardContext dContext)
        {
            var sList = sContext.Professors.ToList();
            foreach (var s in sList)
                dContext.Professors.Add(new Professor
                {
                    Name = s.Name,
                    Description = s.Description,
                    PictureLink = s.PictureLink
                });
            dContext.SaveChanges();
        }

        private void ConvertNews(SourceKeyboardContext sContext, DestinationKeyboardContext dContext)
        {
            var sList = sContext.News.ToList();
            foreach (var s in sList)
                dContext.News.Add(new News
                {
                    NewsDate = s.NewsDate,
                    PosterLink = s.PosterLink,
                    PosterFileType = FileTypeEnum.Image,
                    Title = s.Title,
                    Abstract = s.Abstract,
                    Text = s.Text,
                    Writer = s.Writer,
                    Hot = s.Hot,
                    ThumbnailLink = s.ThumbnailLink,
                    HtmlText = s.HtmlText
                });
            dContext.SaveChanges();
        }

        private void ConvertMobileVerificationCodes(SourceKeyboardContext sContext, DestinationKeyboardContext dContext)
        {
            var sList = sContext.MobileVerificationCodes.ToList();
            foreach (var s in sList)
                dContext.VerificationCodes.Add(new VerificationCode
                {
                    PhoneNumber = s.PhoneNumber,
                    Code = s.Code,
                    SendDateTime = s.SendDateTime
                });
            dContext.SaveChanges();
        }

        private void ConvertFaqs(SourceKeyboardContext sContext, DestinationKeyboardContext dContext)
        {
            var sList = sContext.Faqs.ToList();
            foreach (var s in sList)
                dContext.Faqs.Add(new Faq
                {
                    Question = s.Question,
                    Answer = s.Answer
                });
            dContext.SaveChanges();
        }

        private void ConvertDiscountCodes(SourceKeyboardContext sContext, DestinationKeyboardContext dContext)
        {
            var sList = sContext.DiscountCodes.ToList();
            foreach (var s in sList)
                dContext.DiscountCodes.Add(new DiscountCode
                {
                    Code = s.Code,
                    Amount = s.Amount,
                    MaxUsageCount = s.MaxUsageCount,
                    UsageCount = s.UsageCount,
                    StartDate = s.StartDate,
                    EndDate = s.EndDate,
                    CreateDate = s.CreateDate
                });
            dContext.SaveChanges();
        }

        private void ConvertContactUsMessages(SourceKeyboardContext sContext, DestinationKeyboardContext dContext)
        {
            var sList = sContext.ContactUsMessages.Include(x => x.TicketSubject).ToList();
            var dList = dContext.TicketSubjects.ToList();
            foreach (var s in sList)
            {
                var t = dList.FirstOrDefault(x => x.Subject == s.TicketSubject.Subject);
                if (t != null)
                    dContext.ContactUsMessages.Add(new ContactUsMessage
                    {
                        TicketSubject = t,
                        FirstName = s.FirstName,
                        LastName = s.LastName,
                        Email = s.Email,
                        MobileNumber = s.MobileNumber,
                        Description = s.Description,
                        TimeStamp = s.TimeStamp,
                        Status = s.Status
                    });
            }

            dContext.SaveChanges();
        }

        private void ConvertTicketSubjects(SourceKeyboardContext sContext, DestinationKeyboardContext dContext)
        {
            var sList = sContext.TicketSubjects.ToList();
            foreach (var s in sList)
                dContext.TicketSubjects.Add(new TicketSubject { Subject = s.Subject });
            dContext.SaveChanges();
        }

        private void ConvertAppSettings(SourceKeyboardContext sContext, DestinationKeyboardContext dContext)
        {
            var sList = sContext.AppSettings.ToList();
            var dList = dContext.AppSettings.ToList();
            foreach (var s in sList)
            {
                var d = dContext.AppSettings.FirstOrDefault(x => x.Key == s.Key);
                if (d == null)
                    dContext.AppSettings.Add(new AppSetting { Key = s.Key, Value = s.Value });
                else
                {
                    d.Value = s.Value;
                    dContext.AppSettings.Update(d);
                }
            }

            dContext.SaveChanges();
        }

        private void ConvertAiLandingFaqs(SourceKeyboardContext sContext, DestinationKeyboardContext dContext)
        {
            var sList = sContext.AiLandingFaqs.ToList();
            foreach (var s in sList)
                dContext.LandingFaqs.Add(new LandingFaq
                {
                    Question = s.Question,
                    Answer = s.Answer
                });
            dContext.SaveChanges();
        }
    }
}