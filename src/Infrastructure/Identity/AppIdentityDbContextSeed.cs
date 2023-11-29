using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace Metcom.CardPay3.Infrastructure.Identity
{
    public class AppIdentityDbContextSeed
    {
        public static async Task SeedAsync(AppIdentityDbContext identityDbContext, UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            if (identityDbContext.Database.IsSqlServer())
            {
                identityDbContext.Database.Migrate();
            }

            await roleManager.CreateAsync(new IdentityRole("Administrators"));

            var defaultUser = new ApplicationUser { UserName = "demouser@metcom.ru", Email = "demouser@metcom.ru", EmailConfirmed = true, IdOrganization = 1 };
            await userManager.CreateAsync(defaultUser, "#bZL$N9=8Cym@.#");

            string adminUserName = "admin@metcom.ru";
            var adminUser = new ApplicationUser { UserName = adminUserName, Email = adminUserName, EmailConfirmed = true, IdOrganization = 1 };
            await userManager.CreateAsync(adminUser, "#bZL$N9=8Cym@.#");
            adminUser = await userManager.FindByNameAsync(adminUserName);
            await userManager.AddToRoleAsync(adminUser, "Administrators");
        }
    }
}
