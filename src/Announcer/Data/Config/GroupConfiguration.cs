using Announcer.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Announcer.Data.Config
{
    public class GroupConfiguration : IEntityTypeConfiguration<Group>
    {
        public void Configure(EntityTypeBuilder<Group> builder)
        {
            builder.ToTable("Groups");

            builder.HasKey(g => g.Id);

            builder.Property(g => g.Id)
                   .IsRequired();

            builder.Property(g => g.Name)
                   .IsRequired()
                   .HasMaxLength(255);

            builder.Property(g => g.Description)
                   .HasMaxLength(255);
        }
    }
}