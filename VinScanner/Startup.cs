using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SpaServices.ReactDevelopmentServer;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Nexmo.Api.Request;
using Swashbuckle.AspNetCore.Swagger;
using VinScanner.Services;
using VinScanner.Interfaces;
using VinScanner.Brokers;
using VinScanner.Repository;
using VinScanner.Data;
using VinScanner.Models.Repository;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using VinScanner.Models;

namespace VinScanner.View
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
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
            
            //Application Dependancy Injection 
            services.AddTransient<INexmoBroker, NexmoBroker>();
            services.AddTransient<INpTrackerBroker, NpTrackerBroker>();
            services.AddTransient<ISendGridBroker, SendGridBroker>();

            services.AddTransient<IUserRepository, UserRepository>();
            services.AddTransient<IDealerRepository, DealerRepository>();

            services.AddTransient<IUserService, UserService>();
            services.AddTransient<IDealerService, DealerService>();
            services.AddTransient<IScannerService, ScannerService>();
            services.AddTransient<ISmsService, SmsService>();
            services.AddTransient<IEmailService, EmailService>();

            //Add AppSettings Configuration
            services.Configure<Credentials>(Configuration.GetSection(nameof(Credentials)));
            services.Configure<NpTrackerSettings>(Configuration.GetSection(nameof(NpTrackerSettings)));


            //Configuring Roles
            //services.AddDbContext<VinScannerContext>(option =>
            //option.UseInMemoryDatabase("sqldb-delta-test"));

            services.AddIdentity<User, IdentityRole>()
                .AddEntityFrameworkStores<VinScannerContext>()
                .AddDefaultTokenProviders();

            services.AddAuthorization(options =>
            {
                options.AddPolicy("DealerRole", policy => policy.RequireRole("Dealer"));
            });

            services.AddHttpClient();

            //Adding Swagger
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Info { Title = "Vin Scanner API", Version = "v1" });
            });


            // In production, the React files will be served from this directory
            services.AddSpaStaticFiles(configuration =>
            {
                configuration.RootPath = "ClientApp/build";
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            //Configure Swagger UI
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Vin Scanner");
            });

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseSpaStaticFiles();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller}/{action=Index}/{id?}");
            });

            app.UseSpa(spa =>
            {
                spa.Options.SourcePath = "ClientApp";

                if (env.IsDevelopment())
                {
                    spa.UseReactDevelopmentServer(npmScript: "start");
                }
            });
        }
    }
}
