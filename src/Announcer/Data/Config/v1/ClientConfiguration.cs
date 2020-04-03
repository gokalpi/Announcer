using Announcer.Models.v1;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Announcer.Data.Config.v1
{
    public class ClientConfiguration : IEntityTypeConfiguration<Client>
    {
        public void Configure(EntityTypeBuilder<Client> builder)
        {
            builder.ToTable("Clients");

            builder.HasKey(c => c.Id)
                   .HasName("PK_Clients");

            builder.Property(c => c.Id)
                   .IsRequired()
                   .HasMaxLength(50)
                   .IsUnicode(false);

            builder.Property(c => c.Name)
                   .IsRequired()
                   .HasMaxLength(255);

            builder.Property(c => c.Description)
                   .HasMaxLength(255);

            builder.Property(c => c.UserId)
                   .HasMaxLength(450);

            builder.HasOne(c => c.User)
                .WithOne(u => u.Client)
                .HasForeignKey<ApplicationUser>(u => u.ClientId)
                .IsRequired(false);

            builder.HasOne(c => c.Template)
                .WithMany(t => t.Clients)
                .HasForeignKey(c => c.TemplateId);
        }
    }
}