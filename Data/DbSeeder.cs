using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebTheCao.Data.Models;

namespace WebTheCao.Data
{
    public class DbSeeder
    {
        public static void Seed(WebTheCaoDbContext dbContext, RoleManager<IdentityRole> roleManager, UserManager<ApplicationUser> userManager)
        {
            if (!dbContext.Users.Any())
            {
                CreateUser(dbContext, roleManager, userManager)
                   .GetAwaiter()
                   .GetResult();
            }
            if (!dbContext.Slides.Any())
            {
                CreateSlides(dbContext, userManager);
            }
           
            if (!dbContext.Pages.Any())
            {
                CreatePage(dbContext, userManager);
            }
            if (!dbContext.Contacts.Any())
            {
                CreateContacts(dbContext, userManager);
            }
            if (!dbContext.Cards.Any())
            {
                CreateCard(dbContext);
            }
            if (!dbContext.MenhGias.Any())
            {
                CreateMenhGia(dbContext);
            }
            if (!dbContext.NopCards.Any())
            {
                TaoNopCard(dbContext, userManager);
            }
        }
        private static void TaoNopCard(WebTheCaoDbContext dbContext, UserManager<ApplicationUser> userManager)
        {
            var userId = userManager.FindByEmailAsync("vohung.it@gmail.com").Result.Id;
            List<NopCard> NopCard = new List<NopCard>
            {
                new NopCard
                {
                    Id=Guid.NewGuid().ToString(),
                    NgayNopCard=DateTime.Now,
                    NoiDung="Mua card",
                    UserId=userId,
                    Status=true
                },new NopCard
                {
                    Id=Guid.NewGuid().ToString(),
                    NgayNopCard=DateTime.Now,
                    NoiDung="Mua card viettel",
                    UserId=userId,
                    Status=true
                }
            };
            NopCard.ForEach(x => dbContext.NopCards.Add(x));
            dbContext.SaveChanges();
        }

        private static void CreateCard(WebTheCaoDbContext dbContext)
        {
            List<Card> Cards = new List<Card>
            {
              new Card {
                  Name="VietTel",
                  Status=true
              }
            ,new Card {
                  Name="Vinaphone",
                  
                  Status=true
              },
              new Card
              {
                  Name="Mobiphone",
                 
                  Status=true
              },
            };
            Cards.ForEach(x=>dbContext.Add(x));
            dbContext.SaveChanges();
        }private static void CreateMenhGia(WebTheCaoDbContext dbContext)
        {
            List<MenhGia> menhgia = new List<MenhGia>
            {
              new MenhGia {
                  Price=50000,
                  unit_Price=45000,
                  Point=45000,
                  
              }
            ,new MenhGia {
                  Price=100000,
                  unit_Price=45000,
                  Point=45000,
              },
              new MenhGia
              {
                 Price=200000,
                  unit_Price=45000,
                  Point=45000,
              },

              new MenhGia
              {
                  Price=4000000,
                  unit_Price=45000,
                  Point=45000,
              },
              new MenhGia
              {
                  Price=500000,
                  unit_Price=45000,
                  Point=45000,
              },new MenhGia {
                  Price=50000,
                  unit_Price=45000,
                  Point=45000,
                  
              }
            ,new MenhGia {
                  Price=100000,
                  unit_Price=45000,
                  Point=45000,
              },
              new MenhGia
              {
                 Price=200000,
                  unit_Price=45000,
                  Point=45000,
              },

              new MenhGia
              {
                  Price=4000000,
                  unit_Price=45000,
                  Point=45000,
              },
              new MenhGia
              {
                  Price=500000,
                  unit_Price=45000,
                  Point=45000,
              },
            };
            menhgia.ForEach(x=>dbContext.Add(x));
            dbContext.SaveChanges();
        }
        private static void CreateContacts(WebTheCaoDbContext dbContext, UserManager<ApplicationUser> userManager)
        {
            var userId = userManager.FindByEmailAsync("vohung.it@gmail.com").Result.Id;
            var contact = new Contact
            {
                Address = "Phường Tân Thạnh - Tp.Tam Kỳ - Quảng Nam",
                Email = "vohung.it@gmail.com",
                PhoneNumber = "0169 565 5783",
                Status = true,
                UserId = userId
            };
            dbContext.Contacts.Add(contact);
            dbContext.SaveChanges();
        }
        private static void CreatePage(WebTheCaoDbContext dbContext, UserManager<ApplicationUser> userManager)
        {
            var userId = userManager.FindByEmailAsync("vohung.it@gmail.com").Result.Id;
            List<Page> pages = new List<Page>
            {
                new Page
                {
                    Id=Guid.NewGuid().ToString(),
                    Name="footer",
                    Content="footer",
                    CreatedDate=DateTime.Now,
                    UserId=userId,
                    Status=true
                },new Page
                {
                    Id=Guid.NewGuid().ToString(),
                    Name="contact",
                    Content="contact content seeder",
                    CreatedDate=DateTime.Now,
                    UserId=userId,
                    Status=true
                },new Page
                {
                    Id=Guid.NewGuid().ToString(),
                    Name="about",
                    Content="about content seeder",
                    CreatedDate=DateTime.Now,
                    UserId=userId,
                    Status=true
                }
            };
            pages.ForEach(x => dbContext.Pages.Add(x));
            dbContext.SaveChanges();
        }

        public static void CreateSlides(WebTheCaoDbContext dbContext, UserManager<ApplicationUser> userManager)
        {
            var userId = userManager.FindByEmailAsync("vohung.it@gmail.com").Result.Id;
            List<Slide> slides = new List<Slide>
            {
                 new Slide
            {
                Id=Guid.NewGuid().ToString(),
                Name = "slide 1",
                UserId = userId,
  
                Content = "Lao động trí óc mà không lao động chân tay, chỉ biết lý luận mà không biết thực hành thì cũng là trí thức có một nửa. Vì vậy, cho nên các cháu trong lúc học lý luận cũng phải kết hợp với thực hành và tất cả các ngành khác đều phải: lý luận kết hợp với thực hành, học tập kết hợp với lao động.",
                DisplayOrder = 1,
                Image = "http://www.mediafire.com/convkey/2b3c/cfd3i2sc2t4tr4izg.jpg",
        
                Status = true
            },
                 new Slide
            {
                     Id=Guid.NewGuid().ToString(),
                Name = "slide 2",
                UserId = userId,
 
                Content = "Người ta chỉ học được từ sách và các ví dụ rằng một số thứ có thể làm được. Học hỏi thực sự yêu cầu bạn phải thực hiện chúng.",
            DisplayOrder = 1,
                Image = "http://www.mediafire.com/convkey/6546/66qp4fak56c84qtzg.jpg",

                Status = true
            }
        };
            slides.ForEach(x => dbContext.Slides.Add(x));
            dbContext.SaveChanges();
        }
        public static async Task CreateUser(WebTheCaoDbContext dbContext, RoleManager<IdentityRole> roleManager, UserManager<ApplicationUser> userManager)
        {
            string role_Administrator = "Administrator";
            string role_RegisteredUser = "RegisteredUser";
            if (!await roleManager.RoleExistsAsync(role_Administrator))
            {
                await roleManager.CreateAsync(new IdentityRole(role_Administrator));
            }
            if (!await roleManager.RoleExistsAsync(role_RegisteredUser))
            {
                await roleManager.CreateAsync(new IdentityRole(role_RegisteredUser));
            }
            //create the "Admin" ApplicationUser account
            var user_Admin = new ApplicationUser
            {
                SecurityStamp = Guid.NewGuid().ToString(),
                UserName = "Admin",
                Email = "vohung.it@gmail.com",
                EmailConfirmed = true,
                CreatedDate = DateTime.Now,
                LastModifiedDate = DateTime.Now
            };
            if (await userManager.FindByNameAsync(user_Admin.UserName) == null)
            {
                await userManager.CreateAsync(user_Admin, "pass4Admin");
                //await userManager.AddToRoleAsync(user_Admin,role_Administrator);
                user_Admin.EmailConfirmed = true;
                user_Admin.LockoutEnabled = false;
            }
            await dbContext.SaveChangesAsync();

        }


    }
}
