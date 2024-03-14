using DestinationContext;
using KeyboardDataTransfer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using SourceContext;

IHost host = Host.CreateDefaultBuilder(args)
    .ConfigureServices(services =>
    {
        IConfiguration configuration = services.BuildServiceProvider().GetRequiredService<IConfiguration>();

        services.AddHostedService<Worker>();

        services.AddDbContextPool<SourceKeyboardContext>(opts =>
            opts.UseSqlServer(configuration.GetConnectionString("Source")));
        services.AddIdentity<Infrastructure.Entities.ApplicationUser, IdentityRole>(options =>
            {
                options.SignIn.RequireConfirmedAccount = true;
                options.Password.RequireDigit = false;
                options.Password.RequireLowercase = false;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireUppercase = false;
                options.Password.RequiredLength = 0;
                options.Password.RequiredUniqueChars = 0;
            })
            .AddDefaultTokenProviders()
            .AddEntityFrameworkStores<SourceKeyboardContext>();
        
        services.AddDbContext<DestinationKeyboardContext>(opts =>
            opts.UseSqlServer(configuration.GetConnectionString("Destination")));
        services.AddIdentity<Entities.Models.ApplicationUser, IdentityRole>(options =>
            {
                options.SignIn.RequireConfirmedAccount = true;
                options.Password.RequireDigit = false;
                options.Password.RequireLowercase = false;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireUppercase = false;
                options.Password.RequiredLength = 0;
                options.Password.RequiredUniqueChars = 0;
            })
            .AddDefaultTokenProviders()
            .AddEntityFrameworkStores<DestinationKeyboardContext>();
    })
    .Build();

await host.RunAsync();
