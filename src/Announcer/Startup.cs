using Announcer.Contracts;
using Announcer.Data.Contexts;
using Announcer.Data.Repositories;
using Announcer.Data.UnitOfWork;
using Announcer.Helpers.Extensions;
using Announcer.Hubs;
using Announcer.Services;
using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpOverrides;
using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Announcer
{
    public class Startup
    {
        private readonly IConfiguration _config;

        /// <summary>
        /// Initializes a new instance of the <see cref="Startup"/> class.
        /// </summary>
        /// <param name="config">The current configuration.</param>
        public Startup(IConfiguration config)
        {
            _config = config;
        }

        // This method gets called by the runtime in development environment.
        public void ConfigureDevelopmentServices(IServiceCollection services)
        {
            services.AddDbContext<AnnouncerDbContext>(options =>
                options.UseInMemoryDatabase("AnnouncerDb"));

            ConfigureServices(services);
        }

        // This method gets called by the runtime in production environment.
        public void ConfigureProductionServices(IServiceCollection services)
        {
            services.AddDbContext<AnnouncerDbContext>(options =>
                options.UseSqlite(_config.GetConnectionString("DefaultConnection")));
            //options.UseSqlServer(_config.GetConnectionString("DefaultConnection")));

            ConfigureServices(services);
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddRazorPages()
                    .AddRazorPagesOptions(options =>
            {
                options.Conventions.AllowAnonymousToFolder("/Public");
                options.Conventions.AuthorizeFolder("/Admin", "RequireAdministratorRole");
                options.Conventions.AuthorizeFolder("/");
            });

            services.AddIdentity();

            services.AddAuthorization(options =>
            {
                options.AddPolicy("RequireAdministratorRole", policy => policy.RequireRole("Administrators"));
                options.AddPolicy("RequireUserRole", policy => policy.RequireRole("Users"));
            });

            services.AddCorsPolicy();

            services.AddVersioning();

            services.AddSignalR(e => e.EnableDetailedErrors = true);

            services.AddSwagger();

            services.AddAutoMapper(typeof(Startup));

            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
            services.AddScoped<IClientService, ClientService>();
            services.AddScoped<IGroupService, GroupService>();
            services.AddScoped<IGroupNotificationService, GroupNotificationService>();
            services.AddScoped<INotificationService, NotificationService>();
            services.AddScoped<ITemplateService, TemplateService>();
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

            services.Configure<ForwardedHeadersOptions>(options =>
            {
                options.ForwardedHeaders = ForwardedHeaders.XForwardedFor | ForwardedHeaders.XForwardedProto;
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IApiVersionDescriptionProvider provider, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseDatabaseErrorPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                //app.UseHsts();
            }

            //app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseResponseTimeMiddleware();
            app.UseCustomExceptionMiddleware();

            app.UseRouting();

            app.UseCorsPolicy();

            app.UseForwardedHeaders();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseCookiePolicy();
            app.UseWebSockets();

            app.UseVersionedSwagger(provider);

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapRazorPages();
                endpoints.MapControllers();
                endpoints.MapHub<NotificationHub>("/NotificationHub");
            });
        }
    }
}