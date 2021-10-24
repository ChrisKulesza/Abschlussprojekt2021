using Abschlussprojekt2021.Areas.Identity.Data;
using DataAccess.EFCore.Data;
using DataAccess.EFCore.Repositories;
using DataAccess.EFCore.UnitOfWork;
using Domain.Interfaces;
using Domain.Models;
using Domain.Resources;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.FileProviders;
using Microsoft.Extensions.Hosting;
using Newtonsoft.Json.Serialization;
using System;
using System.IO;

namespace Abschlussprojekt2021
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            // Register DatabaseContext class DataAccess.EFCore.Data
            services.AddDbContext<ApplicationDbContext>(options =>
            {
                options.UseSqlServer(
                    Configuration.GetConnectionString("DefaultConnection"),
                    b => b.MigrationsAssembly(typeof(ApplicationDbContext).Assembly.FullName));
            });

            // DI Synfuction RTE UI component service
            services.AddScoped<SyncfusionOptionsService>();

            #region Repository Pattern
            services.AddTransient(typeof(IGenericRepository<>), typeof(GenericRepository<>));
            services.AddTransient(typeof(IApplicationUserRepository), typeof(ApplicationUserRepository));
            services.AddTransient(typeof(IJobAdRepository), typeof(JobAdRepository));
            services.AddTransient(typeof(IUnitOfWork), typeof(UnitOfWork));
            #endregion

            #region Snycfusion
            // --------------------------------------------------------------------------------------
            // NewtonsoftJson for Synfusion CRUD - Process
            services.AddMvc().AddNewtonsoftJson(options => {
                options.SerializerSettings.ContractResolver = new DefaultContractResolver();
            });
            services.AddAntiforgery(o => o.HeaderName = "XSRF-TOKEN");
            // Synfusion Area End
            // --------------------------------------------------------------------------------------
            #endregion

            services.AddDatabaseDeveloperPageExceptionFilter();

            #region Identity
            // identity configuration
            services.AddDefaultIdentity<ApplicationUser>(options =>
            {
                // password settings
                options.Password.RequireDigit = false; // 0-9
                options.Password.RequireLowercase = true; // a-z
                options.Password.RequireUppercase = true; // A-Z
                options.Password.RequireNonAlphanumeric = false; // !"?$%
                options.Password.RequiredLength = 6;

                // lockout settings
                options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(30);
                options.Lockout.MaxFailedAccessAttempts = 5;
                options.Lockout.AllowedForNewUsers = true;

                // user settings
                options.User.AllowedUserNameCharacters = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789-._@+";
                options.User.RequireUniqueEmail = true;

                // Confirmation at SignIn
                options.SignIn.RequireConfirmedAccount = false;
                options.SignIn.RequireConfirmedEmail = false;
            })
                .AddRoles<IdentityRole>()
                .AddEntityFrameworkStores<ApplicationDbContext>();
            #endregion

            // Authorization
            // https://stackoverflow.com/questions/50743667/authorize-register-page-in-asp-net-core-2-1-with-identity-ui-as-a-library
            services.AddAuthorization(options =>
            {
                options.AddPolicy("RequireAdministratorRole",
                    policy => policy.RequireRole("Admin"));
                options.DefaultPolicy = options.GetPolicy("RequireAdministratorRole");
            });

            services.AddRazorPages(options =>
            {
                //options.Conventions.AuthorizePage("/Error/404");
                //options.Conventions.AuthorizeAreaPage("Identity", "/Account/Register");
            });

            #region AutoMapper
            // Auto Mapper Configurations
            //var mapperConfig = new MapperConfiguration(config =>
            //{
            //    config.AddProfile(new ModelMapper());
            //});

            //IMapper mapper = mapperConfig.CreateMapper();
            //services.AddSingleton(mapper);

            services.AddAutoMapper(typeof(Startup));
            #endregion

            //services.ConfigureApplicationCookie(options =>
            //{
            //    //options.LoginPath = $"/Identity/Account/Login";
            //    //options.LogoutPath = $"/Identity/Account/Logout";
            //    options.AccessDeniedPath = "/Identity/Account/AccessDenied";
            //});
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, IServiceProvider services)
        {
            // Register Syncfusion Community License
            Syncfusion.Licensing.SyncfusionLicenseProvider.RegisterLicense("NTExMzY2QDMxMzkyZTMzMmUzMGY4MlFsbHFtUFRScTFvcDNOYzAzb2k5MnlnaDJvZEFEb1hEb1Ezd2VUWXM9");

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseMigrationsEndPoint();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();

            #region StaticFiles
            app.UseStaticFiles();       // wwwroot folder

            // static files for images - define own querystring in the browser
            app.UseStaticFiles(new StaticFileOptions()
            {
                FileProvider = new PhysicalFileProvider(Path.Combine(Directory.GetCurrentDirectory(), @"Media\Images")),
                RequestPath = new PathString("/img")
            });
            #endregion

            // Here is our middleware registration
            //app.UseStatusCodePagesWithReExecute("/Error/{0}");

            app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapRazorPages();
            });

            // Writes data to the database when the database is empty, otherwise no changes are made.
            AppDbInitializer.Seed(app);

            // Create the roles if they don't already exist
            Roles.CreateRoles(services).Wait();
        }
    }
}
