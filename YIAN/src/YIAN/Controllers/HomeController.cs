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
        public IActionResult GetBar(int year, string town)
        {
            var line = DB.LowLines
                .Where(x => x.Id == 1)
                .SingleOrDefault()
                .Line;
            var villege = DB.Towns
                 .Where(x => x.Title == town)
                 .SingleOrDefault();
            var perso = DB.Familys
                .Where(x => x.TownId == villege.Id)
                .ToList();
            var rich = new List<Rich>();
            var poor = new List<Poor>();
            foreach (var x in perso)
            {
                var situation = DB.FamilySituations
                .Where(z => z.CreateTime.Year == year)
                .Where(z => z.FamilyId == x.Id)
                .ToList();
                var membercount = DB.FamilyMembers.Where(i => i.FamilyId == x.Id).Count() + DB.Familys.Where(i => i.Id == x.Id).Count();
                if (situation.Count() != 0)
                {
                    foreach (var i in situation)
                    {
                        if (i.YearAnnualPerCapitaIncome > line&&i.CreateTime.Month==1)
                        {
                            rich.Add(new Rich
                            {
                                Id = i.Id,
                                Month=1,
                                Income = i.YearAnnualPerCapitaIncome,
                            });
                        }
                        else if (i.YearAnnualPerCapitaIncome < line && i.CreateTime.Month == 1)
                        {
                            poor.Add(new Poor
                            {
                                Id = i.Id,
                                Month = 1,
                                Income = i.YearAnnualPerCapitaIncome,
                            });
                        }
                        if(i.YearAnnualPerCapitaIncome > line && i.CreateTime.Month == 2)
                        {
                            rich.Add(new Rich
                            {
                                Id = i.Id,
                                Month = 2,
                                Income = i.YearAnnualPerCapitaIncome,
                            });
                        }
                        else if (i.YearAnnualPerCapitaIncome < line && i.CreateTime.Month == 2)
                        {
                            poor.Add(new Poor
                            {
                                Id = i.Id,
                                Month = 2,
                                Income = i.YearAnnualPerCapitaIncome,
                            });
                        }
                        if (i.YearAnnualPerCapitaIncome > line && i.CreateTime.Month == 3)
                        {
                            rich.Add(new Rich
                            {
                                Id = i.Id,
                                Month = 3,
                                Income = i.YearAnnualPerCapitaIncome,
                            });
                        }
                        else if (i.YearAnnualPerCapitaIncome < line && i.CreateTime.Month == 3)
                        {
                            poor.Add(new Poor
                            {
                                Id = i.Id,
                                Month = 3,
                                Income = i.YearAnnualPerCapitaIncome,
                            });
                        }
                        if (i.YearAnnualPerCapitaIncome > line && i.CreateTime.Month == 4)
                        {
                            rich.Add(new Rich
                            {
                                Id = i.Id,
                                Month = 4,
                                Income = i.YearAnnualPerCapitaIncome,
                            });
                        }
                        else if (i.YearAnnualPerCapitaIncome < line && i.CreateTime.Month == 4)
                        {
                            poor.Add(new Poor
                            {
                                Id = i.Id,
                                Month = 4,
                                Income = i.YearAnnualPerCapitaIncome,
                            });
                        }
                        if (i.YearAnnualPerCapitaIncome > line && i.CreateTime.Month == 5)
                        {
                            rich.Add(new Rich
                            {
                                Id = i.Id,
                                Month = 5,
                                Income = i.YearAnnualPerCapitaIncome,
                            });
                        }
                        else if (i.YearAnnualPerCapitaIncome < line && i.CreateTime.Month == 5)
                        {
                            poor.Add(new Poor
                            {
                                Id = i.Id,
                                Month = 5,
                                Income = i.YearAnnualPerCapitaIncome,
                            });
                        }
                        if (i.YearAnnualPerCapitaIncome > line && i.CreateTime.Month == 6)
                        {
                            rich.Add(new Rich
                            {
                                Id = i.Id,
                                Month = 6,
                                Income = i.YearAnnualPerCapitaIncome,
                            });
                        }
                        else if (i.YearAnnualPerCapitaIncome < line && i.CreateTime.Month == 6)
                        {
                            poor.Add(new Poor
                            {
                                Id = i.Id,
                                Month = 6,
                                Income = i.YearAnnualPerCapitaIncome,
                            });
                        }
                        if (i.YearAnnualPerCapitaIncome > line && i.CreateTime.Month == 7)
                        {
                            rich.Add(new Rich
                            {
                                Id = i.Id,
                                Month = 7,
                                Income = i.YearAnnualPerCapitaIncome,
                            });
                        }
                        else if (i.YearAnnualPerCapitaIncome < line && i.CreateTime.Month == 7)
                        {
                            poor.Add(new Poor
                            {
                                Id = i.Id,
                                Month = 7,
                                Income = i.YearAnnualPerCapitaIncome,
                            });
                        }
                        if (i.YearAnnualPerCapitaIncome > line && i.CreateTime.Month == 8)
                        {
                            rich.Add(new Rich
                            {
                                Id = i.Id,
                                Month = 8,
                                Income = i.YearAnnualPerCapitaIncome,
                            });
                        }
                        else if (i.YearAnnualPerCapitaIncome < line && i.CreateTime.Month == 8)
                        {
                            poor.Add(new Poor
                            {
                                Id = i.Id,
                                Month = 8,
                                Income = i.YearAnnualPerCapitaIncome,
                            });
                        }
                        if (i.YearAnnualPerCapitaIncome > line && i.CreateTime.Month == 9)
                        {
                            rich.Add(new Rich
                            {
                                Id = i.Id,
                                Month = 9,
                                Income = i.YearAnnualPerCapitaIncome,
                            });
                        }
                        else if (i.YearAnnualPerCapitaIncome < line && i.CreateTime.Month == 9)
                        {
                            poor.Add(new Poor
                            {
                                Id = i.Id,
                                Month = 9,
                                Income = i.YearAnnualPerCapitaIncome,
                            });
                        }
                        if (i.YearAnnualPerCapitaIncome > line && i.CreateTime.Month == 10)
                        {
                            rich.Add(new Rich
                            {
                                Id = i.Id,
                                Month = 10,
                                Income = i.YearAnnualPerCapitaIncome,
                            });
                        }
                        else if (i.YearAnnualPerCapitaIncome < line && i.CreateTime.Month == 10)
                        {
                            poor.Add(new Poor
                            {
                                Id = i.Id,
                                Month = 10,
                                Income = i.YearAnnualPerCapitaIncome,
                            });
                        }
                        if (i.YearAnnualPerCapitaIncome > line && i.CreateTime.Month == 11)
                        {
                            rich.Add(new Rich
                            {
                                Id = i.Id,
                                Month = 11,
                                Income = i.YearAnnualPerCapitaIncome,
                            });
                        }
                        else if (i.YearAnnualPerCapitaIncome < line && i.CreateTime.Month == 11)
                        {
                            poor.Add(new Poor
                            {
                                Id = i.Id,
                                Month = 11,
                                Income = i.YearAnnualPerCapitaIncome,
                            });
                        }
                        if (i.YearAnnualPerCapitaIncome > line && i.CreateTime.Month == 12)
                        {
                            rich.Add(new Rich
                            {
                                Id = i.Id,
                                Month = 12,
                                Income = i.YearAnnualPerCapitaIncome,
                            });
                        }
                        else
                        {
                            poor.Add(new Poor
                            {
                                Id = i.Id,
                                Month = 12,
                                Income = i.YearAnnualPerCapitaIncome,
                            });
                        }
                    }
                }
                else
                {
                    return RedirectToAction("Error", "Home");
                }
            }
            ViewBag.Town = villege;
            //double totalrichincome = 0;
            //double totalpoorincome = 0;
            int RCount = rich.Count();
            int PCount = poor.Count();
            //foreach (var x in rich)
            //{
            //    totalrichincome = totalrichincome + x.Income;
            //};
            //foreach (var x in poor)
            //{
            //    totalpoorincome = totalpoorincome + x.Income;
            //}
            //ViewBag.Poor = Math.Round(totalpoorincome / PCount,2);
            //ViewBag.Rich = Math.Round(totalrichincome / RCount,2);
            ViewBag.Poor = poor;
            ViewBag.Rich = rich;
            ViewBag.RichCount = RCount + 1000;
            ViewBag.LowLine = line;
            return View();
        }
    }
}
