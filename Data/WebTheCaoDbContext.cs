using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Threading.Tasks;
using WebTheCao.Data.Models;

namespace WebTheCao.Data
{
    public class WebTheCaoDbContext : IdentityDbContext<ApplicationUser>
    {
        public WebTheCaoDbContext(DbContextOptions options) : base(options)
        {
        }

        public static async Task CreateAdminAccount(IServiceProvider serviceProvider,
           IConfiguration configuration)
        {
            UserManager<ApplicationUser> userManager =
            serviceProvider.GetRequiredService<UserManager<ApplicationUser>>();
            RoleManager<IdentityRole> roleManager =
            serviceProvider.GetRequiredService<RoleManager<IdentityRole>>();
            string adminUser = configuration["Data:AdminUser:Name"];
            string adminEmail = configuration["Data:AdminUser:Email"];
            string adminPassword = configuration["Data:AdminUser:Password"];
            string adminRole = configuration["Data:AdminUser:Role"];
            if (await userManager.FindByNameAsync(adminUser) == null)
            {
                if (await roleManager.FindByNameAsync(adminRole) == null)
                {
                    await roleManager.CreateAsync(new IdentityRole(adminRole));
                }
                ApplicationUser admin = new ApplicationUser
                {
                    UserName = adminUser,
                    Email = adminEmail,
                    EmailConfirmed=true,
                    Status=true
                };
                IdentityResult result = await userManager
                .CreateAsync(admin, adminPassword);
                if (result.Succeeded)
                {
                    await userManager.AddToRoleAsync(admin, adminRole);
                }
            }
            //create guest account
            string guestUser = configuration["Data:guestUser:Name"];
            string guestEmail = configuration["Data:guestUser:Email"];
            string guestPassword = configuration["Data:guestUser:Password"];
            string guestRole = configuration["Data:guestUser:Role"];
            if (await userManager.FindByNameAsync(guestUser) == null)
            {
                if (await roleManager.FindByNameAsync(guestRole) == null)
                {
                    await roleManager.CreateAsync(new IdentityRole(guestRole));
                }
                ApplicationUser guest = new ApplicationUser
                {
                    UserName = guestUser,
                    Email = guestEmail,
                    EmailConfirmed = true,
                    Status=true
                };
                IdentityResult result = await userManager
                .CreateAsync(guest, guestPassword);
                if (result.Succeeded)
                {
                    await userManager.AddToRoleAsync(guest, guestRole);
                }
            }
        }

        public virtual DbSet<ApplicationUser> ApplicationUsers { get; set; }
        public virtual DbSet<Feedback> Feedbacks { get; set; }
        public virtual DbSet<Page> Pages { get; set; }
        public virtual DbSet<Slide> Slides { get; set; }
        public virtual DbSet<Contact> Contacts { get; set; }
        public virtual DbSet<Card> Cards { get; set; }
        public virtual DbSet<MenhGia> MenhGias { get; set; }
        public virtual DbSet<Post> Posts { get; set; }
        public virtual DbSet<Tags> Tags { get; set; }
        public virtual DbSet<NopCard> NopCards { get; set; }
        public virtual DbSet<Partial> Partials { get; set; }
        public virtual DbSet<GiaoDich> GiaoDichs { get; set; }
        public virtual DbSet<TaiKhoanNganHang> TaiKhoanNganHangs { get; set; }
    }
}