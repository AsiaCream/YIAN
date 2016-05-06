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
                    #region 垃圾循环法
                    foreach (var i in situation)
                    {
                        if (i.YearAnnualPerCapitaIncome > line && i.CreateTime.Month == 1)
                        {
                            rich.Add(new Rich
                            {
                                Id = i.Id,
                                Month = 1,
                                Income = i.YearAnnualPerCapitaIncome,
                            });
                        }
                        if (i.YearAnnualPerCapitaIncome < line && i.CreateTime.Month == 1)
                        {
                            poor.Add(new Poor
                            {
                                Id = i.Id,
                                Month = 1,
                                Income = i.YearAnnualPerCapitaIncome,
                            });
                        }
                        if (i.YearAnnualPerCapitaIncome > line && i.CreateTime.Month == 2)
                        {
                            rich.Add(new Rich
                            {
                                Id = i.Id,
                                Month = 2,
                                Income = i.YearAnnualPerCapitaIncome,
                            });
                        }
                        if (i.YearAnnualPerCapitaIncome < line && i.CreateTime.Month == 2)
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
                        if (i.YearAnnualPerCapitaIncome < line && i.CreateTime.Month == 3)
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
                        if (i.YearAnnualPerCapitaIncome < line && i.CreateTime.Month == 4)
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
                        if (i.YearAnnualPerCapitaIncome < line && i.CreateTime.Month == 5)
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
                        if (i.YearAnnualPerCapitaIncome < line && i.CreateTime.Month == 6)
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
                        if (i.YearAnnualPerCapitaIncome < line && i.CreateTime.Month == 7)
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
                        if (i.YearAnnualPerCapitaIncome < line && i.CreateTime.Month == 8)
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
                        if (i.YearAnnualPerCapitaIncome < line && i.CreateTime.Month == 9)
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
                        if (i.YearAnnualPerCapitaIncome < line && i.CreateTime.Month == 10)
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
                        if (i.YearAnnualPerCapitaIncome < line && i.CreateTime.Month == 11)
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
                        if (i.YearAnnualPerCapitaIncome < line && i.CreateTime.Month == 12)
                        {
                            poor.Add(new Poor
                            {
                                Id = i.Id,
                                Month = 12,
                                Income = i.YearAnnualPerCapitaIncome,
                            });
                        }
                    } 
                    #endregion
                }
                else
                {
                    return RedirectToAction("Error", "Home");
                }
            }
            #region Rich
            var RichJan = rich.Where(x => x.Month == 1).ToList();
            double num = 0;
            foreach (var x in RichJan)
            {
                num = x.Income + num;
            }
            ViewBag.RichJan = num / RichJan.Count();
            ViewBag.RichJanCount = RichJan.Count();
            num = 0;
            var RichFeb = rich.Where(x => x.Month == 2).ToList();
            foreach (var x in RichFeb)
            {
                num = x.Income + num;
            }
            ViewBag.RichFeb = num / RichFeb.Count();
            ViewBag.RichFebCount = RichFeb.Count();
            num = 0;
            var RichMar = rich.Where(x => x.Month == 3).ToList();
            foreach (var x in RichMar)
            {
                num = x.Income + num;
            }
            ViewBag.RichMar = num / RichMar.Count();
            ViewBag.RichMarCount = RichMar.Count();
            num = 0;
            var RichApr = rich.Where(x => x.Month == 4).ToList();
            foreach (var x in RichApr)
            {
                num = x.Income + num;
            }
            ViewBag.RichApr = num / RichApr.Count();
            ViewBag.RichAprCount = RichApr.Count();
            num = 0;
            var RichMay = rich.Where(x => x.Month == 5).ToList();
            foreach (var x in RichMay)
            {
                num = x.Income + num;
            }
            ViewBag.RichMay = num / RichMay.Count();
            ViewBag.RichMayCount = RichMay.Count();
            num = 0;
            var RichJun = rich.Where(x => x.Month == 6).ToList();
            foreach (var x in RichJun)
            {
                num = x.Income + num;
            }
            ViewBag.RichJun = num / RichJun.Count();
            ViewBag.RichJunCount = RichJun.Count();
            num = 0;
            var RichJul = rich.Where(x => x.Month == 7).ToList();
            foreach (var x in RichJul)
            {
                num = x.Income + num;
            }
            ViewBag.RichJul = num / RichJul.Count();
            ViewBag.RichJulCount = RichJul.Count();
            num = 0;
            var RichAug = rich.Where(x => x.Month == 8).ToList();
            foreach (var x in RichAug)
            {
                num = x.Income + num;
            }
            ViewBag.RichAug = num / RichAug.Count();
            ViewBag.RichAugCount = RichAug.Count();
            num = 0;
            var RichSep = rich.Where(x => x.Month == 9).ToList();
            foreach (var x in RichSep)
            {
                num = x.Income + num;
            }
            ViewBag.RichSep = num / RichSep.Count();
            ViewBag.RichSepCount = RichSep.Count();
            num = 0;
            var RichOct = rich.Where(x => x.Month == 10).ToList();
            foreach (var x in RichOct)
            {
                num = x.Income + num;
            }
            ViewBag.RichOct = num / RichOct.Count();
            ViewBag.RichOctCount = RichOct.Count();
            num = 0;
            var RichNov = rich.Where(x => x.Month == 11).ToList();
            foreach (var x in RichNov)
            {
                num = x.Income + num;
            }
            ViewBag.RichNov = num / RichNov.Count();
            ViewBag.RichNovCount = RichNov.Count();
            num = 0;
            var RichDec = rich.Where(x => x.Month == 12).ToList();
            foreach (var x in RichDec)
            {
                num = x.Income + num;
            }
            ViewBag.RichDec = num / RichDec.Count();
            ViewBag.RichDecCount = RichDec.Count();
            num = 0;
            #endregion
            #region Poor
            var PoorJan = poor.Where(x => x.Month == 1).ToList();
            foreach (var x in PoorJan)
            {
                num = x.Income + num;
            }
            ViewBag.PoorJan = num / PoorJan.Count();
            num = 0;
            var PoorFeb = poor.Where(x => x.Month == 2).ToList();
            foreach (var x in PoorFeb)
            {
                num = x.Income + num;
            }
            ViewBag.PoorFeb = num / PoorFeb.Count();
            num = 0;
            var PoorMar = poor.Where(x => x.Month == 3).ToList();
            foreach (var x in PoorMar)
            {
                num = x.Income + num;
            }
            ViewBag.PoorMar = num / PoorMar.Count();
            num = 0;
            var PoorApr = poor.Where(x => x.Month == 4).ToList();
            foreach (var x in PoorApr)
            {
                num = x.Income + num;
            }
            ViewBag.PoorApr = num / PoorApr.Count();
            num = 0;
            var PoorMay = poor.Where(x => x.Month == 5).ToList();
            foreach (var x in PoorMay)
            {
                num = x.Income + num;
            }
            ViewBag.PoorMay = num / PoorMay.Count();
            num = 0;
            var PoorJun = poor.Where(x => x.Month == 6).ToList();
            foreach (var x in PoorJun)
            {
                num = x.Income + num;
            }
            ViewBag.PoorJun = num / PoorJun.Count();
            num = 0;
            var PoorJul = poor.Where(x => x.Month == 7).ToList();
            foreach (var x in PoorJul)
            {
                num = x.Income + num;
            }
            ViewBag.PoorJul = num / PoorJul.Count();
            num = 0;
            var PoorAug = poor.Where(x => x.Month == 8).ToList();
            foreach (var x in PoorAug)
            {
                num = x.Income + num;
            }
            ViewBag.PoorAug = num / PoorAug.Count();
            num = 0;
            var PoorSep = poor.Where(x => x.Month == 9).ToList();
            foreach (var x in PoorSep)
            {
                num = x.Income + num;
            }
            ViewBag.PoorSep = num / PoorSep.Count();
            num = 0;
            var PoorOct = poor.Where(x => x.Month == 10).ToList();
            foreach (var x in PoorOct)
            {
                num = x.Income + num;
            }
            ViewBag.PoorOct = num / PoorOct.Count();
            num = 0;
            var PoorNov = poor.Where(x => x.Month == 11).ToList();
            foreach (var x in PoorNov)
            {
                num = x.Income + num;
            }
            ViewBag.PoorNov = num / PoorNov.Count();
            num = 0;
            var PoorDec = poor.Where(x => x.Month == 12).ToList();
            foreach (var x in PoorDec)
            {
                num = x.Income + num;
            }
            ViewBag.PoorDec = num / PoorDec.Count();
            num = 0;
            #endregion
            ViewBag.Town = villege;
            ViewBag.LowLine = line;
            return View();
        }
        /// <summary>
        /// 数据统计页面
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult Statistics()
        {
            return View();
        }
    }
}
