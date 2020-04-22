using Announcer.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Announcer.Data.Config
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

            builder.HasData(
                new Client() { Id = "10.100.1.1", Name = "Alerji ve İmmünoloji Bekleme 1", Description = "E Blok", UserId = null, TemplateId = 1 },
                new Client() { Id = "10.100.1.2", Name = "Beyin ve Sinir Cerrahisi Bekleme 1", Description = "B Blok", UserId = null, TemplateId = 1 },
                new Client() { Id = "10.100.1.3", Name = "Cerrahi Onkoloji Bekleme 1", Description = "D Blok", UserId = null, TemplateId = 1 },
                new Client() { Id = "10.100.1.4", Name = "Çocuk Bekleme 1", Description = "C Blok", UserId = null, TemplateId = 1 },
                new Client() { Id = "10.100.1.5", Name = "Çocuk Sağlığı ve Hastalıkları Bekleme 1", Description = "E Blok", UserId = null, TemplateId = 1 },
                new Client() { Id = "10.100.1.6", Name = "Çocuk Sağlığı ve Hastalıkları Bekleme 2", Description = "E Blok", UserId = null, TemplateId = 1 },
                new Client() { Id = "10.100.1.7", Name = "Dermatoloji Bekleme 1", Description = "C Blok", UserId = null, TemplateId = 1 },
                new Client() { Id = "10.100.1.8", Name = "Enfeksiyon Bekleme 1", Description = "B Blok", UserId = null, TemplateId = 1 },
                new Client() { Id = "10.100.1.9", Name = "Fizik Tedavi Bekleme 1", Description = "FTR", UserId = null, TemplateId = 1 },
                new Client() { Id = "10.100.1.10", Name = "Fizik Tedavi Bekleme 2", Description = "FTR", UserId = null, TemplateId = 1 },
                new Client() { Id = "10.100.1.11", Name = "Genel Cerrahi Bekleme 1", Description = "B Blok", UserId = null, TemplateId = 1 },
                new Client() { Id = "10.100.1.12", Name = "Genel Cerrahi Bekleme 2", Description = "B Blok", UserId = null, TemplateId = 1 },
                new Client() { Id = "10.100.1.13", Name = "Göğüs Cerrahisi Bekleme 1", Description = "A Blok", UserId = null, TemplateId = 1 },
                new Client() { Id = "10.100.1.14", Name = "Göğüs Hastalıkları Bekleme 1", Description = "A Blok", UserId = null, TemplateId = 1 },
                new Client() { Id = "10.100.1.15", Name = "Göğüs Hastalıkları Bekleme 2", Description = "A Blok", UserId = null, TemplateId = 1 },
                new Client() { Id = "10.100.1.16", Name = "Göz Hastalıkları Bekleme 1", Description = "C Blok", UserId = null, TemplateId = 1 },
                new Client() { Id = "10.100.1.17", Name = "Göz Hastalıkları Bekleme 2", Description = "C Blok", UserId = null, TemplateId = 1 },
                new Client() { Id = "10.100.1.18", Name = "Hematoloji Bekleme 1", Description = "D Blok", UserId = null, TemplateId = 1 },
                new Client() { Id = "10.100.1.19", Name = "İç Hastalıkları Bekleme 1", Description = "C Blok", UserId = null, TemplateId = 1 },
                new Client() { Id = "10.100.1.20", Name = "İç Hastalıkları Bekleme 2", Description = "C Blok", UserId = null, TemplateId = 1 },
                new Client() { Id = "10.100.1.21", Name = "Kadın Hastalıkları ve Doğum Bekleme 1", Description = "C Blok", UserId = null, TemplateId = 1 },
                new Client() { Id = "10.100.1.22", Name = "Kadın Hastalıkları ve Doğum Bekleme 2", Description = "C Blok", UserId = null, TemplateId = 1 },
                new Client() { Id = "10.100.1.23", Name = "Kadın Hastalıkları ve Doğum Bekleme 3", Description = "C Blok", UserId = null, TemplateId = 1 },
                new Client() { Id = "10.100.1.24", Name = "Kalp ve Damar Cerrahisi Bekleme 1", Description = "A Blok", UserId = null, TemplateId = 1 },
                new Client() { Id = "10.100.1.25", Name = "Kardiyoloji Bekleme 1", Description = "A Blok", UserId = null, TemplateId = 1 },
                new Client() { Id = "10.100.1.26", Name = "Kardiyoloji Bekleme 2", Description = "A Blok", UserId = null, TemplateId = 1 },
                new Client() { Id = "10.100.1.27", Name = "Kulak Burun Boğaz Bekleme 1", Description = "C Blok", UserId = null, TemplateId = 1 },
                new Client() { Id = "10.100.1.28", Name = "Kulak Burun Boğaz Bekleme 2", Description = "C Blok", UserId = null, TemplateId = 1 },
                new Client() { Id = "10.100.1.29", Name = "Nefroloji Bekleme 1", Description = "D Blok", UserId = null, TemplateId = 1 },
                new Client() { Id = "10.100.1.30", Name = "Nöroloji Bekleme 1", Description = "D Blok", UserId = null, TemplateId = 1 },
                new Client() { Id = "10.100.1.31", Name = "Ortopedi Bekleme 1", Description = "B Blok", UserId = null, TemplateId = 1 },
                new Client() { Id = "10.100.1.32", Name = "Ortopedi Bekleme 2", Description = "B Blok", UserId = null, TemplateId = 1 },
                new Client() { Id = "10.100.1.33", Name = "Ortopedi Bekleme 3", Description = "B Blok", UserId = null, TemplateId = 1 },
                new Client() { Id = "10.100.1.34", Name = "Psikiyatri Bekleme 1", Description = "C Blok", UserId = null, TemplateId = 1 },
                new Client() { Id = "10.100.1.35", Name = "Radyasyon Onkolojisi Bekleme 1", Description = "D Blok", UserId = null, TemplateId = 1 },
                new Client() { Id = "10.100.1.36", Name = "Romatoloji Bekleme 1", Description = "FTR", UserId = null, TemplateId = 1 },
                new Client() { Id = "10.100.1.37", Name = "Sigarayı Bıraktırma Bekleme 1", Description = "B Blok", UserId = null, TemplateId = 1 },
                new Client() { Id = "10.100.1.38", Name = "Tıbbi Genetik Bekleme 1", Description = "E Blok", UserId = null, TemplateId = 1 },
                new Client() { Id = "10.100.1.39", Name = "Tıbbi Onkoloji Bekleme 1", Description = "D Blok", UserId = null, TemplateId = 1 },
                new Client() { Id = "10.100.1.40", Name = "Üroloji Bekleme 1", Description = "D Blok", UserId = null, TemplateId = 1 },
                new Client() { Id = "10.100.1.41", Name = "Üroloji Bekleme 2", Description = "D Blok", UserId = null, TemplateId = 1 },
                new Client() { Id = "10.100.1.42", Name = "Yanık Polikliniği Bekleme 1", Description = "B Blok", UserId = null, TemplateId = 1 }
                );
        }
    }
}