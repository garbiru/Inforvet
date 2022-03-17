using Inforvet.Areas.Identity.Data;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MediESTeca.Data
{
    public static class SeedData
    {
        public static async Task Seed(/*UserManager<InforvetUser> userManager,*/ RoleManager<IdentityRole> roleManager)
        {
            await SeedRolesAsync(roleManager);
            //await SeedUsersAsync(userManager);
        }

        /*private static async Task SeedUsersAsync(UserManager<Utente> userManager)
        {

            if (userManager.FindByNameAsync("admin").Result == null)
            {
                var admin = new Utente { Nome = "admin", Telefone = 123456789, UserName = "admin@ips.pt", Email = "admin@ips.pt" };
                var result = await userManager.CreateAsync(admin, "123456");
                if (result.Succeeded)
                {
                    await userManager.AddToRoleAsync(admin, "admins");
                }
            }

            if (userManager.FindByNameAsync("João Manuel").Result == null)
            {
                var joao = new Utente { Nome = "João Manuel", Telefone = 1234567890, UserName = "jonas@ip.pt", Email = "jonas@ip.pt" };
                var result1 = await userManager.CreateAsync(joao, "123456");
                if (result1.Succeeded)
                {
                    await userManager.AddToRoleAsync(joao, "users");
                }
            }

            if (userManager.FindByNameAsync("Ana").Result == null)
            {
                var ana = new Utente { Nome = "Ana", Telefone = 234567890, UserName = "ana@gmail.com", Email = "ana@gmail.com" };
                var result2 = await userManager.CreateAsync(ana, "123456");
                if (result2.Succeeded)
                {
                    await userManager.AddToRoleAsync(ana, "users");
                }
            }
        }*/

        private static async Task SeedRolesAsync(RoleManager<IdentityRole> roleManager)
        {
            var clientRole = new IdentityRole("client");
            if (!await roleManager.RoleExistsAsync(clientRole.Name))
            {
                await roleManager.CreateAsync(clientRole);
            }

            var funcRole = new IdentityRole("func");
            if (!await roleManager.RoleExistsAsync(funcRole.Name))
            {
                await roleManager.CreateAsync(funcRole);
            }

            var adminRole = new IdentityRole("admin");
            if (!await roleManager.RoleExistsAsync(adminRole.Name))
            {
                await roleManager.CreateAsync(adminRole);
            }

        }

    }
}
