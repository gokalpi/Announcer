using Announcer.Models.v1;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Announcer.Data.Config.v1
{
    public class NotificationConfiguration : IEntityTypeConfiguration<Notification>
    {
        public void Configure(EntityTypeBuilder<Notification> builder)
        {
            builder.ToTable("Notifications");

            builder.HasKey(n => n.Id)
                   .HasName("PK_Notifications");

            builder.Property(n => n.Id)
                   .IsRequired()
                   .HasMaxLength(50)
                   .IsUnicode(false);

            builder.Property(n => n.Content)
                   .IsRequired();

            builder.Property(n => n.SentTime)
                   .IsRequired();

            builder.Property(n => n.SenderId)
                   .IsRequired()
                   .HasMaxLength(50)
                   .IsUnicode(false);

            builder.Property(n => n.GroupId)
                   .HasMaxLength(50)
                   .IsUnicode(false);

            builder.Property(n => n.SenderId)
                   .HasMaxLength(50)
                   .IsUnicode(false);

            builder.Property(n => n.RecipientId)
                   .HasMaxLength(50)
                   .IsUnicode(false);

            builder.HasIndex(n => n.GroupId);

            builder.HasIndex(n => n.RecipientId);

            builder.HasIndex(n => n.SenderId);

            builder.HasOne(n => n.Sender)
                .WithMany(c => c.NotificationsSent)
                .HasForeignKey(n => n.SenderId);

            builder.HasOne(n => n.Recipient)
                .WithMany(c => c.NotificationsReceived)
                .HasForeignKey(n => n.RecipientId)
                .IsRequired(false);

            builder.HasOne(n => n.Group)
                .WithMany(g => g.NotificationsReceived)
                .HasForeignKey(n => n.GroupId)
                .IsRequired(false);
        }
    }
}