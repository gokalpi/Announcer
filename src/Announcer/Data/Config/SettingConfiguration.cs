using Announcer.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Announcer.Data.Config
{
    public class SettingConfiguration : IEntityTypeConfiguration<Setting>
    {
        public void Configure(EntityTypeBuilder<Setting> builder)
        {
            builder.ToTable("Settings");

            builder.HasKey(s => s.Id);

            builder.Property(s => s.Id)
                   .IsRequired();

            builder.Property(s => s.Key)
                   .IsRequired()
                   .HasMaxLength(255);

            builder.Property(s => s.Value)
                   .IsRequired();

            builder.HasQueryFilter(t => !t.IsDeleted);
        }
    }
}