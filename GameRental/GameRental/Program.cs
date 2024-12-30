using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Localization;
using Infrastructure.Data;
using System.Globalization;
using Application.ModelsDTO;
using Application.Services.Interfaces;
using GameRental.Data;
using Microsoft.AspNetCore.Identity.UI.Services;
using Domain.Entities;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddInfrastructureServices();
builder.Services.AddDatabaseDeveloperPageExceptionFilter();
builder.Services.AddLocalization();
builder.Services.AddSingleton<IEmailSender, SendGridEmailSender>();
builder.Services.AddMvc().AddDataAnnotationsLocalization()
    .AddViewLocalization(options => options.ResourcesPath = "Resources");

builder.Services.AddDefaultIdentity<ApplicationUser>(options => options.SignIn.RequireConfirmedAccount = true)
    .AddEntityFrameworkStores<ApplicationDbContext>()
    .AddDefaultTokenProviders();

builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("RequireAccount",
        policy => policy.RequireRole("User"));
});

builder.Services.AddRazorPages(options =>
{
    options.Conventions.AuthorizeFolder("/Game/Actions");
    options.Conventions.AuthorizeFolder("/Genre/Actions");
    options.Conventions.AuthorizeFolder("/GameOffer/Actions");
    options.Conventions.AuthorizeFolder("/GameLeased/Actions");
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

#region API
//Endpoint for /games
app.MapMethods("/api/games", new[] { "GET" }, async (HttpContext context, IGameService service) =>
{
    if (context.Request.Method == "GET")
    {
        var games = await service.GetAllAsync();
        return Results.Ok(games);
    }
    return Results.BadRequest();
});

// Endpoint for /games/{id} (handles GET, PUT, DELETE)
app.MapMethods("/api/games/{id:int}", new[] { "GET", "PUT", "DELETE" }, async (HttpContext context, int id, IGameService service) =>
{
    if (context.Request.Method == "GET")
    {
        var game = await service.GetByIdAsync(id);
        return game is not null ? Results.Ok(game) : Results.NotFound();
    }
    else if (context.Request.Method == "PUT")
    {
        var updatedGame = await context.Request.ReadFromJsonAsync<GameDTO>();
        if (updatedGame == null || updatedGame.Id != id)
            return Results.BadRequest("Invalid or mismatched player data.");

        await service.UpdateAsync(updatedGame);
        return Results.NoContent();
    }
    else if (context.Request.Method == "DELETE")
    {
        await service.DeleteAsync(id);
        return Results.NoContent();
    }
    return Results.BadRequest();
});

//Endpoint for /genre
app.MapMethods("/api/genre", new[] { "GET" }, async (HttpContext context, IGenreService service) =>
{
    if (context.Request.Method == "GET")
    {
        var genre = await service.GetAllAsync();
        return Results.Ok(genre);
    }
    return Results.BadRequest();
});

// Endpoint for /genre/{id} (handles GET, PUT, DELETE)
app.MapMethods("/api/genre/{id:int}", new[] { "GET", "PUT", "DELETE" }, async (HttpContext context, int id, IGenreService service) =>
{
    if (context.Request.Method == "GET")
    {
        var genre = await service.GetByIdAsync(id);
        return genre is not null ? Results.Ok(genre) : Results.NotFound();
    }
    else if (context.Request.Method == "PUT")
    {
        var updatedGenre = await context.Request.ReadFromJsonAsync<GenreDTO>();
        if (updatedGenre == null || updatedGenre.Id != id)
            return Results.BadRequest("Invalid or mismatched player data.");

        await service.UpdateAsync(updatedGenre);
        return Results.NoContent();
    }
    else if (context.Request.Method == "DELETE")
    {
        await service.DeleteAsync(id);
        return Results.NoContent();
    }
    return Results.BadRequest();
});

//Endpoint for /gameOffer
app.MapMethods("/api/gameOffer", new[] { "GET" }, async (HttpContext context, IGameOfferService service) =>
{
    if (context.Request.Method == "GET")
    {
        var gameOffer = await service.GetAllAsync();
        return Results.Ok(gameOffer);
    }
    return Results.BadRequest();
});

// Endpoint for /gameOffer/{id} (handles GET, PUT, DELETE)
app.MapMethods("/api/gameOffer/{id:int}", new[] { "GET", "PUT", "DELETE" }, async (HttpContext context, int id, IGameOfferService service) =>
{
    if (context.Request.Method == "GET")
    {
        var gameOffer = await service.GetByIdAsync(id);
        return gameOffer is not null ? Results.Ok(gameOffer) : Results.NotFound();
    }
    else if (context.Request.Method == "PUT")
    {
        var updatedGameOffer = await context.Request.ReadFromJsonAsync<GameOfferDTO>();
        if (updatedGameOffer == null || updatedGameOffer.Id != id)
            return Results.BadRequest("Invalid or mismatched player data.");

        await service.UpdateAsync(updatedGameOffer);
        return Results.NoContent();
    }
    else if (context.Request.Method == "DELETE")
    {
        await service.DeleteAsync(id);
        return Results.NoContent();
    }
    return Results.BadRequest();
});

//Endpoint for /gameLeased
app.MapMethods("/api/gameLeased", new[] { "GET" }, async (HttpContext context, IGameLeasedService service) =>
{
    if (context.Request.Method == "GET")
    {
        var gameLeased = await service.GetAllAsync();
        return Results.Ok(gameLeased);
    }
    return Results.BadRequest();
});

// Endpoint for /gameLeased/{id} (handles GET, PUT, DELETE)
app.MapMethods("/api/gameLeased/{id:int}", new[] { "GET", "PUT", "DELETE" }, async (HttpContext context, int id, IGameLeasedService service) =>
{
    if (context.Request.Method == "GET")
    {
        var gameLeased = await service.GetByIdAsync(id);
        return gameLeased is not null ? Results.Ok(gameLeased) : Results.NotFound();
    }
    else if (context.Request.Method == "PUT")
    {
        var updatedGameLeased = await context.Request.ReadFromJsonAsync<GameLeasedDTO>();
        if (updatedGameLeased == null || updatedGameLeased.Id != id)
            return Results.BadRequest("Invalid or mismatched player data.");

        await service.UpdateAsync(updatedGameLeased);
        return Results.NoContent();
    }
    else if (context.Request.Method == "DELETE")
    {
        await service.DeleteAsync(id);
        return Results.NoContent();
    }
    return Results.BadRequest();
});

////Endpoint for /applicationUser
//app.MapMethods("/api/applicationUser", new[] { "GET" }, async (HttpContext context, IApplicationUserService service) =>
//{
//    if (context.Request.Method == "GET")
//    {
//        var applicationUser = await service.GetAllAsync();
//        return Results.Ok(applicationUser);
//    }
//    return Results.BadRequest();
//});

//// Endpoint for /applicationUser/{id} (handles GET, PUT, DELETE)
//app.MapMethods("/api/applicationUser/{id}", new[] { "GET", "PUT", "DELETE" }, async (HttpContext context, string id, IApplicationUserService service) =>
//{
//    if (context.Request.Method == "GET")
//    {
//        var applicationUser = await service.GetByIdAsync(id);
//        return applicationUser is not null ? Results.Ok(applicationUser) : Results.NotFound();
//    }
//    else if (context.Request.Method == "PUT")
//    {
//        var updatedApplicationUser = await context.Request.ReadFromJsonAsync<ApplicationUserDTO>();
//        if (updatedApplicationUser == null || updatedApplicationUser.Id != id)
//            return Results.BadRequest("Invalid or mismatched player data.");

//        await service.UpdateAsync(updatedApplicationUser);
//        return Results.NoContent();
//    }
//    else if (context.Request.Method == "DELETE")
//    {
//        await service.DeleteAsync(id);
//        return Results.NoContent();
//    }
//    return Results.BadRequest();
//});

#endregion

app.Run();
