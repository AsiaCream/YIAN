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
        [HttpGet]
        public IActionResult Error()
        {
            return View();
        }
        [HttpGet]
        public IActionResult Analysis()
        {
            var town = DB.Towns.OrderBy(x => x.Id).ToList();
            ViewBag.Town = town;
            return View();
        }
        [HttpGet]
        public IActionResult GetBar(int year,string town)
        {
            var RichCount = 0;
            var perso = DB.Familys
                .Where(x => x.TownId == DB.Towns.Where(y=>y.Title==town).SingleOrDefault().Id)
                .ToList();
            var rich = new List<Rich>();
            var poor = new List<Poor>();
            var richcount = new List<RichCount>();
            foreach(var x in perso)
            {
                var situation = DB.FamilySituations
                .Where(z=>z.FamilyId==x.Id)
                .SingleOrDefault();
                var membercount = DB.FamilyMembers.Where(i => i.FamilyId == x.Id).Count() + 1;
                if (situation != null)
                {
                    if ((situation.YearAnnualPerCapitaIncome * 12) / membercount > 2800)
                    {
                        richcount.Add(new RichCount
                        {
                            Count = RichCount + 1,
                        });
                        rich.Add(new Rich
                        {
                            Id = x.Id,
                            Income = (situation.YearAnnualPerCapitaIncome * 12) / membercount,
                        });
                    }
                    else
                    {
                        poor.Add(new Poor
                        {
                            Id = x.Id,
                            Income = (situation.YearAnnualPerCapitaIncome * 12) / membercount,
                        });
                    }
                }
                else
                {
                    return RedirectToAction("Error", "Home");
                }
            }
            ViewBag.Rich = rich;
            ViewBag.Poor = poor;
            ViewBag.RichCount = RichCount;
            ViewBag.Test1 = 999;
            ViewBag.Test2 = 800;
            return View();
        }
    }
}
