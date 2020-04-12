﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
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

            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(
                    Configuration.GetConnectionString("DefaultConnection")));
            services.AddDefaultIdentity<IdentityUser>()
                .AddDefaultUI(UIFramework.Bootstrap4)
                .AddEntityFrameworkStores<ApplicationDbContext>();

            //Automapper
            services.AddAutoMapper(typeof(Startup));

            services.AddTransient<IEmailSender, EmailSender>(i =>
                new EmailSender(
                    Configuration["EmailSender:Host"],
                    Configuration.GetValue<int>("EmailSender:Port"),
                    Configuration.GetValue<bool>("EmailSender:EnableSSL"),
                    Configuration["EmailSender:UserName"],
                    Configuration["EmailSender:Password"]
                )
            );

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

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseCookiePolicy();

            app.UseAuthentication();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
