using Announcer.Contracts;
using Announcer.Data.Repositories;
using Announcer.Data.UnitOfWork;
using Announcer.Helpers.Extensions;
using Announcer.Hubs;
using Announcer.Services;
using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Announcer
{
    public class Startup
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Startup"/> class.
        /// </summary>
        /// <param name="configuration">The current configuration.</param>
        /// <param name="env">The current working environment.</param>
        public Startup(IConfiguration configuration, IWebHostEnvironment env)
        {
            _env = env;
            Configuration = configuration;
        }

        /// <summary>
        /// Gets the current configuration.
        /// </summary>
        /// <value>The current application configuration.</value>
        public IConfiguration Configuration { get; }

        /// <summary>
        /// Gets the current working environment
        /// </summary>
        private readonly IWebHostEnvironment _env;

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.Configure<CookiePolicyOptions>(options =>
            {
                // This lambda determines whether user consent for non-essential cookies
                // is needed for a given request.
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });

            services.AddRazorPages()
                    .AddRazorPagesOptions(options =>
            {
                options.Conventions.AllowAnonymousToPage("/Notifications");
                options.Conventions.AuthorizeFolder("/Admin", "RequireAdministratorRole");
                options.Conventions.AuthorizeFolder("/");
            });

            services.AddDatabaseServices(Configuration.GetConnectionString("DefaultConnection"), _env.EnvironmentName);

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
            services.AddScoped<INotificationService, NotificationService>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IApiVersionDescriptionProvider provider)
        {
            if (_env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseDatabaseErrorPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseResponseTimeMiddleware();
            app.UseCustomExceptionMiddleware();

            app.UseRouting();

            app.UseCorsPolicy();

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