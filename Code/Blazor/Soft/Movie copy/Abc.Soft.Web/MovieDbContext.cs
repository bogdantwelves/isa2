using Microsoft.EntityFrameworkCore;

public class MovieDbContext(DbContextOptions<MovieDbContext> options) : DbContext(options)
{
    public DbSet<Abc.Soft.Web.Model.Movie> Movie { get; set; } = default!;
}
