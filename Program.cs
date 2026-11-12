using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Ungur_Alina_Lab2.Data;


var builder = WebApplication.CreateBuilder(args);

builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("AdminPolicy", policy =>
policy.RequireRole("Admin"));
});


var connectionString = builder.Configuration.GetConnectionString("Ungur_Alina_Lab2Context")
    ?? throw new InvalidOperationException("Connection string 'Ungur_Alina_Lab2Context' not found.");


builder.Services.AddDbContext<Ungur_Alina_Lab2Context>(options =>
    options.UseSqlServer(connectionString));

builder.Services.AddDbContext<LibraryIdentityContext>(options =>
    options.UseSqlServer(connectionString));


builder.Services.AddDefaultIdentity<ApplicationUser>(options => options.SignIn.RequireConfirmedAccount = false)
    .AddRoles<IdentityRole>()
    .AddEntityFrameworkStores<LibraryIdentityContext>();

builder.Services.AddRazorPages(options =>
{
    options.Conventions.AuthorizeFolder("/BookPages");
    options.Conventions.AllowAnonymousToPage("/BookPages/Index");
    options.Conventions.AllowAnonymousToPage("/BookPages/Details");
    options.Conventions.AuthorizeFolder("/MemberPages", "AdminPolicy");
    options.Conventions.AuthorizeFolder("/PublisherPages", "AdminPolicy");
    options.Conventions.AuthorizeFolder("/CategoryPages", "AdminPolicy");
});


var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapRazorPages();

app.Run();