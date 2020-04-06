using Announcer.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Announcer.Data.Contexts
{
    public static class AnnouncerDbContextSeed
    {
        private const string ADMIN_EMAIL = "admin@test.com";
        private const string ADMIN_ROLE = "Administrators";
        private const string ADMIN_USER = "admin";
        private const string DEFAULT_PASSWORD = "Pa$$w0rd";

        public static async Task SeedAsync(AnnouncerDbContext catalogContext, UserManager<ApplicationUser> userManager,
            RoleManager<ApplicationRole> roleManager, ILoggerFactory loggerFactory, int? retry = 0)
        {
            int retryForAvailability = retry.Value;
            try
            {
                // TODO: Only run this if using a real database
                // context.Database.Migrate();

                // Create admin user
                var adminUser = await CreateUserWithRoleAsync(userManager, roleManager, ADMIN_USER, DEFAULT_PASSWORD, ADMIN_EMAIL, ADMIN_ROLE, null);

                // Create groups
                if (!catalogContext.Groups.Any())
                {
                    foreach (var group in GetGroups())
                    {
                        group.CreatedAt = DateTime.Now;
                        group.CreatedBy = adminUser.Id;

                        catalogContext.Groups.Add(group);
                    }

                    await catalogContext.SaveChangesAsync();
                }

                // Create templates
                if (!catalogContext.Templates.Any())
                {
                    foreach (var template in GetTemplates())
                    {
                        template.CreatedAt = DateTime.Now;
                        template.CreatedBy = adminUser.Id;

                        catalogContext.Templates.Add(template);
                    }

                    await catalogContext.SaveChangesAsync();
                }

                // Create clients
                if (!catalogContext.Clients.Any())
                {
                    var clients = GetClients();

                    foreach (var client in clients)
                    {
                        client.CreatedAt = DateTime.Now;
                        client.CreatedBy = adminUser.Id;

                        catalogContext.Clients.Add(client);
                    }

                    await catalogContext.SaveChangesAsync();

                    foreach (var client in clients)
                    {
                        client.UserId = (await CreateUserWithRoleAsync(userManager, roleManager, client.Id, DEFAULT_PASSWORD, null, "Users", client.Id)).Id;
                    }

                    await catalogContext.SaveChangesAsync();
                }

                // Create group members
                if (!catalogContext.GroupMembers.Any())
                {
                    foreach (var groupMember in GetGroupMembers())
                    {
                        groupMember.CreatedAt = DateTime.Now;
                        groupMember.CreatedBy = adminUser.Id;

                        catalogContext.GroupMembers.Add(groupMember);
                    }

                    await catalogContext.SaveChangesAsync();
                }

                // Create notifications
                if (!catalogContext.Notifications.Any())
                {
                    foreach (var notification in GetNotifications())
                    {
                        notification.CreatedAt = notification.SentTime;
                        notification.CreatedBy = notification.SenderId;

                        catalogContext.Notifications.Add(notification);
                    }

                    await catalogContext.SaveChangesAsync();
                }
            }
            catch (Exception ex)
            {
                if (retryForAvailability < 10)
                {
                    retryForAvailability++;
                    var log = loggerFactory.CreateLogger(nameof(AnnouncerDbContextSeed));
                    log.LogError(ex.Message);
                    await SeedAsync(catalogContext, userManager, roleManager, loggerFactory, retryForAvailability);
                }
                throw;
            }
        }

        private static async Task<ApplicationUser> CreateUserWithRoleAsync(UserManager<ApplicationUser> userManager, RoleManager<ApplicationRole> roleManager,
            string userName, string password, string email, string role, string clientId)
        {
            // Check if role exists
            if (!await roleManager.RoleExistsAsync(role))
            {
                // Create role
                var createRoleResult = await roleManager.CreateAsync(new ApplicationRole(role));
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

        private static IEnumerable<Client> GetClients()
        {
            return new List<Client>()
            {
                new Client("18.145.60.28", "Reinhard Burgiss", null, null, "9b5b4f26-1daf-4ed2-a833-3460654432d1"),
                new Client("118.68.181.18", "Gayel Verrick", "Nulla ut erat id mauris vulputate elementum. Nullam varius. Nulla facilisi. Cras non velit nec nisi vulputate nonummy.", null, "9b5b4f26-1daf-4ed2-a833-3460654432d1"),
                new Client("252.149.255.172", "Carlyle Clawe", null, null, "9b5b4f26-1daf-4ed2-a833-3460654432d1"),
                new Client("101.172.125.222", "Homere Rawstorn", null, null, "9b5b4f26-1daf-4ed2-a833-3460654432d1"),
                new Client("182.173.77.191", "Klemens Miners", null, null, "9b5b4f26-1daf-4ed2-a833-3460654432d1"),
                new Client("125.91.241.186", "Emmy Vallantine", "In hac habitasse platea dictumst. Etiam faucibus cursus urna. Ut tellus. Nulla ut erat id mauris vulputate elementum. Nullam varius. Nulla facilisi. Cras non velit nec nisi vulputate nonummy.", null, "9b5b4f26-1daf-4ed2-a833-3460654432d1"),
                new Client("252.68.177.127", "Rolland Stango", null, null, "9b5b4f26-1daf-4ed2-a833-3460654432d1"),
                new Client("183.43.177.95", "Gavrielle Fenney", "In congue. Etiam justo. Etiam pretium iaculis justo. In hac habitasse platea dictumst. Etiam faucibus cursus urna. Ut tellus. Nulla ut erat id mauris vulputate elementum. Nullam varius. Nulla facilisi. Cras non velit nec nisi vulputate nonummy.", null, "9b5b4f26-1daf-4ed2-a833-3460654432d1"),
                new Client("197.21.10.207", "Mayne Kaemena", null, null, "9b5b4f26-1daf-4ed2-a833-3460654432d1"),
                new Client("99.169.206.225", "Judah Braniff", "Vestibulum ante ipsum primis in faucibus orci luctus et ultrices posuere cubilia Curae; Donec pharetra, magna vestibulum aliquet ultrices, erat tortor sollicitudin mi, sit amet lobortis sapien sapien non mi. Integer ac neque. Duis bibendum. Morbi non quam", null, "9b5b4f26-1daf-4ed2-a833-3460654432d1"),
                new Client("227.61.108.30", "Arline Jeffcoat", null, null, "9b5b4f26-1daf-4ed2-a833-3460654432d1"),
                new Client("184.161.241.44", "Ethe Hubbucks", null, null, "9b5b4f26-1daf-4ed2-a833-3460654432d1"),
                new Client("136.206.138.34", "Cherri Carnaman", "Morbi a ipsum. Integer a nibh. In quis justo. Maecenas rhoncus aliquam lacus. Morbi quis tortor id nulla ultrices aliquet. Maecenas leo odio, condimentum id, luctus nec, molestie sed, justo.", null, "9b5b4f26-1daf-4ed2-a833-3460654432d1"),
                new Client("215.182.79.194", "Florrie Temlett", "Donec quis orci eget orci vehicula condimentum. Curabitur in libero ut massa volutpat convallis. Morbi odio odio, elementum eu, interdum eu, tincidunt in, leo.", null, "9b5b4f26-1daf-4ed2-a833-3460654432d1"),
                new Client("32.136.41.245", "Alfred Cleef", "Sed accumsan felis. Ut at dolor quis odio consequat varius. Integer ac leo. Pellentesque ultrices mattis odio. Donec vitae nisi. Nam ultrices, libero non mattis pulvinar, nulla pede ullamcorper augue, a suscipit nulla elit ac nulla. Sed vel enim sit amet ", null, "9b5b4f26-1daf-4ed2-a833-3460654432d1"),
                new Client("73.99.143.230", "Vivianna Harverson", "In congue. Etiam justo. Etiam pretium iaculis justo. In hac habitasse platea dictumst.", null, "9b5b4f26-1daf-4ed2-a833-3460654432d1"),
                new Client("94.153.4.188", "Virgil Vanderplas", null, null, "9b5b4f26-1daf-4ed2-a833-3460654432d1"),
                new Client("34.176.238.79", "Marisa Pinchen", "In tempor, turpis nec euismod scelerisque, quam turpis adipiscing lorem, vitae mattis nibh ligula nec sem. Duis aliquam convallis nunc. Proin at turpis a pede posuere nonummy. Integer non velit. Donec diam neque, vestibulum eget, vulputate ut, ultrices ve", null, "9b5b4f26-1daf-4ed2-a833-3460654432d1"),
                new Client("93.86.33.122", "Linnell Mapledoore", null, null, "9b5b4f26-1daf-4ed2-a833-3460654432d1"),
                new Client("56.185.140.27", "Haleigh Kynge", "Sed ante. Vivamus tortor. Duis mattis egestas metus. Aenean fermentum. Donec ut mauris eget massa tempor convallis. Nulla neque libero, convallis eget, eleifend luctus, ultricies eu, nibh.", null, "9b5b4f26-1daf-4ed2-a833-3460654432d1"),
                new Client("184.224.148.70", "Philly Whorall", "Maecenas pulvinar lobortis est. Phasellus sit amet erat. Nulla tempus. Vivamus in felis eu sapien cursus vestibulum. Proin eu mi. Nulla ac enim.", null, "9b5b4f26-1daf-4ed2-a833-3460654432d1"),
                new Client("83.179.153.38", "Aaren Garbert", null, null, "9b5b4f26-1daf-4ed2-a833-3460654432d1"),
                new Client("173.83.228.226", "Irvin Verman", null, null, "9b5b4f26-1daf-4ed2-a833-3460654432d1"),
                new Client("133.37.65.43", "Hugo Geal", null, null, "9b5b4f26-1daf-4ed2-a833-3460654432d1"),
                new Client("177.6.108.10", "Benn Woolway", "Morbi porttitor lorem id ligula. Suspendisse ornare consequat lectus. In est risus, auctor sed, tristique in, tempus sit amet, sem. Fusce consequat. Nulla nisl. Nunc nisl. Duis bibendum, felis sed interdum venenatis, turpis enim blandit mi, in porttitor p", null, "9b5b4f26-1daf-4ed2-a833-3460654432d1"),
                new Client("197.76.200.105", "Carmina Mannakee", null, null, "9b5b4f26-1daf-4ed2-a833-3460654432d1"),
                new Client("10.8.64.147", "Meade Macvain", null, null, "9b5b4f26-1daf-4ed2-a833-3460654432d1"),
                new Client("240.223.102.2", "Meghan Danter", "Duis bibendum, felis sed interdum venenatis, turpis enim blandit mi, in porttitor pede justo eu massa. Donec dapibus. Duis at velit eu est congue elementum. In hac habitasse platea dictumst. Morbi vestibulum, velit id pretium iaculis, diam erat fermentum ", null, "9b5b4f26-1daf-4ed2-a833-3460654432d1"),
                new Client("168.167.250.98", "Byrle Rowbrey", null, null, "9b5b4f26-1daf-4ed2-a833-3460654432d1"),
                new Client("218.123.63.7", "Gui Barthot", "In quis justo. Maecenas rhoncus aliquam lacus. Morbi quis tortor id nulla ultrices aliquet. Maecenas leo odio, condimentum id, luctus nec, molestie sed, justo. Pellentesque viverra pede ac diam.", null, "9b5b4f26-1daf-4ed2-a833-3460654432d1"),
                new Client("123.28.40.92", "Richmond MacKegg", null, null, "9b5b4f26-1daf-4ed2-a833-3460654432d1"),
                new Client("216.217.115.239", "Renault Brunsen", "Fusce congue, diam id ornare imperdiet, sapien urna pretium nisl, ut volutpat sapien arcu sed augue. Aliquam erat volutpat. In congue. Etiam justo. Etiam pretium iaculis justo. In hac habitasse platea dictumst.", null, "9b5b4f26-1daf-4ed2-a833-3460654432d1"),
                new Client("166.51.142.176", "Rawley Grishankov", "Quisque porta volutpat erat. Quisque erat eros, viverra eget, congue eget, semper rutrum, nulla. Nunc purus. Phasellus in felis. Donec semper sapien a libero. Nam dui. Proin leo odio, porttitor id, consequat in, consequat ut, nulla. Sed accumsan felis. Ut", null, "9b5b4f26-1daf-4ed2-a833-3460654432d1"),
                new Client("235.161.232.109", "Hildagarde Cherrison", null, null, "9b5b4f26-1daf-4ed2-a833-3460654432d1"),
                new Client("170.76.255.2", "Beltran Cackett", null, null, "9b5b4f26-1daf-4ed2-a833-3460654432d1"),
                new Client("78.27.165.38", "Anna-maria Gosling", "Fusce consequat.", null, "9b5b4f26-1daf-4ed2-a833-3460654432d1"),
                new Client("175.143.74.113", "Blake Searl", null, null, "9b5b4f26-1daf-4ed2-a833-3460654432d1"),
                new Client("90.141.55.244", "Finlay Montague", "Sed accumsan felis. Ut at dolor quis odio consequat varius.", null, "9b5b4f26-1daf-4ed2-a833-3460654432d1"),
                new Client("80.116.149.72", "Hatti McConachie", "Aliquam quis turpis eget elit sodales scelerisque.", null, "9b5b4f26-1daf-4ed2-a833-3460654432d1"),
                new Client("234.203.187.169", "Suzette Sealove", null, null, "9b5b4f26-1daf-4ed2-a833-3460654432d1"),
                new Client("238.0.67.143", "Ephraim Crohan", null, null, "9b5b4f26-1daf-4ed2-a833-3460654432d1"),
                new Client("244.107.164.48", "Hilly Levet", "Quisque arcu libero, rutrum ac, lobortis vel, dapibus at, diam. Nam tristique tortor eu pede.", null, "9b5b4f26-1daf-4ed2-a833-3460654432d1"),
                new Client("175.247.189.212", "Arlana Brownsmith", null, null, "9b5b4f26-1daf-4ed2-a833-3460654432d1"),
                new Client("169.4.15.55", "Brod Cawcutt", "Suspendisse accumsan tortor quis turpis. Sed ante. Vivamus tortor.", null, "9b5b4f26-1daf-4ed2-a833-3460654432d1"),
                new Client("25.231.65.211", "Nixie Guiraud", "Proin risus. Praesent lectus. Vestibulum quam sapien, varius ut, blandit non, interdum in, ante. Vestibulum ante ipsum primis in faucibus orci luctus et ultrices posuere cubilia Curae; Duis faucibus accumsan odio. Curabitur convallis. Duis consequat dui n", null, "9b5b4f26-1daf-4ed2-a833-3460654432d1"),
                new Client("115.100.97.104", "Ginni Pestor", "Integer pede justo, lacinia eget, tincidunt eget, tempus vel, pede. Morbi porttitor lorem id ligula. Suspendisse ornare consequat lectus. In est risus, auctor sed, tristique in, tempus sit amet, sem. Fusce consequat. Nulla nisl. Nunc nisl. Duis bibendum, ", null, "9b5b4f26-1daf-4ed2-a833-3460654432d1"),
                new Client("28.179.53.91", "Roxane Shatliff", null, null, "9b5b4f26-1daf-4ed2-a833-3460654432d1"),
                new Client("94.85.31.216", "Ciro Gowen", "Vestibulum ante ipsum primis in faucibus orci luctus et ultrices posuere cubilia Curae; Donec pharetra, magna vestibulum aliquet ultrices, erat tortor sollicitudin mi, sit amet lobortis sapien sapien non mi.", null, "9b5b4f26-1daf-4ed2-a833-3460654432d1"),
                new Client("21.128.128.93", "Manny McAteer", "Aenean auctor gravida sem.", null, "9b5b4f26-1daf-4ed2-a833-3460654432d1"),
                new Client("8.75.99.73", "Dacey Hurdle", null, null, "9b5b4f26-1daf-4ed2-a833-3460654432d1")
            };
        }

        private static IEnumerable<GroupMember> GetGroupMembers()
        {
            return new List<GroupMember>()
            {
                new GroupMember("a9d2b348-a054-49bd-b8cb-fcb496304e4d", "184.161.241.44"),
                new GroupMember("0eee704c-0321-41cf-b7ad-55a22892be2c", "93.86.33.122"),
                new GroupMember("1ef7f6f0-7222-4481-9b8e-bc8de17469f0", "93.86.33.122"),
                new GroupMember("1ef7f6f0-7222-4481-9b8e-bc8de17469f0", "94.85.31.216"),
                new GroupMember("ac9f1449-1922-42a1-8a6a-e7181cf2d218", "136.206.138.34"),
                new GroupMember("1ef7f6f0-7222-4481-9b8e-bc8de17469f0", "168.167.250.98"),
                new GroupMember("a5da5a6f-4627-4d0a-92fa-72b2b6f266d8", "136.206.138.34"),
                new GroupMember("d4530752-c8d4-4a21-a409-c900548f4434", "101.172.125.222"),
                new GroupMember("a5da5a6f-4627-4d0a-92fa-72b2b6f266d8", "170.76.255.2"),
                new GroupMember("ac9f1449-1922-42a1-8a6a-e7181cf2d218", "252.149.255.172"),
                new GroupMember("ac9f1449-1922-42a1-8a6a-e7181cf2d218", "216.217.115.239"),
                new GroupMember("ac9f1449-1922-42a1-8a6a-e7181cf2d218", "197.76.200.105"),
                new GroupMember("d4530752-c8d4-4a21-a409-c900548f4434", "83.179.153.38"),
                new GroupMember("ac9f1449-1922-42a1-8a6a-e7181cf2d218", "115.100.97.104"),
                new GroupMember("f854220c-1b78-4f2a-8ce5-eed7c06f30f4", "169.4.15.55"),
                new GroupMember("1ef7f6f0-7222-4481-9b8e-bc8de17469f0", "125.91.241.186"),
                new GroupMember("ac9f1449-1922-42a1-8a6a-e7181cf2d218", "240.223.102.2"),
                new GroupMember("d4530752-c8d4-4a21-a409-c900548f4434", "32.136.41.245"),
                new GroupMember("f854220c-1b78-4f2a-8ce5-eed7c06f30f4", "216.217.115.239"),
                new GroupMember("a9d2b348-a054-49bd-b8cb-fcb496304e4d", "73.99.143.230"),
                new GroupMember("0eee704c-0321-41cf-b7ad-55a22892be2c", "101.172.125.222"),
                new GroupMember("dc74c4e5-8bab-4062-8725-4ed642763cfd", "252.149.255.172"),
                new GroupMember("d4530752-c8d4-4a21-a409-c900548f4434", "28.179.53.91"),
                new GroupMember("a9d2b348-a054-49bd-b8cb-fcb496304e4d", "175.247.189.212"),
                new GroupMember("ac9f1449-1922-42a1-8a6a-e7181cf2d218", "133.37.65.43"),
                new GroupMember("a5da5a6f-4627-4d0a-92fa-72b2b6f266d8", "227.61.108.30"),
                new GroupMember("dc74c4e5-8bab-4062-8725-4ed642763cfd", "173.83.228.226"),
                new GroupMember("0eee704c-0321-41cf-b7ad-55a22892be2c", "184.161.241.44"),
                new GroupMember("ac9f1449-1922-42a1-8a6a-e7181cf2d218", "99.169.206.225"),
                new GroupMember("a9d2b348-a054-49bd-b8cb-fcb496304e4d", "115.100.97.104"),
                new GroupMember("ac9f1449-1922-42a1-8a6a-e7181cf2d218", "244.107.164.48"),
                new GroupMember("0eee704c-0321-41cf-b7ad-55a22892be2c", "32.136.41.245"),
                new GroupMember("a5da5a6f-4627-4d0a-92fa-72b2b6f266d8", "252.149.255.172"),
                new GroupMember("0eee704c-0321-41cf-b7ad-55a22892be2c", "169.4.15.55"),
                new GroupMember("0eee704c-0321-41cf-b7ad-55a22892be2c", "125.91.241.186"),
                new GroupMember("d4530752-c8d4-4a21-a409-c900548f4434", "235.161.232.109"),
                new GroupMember("a9d2b348-a054-49bd-b8cb-fcb496304e4d", "136.206.138.34"),
                new GroupMember("0eee704c-0321-41cf-b7ad-55a22892be2c", "244.107.164.48"),
                new GroupMember("f854220c-1b78-4f2a-8ce5-eed7c06f30f4", "136.206.138.34"),
                new GroupMember("0eee704c-0321-41cf-b7ad-55a22892be2c", "170.76.255.2"),
                new GroupMember("a5da5a6f-4627-4d0a-92fa-72b2b6f266d8", "25.231.65.211"),
                new GroupMember("d4530752-c8d4-4a21-a409-c900548f4434", "25.231.65.211"),
                new GroupMember("ac9f1449-1922-42a1-8a6a-e7181cf2d218", "94.153.4.188"),
                new GroupMember("a9d2b348-a054-49bd-b8cb-fcb496304e4d", "83.179.153.38"),
                new GroupMember("f854220c-1b78-4f2a-8ce5-eed7c06f30f4", "175.143.74.113"),
                new GroupMember("a9d2b348-a054-49bd-b8cb-fcb496304e4d", "166.51.142.176"),
                new GroupMember("a9d2b348-a054-49bd-b8cb-fcb496304e4d", "175.143.74.113"),
                new GroupMember("0eee704c-0321-41cf-b7ad-55a22892be2c", "235.161.232.109"),
                new GroupMember("1ef7f6f0-7222-4481-9b8e-bc8de17469f0", "94.153.4.188"),
                new GroupMember("a5da5a6f-4627-4d0a-92fa-72b2b6f266d8", "125.91.241.186"),
                new GroupMember("a9d2b348-a054-49bd-b8cb-fcb496304e4d", "183.43.177.95"),
                new GroupMember("a5da5a6f-4627-4d0a-92fa-72b2b6f266d8", "32.136.41.245"),
                new GroupMember("0eee704c-0321-41cf-b7ad-55a22892be2c", "215.182.79.194"),
                new GroupMember("a5da5a6f-4627-4d0a-92fa-72b2b6f266d8", "182.173.77.191"),
            };
        }

        private static IEnumerable<Group> GetGroups()
        {
            return new List<Group>()
            {
                new Group("d4530752-c8d4-4a21-a409-c900548f4434", "Accounting", "Mauris lacinia sapien quis libero. Nullam sit amet turpis elementum ligula vehicula consequat. Morbi a ipsum."),
                new Group("63341b5b-eec0-436c-9559-d65538d4bae7", "Business Development", null),
                new Group("0eee704c-0321-41cf-b7ad-55a22892be2c", "Engineering", null),
                new Group("1ef7f6f0-7222-4481-9b8e-bc8de17469f0", "Human Resources", null),
                new Group("dc74c4e5-8bab-4062-8725-4ed642763cfd", "Legal", null),
                new Group("f854220c-1b78-4f2a-8ce5-eed7c06f30f4", "Marketing", null),
                new Group("ac9f1449-1922-42a1-8a6a-e7181cf2d218", "Research and Development", null),
                new Group("a5da5a6f-4627-4d0a-92fa-72b2b6f266d8", "Sales", null),
                new Group("a9d2b348-a054-49bd-b8cb-fcb496304e4d", "Services", null),
                new Group("f11b6017-7010-4a9e-924c-5f2d1a7b00ec", "Support", "Vivamus metus arcu, adipiscing molestie, hendrerit at, vulputate vitae, nisl. Aenean lectus. Pellentesque eget nunc.")
            };
        }

        private static IEnumerable<Notification> GetNotifications()
        {
            return new List<Notification>()
            {
                new Notification("b25acb82-e343-4fe3-9bde-b063dfb080ad", "Etiam faucibus cursus urna. Ut tellus. Nulla ut erat id mauris vulputate elementum.", "235.161.232.109", DateTime.Parse("2019-06-27 02:17:49"), null, "216.217.115.239"),
                new Notification("4c486687-3d56-424a-b882-e069f9939a98", "In hac habitasse platea dictumst. Aliquam augue quam, sollicitudin vitae, consectetuer eget, rutrum at, lorem. Integer tincidunt ante vel ipsum.", "80.116.149.72", DateTime.Parse("2020-01-07 16:56:40"), null, "25.231.65.211"),
                new Notification("bcb82750-a93a-42c3-8881-b7dca16c1480", "Donec ut mauris eget massa tempor convallis.", "175.143.74.113", DateTime.Parse("2019-07-12 20:26:48"), "1ef7f6f0-7222-4481-9b8e-bc8de17469f0", null),
                new Notification("9f90e2ac-af40-4216-acff-ff9aea9b06ef", "Donec ut mauris eget massa tempor convallis. Nulla neque libero, convallis eget, eleifend luctus, ultricies eu, nibh.", "90.141.55.244", DateTime.Parse("2020-02-16 02:15:48"), "d4530752-c8d4-4a21-a409-c900548f4434", null),
                new Notification("b6aae543-7066-40be-b207-ed15bd838642", "In blandit ultrices enim. Lorem ipsum dolor sit amet, consectetuer adipiscing elit. Proin interdum mauris non ligula pellentesque ultrices.", "125.91.241.186", DateTime.Parse("2019-09-01 01:37:12"), "dc74c4e5-8bab-4062-8725-4ed642763cfd", null),
                new Notification("2387008a-f722-435a-b135-2b96288bac3e", "Vivamus vestibulum sagittis sapien. Cum sociis natoque penatibus et magnis dis parturient montes, nascetur ridiculus mus. Etiam vel augue.", "28.179.53.91", DateTime.Parse("2019-11-27 15:13:19"), null, "244.107.164.48"),
                new Notification("e07b3935-1185-456e-ba44-b2069bec3755", "In hac habitasse platea dictumst.", "175.247.189.212", DateTime.Parse("2019-05-16 13:09:58"), "63341b5b-eec0-436c-9559-d65538d4bae7", null),
                new Notification("fe4a8a8d-6fe3-4c5e-a4b3-5c9e3e910ebc", "Quisque erat eros, viverra eget, congue eget, semper rutrum, nulla. Nunc purus. Phasellus in felis.", "125.91.241.186", DateTime.Parse("2019-04-10 02:23:19"), null, "123.28.40.92"),
                new Notification("65be6c51-e902-439b-be4e-437cbfa78612", "Suspendisse potenti.", "10.8.64.147", DateTime.Parse("2019-05-16 15:52:45"), null, "175.143.74.113"),
                new Notification("9ca8a673-d51b-4c2a-ab1e-b85a25608cd6", "In hac habitasse platea dictumst.", "173.83.228.226", DateTime.Parse("2019-11-29 14:37:05"), "0eee704c-0321-41cf-b7ad-55a22892be2c", null),
                new Notification("2dee9591-705e-40bd-870f-f452968af990", "Aenean fermentum. Donec ut mauris eget massa tempor convallis. Nulla neque libero, convallis eget, eleifend luctus, ultricies eu, nibh.", "125.91.241.186", DateTime.Parse("2019-06-02 09:48:02"), null, "80.116.149.72"),
                new Notification("fd515347-aedc-4e45-8596-b5341afa4b7a", "Integer tincidunt ante vel ipsum. Praesent blandit lacinia erat. Vestibulum sed magna at nunc commodo placerat.", "177.6.108.10", DateTime.Parse("2019-11-21 13:50:39"), null, "168.167.250.98"),
                new Notification("5f673c66-50d5-4ead-8517-792dade5e4da", "Integer ac leo.", "21.128.128.93", DateTime.Parse("2020-03-04 18:08:48"), null, "216.217.115.239"),
                new Notification("67befb05-89f8-4cd8-b9f5-2cd4360fcf67", "Vestibulum ante ipsum primis in faucibus orci luctus et ultrices posuere cubilia Curae; Nulla dapibus dolor vel est.", "123.28.40.92", DateTime.Parse("2020-02-21 13:48:15"), null, "34.176.238.79"),
                new Notification("77401c08-7890-42d4-8243-b3a1efe8ff1a", "Morbi non quam nec dui luctus rutrum. Nulla tellus.", "94.153.4.188", DateTime.Parse("2020-03-03 21:08:20"), "a9d2b348-a054-49bd-b8cb-fcb496304e4d", null),
                new Notification("363e64ef-1fda-45b3-b277-8fbf90733a97", "Proin risus. Praesent lectus. Vestibulum quam sapien, varius ut, blandit non, interdum in, ante.", "216.217.115.239", DateTime.Parse("2020-02-28 18:20:53"), "ac9f1449-1922-42a1-8a6a-e7181cf2d218", null),
                new Notification("e2c2d985-ea75-40b1-910f-c4aa4eb2e295", "Nam congue, risus semper porta volutpat, quam pede lobortis ligula, sit amet eleifend pede libero quis orci. Nullam molestie nibh in lectus. Pellentesque at nulla.", "94.85.31.216", DateTime.Parse("2019-09-02 23:48:25"), null, "83.179.153.38"),
                new Notification("194ca337-8931-4e12-bd1e-019a39372191", "Integer ac leo. Pellentesque ultrices mattis odio. Donec vitae nisi.", "28.179.53.91", DateTime.Parse("2019-09-30 22:39:29"), null, "252.149.255.172"),
                new Notification("9a24580a-0af3-43a6-b225-1d30264ef01e", "Nullam varius.", "234.203.187.169", DateTime.Parse("2019-08-13 15:48:51"), "d4530752-c8d4-4a21-a409-c900548f4434", null),
                new Notification("9348a3ce-59da-424a-830a-0086884da8ee", "Curabitur convallis. Duis consequat dui nec nisi volutpat eleifend.", "10.8.64.147", DateTime.Parse("2019-07-01 08:31:38"), "a5da5a6f-4627-4d0a-92fa-72b2b6f266d8", null),
                new Notification("4726e842-915c-4bb3-afeb-17a8e2910fc1", "Nam dui. Proin leo odio, porttitor id, consequat in, consequat ut, nulla. Sed accumsan felis.", "252.149.255.172", DateTime.Parse("2019-11-13 01:03:43"), null, "234.203.187.169"),
                new Notification("06e0e2a8-7bcc-443d-98d3-db3842a4022e", "Donec ut dolor. Morbi vel lectus in quam fringilla rhoncus.", "18.145.60.28", DateTime.Parse("2019-10-04 11:28:35"), "d4530752-c8d4-4a21-a409-c900548f4434", null),
                new Notification("4b789562-ef63-4e3d-9254-77df5b0b8506", "Pellentesque ultrices mattis odio.", "80.116.149.72", DateTime.Parse("2019-12-27 07:03:36"), "dc74c4e5-8bab-4062-8725-4ed642763cfd", null),
                new Notification("be0cdbb3-c295-48cf-9b55-0a04137a08a9", "In est risus, auctor sed, tristique in, tempus sit amet, sem. Fusce consequat. Nulla nisl.", "28.179.53.91", DateTime.Parse("2020-02-07 08:41:48"), "1ef7f6f0-7222-4481-9b8e-bc8de17469f0", null),
                new Notification("2ee0d5aa-5f29-43cc-a295-384c9311b6e1", "Aliquam sit amet diam in magna bibendum imperdiet.", "10.8.64.147", DateTime.Parse("2019-12-13 18:40:26"), "1ef7f6f0-7222-4481-9b8e-bc8de17469f0", null),
                new Notification("c6938693-754c-4e08-a060-a7d52cb561a7", "Nulla ut erat id mauris vulputate elementum. Nullam varius. Nulla facilisi.", "238.0.67.143", DateTime.Parse("2019-07-11 22:52:34"), "a5da5a6f-4627-4d0a-92fa-72b2b6f266d8", null),
                new Notification("4a6628cc-e8c4-4eac-ad83-b7cca8dd67bc", "Morbi porttitor lorem id ligula.", "133.37.65.43", DateTime.Parse("2019-12-26 22:10:40"), "1ef7f6f0-7222-4481-9b8e-bc8de17469f0", null),
                new Notification("f1722535-5e45-4e6c-8fc7-bfcfc9c0f36d", "Vivamus vel nulla eget eros elementum pellentesque.", "175.247.189.212", DateTime.Parse("2019-11-30 17:17:01"), "0eee704c-0321-41cf-b7ad-55a22892be2c", null),
                new Notification("d6185e29-cd61-40db-979e-2073d38cd2b7", "Fusce consequat. Nulla nisl.", "197.76.200.105", DateTime.Parse("2019-10-27 14:59:41"), null, "177.6.108.10"),
                new Notification("b63d79d5-1d40-432b-9fc9-75f8cbea4806", "Etiam pretium iaculis justo. In hac habitasse platea dictumst. Etiam faucibus cursus urna.", "252.149.255.172", DateTime.Parse("2019-06-10 02:03:59"), "a5da5a6f-4627-4d0a-92fa-72b2b6f266d8", null),
                new Notification("4eefc272-9f41-497b-83c3-03d395c29204", "Lorem ipsum dolor sit amet, consectetuer adipiscing elit. Proin interdum mauris non ligula pellentesque ultrices.", "34.176.238.79", DateTime.Parse("2019-07-19 08:59:03"), null, "136.206.138.34"),
                new Notification("351e76f5-b987-4fb0-b1da-a8640ee5fd6b", "In est risus, auctor sed, tristique in, tempus sit amet, sem. Fusce consequat. Nulla nisl.", "227.61.108.30", DateTime.Parse("2019-12-05 20:08:06"), null, "197.21.10.207"),
                new Notification("666f39d7-df99-4bf8-8078-51d44eb163b5", "In congue.", "240.223.102.2", DateTime.Parse("2019-04-21 18:17:32"), null, "182.173.77.191"),
                new Notification("cfd8511f-1821-4304-919a-fdc605631ae4", "Sed ante. Vivamus tortor. Duis mattis egestas metus.", "21.128.128.93", DateTime.Parse("2019-03-25 23:12:44"), "1ef7f6f0-7222-4481-9b8e-bc8de17469f0", null),
                new Notification("43c56817-93f5-4fab-b342-c5146b4426de", "In hac habitasse platea dictumst. Aliquam augue quam, sollicitudin vitae, consectetuer eget, rutrum at, lorem. Integer tincidunt ante vel ipsum.", "197.21.10.207", DateTime.Parse("2019-09-13 20:43:39"), null, "90.141.55.244"),
                new Notification("98d98d5c-af5e-4e32-967b-63530fdf0a0b", "Praesent blandit.", "238.0.67.143", DateTime.Parse("2019-10-04 21:59:51"), null, "73.99.143.230"),
                new Notification("c7bcbf3c-1e7c-4796-80bc-b3251945303f", "Nullam porttitor lacus at turpis.", "216.217.115.239", DateTime.Parse("2019-10-06 04:26:43"), null, "118.68.181.18"),
                new Notification("e55eb29f-0e04-4eb1-ac0a-b8b5313f775e", "Vivamus in felis eu sapien cursus vestibulum. Proin eu mi.", "99.169.206.225", DateTime.Parse("2019-03-22 00:39:09"), "63341b5b-eec0-436c-9559-d65538d4bae7", null),
                new Notification("5a767e37-5313-4b12-989d-cd349693b514", "Sed sagittis. Nam congue, risus semper porta volutpat, quam pede lobortis ligula, sit amet eleifend pede libero quis orci.", "25.231.65.211", DateTime.Parse("2019-11-02 11:18:54"), "d4530752-c8d4-4a21-a409-c900548f4434", null),
                new Notification("fe0e90e5-8b1f-4938-8cf5-60c5957c9e8b", "Proin leo odio, porttitor id, consequat in, consequat ut, nulla. Sed accumsan felis.", "32.136.41.245", DateTime.Parse("2019-04-14 23:40:12"), "63341b5b-eec0-436c-9559-d65538d4bae7", null),
                new Notification("5c4a2e0b-7c21-44cd-81e0-7f18731baa62", "Quisque arcu libero, rutrum ac, lobortis vel, dapibus at, diam. Nam tristique tortor eu pede.", "56.185.140.27", DateTime.Parse("2020-01-30 07:01:30"), "ac9f1449-1922-42a1-8a6a-e7181cf2d218", null),
                new Notification("e0edce8f-dba9-4aaf-8086-22c8175fc4e5", "Integer ac leo. Pellentesque ultrices mattis odio.", "216.217.115.239", DateTime.Parse("2019-08-01 02:22:23"), null, "56.185.140.27"),
                new Notification("e2925f5a-5e2f-4b10-b4a3-357415e5822c", "Aliquam augue quam, sollicitudin vitae, consectetuer eget, rutrum at, lorem. Integer tincidunt ante vel ipsum. Praesent blandit lacinia erat.", "73.99.143.230", DateTime.Parse("2019-11-05 04:01:55"), "a9d2b348-a054-49bd-b8cb-fcb496304e4d", null),
                new Notification("8a5c8176-1b79-4696-9c0d-d199a4301634", "Nam ultrices, libero non mattis pulvinar, nulla pede ullamcorper augue, a suscipit nulla elit ac nulla. Sed vel enim sit amet nunc viverra dapibus. Nulla suscipit ligula in lacus.", "80.116.149.72", DateTime.Parse("2019-04-10 06:41:53"), "a9d2b348-a054-49bd-b8cb-fcb496304e4d", null),
                new Notification("1fb080b1-114b-43d9-b048-1cf8ab5fbc14", "Duis aliquam convallis nunc. Proin at turpis a pede posuere nonummy.", "32.136.41.245", DateTime.Parse("2019-04-06 19:08:25"), null, "238.0.67.143"),
                new Notification("e069f91b-1622-44ce-abba-6f5a67ce12c1", "In sagittis dui vel nisl. Duis ac nibh.", "94.153.4.188", DateTime.Parse("2020-02-18 15:56:37"), "a9d2b348-a054-49bd-b8cb-fcb496304e4d", null),
                new Notification("ccae3d69-333e-4a78-adc3-da0bab4f0f0a", "Nullam porttitor lacus at turpis. Donec posuere metus vitae ipsum. Aliquam non mauris.", "216.217.115.239", DateTime.Parse("2019-10-04 09:15:32"), null, "168.167.250.98"),
                new Notification("b72c80c9-7cae-44fd-821b-a86a89c15c68", "Suspendisse potenti. Nullam porttitor lacus at turpis.", "173.83.228.226", DateTime.Parse("2019-04-14 12:01:28"), null, "234.203.187.169"),
                new Notification("a51f8d00-c8e3-438c-b2d8-53803a573234", "Maecenas tincidunt lacus at velit. Vivamus vel nulla eget eros elementum pellentesque.", "238.0.67.143", DateTime.Parse("2019-12-26 07:12:56"), "d4530752-c8d4-4a21-a409-c900548f4434", null),
                new Notification("0bedab27-c5df-44b3-92bb-0f7ceb3bb6f3", "Maecenas tincidunt lacus at velit. Vivamus vel nulla eget eros elementum pellentesque.", "123.28.40.92", DateTime.Parse("2019-09-27 14:38:20"), null, "234.203.187.169"),
            };
        }

        private static IEnumerable<Template> GetTemplates()
        {
            return new List<Template>()
            {
                new Template("9b5b4f26-1daf-4ed2-a833-3460654432d1", "Default Template", null)
            };
        }
    }
}