using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Localization;
using Microsoft.EntityFrameworkCore;
using Infrastructure.Data;
using System.Globalization;
using Application.Repositories.Classes;
using Application.Repositories.Interfaces;
using Application.Services.Classes;
using GameRental.Data;
using Microsoft.AspNetCore.Identity.UI.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

//var connectionString = builder.Configuration.GetConnectionString("DefaultConnection") ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");
//builder.Services.AddDbContext<ApplicationDbContext>(options =>
//    options.UseSqlServer(connectionString));

builder.Services.AddInfrastructureServices();
builder.Services.AddDatabaseDeveloperPageExceptionFilter();
builder.Services.AddLocalization();
builder.Services.AddSingleton<IEmailSender, SendGridEmailSender>();
builder.Services.AddMvc().AddDataAnnotationsLocalization()
    .AddViewLocalization(options => options.ResourcesPath = "Resources");

builder.Services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
    .AddEntityFrameworkStores<ApplicationDbContext>()
    .AddDefaultTokenProviders();

builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("RequireAccount",
        policy => policy.RequireRole("User"));
});

builder.Services.AddRazorPages(options =>
{
    options.Conventions.AuthorizeFolder("/");
});

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


var app = builder.Build();

var supportedCultures = new[] { new
    CultureInfo("en"), new CultureInfo("pl")};

app.UseRequestLocalization(new RequestLocalizationOptions
{
    DefaultRequestCulture = new RequestCulture("en"),
    SupportedCultures = supportedCultures,
    SupportedUICultures = supportedCultures
});

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseMigrationsEndPoint();
}
else
{
    app.UseExceptionHandler("/Error");
}

//app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();

app.UseSwagger();
app.UseSwaggerUI();

//API

//Endpoint /games
app.MapMethods("/api/games", new[] { "GET" }, async (HttpContext context, GameService service) =>
{
    if (context.Request.Method == "GET")
    {
        var games = await service.GetAllGames();
        return Results.Ok(games);
    }
    return Results.BadRequest();
});

app.Run();
