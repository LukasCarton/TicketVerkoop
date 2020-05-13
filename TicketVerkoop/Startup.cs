using System;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TicketVerkoop.Data;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using TicketVerkoop.Service.Interfaces;
using TicketVerkoop.Repository.Interfaces;
using TicketVerkoop.Service;
using TicketVerkoop.Repository;
using AutoMapper;
using TicketVerkoop.Util.Mail;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.OpenApi.Models;
using Microsoft.Extensions.Http;
using System.Net.Http;

namespace TicketVerkoop
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
            services.Configure<CookiePolicyOptions>(options =>
            {
                // This lambda determines whether user consent for non-essential cookies is needed for a given request.
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });


            //----> Dependency Injection
            // syntax services.AddTransient<service, implType>();
            //Customer
            services.AddTransient<ICustomerService, CustomerService>();
            services.AddTransient<ICustomerDAO, CustomerDAO>();
            // Stadium
            services.AddTransient<IStadiumService, StadiumService>();
            services.AddTransient<IStadiumDAO, StadiumDAO>();
            //Section
            services.AddTransient<ISectionService, SectionService>();
            services.AddTransient<ISectionDAO, SectionDAO>();
            //Team
            services.AddTransient<ITeamService, TeamService>();
            services.AddTransient<ITeamDAO, TeamDAO>();
            //Match
            services.AddTransient<IMatchService, MatchService>();
            services.AddTransient<IMatchDAO, MatchDAO>();
            //Reservation
            services.AddTransient<IReservationService,ReservationService>();
            services.AddTransient<IReservationDAO, ReservationDAO>();
            //Subscription
            services.AddTransient<ISubscriptionService, SubscriptionService>();
            services.AddTransient<ISubscriptionDAO, SubscriptionDAO>();
            //MatchSection
            services.AddTransient<IMatchSectionService, MatchSectionService>();
            services.AddTransient<IMatchSectionDAO, MatchSectionDAO>();
            //Season
            services.AddTransient<ISeasonService, SeasonService>();
            services.AddTransient<ISeasonDAO, SeasonDAO>();

            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(
                    Configuration.GetConnectionString("DefaultConnection")));
            services.AddDefaultIdentity<IdentityUser>()
                .AddDefaultUI(UIFramework.Bootstrap4)
                .AddEntityFrameworkStores<ApplicationDbContext>();

            //Automapper
            services.AddAutoMapper(typeof(Startup));

            //Session
            services.AddDistributedMemoryCache();
            services.AddSession(options =>
            {
                options.Cookie.Name = "TicketVerkoop.Session"; // name of the cookie
                options.Cookie.SecurePolicy = CookieSecurePolicy.Always;
                options.IdleTimeout = TimeSpan.FromMinutes(10); // expiration -> cookie lifes 10 min.
                options.Cookie.IsEssential = true;
                options.Cookie.HttpOnly = true;
            });

            services.AddTransient<IEmailSender, EmailSender>(i =>
                new EmailSender(
                    Configuration["EmailSender:Host"],
                    Configuration.GetValue<int>("EmailSender:Port"),
                    Configuration.GetValue<bool>("EmailSender:EnableSSL"),
                    Configuration["EmailSender:UserName"],
                    Configuration["EmailSender:Password"]
                )
            );

            //Swagger API
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "My API Match",
                    Version = "version 1",
                    Description = "An API to get all the matches",
                    TermsOfService = new Uri("https://example.com/terms"),
                    Contact = new OpenApiContact
                    {
                        Name = "TicketVerkoop Admin",
                        Email = "ticketverkoopvives@gmail.com",
                        Url = new Uri("https://vives.be"),
                    },
                    License = new OpenApiLicense
                    {
                        Name = "Employee API LICX",
                        Url = new Uri("https://example.com/license"),
                    }


                });
            });
            services.AddHttpClient("API Client", client =>
            {
                client.BaseAddress = new Uri("https://www.metaweather.com/");
                client.DefaultRequestHeaders.Add("Accept", "application/json");
            });
            // Add the re-try policy: in this instance, re-try three times,
            // in 1, 3 and 5 seconds intervals.
            


            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseDatabaseErrorPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            var swaggerOptions = new Options.SwaggerOptions();
            Configuration.GetSection(nameof(Options.SwaggerOptions)).Bind(swaggerOptions);

            // Enable middleware to serve generated Swagger as a JSON endpoint.
            //RouteTemplate legt het path vast waar de JSON-file wordt aangemaakt
            app.UseSwagger(option => { option.RouteTemplate = swaggerOptions.JsonRoute; });

            // By default, your Swagger UI loads up under / swagger /.If you want to change this, it's thankfully very straight-forward. Simply set the RoutePrefix option in your call to app.UseSwaggerUI in StartUp.cs:
            app.UseSwaggerUI(option =>
            {
                option.SwaggerEndpoint(swaggerOptions.UiEndpoint, swaggerOptions.Description);
            });



            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseCookiePolicy();

            app.UseAuthentication();
            app.UseSession();
            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
