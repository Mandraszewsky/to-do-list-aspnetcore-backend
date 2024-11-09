using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ToDoList.Infrastructure.Data.Configurations;

public class UserConfiguration : IEntityTypeConfiguration<Domain.Models.User>
{
    public void Configure(EntityTypeBuilder<Domain.Models.User> builder)
    {
        builder.HasKey(x => x.Id);

        builder.Property(x => x.Name)
            .HasMaxLength(50)
            .IsRequired();
    }
}
