using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace YIAN.Models
{
    public static class SampleData
    {
        public async static Task InitDB(IServiceProvider service)
        {
            var DB = service.GetRequiredService<YIANContext>();

            var userManager = service.GetRequiredService<UserManager<User>>();

            var roleManager = service.GetRequiredService<RoleManager<IdentityRole<long>>>();

            if (DB.Database != null && DB.Database.EnsureCreated())
            {
                //初始化管理员角色
                await roleManager.CreateAsync(new IdentityRole<long> { Name = "超级管理员" });
                await roleManager.CreateAsync(new IdentityRole<long> { Name = "管理员" });
                //初始化超级管理员
                var superadmin = new User
                {
                    Name = "超级管理员",
                    UserName = "Admin"
                };
                await userManager.CreateAsync(superadmin, "123456");
                await userManager.AddToRoleAsync(superadmin, "超级管理员");
                //初始化普通管理员
                var admin = new User
                {
                    Name="普通管理员",
                    UserName = "Guest"
                };
                await userManager.CreateAsync(admin, "123456");
                await userManager.AddToRoleAsync(admin, "管理员");

                var town1= DB.Towns.Add(new Town { Title = "长安村", CreateTime = DateTime.Now });
                var town2= DB.Towns.Add(new Town { Title = "平安村", CreateTime = DateTime.Now });

                var lowline = DB.LowLines.Add(new LowLine { Line = 2800, Time = DateTime.Now });
                
            }
            DB.SaveChanges();
        }
    }
}
