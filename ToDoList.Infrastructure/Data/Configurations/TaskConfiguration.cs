using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ToDoList.Domain.Models;

namespace ToDoList.Infrastructure.Data.Configurations;

public class TaskConfiguration : IEntityTypeConfiguration<Domain.Models.Task>
{
    public void Configure(EntityTypeBuilder<Domain.Models.Task> builder)
    {
        builder.HasKey(x => x.Id);

        builder.HasOne<User>()
            .WithMany()
            .HasForeignKey(x => x.UserId)
            .IsRequired();

        builder.Property(x => x.Summary)
            .HasMaxLength(100)
            .IsRequired();
    }
}
