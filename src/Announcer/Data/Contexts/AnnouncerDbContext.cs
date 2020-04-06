using Announcer.Contracts;
using Announcer.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;

namespace Announcer.Data.Contexts
{
    public class AnnouncerDbContext : IdentityDbContext<ApplicationUser, ApplicationRole, string>
    {
        public AnnouncerDbContext()
        {
        }

        public AnnouncerDbContext(DbContextOptions<AnnouncerDbContext> options) : base(options)
        {
        }

        public DbSet<Client> Clients { get; set; }
        public DbSet<GroupMember> GroupMembers { get; set; }
        public DbSet<Group> Groups { get; set; }
        public DbSet<Notification> Notifications { get; set; }
        public DbSet<Template> Templates { get; set; }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            foreach (var entry in ChangeTracker.Entries<ISoftDelete>())
            {
                switch (entry.State)
                {
                    case EntityState.Deleted:
                        entry.State = EntityState.Modified;
                        entry.Entity.IsDeleted = true;
                        break;

                    case EntityState.Added:
                        entry.Entity.IsDeleted = false;
                        break;

                    default:
                        break;
                }
            }

            foreach (var entry in ChangeTracker.Entries<IAuditableEntity>())
            {
                switch (entry.State)
                {
                    case EntityState.Modified:
                        entry.Entity.LastModifiedAt = DateTime.Now;
                        entry.Entity.LastModifiedBy = "";  // TODO: Update last modified user
                        entry.Property("CreatedAt").IsModified = false;
                        entry.Property("CreatedBy").IsModified = false;
                        break;

                    case EntityState.Added:
                        entry.Entity.CreatedAt = DateTime.Now;
                        entry.Entity.CreatedBy = "";  // TODO: Update created user
                        break;

                    default:
                        break;
                }
            }

            return base.SaveChangesAsync(cancellationToken);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            foreach (var entityType in modelBuilder.Model.GetEntityTypes().Where(e => typeof(IAuditableEntity).IsAssignableFrom(e.ClrType)))
            {
                modelBuilder.Entity(entityType.ClrType)
                    .Property<string>("CreatedBy")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                modelBuilder.Entity(entityType.ClrType)
                    .Property<DateTime>("CreatedAt")
                    .IsRequired();

                modelBuilder.Entity(entityType.ClrType)
                    .Property<string>("LastModifiedBy")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                modelBuilder.Entity(entityType.ClrType)
                    .Property<DateTime?>("LastModifiedAt");
            }

            foreach (var entityType in modelBuilder.Model.GetEntityTypes().Where(e => typeof(ISoftDelete).IsAssignableFrom(e.ClrType)))
            {
                modelBuilder.Entity(entityType.ClrType)
                    .Property<bool>("IsDeleted")
                    .IsRequired();
            }

            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

            base.OnModelCreating(modelBuilder);
        }
    }
}