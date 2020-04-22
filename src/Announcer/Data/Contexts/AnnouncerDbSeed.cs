using Announcer.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Encodings.Web;
using System.Text.Json;
using System.Text.Unicode;
using System.Threading.Tasks;

namespace Announcer.Data.Contexts
{
    public static class AnnouncerDbSeed
    {
        private const string ADMIN_USER = "admin";
        private const string ADMIN_EMAIL = "admin@announcer.com";
        private const string ADMIN_ROLE = "Administrators";
        private const string USERS_ROLE = "Users";
        private const string DEFAULT_PASSWORD = "Pa$$w0rd";

        public static async Task SeedAsync(AnnouncerDbContext context, UserManager<ApplicationUser> userManager,
            RoleManager<IdentityRole> roleManager, ILoggerFactory loggerFactory)
        {
            var logger = loggerFactory.CreateLogger("AnnouncerDbSeed");
            string seedDataDir = "./Data/Contexts/SeedData";

            try
            {
                var adminUser = await userManager.FindByNameAsync(ADMIN_USER);
                if (adminUser == null)
                {
                    // Create admin user
                    adminUser = await CreateUserWithRoleAsync(userManager, roleManager, ADMIN_USER, DEFAULT_PASSWORD, ADMIN_EMAIL, ADMIN_ROLE, null);
                }

                if (!context.Templates.Any())
                {
                    var templatesData = File.ReadAllText($"{seedDataDir}/templates.json");

                    var templates = JsonSerializer.Deserialize<List<Template>>(templatesData);

                    foreach (var template in templates)
                    {
                        template.CreatedBy = adminUser.Id;
                        context.Templates.Add(template);
                    }

                    await context.SaveChangesAsync();

                    logger.LogInformation($"{templates.Count} templates imported");
                }

                if (!context.Groups.Any())
                {
                    var groupsData = File.ReadAllText($"{seedDataDir}/groups.json");

                    var groups = JsonSerializer.Deserialize<List<Group>>(groupsData);

                    foreach (var group in groups)
                    {
                        group.CreatedBy = adminUser.Id;
                        context.Groups.Add(group);
                    }

                    await context.SaveChangesAsync();

                    logger.LogInformation($"{groups.Count} groups imported");
                }

                if (!context.Clients.Any())
                {
                    var clientsData = File.ReadAllText($"{seedDataDir}/clients.json");

                    var clients = JsonSerializer.Deserialize<List<Client>>(clientsData);

                    foreach (var client in clients)
                    {
                        client.CreatedBy = adminUser.Id;
                        context.Clients.Add(client);
                    }

                    await context.SaveChangesAsync();

                    foreach (var client in clients)
                    {
                        client.UserId = (await CreateUserWithRoleAsync(userManager, roleManager, client.Id, DEFAULT_PASSWORD, null, USERS_ROLE, client.Id)).Id;
                    }

                    await context.SaveChangesAsync();

                    logger.LogInformation($"{clients.Count} clients imported");
                }

                if (!context.GroupMembers.Any())
                {
                    var groupMembersData = File.ReadAllText($"{seedDataDir}/groupMembers.json");

                    var groupMembers = JsonSerializer.Deserialize<List<GroupMember>>(groupMembersData);

                    foreach (var groupMember in groupMembers)
                    {
                        groupMember.CreatedBy = adminUser.Id;
                        context.GroupMembers.Add(groupMember);
                    }

                    await context.SaveChangesAsync();

                    logger.LogInformation($"{groupMembers.Count} group members imported");
                }

                if (!context.Notifications.Any())
                {
                    var notificationsData = File.ReadAllText($"{seedDataDir}/notifications.json");

                    var notifications = JsonSerializer.Deserialize<List<Notification>>(notificationsData);

                    foreach (var notification in notifications)
                    {
                        notification.CreatedBy = adminUser.Id;
                        context.Notifications.Add(notification);
                    }

                    await context.SaveChangesAsync();

                    logger.LogInformation($"{notifications.Count} notifications imported");
                }
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "Error occured during seeding database");
            }
        }

        private static async Task<ApplicationUser> CreateUserWithRoleAsync(UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager,
            string userName, string password, string email, string role, string clientId)
        {
            // Check if role exists
            if (!await roleManager.RoleExistsAsync(role))
            {
                // Create role
                var createRoleResult = await roleManager.CreateAsync(new IdentityRole(role));
                if (!createRoleResult.Succeeded)
                    throw new ApplicationException($"{role} role can not be created.");
            }

            // Check if user exists
            var user = await userManager.FindByNameAsync(userName);
            if (null == user)
            {
                // Create user
                user = new ApplicationUser { UserName = userName, Email = email, ClientId = clientId, ProfileImage = "~\\img\\profile.svg" };
                var createUserResult = await userManager.CreateAsync(user, password);
                if (!createUserResult.Succeeded)
                    throw new ApplicationException($"{userName} user can not be created.");
            }

            // Check if user is assigned to role
            if (!await userManager.IsInRoleAsync(user, role))
            {
                // Assign user to role
                var addToRoleResult = await userManager.AddToRoleAsync(user, role);
                if (!addToRoleResult.Succeeded)
                    throw new ApplicationException($"{user.UserName} user can be assigned to {role} role.");
            }

            return user;
        }
    }
}