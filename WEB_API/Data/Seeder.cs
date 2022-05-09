using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using API.Data;
using API.Model;
using Microsoft.AspNetCore.Identity;
using Model;
using Newtonsoft.Json;

namespace Data
{
    public static class Seeder
    {
        public static async Task Seed(RoleManager<IdentityRole> roleManager, UserManager<UserContact> userManager,
            ApplicationContext context)
        {
            
            await context.Database.EnsureCreatedAsync();
            if (!userManager.Users.Any())
            {
                List<string> roles = new List<string>{"Admin" , "Regular"};

                foreach (var role in roles)
                {
                    await roleManager.CreateAsync(new IdentityRole {Name = role});
                }

                //var path =await File.ReadAllTextAsync(Path.Combine(Environment.CurrentDirectory, @"Json\"));
                var path = await File.ReadAllTextAsync("C:/Users/hp/Desktop/karonwi/week-10-karonwi/WEB_API/Data/Json/UserContact.json");
                List<UserContact> users = JsonConvert.DeserializeObject<List<UserContact>>(path);
                

                foreach (var user in users)
                {
                    user.UserName = user.Email;
                   var result =  await userManager.CreateAsync(user, "S@muel7413");
                   if (user == users[0])
                    {
                        user.IsAdmin = true;
                        foreach (var address in user.Address)
                        {
                            address.UserId = user.Id;
                        }

                        if (result.Succeeded)
                        {
                         await userManager.AddToRoleAsync(user, "Admin");

                        }
                    }
                    else
                    {

                        user.IsAdmin=false;
                        foreach (var address in user.Address)
                        {
                            address.UserId = user.Id;
                        }

                        if (result.Succeeded)
                        {
                            await userManager.AddToRoleAsync(user, "Regular User");

                        }
                    }
                }
            }
        }
    }
}
