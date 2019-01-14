using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using reCAPTCHA.AspNetCore;
using System;
using WebTheCao.Data;
using WebTheCao.Data.Interfaces;
using WebTheCao.Data.Models;
using WebTheCao.Data.Repositories;
using WebTheCao.Infrastructures;

namespace WebTheCao
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
            services.AddEntityFrameworkSqlServer();
            services.AddTransient<IPasswordValidator<ApplicationUser>, CustomPasswordValidator>();
            services.AddIdentity<ApplicationUser, IdentityRole>(
                            opts =>
                            {
                                opts.User.RequireUniqueEmail = true;

                                opts.Password.RequireDigit = true;
                                opts.Password.RequireLowercase = true;
                                opts.Password.RequireUppercase = false;
                                opts.Password.RequireNonAlphanumeric = true;
                                opts.Password.RequiredLength = 8;
                                opts.SignIn.RequireConfirmedEmail = true;
                            })
                            .AddEntityFrameworkStores<WebTheCaoDbContext>()
                            .AddDefaultTokenProviders();
 
            services.ConfigureApplicationCookie(options =>
            {
                options.AccessDeniedPath = "/AccessDenied";
                options.LoginPath = "/login";
            });
            services.AddDbContext<WebTheCaoDbContext>(options => options.UseSqlServer(Configuration.GetConnectionString("WebTheCaoConnectionString")));
            //recapcha service
            services.Configure<RecaptchaSettings>(Configuration.GetSection("RecaptchaSettings"));
            services.AddTransient<IRecaptchaService, RecaptchaService>();

            //add transient
            services.AddTransient<ICardRepository, CardRepository>();
            services.AddTransient<IMenhGiaRepository, MenhGiaRepository>();
            services.AddTransient<IContactRepository, ContactRepository>();
            services.AddTransient<IFeedbackRepository, FeedbackRepository>();
            services.AddTransient<INopCardRepository, NopCardRepository>();
            services.AddTransient<IPageRepository, PageRepository>();
            services.AddTransient<IPostRepository, PostRepository>();
            services.AddTransient<ISlideRepository, SlideRepository>();
            services.AddTransient<ITagsRepository, TagsRepository>();
            services.AddTransient<IPartialRepository, PartialRepository>();
            services.AddTransient<IGiaoDichRepository, GiaoDichRepository>();
            services.AddTransient<ITKNHRepository, TKNHRepository>();
            services.Configure<CookiePolicyOptions>(options =>
            {
                // This lambda determines whether user consent for non-essential cookies is needed for a given request.
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });
            services.Configure<IISOptions>(options =>
            {
                options.ForwardClientCertificate = false;
            });

            services.AddResponseCompression();
            services.AddMemoryCache();
            services.AddDistributedMemoryCache();

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1).AddSessionStateTempDataProvider();
            services.Configure<CookiePolicyOptions>(options =>
            {
                options.CheckConsentNeeded = context => false;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });
            services.AddSession(options => {
                options.IdleTimeout = TimeSpan.FromMinutes(1);//You can set Time   
            });
         
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }

            //app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseCookiePolicy();
            app.UseAuthentication();
            app.UseSession();
            app.UseResponseCompression();
            app.UseMvc(routes =>
            {
                routes.MapRoute(
            name: "homeAdmin",
            template: "{area:exists}/{controller=home}/{action=Index}/{id?}"
          ); routes.MapRoute(
            name: "cardAdmin",
            template: "{area:exists}/{controller=card}/{action=Index}/{id?}"
          ); routes.MapRoute(
             name: "NopCardAdmin",
             template: "{area:exists}/{controller=giao-dich}/{action=Index}/{id?}"
           ); routes.MapRoute(
              name: "slideAdmin",
              template: "{area:exists}/{controller=slide}/{action=Index}/{id?}"
            ); routes.MapRoute(
               name: "feedbackAdmin",
               template: "{area:exists}/{controller=feedback}/{action=Index}/{id?}"
             ); routes.MapRoute(
                name: "pageAdmin",
                template: "{area:exists}/{controller=page}/{action=Index}/{id?}"
              ); routes.MapRoute(
                 name: "postAdmin",
                 template: "{area:exists}/{controller=post}/{action=Index}/{id?}"
               ); routes.MapRoute(
                  name: "tagsAdmin",
                  template: "{area:exists}/{controller=tags}/{action=Index}/{id?}"
                ); routes.MapRoute(
                   name: "contactAdmin",
                   template: "{area:exists}/{controller=contact}/{action=Index}/{id?}"
                 ); routes.MapRoute(
                    name: "accountAdmin",
                    template: "{area:exists}/{controller=account}/{action=Index}/{id?}"
                  );
                routes.MapRoute(
                     name: "nopthe",
                     template: "/nap-the.html",
                     defaults: new { controller = "Card", action = "Index" }
               ); routes.MapRoute(
                      name: "post",
                      template: "/khuyen-mai.html",
                      defaults: new { controller = "Post", action = "Index" }
                ); routes.MapRoute(
                       name: "post-detail",
                       template: "/khuyen-mai/{metaname}/{id}",
                       defaults: new { controller = "Post", action = "Detail" }
                 ); routes.MapRoute(
                        name: "lien-he",
                        template: "/lien-he.html",
                        defaults: new { controller = "Page", action = "ContactPage" }
                  ); routes.MapRoute(
                         name: "bang-gia",
                         template: "/bang-gia.html",
                         defaults: new { controller = "Page", action = "BangGia" }
                   ); routes.MapRoute(
                         name: "NopCard",
                         template: "/giao-dich/{userId}",
                         defaults: new { controller = "UserAccount", action = "LichSuNopCard" }
                   ); routes.MapRoute(
                         name: "NapThe",
                         template: "/giao-dich/nap-tien",
                         defaults: new { controller = "UserAccount", action = "NapTien" }
                   ); routes.MapRoute(
                         name: "XacThuc",
                         template: "UserAccount/ConfirmEmail/{userid?}/{token?}",
                         defaults: new { controller = "UserAccount", action = "ConfirmEmail" }
                   );
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Card}/{action=Index}/{id?}");
            }); 
            WebTheCaoDbContext.CreateAdminAccount(app.ApplicationServices, Configuration).Wait();
            using (var serviceScope = app.ApplicationServices.GetRequiredService<IServiceScopeFactory>().CreateScope())
            {
                var dbContext = serviceScope.ServiceProvider.GetRequiredService<WebTheCaoDbContext>();
                var roleManager = serviceScope.ServiceProvider.GetService<RoleManager<IdentityRole>>();
                var userManager = serviceScope.ServiceProvider.GetService<UserManager<ApplicationUser>>();
                dbContext.Database.Migrate();
                DbSeeder.Seed(dbContext, roleManager, userManager);
            }
        }
    }
}