using Announcer.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Announcer.Data.Config
{
    public class TemplateConfiguration : IEntityTypeConfiguration<Template>
    {
        public void Configure(EntityTypeBuilder<Template> builder)
        {
            builder.ToTable("Templates");

            builder.HasKey(t => t.Id);

            builder.Property(t => t.Id)
                   .IsRequired()
                   .HasMaxLength(50)
                   .IsUnicode(false);

            builder.Property(t => t.Name)
                   .IsRequired()
                   .HasMaxLength(255);

            builder.Property(t => t.Content);
        }
    }
}