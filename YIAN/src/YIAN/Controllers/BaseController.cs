﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Mvc;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Mvc.Filters;
using YIAN.Models;
using YIAN.ViewModels;

namespace YIAN.Controllers
{
    public class BaseController : Controller
    {
        [FromServices]
        public YIANContext DB { get; set; }
        [FromServices]
        public SignInManager<User> signInManager { get; set; }
        [FromServices]
        public UserManager<User> userManager { get; set; }

        public User UserCurrent { get; set; }

        public override void OnActionExecuting(ActionExecutingContext context)
        {
            base.OnActionExecuting(context);
            if (HttpContext.User.Identity.IsAuthenticated)
            {
                UserCurrent = DB.Users.Where(x => x.UserName == HttpContext.User.Identity.Name).SingleOrDefault();
                ViewBag.UserCurrent = UserCurrent;
            }
        }
    }
}
