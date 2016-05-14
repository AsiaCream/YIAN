using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Mvc;
using Microsoft.AspNet.Authorization;
using YIAN.Models;

namespace YIAN.Controllers
{
    public class AccountController : BaseController
    {
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Login(string username,string password)
        {
            var result = await signInManager.PasswordSignInAsync(username, password, false, false);
            if (result.Succeeded)
            {
                return RedirectToAction("Index", "Home");
            }
            else
            {
                return RedirectToAction("Login", "Account");
            }
        }
        [Authorize]
        [HttpPost]
        public async Task<IActionResult> Logout()
        {
            await signInManager.SignOutAsync();
            return RedirectToAction("Login", "Account");
        }
        [Authorize(Roles =("超级管理员"))]
        [HttpGet]
        public async Task<IActionResult> CreateAdmin()
        {
            var users = (await userManager.GetUsersInRoleAsync("管理员"))
                .OrderBy(x => x.Id)
                .ToList();
            var admin = (await userManager.GetUsersInRoleAsync("超级管理员"))
                .OrderBy(x => x.Id)
                .ToList();
            ViewBag.Admin = admin;
            ViewBag.AdminCount = admin.Count();
            ViewBag.UserCount = users.Count();
            return View(users);
        }
        [Authorize(Roles = ("超级管理员"))]
        [HttpPost]
        public async Task<IActionResult> CreateAdmin(string username, string password,string name,string position)
        {
            var admin = new User
            {
                UserName = username,
                Name = name,
            };
            var result = await userManager.CreateAsync(admin, password);
            if (result.Succeeded)
            {
                if (position == "是")
                {
                    await userManager.AddToRoleAsync(admin, "超级管理员");
                    DB.SaveChanges();
                    return RedirectToAction("CreateAdmin","Account");
                }
                else
                {
                    await userManager.AddToRoleAsync(admin, "管理员");
                    DB.SaveChanges();
                    return RedirectToAction("CreateAdmin", "Account");
                }
            }
            else
            {
                return Content("error");
            }
            
        }
        [Authorize]
        [HttpGet]
        public IActionResult Modify()
        {
            return View();
        }
        [Authorize]
        [HttpPost]
        public async Task<IActionResult> Modify(string password,string newpwd)
        {
            var result = await userManager.ChangePasswordAsync(UserCurrent, password, newpwd);
            if (result.Succeeded)
            {
                return Content("success");
            }
            else
            {
                return Content("error");
            }
        }
    }
}
