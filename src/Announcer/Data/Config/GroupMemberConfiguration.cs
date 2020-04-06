using Announcer.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Announcer.Data.Config
{
    public class GroupMemberConfiguration : IEntityTypeConfiguration<GroupMember>
    {
        public void Configure(EntityTypeBuilder<GroupMember> builder)
        {
            builder.ToTable("GroupMembers");

            builder.HasKey(gm => new { gm.GroupId, gm.ClientId });

            builder.Property(gm => gm.GroupId)
                   .IsRequired()
                   .HasMaxLength(50)
                   .IsUnicode(false);

            builder.Property(gm => gm.ClientId)
                   .IsRequired()
                   .HasMaxLength(50)
                   .IsUnicode(false);

            builder.HasOne(gm => gm.Group)
                .WithMany(g => g.Clients)
                .HasForeignKey(gm => gm.GroupId);

            builder.HasOne(gm => gm.Client)
                .WithMany(c => c.Groups)
                .HasForeignKey(gm => gm.ClientId);
        }
    }
}