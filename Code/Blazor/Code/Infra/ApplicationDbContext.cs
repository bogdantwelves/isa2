using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Abc.Data;

namespace Abc.Infra;

public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : IdentityDbContext<ApplicationUser>(options)
{
    public DbSet<Movie> Movie { get; set; } = default!;
    public DbSet<Country> Countries { get; set; } = default!;

    public DbSet<Currency> Currencies { get; set; } = default!; 
    public DbSet<CountryCurrency> CountryCurrencies { get; set; } = default!;
    public DbSet<Money> Money { get; set; } = default!;

}