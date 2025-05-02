namespace DotNet8.Shared.DbService;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

    public DbSet<BlogModel> Blogs => Set<BlogModel>();
}