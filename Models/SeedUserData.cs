using System.Linq;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using Su_Project.DataContext;
namespace Su_Project.Models
{
    public class SeedUserData
    {
        public static void SeedUser(IApplicationBuilder app)
        {
            RiviuNhaTrangDBContext context = app.ApplicationServices
                                            .CreateScope().ServiceProvider
                                            .GetRequiredService<RiviuNhaTrangDBContext>();
            if (context.Database.GetPendingMigrations().Any())
            {
                context.Database.Migrate();
            }
            if (!context.Users.Any())
            {
                context.Users.AddRange(
                    new User
                    {
                        AccountName = "admin",
                        Password = "admin",
                        FullName = "VietFaia",
                        Email = "nhuviet2012@gmail.com",
                        Phone = "+84 905070469",
                        FaceBook = "",
                        Website = ""

                    }
                );
                context.SaveChanges();
            }
        }
    }
}
