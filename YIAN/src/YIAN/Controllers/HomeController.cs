using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Mvc;
using YIAN.Models;
using YIAN.ViewModels;


namespace YIAN.Controllers
{
    public class HomeController : BaseController
    {
        public IActionResult Index()
        {
            
            return View();
        }
        /// <summary>
        /// 错误页面
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult Error()
        {
            return View();
        }
        /// <summary>
        /// 数据分析页面
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult Analysis()
        {
            var town = DB.Towns.OrderBy(x => x.Id).ToList();
            ViewBag.Town = town;
            ViewBag.LowLine = DB.LowLines.SingleOrDefault(x => x.Id == 1);
            return View();
        }
        /// <summary>
        /// 数据分析查询页面
        /// </summary>
        /// <param name="year"></param>
        /// <param name="town"></param>
        /// <returns></returns>
        [HttpGet]
        public IActionResult GetBar(int year,string town)
        {
            var line= DB.LowLines.Where(x => x.Id == 1).SingleOrDefault().Line;
            var villege = DB.Towns
                 .Where(x => x.Title == town)
                 .SingleOrDefault();
            var perso = DB.Familys
                .Where(x => x.TownId == villege.Id)
                .ToList();
            var rich = new List<Rich>();
            var poor = new List<Poor>();
            foreach(var x in perso)
            {
                var situation = DB.FamilySituations
                .Where(z=>z.FamilyId==x.Id)
                .SingleOrDefault();
                var membercount = DB.FamilyMembers.Where(i => i.FamilyId == x.Id).Count() + DB.Familys.Where(i=>i.Id==x.Id).Count();
                if (situation != null)
                {
                    if ((situation.YearAnnualPerCapitaIncome) > line)
                    {
                        
                        rich.Add(new Rich
                        {
                            Id = x.Id,
                            Income = (situation.YearAnnualPerCapitaIncome),
                        });
                    }
                    else
                    {
                        poor.Add(new Poor
                        {
                            Id = x.Id,
                            Income = (situation.YearAnnualPerCapitaIncome),
                        });
                    }
                }
                else
                {
                    return RedirectToAction("Error", "Home");
                }
            }
            ViewBag.Town = villege;
            double totalrichincome = 0;
            double totalpoorincome = 0;
            int RCount = 0;
            int PCount = 0;
            foreach(var x in rich)
            {
                totalrichincome = totalrichincome + x.Income;
                RCount++;

            };
            foreach(var x in poor)
            {
                totalpoorincome = totalpoorincome + x.Income;
                PCount++;
            }
            ViewBag.Poor = totalpoorincome / PCount;
            ViewBag.Rich = totalrichincome / RCount;
            ViewBag.RichCount = RCount + 1000;
            ViewBag.LowLine = line;
            return View();
        }
    }
}
