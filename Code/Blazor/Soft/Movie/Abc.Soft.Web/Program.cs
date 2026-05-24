using Abc.Infra;
using Abc.Soft.Web;
using Abc.Soft.Web.Components.Account;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using static Abc.Infra.Repos;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents()
    .AddInteractiveWebAssemblyComponents()
    .AddAuthenticationStateSerialization();

builder.Services.AddCascadingAuthenticationState();
builder.Services.AddScoped<IdentityRedirectManager>();
builder.Services.AddScoped<AuthenticationStateProvider, IdentityRevalidatingAuthenticationStateProvider>();

builder.Services.AddAuthentication(options =>
    {
        options.DefaultScheme = IdentityConstants.ApplicationScheme;
        options.DefaultSignInScheme = IdentityConstants.ExternalScheme;
    })
    .AddIdentityCookies();

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection") ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");

builder.Services.AddDbContextFactory<ApplicationDbContext>(options => options.UseSqlite(connectionString));

builder.Services.AddQuickGridEntityFrameworkAdapter();
//builder.Services.AddDbContext<ApplicationDbContext>(options =>
//    options.UseSqlite(connectionString));

// Kui kuskil on DI-s vaja ApplicationDbContext-i (mitte factory’t), võta see factory kaudu:
builder.Services.AddScoped(sp =>
    sp.GetRequiredService<IDbContextFactory<ApplicationDbContext>>().CreateDbContext());

builder.Services.AddDatabaseDeveloperPageExceptionFilter();

builder.Services.AddIdentityCore<ApplicationUser>(options =>
    {
        options.SignIn.RequireConfirmedAccount = true;
        options.Stores.SchemaVersion = IdentitySchemaVersions.Version3;
    })
    .AddEntityFrameworkStores<ApplicationDbContext>()
    .AddSignInManager()
    .AddDefaultTokenProviders();

builder.Services.AddSingleton<IEmailSender<ApplicationUser>, IdentityNoOpEmailSender>();
builder.Services.AddScoped<IMoviesRepo, MoviesRepo>();
builder.Services.AddScoped<ICountriesRepo, CountriesRepo>();
builder.Services.AddScoped<ICurrenciesRepo, CurrenciesRepo>();
builder.Services.AddScoped<IMoneyRepo, MoneyRepo>();
builder.Services.AddScoped<ICountryCurrenciesRepo, CountryCurrenciesRepo>();

var app = builder.Build();

// using var scope = app.Services.CreateScope();
// var sp = scope.ServiceProvider;
// var db = sp.GetRequiredService<ApplicationDbContext>();
// await db.Database.MigrateAsync();

// var seedEnabled = builder.Configuration.GetValue("SeedDb:Enabled", app.Environment.IsDevelopment());
// if (seedEnabled) {
//     var seedCount = builder.Configuration.GetValue("SeedDb:RecordCount", 200);
//     await new SeedDb(db, seedCount).Seed();
// }

using var scope = app.Services.CreateScope();
var sp = scope.ServiceProvider;
var db = sp.GetRequiredService<ApplicationDbContext>();
await new SeedDb(db, 10000).Seed();



// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseWebAssemblyDebugging();
    app.UseMigrationsEndPoint();
}
else
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
    app.UseMigrationsEndPoint();
}
app.UseStatusCodePagesWithReExecute("/not-found", createScopeForStatusCodePages: true);
app.UseHttpsRedirection();

app.UseAntiforgery();

app.MapStaticAssets();
app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode()
    .AddInteractiveWebAssemblyRenderMode()
    .AddAdditionalAssemblies(typeof(Abc.Soft.Web.Client.ClientAssemblyMarker).Assembly);

// Add additional endpoints required by the Identity /Account Razor components.
app.MapAdditionalIdentityEndpoints();

app.Run();
