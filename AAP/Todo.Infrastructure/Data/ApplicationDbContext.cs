
namespace Todo.Infrastructure.Data;

public class ApplicationDbContext:DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }

    public DbSet<Domain.Entities.Todo> Todo { get; set; }
}
