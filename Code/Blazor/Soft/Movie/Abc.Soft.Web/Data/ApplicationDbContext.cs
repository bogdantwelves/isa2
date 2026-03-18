using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Abc.Data;

namespace Abc.Soft.Web.Data;

public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : IdentityDbContext<ApplicationUser>(options)
{
    public DbSet<Movie> Movie { get; set; } = default!;
    public DbSet<Country> Countries { get; set; } = default!;

}