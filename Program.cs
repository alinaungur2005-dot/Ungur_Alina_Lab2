using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Ungur_Alina_Lab2.Data;

var builder = WebApplication.CreateBuilder(args);

var connectionString = builder.Configuration.GetConnectionString("Ungur_Alina_Lab2Context")
    ?? throw new InvalidOperationException("Connection string 'Ungur_Alina_Lab2Context' not found.");

builder.Services.AddRazorPages();

builder.Services.AddDbContext<Ungur_Alina_Lab2Context>(options =>
    options.UseSqlServer(connectionString));

builder.Services.AddDbContext<LibraryIdentityContext>(options =>
    options.UseSqlServer(connectionString));

// Înregistrare Identity cu ApplicationUser
builder.Services.AddDefaultIdentity<ApplicationUser>(options => options.SignIn.RequireConfirmedAccount = false)
    .AddEntityFrameworkStores<LibraryIdentityContext>();

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