
namespace Todo.Infrastructure.Configurations;

internal class TodoConfiguration : IEntityTypeConfiguration<Domain.Entities.Todo>
{
    public void Configure(EntityTypeBuilder<Domain.Entities.Todo> builder)
    {
        builder.HasKey(t => t.Id);
        builder.Property(t => t.Id).HasConversion(
            tId => tId.Value,
            dbId => TodoId.Of(dbId));

        builder.Property(t => t.Name).HasMaxLength(100).IsRequired()
            .HasConversion(
                tName => tName.Value,
                dbName => TodoName.Of(dbName));

        builder.Property(t => t.StartDate).IsRequired();
        builder.Property(t =>t.EndDate).IsRequired();
    }
}
