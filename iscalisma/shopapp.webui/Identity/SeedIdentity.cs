using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace shopapp.webui.Identity
{
    public static class SeedIdentity
    {
        public static async Task Seed(UserManager<User> userManager, RoleManager<IdentityRole> roleManager,IConfiguration configuration)
        {
            //appsettings.json daki bilgileri alalım
            var username = configuration["Data:AdminUser:username"];
            var email = configuration["Data:AdminUser:email"];
            var password = configuration["Data:AdminUser:password"];
            var role = configuration["Data:AdminUser:role"];

            //Bir kullanıcı oluşturalım
            if(await userManager.FindByNameAsync(username) == null)
            {
                //kullanıcı oluşmadan önce role oluşturmak gerekiyor
                await roleManager.CreateAsync(new IdentityRole(role));
                //role oluştuktan sonra user bilgilerini tanımlayalım
                var user = new User()
                {
                    UserName = username,
                    Email = email,
                    FirstName = "admin",
                    LastName = "admin",
                    EmailConfirmed = true
                };
                //bu bilgilerle bir user oluşturalım
                var result = await userManager.CreateAsync(user, password);
                if (result.Succeeded)
                {
                    //eğer işlem başarılıyla role ataması yapalım
                    await userManager.AddToRoleAsync(user, role);
                    //daha sonra bunu sturtup içerisine aktarıyor olmalıyız
                }

            }
        }
    }
}
