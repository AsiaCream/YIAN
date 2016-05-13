using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Mvc;
using YIAN.Models;
using YIAN.ViewModels;
using Microsoft.Data.Entity;

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
            var line = DB.LowLines.SingleOrDefault(x => x.Id == 1).Line;
            ViewBag.LowLine = line;

            var perso = DB.Familys
                .OrderByDescending(x => x.TownId)
                .ToList();
            var rich = new List<Rich>();
            var poor = new List<Poor>();
            foreach (var x in perso)
            {
                var situation = DB.FamilySituations
                .Where(z => z.CreateTime.Year == DateTime.Now.Year)
                .Where(z => z.FamilyId == x.Id)
                .ToList();
                var membercount = DB.FamilyMembers.Where(i => i.FamilyId == x.Id).Count() + DB.Familys.Where(i => i.Id == x.Id).Count();
                
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
            #region Rich
            var RichJan = rich.Where(x => x.Month == 1).ToList();
            double num = 0;
            foreach (var x in RichJan)
            {
                num = x.Income + num;
            }
            ViewBag.AllRichJan = Math.Round(num / RichJan.Count(), 2);
            ViewBag.AllRichJanCount = RichJan.Count();
            num = 0;
            var RichFeb = rich.Where(x => x.Month == 2).ToList();
            foreach (var x in RichFeb)
            {
                num = x.Income + num;
            }
            ViewBag.AllRichFeb = Math.Round(num / RichFeb.Count(), 2);
            ViewBag.AllRichFebCount = RichFeb.Count();
            num = 0;
            var RichMar = rich.Where(x => x.Month == 3).ToList();
            foreach (var x in RichMar)
            {
                num = x.Income + num;
            }
            ViewBag.AllRichMar = Math.Round(num / RichMar.Count(), 2);
            ViewBag.AllRichMarCount = RichMar.Count();
            num = 0;
            var RichApr = rich.Where(x => x.Month == 4).ToList();
            foreach (var x in RichApr)
            {
                num = x.Income + num;
            }
            ViewBag.AllRichApr = Math.Round(num / RichApr.Count(), 2);
            ViewBag.AllRichAprCount = RichApr.Count();
            num = 0;
            var RichMay = rich.Where(x => x.Month == 5).ToList();
            foreach (var x in RichMay)
            {
                num = x.Income + num;
            }
            ViewBag.AllRichMay = Math.Round(num / RichMay.Count(), 2);
            ViewBag.AllRichMayCount = RichMay.Count();
            num = 0;
            var RichJun = rich.Where(x => x.Month == 6).ToList();
            foreach (var x in RichJun)
            {
                num = x.Income + num;
            }
            ViewBag.AllRichJun = Math.Round(num / RichJun.Count(), 2);
            ViewBag.AllRichJunCount = RichJun.Count();
            num = 0;
            var RichJul = rich.Where(x => x.Month == 7).ToList();
            foreach (var x in RichJul)
            {
                num = x.Income + num;
            }
            ViewBag.AllRichJul = Math.Round(num / RichJul.Count(), 2);
            ViewBag.AllRichJulCount = RichJul.Count();
            num = 0;
            var RichAug = rich.Where(x => x.Month == 8).ToList();
            foreach (var x in RichAug)
            {
                num = x.Income + num;
            }
            ViewBag.AllRichAug = Math.Round(num / RichAug.Count(), 2);
            ViewBag.AllRichAugCount = RichAug.Count();
            num = 0;
            var RichSep = rich.Where(x => x.Month == 9).ToList();
            foreach (var x in RichSep)
            {
                num = x.Income + num;
            }
            ViewBag.AllRichSep = Math.Round(num / RichSep.Count(), 2);
            ViewBag.AllRichSepCount = RichSep.Count();
            num = 0;
            var RichOct = rich.Where(x => x.Month == 10).ToList();
            foreach (var x in RichOct)
            {
                num = x.Income + num;
            }
            ViewBag.AllRichOct = Math.Round(num / RichOct.Count(), 2);
            ViewBag.AllRichOctCount = RichOct.Count();
            num = 0;
            var RichNov = rich.Where(x => x.Month == 11).ToList();
            foreach (var x in RichNov)
            {
                num = x.Income + num;
            }
            ViewBag.AllRichNov = Math.Round(num / RichNov.Count(), 2);
            ViewBag.AllRichNovCount = RichNov.Count();
            num = 0;
            var RichDec = rich.Where(x => x.Month == 12).ToList();
            foreach (var x in RichDec)
            {
                num = x.Income + num;
            }
            ViewBag.AllRichDec = Math.Round(num / RichDec.Count(), 2);
            ViewBag.AllRichDecCount = RichDec.Count();
            num = 0;
            #endregion
            #region Poor
            var PoorJan = poor.Where(x => x.Month == 1).ToList();
            foreach (var x in PoorJan)
            {
                num = x.Income + num;
            }
            ViewBag.AllPoorJan = Math.Round(num / PoorJan.Count(), 2);
            num = 0;
            var PoorFeb = poor.Where(x => x.Month == 2).ToList();
            foreach (var x in PoorFeb)
            {
                num = x.Income + num;
            }
            ViewBag.AllPoorFeb = Math.Round(num / PoorFeb.Count(), 2);
            num = 0;
            var PoorMar = poor.Where(x => x.Month == 3).ToList();
            foreach (var x in PoorMar)
            {
                num = x.Income + num;
            }
            ViewBag.AllPoorMar = Math.Round(num / PoorMar.Count(), 2);
            num = 0;
            var PoorApr = poor.Where(x => x.Month == 4).ToList();
            foreach (var x in PoorApr)
            {
                num = x.Income + num;
            }
            ViewBag.AllPoorApr = Math.Round(num / PoorApr.Count(), 2);
            num = 0;
            var PoorMay = poor.Where(x => x.Month == 5).ToList();
            foreach (var x in PoorMay)
            {
                num = x.Income + num;
            }
            ViewBag.AllPoorMay = Math.Round(num / PoorMay.Count(), 2);
            num = 0;
            var PoorJun = poor.Where(x => x.Month == 6).ToList();
            foreach (var x in PoorJun)
            {
                num = x.Income + num;
            }
            ViewBag.AllPoorJun = Math.Round(num / PoorJun.Count(), 2);
            num = 0;
            var PoorJul = poor.Where(x => x.Month == 7).ToList();
            foreach (var x in PoorJul)
            {
                num = x.Income + num;
            }
            ViewBag.AllPoorJul = Math.Round(num / PoorJul.Count(), 2);
            num = 0;
            var PoorAug = poor.Where(x => x.Month == 8).ToList();
            foreach (var x in PoorAug)
            {
                num = x.Income + num;
            }
            ViewBag.AllPoorAug = Math.Round(num / PoorAug.Count(), 2);
            num = 0;
            var PoorSep = poor.Where(x => x.Month == 9).ToList();
            foreach (var x in PoorSep)
            {
                num = x.Income + num;
            }
            ViewBag.AllPoorSep = Math.Round(num / PoorSep.Count(), 2);
            num = 0;
            var PoorOct = poor.Where(x => x.Month == 10).ToList();
            foreach (var x in PoorOct)
            {
                num = x.Income + num;
            }
            ViewBag.AllPoorOct = Math.Round(num / PoorOct.Count(), 2);
            num = 0;
            var PoorNov = poor.Where(x => x.Month == 11).ToList();
            foreach (var x in PoorNov)
            {
                num = x.Income + num;
            }
            ViewBag.AllPoorNov = Math.Round(num / PoorNov.Count(),2);
            num = 0;
            var PoorDec = poor.Where(x => x.Month == 12).ToList();
            foreach (var x in PoorDec)
            {
                num = x.Income + num;
            }
            ViewBag.AllPoorDec = Math.Round(num / PoorDec.Count(), 2);
            num = 0;
            #endregion
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
            #region Rich
            var RichJan = rich.Where(x => x.Month == 1).ToList();
            double num = 0;
            foreach (var x in RichJan)
            {
                num = x.Income + num;
            }
            ViewBag.RichJan = Math.Round(num / RichJan.Count(), 2);
            ViewBag.RichJanCount = RichJan.Count();
            num = 0;
            var RichFeb = rich.Where(x => x.Month == 2).ToList();
            foreach (var x in RichFeb)
            {
                num = x.Income + num;
            }
            ViewBag.RichFeb = Math.Round(num / RichFeb.Count(), 2);
            ViewBag.RichFebCount = RichFeb.Count();
            num = 0;
            var RichMar = rich.Where(x => x.Month == 3).ToList();
            foreach (var x in RichMar)
            {
                num = x.Income + num;
            }
            ViewBag.RichMar = Math.Round(num / RichMar.Count(), 2);
            ViewBag.RichMarCount = RichMar.Count();
            num = 0;
            var RichApr = rich.Where(x => x.Month == 4).ToList();
            foreach (var x in RichApr)
            {
                num = x.Income + num;
            }
            ViewBag.RichApr = Math.Round(num / RichApr.Count(), 2);
            ViewBag.RichAprCount = RichApr.Count();
            num = 0;
            var RichMay = rich.Where(x => x.Month == 5).ToList();
            foreach (var x in RichMay)
            {
                num = x.Income + num;
            }
            ViewBag.RichMay = Math.Round(num / RichMay.Count(), 2);
            ViewBag.RichMayCount = RichMay.Count();
            num = 0;
            var RichJun = rich.Where(x => x.Month == 6).ToList();
            foreach (var x in RichJun)
            {
                num = x.Income + num;
            }
            ViewBag.RichJun = Math.Round(num / RichJun.Count(), 2);
            ViewBag.RichJunCount = RichJun.Count();
            num = 0;
            var RichJul = rich.Where(x => x.Month == 7).ToList();
            foreach (var x in RichJul)
            {
                num = x.Income + num;
            }
            ViewBag.RichJul = Math.Round(num / RichJul.Count(), 2);
            ViewBag.RichJulCount = RichJul.Count();
            num = 0;
            var RichAug = rich.Where(x => x.Month == 8).ToList();
            foreach (var x in RichAug)
            {
                num = x.Income + num;
            }
            ViewBag.RichAug = Math.Round(num / RichAug.Count(), 2);
            ViewBag.RichAugCount = RichAug.Count();
            num = 0;
            var RichSep = rich.Where(x => x.Month == 9).ToList();
            foreach (var x in RichSep)
            {
                num = x.Income + num;
            }
            ViewBag.RichSep = Math.Round(num / RichSep.Count(), 2);
            ViewBag.RichSepCount = RichSep.Count();
            num = 0;
            var RichOct = rich.Where(x => x.Month == 10).ToList();
            foreach (var x in RichOct)
            {
                num = x.Income + num;
            }
            ViewBag.RichOct = Math.Round(num / RichOct.Count(), 2);
            ViewBag.RichOctCount = RichOct.Count();
            num = 0;
            var RichNov = rich.Where(x => x.Month == 11).ToList();
            foreach (var x in RichNov)
            {
                num = x.Income + num;
            }
            ViewBag.RichNov = Math.Round(num / RichNov.Count(), 2);
            ViewBag.RichNovCount = RichNov.Count();
            num = 0;
            var RichDec = rich.Where(x => x.Month == 12).ToList();
            foreach (var x in RichDec)
            {
                num = x.Income + num;
            }
            ViewBag.RichDec = Math.Round(num / RichDec.Count(), 2);
            ViewBag.RichDecCount = RichDec.Count();
            num = 0;
            #endregion
            #region Poor
            var PoorJan = poor.Where(x => x.Month == 1).ToList();
            foreach (var x in PoorJan)
            {
                num = x.Income + num;
            }
            ViewBag.PoorJan = Math.Round(num / PoorJan.Count(), 2);
            num = 0;
            var PoorFeb = poor.Where(x => x.Month == 2).ToList();
            foreach (var x in PoorFeb)
            {
                num = x.Income + num;
            }
            ViewBag.PoorFeb = Math.Round(num / PoorFeb.Count(), 2);
            num = 0;
            var PoorMar = poor.Where(x => x.Month == 3).ToList();
            foreach (var x in PoorMar)
            {
                num = x.Income + num;
            }
            ViewBag.PoorMar = Math.Round(num / PoorMar.Count(), 2);
            num = 0;
            var PoorApr = poor.Where(x => x.Month == 4).ToList();
            foreach (var x in PoorApr)
            {
                num = x.Income + num;
            }
            ViewBag.PoorApr = Math.Round(num / PoorApr.Count(), 2);
            num = 0;
            var PoorMay = poor.Where(x => x.Month == 5).ToList();
            foreach (var x in PoorMay)
            {
                num = x.Income + num;
            }
            ViewBag.PoorMay = Math.Round(num / PoorMay.Count(), 2);
            num = 0;
            var PoorJun = poor.Where(x => x.Month == 6).ToList();
            foreach (var x in PoorJun)
            {
                num = x.Income + num;
            }
            ViewBag.PoorJun = Math.Round(num / PoorJun.Count(), 2);
            num = 0;
            var PoorJul = poor.Where(x => x.Month == 7).ToList();
            foreach (var x in PoorJul)
            {
                num = x.Income + num;
            }
            ViewBag.PoorJul = Math.Round(num / PoorJul.Count(), 2);
            num = 0;
            var PoorAug = poor.Where(x => x.Month == 8).ToList();
            foreach (var x in PoorAug)
            {
                num = x.Income + num;
            }
            ViewBag.PoorAug = Math.Round(num / PoorAug.Count(), 2);
            num = 0;
            var PoorSep = poor.Where(x => x.Month == 9).ToList();
            foreach (var x in PoorSep)
            {
                num = x.Income + num;
            }
            ViewBag.PoorSep = Math.Round(num / PoorSep.Count(), 2);
            num = 0;
            var PoorOct = poor.Where(x => x.Month == 10).ToList();
            foreach (var x in PoorOct)
            {
                num = x.Income + num;
            }
            ViewBag.PoorOct = Math.Round(num / PoorOct.Count(), 2);
            num = 0;
            var PoorNov = poor.Where(x => x.Month == 11).ToList();
            foreach (var x in PoorNov)
            {
                num = x.Income + num;
            }
            ViewBag.PoorNov = Math.Round(num / PoorNov.Count(), 2);
            num = 0;
            var PoorDec = poor.Where(x => x.Month == 12).ToList();
            foreach (var x in PoorDec)
            {
                num = x.Income + num;
            }
            ViewBag.PoorDec = Math.Round(num / PoorDec.Count(), 2);
            num = 0;
            #endregion
            ViewBag.Town = villege;
            ViewBag.LowLine = line;
            ViewBag.Year = year;
            return View();
        }
        /// <summary>
        /// 数据查询具体用户列表显示
        /// </summary>
        /// <param name="townid">村镇ID</param>
        /// <param name="year">查询年份</param>
        /// <param name="month">查询月份</param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult GetBarRich(int townid,int year,int month)
        {
            var line = DB.LowLines
                .Where(x => x.Id == 1)
                .SingleOrDefault()
                .Line;
            var perso = DB.Familys
                .Where(x => x.TownId == townid)
                .ToList();
            var rich = new List<Rich>();
            foreach (var x in perso)
            {
                var situation = DB.FamilySituations
                .Include(z=>z.Family)
                .Where(z => z.CreateTime.Year == year)
                .Where(z => z.FamilyId == x.Id)
                .ToList();
                var membercount = DB.FamilyMembers.Where(i => i.FamilyId == x.Id).Count() + DB.Familys.Where(i => i.Id == x.Id).Count();
                if (situation.Count() != 0)
                {
                    #region 垃圾循环法
                    foreach (var i in situation)
                    {
                        if (i.YearAnnualPerCapitaIncome > line && i.CreateTime.Month == month)
                        {
                            rich.Add(new Rich
                            {
                                Id = DB.Familys.Where(j => j.Id == i.Family.Id).SingleOrDefault().Id,
                                Month = month,
                                Income = Math.Round(i.YearAnnualPerCapitaIncome,2),
                                Host = DB.Familys.Where(j => j.Id == i.Family.Id).SingleOrDefault().Name,
                                Town = DB.Towns.Where(j => j.Id == townid).SingleOrDefault().Title,
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
            
            return View(rich);
        }
        /// <summary>
        /// 具体脱贫用户
        /// </summary>
        /// <param name="townid"></param>
        /// <param name="year"></param>
        /// <param name="month"></param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult GetBarPoor(int townid,int year,int month)
        {
            var line = DB.LowLines
                .Where(x => x.Id == 1)
                .SingleOrDefault()
                .Line;
            var perso = DB.Familys
                .Where(x => x.TownId == townid)
                .ToList();
            var poor = new List<Poor>();
            foreach (var x in perso)
            {
                var situation = DB.FamilySituations
                .Include(z => z.Family)
                .Where(z => z.CreateTime.Year == year)
                .Where(z => z.FamilyId == x.Id)
                .ToList();
                var membercount = DB.FamilyMembers.Where(i => i.FamilyId == x.Id).Count() + DB.Familys.Where(i => i.Id == x.Id).Count();
                if (situation.Count() != 0)
                {
                    #region 垃圾循环法
                    foreach (var i in situation)
                    {
                        if (i.YearAnnualPerCapitaIncome < line && i.CreateTime.Month == month)
                        {
                            poor.Add(new Poor
                            {
                                Id = DB.Familys.Where(j => j.Id == i.Family.Id).SingleOrDefault().Id,
                                Month = month,
                                Income = Math.Round(i.YearAnnualPerCapitaIncome, 2),
                                Host = DB.Familys.Where(j => j.Id == i.Family.Id).SingleOrDefault().Name,
                                Town = DB.Towns.Where(j => j.Id == townid).SingleOrDefault().Title,
                                Reason=i.PoorReason,
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

            return View(poor);
        }
        /// <summary>
        /// 用户详细家庭情况列表
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        public IActionResult SituationDetails(int id)
        {
            var situation = DB.FamilySituations
                .Where(x => x.FamilyId == id)
                .OrderBy(x=>x.CreateTime)
                .ToList();
            return View(situation);
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
        /// <summary>
        /// 农用四轮机扇形图
        /// </summary>
        /// <param name="selectyear"></param>
        /// <param name="selectmonth"></param>
        /// <param name="startyear"></param>
        /// <param name="startmonth"></param>
        /// <param name="endyear"></param>
        /// <param name="endmonth"></param>
        /// <returns></returns>
        [HttpGet]
        public IActionResult GetFourTurbines(int selectyear,int selectmonth)
        {
            //先找村镇
            var town = DB.Towns
                .OrderBy(x => x.Id)
                .ToList();
            var ret = new List<SituationPie>();
            foreach (var x in town)
            {
                var person = DB.Familys
                .Where(y => y.TownId == x.Id)
                .OrderBy(y => y.TownId)
                .ToList();
                foreach(var y in person)
                {
                    var fourturbines = DB.FamilySituations
                        .Include(z=>z.Family)
                        .Where(z => z.FamilyId == y.Id)
                        .OrderBy(z => z.Family.TownId)
                        .ToList();
                        foreach (var z in fourturbines)
                        {
                            if (z.CreateTime.Year == selectyear && z.CreateTime.Month == selectmonth)
                            {
                                
                                ret.Add(new SituationPie
                                {
                                    Id = z.Id,
                                    Type = "农用四轮机",
                                    Time = selectyear + "/" + selectmonth,
                                    Town = DB.Towns.Where(i => i.Id == z.Family.TownId).SingleOrDefault().Title,
                                    Count=z.FourTurbines,
                                });
                            }
                        }
                        
                    
                }
            }
            ViewBag.Ret = ret;
            ViewBag.Time = selectyear + "/" + selectmonth;
            double? number = 0;
            foreach (var x in ret)
            {
                if (x.Town == "长安村")
                {
                    number = x.Count+number;
                }
            }
            ViewBag.One = number;
            number = 0;
            foreach (var x in ret)
            {
                if (x.Town == "精进村")
                {
                    number += x.Count;
                }
            }
            ViewBag.Two = number;
            number = 0;
            foreach (var x in ret)
            {
                if (x.Town == "东风村")
                {
                    number += x.Count;
                }
            }
            ViewBag.Three = number;
            number = 0;
            foreach (var x in ret)
            {
                if (x.Town == "民利村")
                {
                    number += x.Count;
                }
            }
            ViewBag.Four = number;
            number = 0;
            foreach (var x in ret)
            {
                if (x.Town == "龙泉村")
                {
                    number += x.Count;
                }
            }
            ViewBag.Five = number;
            number = 0;
            foreach (var x in ret)
            {
                if (x.Town == "福德村")
                {
                    number += x.Count;
                }
            }
            ViewBag.Six = number;
            number = 0;
            foreach (var x in ret)
            {
                if (x.Town == "和乐村")
                {
                    number += x.Count;
                }
            }
            ViewBag.Seven = number;
            number = 0;
            foreach (var x in ret)
            {
                if (x.Town == "德宝村")
                {
                    number += x.Count;
                }
            }
            ViewBag.Eight = number;
            number = 0;
            foreach (var x in ret)
            {
                if (x.Town == "祥顺村")
                {
                    number += x.Count;
                }
            }
            ViewBag.Nine = number;
            number = 0;
            foreach (var x in ret)
            {
                if (x.Town == "诚顺村")
                {
                    number += x.Count;
                }
            }
            ViewBag.Ten = number;
            number = 0;

            return View();
        }
        /// <summary>
        /// 农机具扇形图
        /// </summary>
        /// <param name="selectyear"></param>
        /// <param name="selectmonth"></param>
        /// <returns></returns>
        [HttpGet]
        public IActionResult GetAgriculturalMachinery(int selectyear,int selectmonth)
        {
            var town = DB.Towns
                .OrderBy(x => x.Id)
                .ToList();
            var ret = new List<SituationPie>();
            foreach(var x in town)
            {
                var person = DB.Familys
                    .Where(y => y.TownId == x.Id)
                    .OrderBy(y => y.TownId)
                    .ToList();
                foreach(var y in person)
                {
                    var agriculturalMachinery = DB.FamilySituations
                        .Include(z=>z.Family)
                        .Where(z => z.FamilyId == y.Id)
                        .OrderBy(z => z.Family.TownId)
                        .ToList();
                    foreach(var z in agriculturalMachinery)
                    {
                        if(z.CreateTime.Year == selectyear && z.CreateTime.Month == selectmonth)
                        {
                            ret.Add(new SituationPie
                            {
                                Id = z.Id,
                                Type = "农机具",
                                Time = selectyear+"/"+selectmonth,
                                Town = DB.Towns.Where(i=>i.Id == z.Family.TownId).SingleOrDefault().Title,
                                Count = z.AgriculturalMachinery,
                            });
                        }
                    }
                }
            }
            ViewBag.Ret = ret;
            ViewBag.Time = selectyear + "/" + selectmonth;
            var number = 0;
            foreach (var x in ret)
            {
                if (x.Town == "长安村")
                {
                    number += x.Count;
                }
            }
            ViewBag.One = number;
            number = 0;
            foreach (var x in ret)
            {
                if (x.Town == "精进村")
                {
                    number += x.Count;
                }
            }
            ViewBag.Two = number;
            number = 0;
            foreach (var x in ret)
            {
                if (x.Town == "东风村")
                {
                    number += x.Count;
                }
            }
            ViewBag.Three = number;
            number = 0;
            foreach (var x in ret)
            {
                if (x.Town == "民利村")
                {
                    number += x.Count;
                }
            }
            ViewBag.Four = number;
            number = 0;
            foreach (var x in ret)
            {
                if (x.Town == "龙泉村")
                {
                    number += x.Count;
                }
            }
            ViewBag.Five = number;
            number = 0;
            foreach (var x in ret)
            {
                if (x.Town == "福德村")
                {
                    number += x.Count;
                }
            }
            ViewBag.Six = number;
            number = 0;
            foreach (var x in ret)
            {
                if (x.Town == "和乐村")
                {
                    number += x.Count;
                }
            }
            ViewBag.Seven = number;
            number = 0;
            foreach (var x in ret)
            {
                if (x.Town == "德宝村")
                {
                    number += x.Count;
                }
            }
            ViewBag.Eight = number;
            number = 0;
            foreach (var x in ret)
            {
                if (x.Town == "祥顺村")
                {
                    number += x.Count;
                }
            }
            ViewBag.Nine = number;
            number = 0;
            foreach (var x in ret)
            {
                if (x.Town == "诚顺村")
                {
                    number += x.Count;
                }
            }
            ViewBag.Ten = number;
            number = 0;
            return View();
        }
        /// <summary>
        /// 耕地面积扇形图
        /// </summary>
        /// <param name="selectyear"></param>
        /// <param name="selectmonth"></param>
        /// <returns></returns>
        [HttpGet]
        public IActionResult GetArableLand(int selectyear, int selectmonth)
        {
            var town = DB.Towns
                .OrderBy(x => x.Id)
                .ToList();
            var ret = new List<SituationPie>();
            foreach (var x in town)
            {
                var person = DB.Familys
                    .Where(y => y.TownId == x.Id)
                    .OrderBy(y => y.TownId)
                    .ToList();
                foreach (var y in person)
                {
                    var arableLand = DB.FamilySituations
                        .Include(z => z.Family)
                        .Where(z => z.FamilyId == y.Id)
                        .OrderBy(z => z.Family.TownId)
                        .ToList();
                    foreach (var z in arableLand)
                    {
                        if (z.CreateTime.Year == selectyear && z.CreateTime.Month == selectmonth)
                        {
                            ret.Add(new SituationPie
                            {
                                Id = z.Id,
                                Type = "耕地面积",
                                Time = selectyear + "/" + selectmonth,
                                Town = DB.Towns.Where(i => i.Id == z.Family.TownId).SingleOrDefault().Title,
                                Area = z.ArableLand,
                            });
                        }
                    }
                }
            }
            ViewBag.Ret = ret;
            ViewBag.Time = selectyear + "/" + selectmonth;
            Double number = 0;
            foreach (var x in ret)
            {
                if (x.Town == "长安村")
                {
                    number += x.Area;
                }
            }
            ViewBag.One = number;
            number = 0;
            foreach (var x in ret)
            {
                if (x.Town == "精进村")
                {
                    number += x.Area;
                }
            }
            ViewBag.Two = number;
            number = 0;
            foreach (var x in ret)
            {
                if (x.Town == "东风村")
                {
                    number += x.Area;
                }
            }
            ViewBag.Three = number;
            number = 0;
            foreach (var x in ret)
            {
                if (x.Town == "民利村")
                {
                    number += x.Area;
                }
            }
            ViewBag.Four = number;
            number = 0;
            foreach (var x in ret)
            {
                if (x.Town == "龙泉村")
                {
                    number += x.Area;
                }
            }
            ViewBag.Five = number;
            number = 0;
            foreach (var x in ret)
            {
                if (x.Town == "福德村")
                {
                    number += x.Area;
                }
            }
            ViewBag.Six = number;
            number = 0;
            foreach (var x in ret)
            {
                if (x.Town == "和乐村")
                {
                    number += x.Area;
                }
            }
            ViewBag.Seven = number;
            number = 0;
            foreach (var x in ret)
            {
                if (x.Town == "德宝村")
                {
                    number += x.Area;
                }
            }
            ViewBag.Eight = number;
            number = 0;
            foreach (var x in ret)
            {
                if (x.Town == "祥顺村")
                {
                    number += x.Area;
                }
            }
            ViewBag.Nine = number;
            number = 0;
            foreach (var x in ret)
            {
                if (x.Town == "诚顺村")
                {
                    number += x.Area;
                }
            }
            ViewBag.Ten = number;
            number = 0;
            return View();
        }
        /// <summary>
        /// 住房面积扇形图
        /// </summary>
        /// <param name="selectyear"></param>
        /// <param name="selectmonth"></param>
        /// <returns></returns>
        [HttpGet]
        public IActionResult GetHousingArea(int selectyear, int selectmonth)
        {
            var town = DB.Towns
                .OrderBy(x => x.Id)
                .ToList();
            var ret = new List<SituationPie>();
            foreach (var x in town)
            {
                var person = DB.Familys
                    .Where(y => y.TownId == x.Id)
                    .OrderBy(y => y.TownId)
                    .ToList();
                foreach (var y in person)
                {
                    var housingArea = DB.FamilySituations
                        .Include(z => z.Family)
                        .Where(z => z.FamilyId == y.Id)
                        .OrderBy(z => z.Family.TownId)
                        .ToList();
                    foreach (var z in housingArea)
                    {
                        if (z.CreateTime.Year == selectyear && z.CreateTime.Month == selectmonth)
                        {
                            ret.Add(new SituationPie
                            {
                                Id = z.Id,
                                Type = "耕地面积",
                                Time = selectyear + "/" + selectmonth,
                                Town = DB.Towns.Where(i => i.Id == z.Family.TownId).SingleOrDefault().Title,
                                Area = z.HousingArea,
                            });
                        }
                    }
                }
            }
            ViewBag.Ret = ret;
            ViewBag.Time = selectyear + "/" + selectmonth;
            Double number = 0;
            foreach (var x in ret)
            {
                if (x.Town == "长安村")
                {
                    number += x.Area;
                }
            }
            ViewBag.One = number;
            number = 0;
            foreach (var x in ret)
            {
                if (x.Town == "精进村")
                {
                    number += x.Area;
                }
            }
            ViewBag.Two = number;
            number = 0;
            foreach (var x in ret)
            {
                if (x.Town == "东风村")
                {
                    number += x.Area;
                }
            }
            ViewBag.Three = number;
            number = 0;
            foreach (var x in ret)
            {
                if (x.Town == "民利村")
                {
                    number += x.Area;
                }
            }
            ViewBag.Four = number;
            number = 0;
            foreach (var x in ret)
            {
                if (x.Town == "龙泉村")
                {
                    number += x.Area;
                }
            }
            ViewBag.Five = number;
            number = 0;
            foreach (var x in ret)
            {
                if (x.Town == "福德村")
                {
                    number += x.Area;
                }
            }
            ViewBag.Six = number;
            number = 0;
            foreach (var x in ret)
            {
                if (x.Town == "和乐村")
                {
                    number += x.Area;
                }
            }
            ViewBag.Seven = number;
            number = 0;
            foreach (var x in ret)
            {
                if (x.Town == "德宝村")
                {
                    number += x.Area;
                }
            }
            ViewBag.Eight = number;
            number = 0;
            foreach (var x in ret)
            {
                if (x.Town == "祥顺村")
                {
                    number += x.Area;
                }
            }
            ViewBag.Nine = number;
            number = 0;
            foreach (var x in ret)
            {
                if (x.Town == "诚顺村")
                {
                    number += x.Area;
                }
            }
            ViewBag.Ten = number;
            number = 0;
            return View();
        }
        /// <summary>
        /// 房屋结构扇形图
        /// </summary>
        /// <param name="selectyear"></param>
        /// <param name="selectmonth"></param>
        /// <returns></returns>
        [HttpGet]
        public IActionResult GetBuildingStructure(int selectyear, int selectmonth)
        {
            var town = DB.Towns
                .OrderBy(x => x.Id)
                .ToList();
            var ret = new List<SituationPie>();
            foreach (var x in town)
            {
                var person = DB.Familys
                    .Where(y => y.TownId == x.Id)
                    .OrderBy(y => y.TownId)
                    .ToList();
                foreach (var y in person)
                {
                    var buildingStructure = DB.FamilySituations
                        .Include(z => z.Family)
                        .Where(z => z.FamilyId == y.Id)
                        .OrderBy(z => z.Family.TownId)
                        .ToList();
                    foreach (var z in buildingStructure)
                    {
                        if (z.CreateTime.Year == selectyear && z.CreateTime.Month == selectmonth)
                        {
                            ret.Add(new SituationPie
                            {
                                Id = z.Id,
                                Type = "房屋结构",
                                Time = selectyear + "/" + selectmonth,
                                Town = DB.Towns.Where(i => i.Id == z.Family.TownId).SingleOrDefault().Title,
                                Structure = z.BuildingStructure,
                            });
                        }
                    }
                }
            }
            ViewBag.Ret = ret;
            ViewBag.Time = selectyear + "/" + selectmonth;
            var number = 0;
            foreach (var x in ret)
            {
                if (x.Town == "长安村")
                {
                    number += x.Count;
                }
            }
            ViewBag.One = number;
            number = 0;
            foreach (var x in ret)
            {
                if (x.Town == "精进村")
                {
                    number += x.Count;
                }
            }
            ViewBag.Two = number;
            number = 0;
            foreach (var x in ret)
            {
                if (x.Town == "东风村")
                {
                    number += x.Count;
                }
            }
            ViewBag.Three = number;
            number = 0;
            foreach (var x in ret)
            {
                if (x.Town == "民利村")
                {
                    number += x.Count;
                }
            }
            ViewBag.Four = number;
            number = 0;
            foreach (var x in ret)
            {
                if (x.Town == "龙泉村")
                {
                    number += x.Count;
                }
            }
            ViewBag.Five = number;
            number = 0;
            foreach (var x in ret)
            {
                if (x.Town == "福德村")
                {
                    number += x.Count;
                }
            }
            ViewBag.Six = number;
            number = 0;
            foreach (var x in ret)
            {
                if (x.Town == "和乐村")
                {
                    number += x.Count;
                }
            }
            ViewBag.Seven = number;
            number = 0;
            foreach (var x in ret)
            {
                if (x.Town == "德宝村")
                {
                    number += x.Count;
                }
            }
            ViewBag.Eight = number;
            number = 0;
            foreach (var x in ret)
            {
                if (x.Town == "祥顺村")
                {
                    number += x.Count;
                }
            }
            ViewBag.Nine = number;
            number = 0;
            foreach (var x in ret)
            {
                if (x.Town == "诚顺村")
                {
                    number += x.Count;
                }
            }
            ViewBag.Ten = number;
            number = 0;
            return View();
        }


        /// <summary>
        /// 全镇：牛
        /// </summary>
        /// <param name="selectyear"></param>
        /// <param name="selectmonth"></param>
        /// <returns></returns>
        [HttpGet]
        public IActionResult GetCow(int selectyear,int selectmonth)
        {
            var town = DB.Towns
                .OrderBy(x => x.Id)
                .ToList();
            var ret = new List<SituationPie>();
            foreach(var x in town)
            {
                var person = DB.Familys
                    .Where(y => y.TownId == x.Id)
                    .OrderBy(y => y.TownId)
                    .ToList();
                foreach(var y in person)
                {
                    var cow = DB.FamilySituations
                        .Include(z => z.Family)
                        .Where(z => z.FamilyId == y.Id)
                        .OrderBy(z => z.Family.TownId)
                        .ToList();
                    foreach(var z in cow)
                    {
                        if(z.CreateTime.Year == selectyear && z.CreateTime.Month == selectmonth)
                        {
                            ret.Add(new SituationPie
                            {
                                Id = z.Id,
                                Type = "牛",
                                Time = selectyear + "/" + selectmonth,
                                Town = DB.Towns.Where(i => i.Id == z.Family.TownId).SingleOrDefault().Title,
                                Count = z.Cow,
                            });
                        }
                    }
                }
            }
            ViewBag.Time = selectyear + "/" + selectmonth;
            ViewBag.Ret = ret;
            var number = 0;
            foreach(var x in ret)
            {
                if(x.Town == "长安村")
                {
                    number += x.Count;
                }
            }
            ViewBag.One = number;
            number = 0;
            foreach (var x in ret)
            {
                if (x.Town == "精进村")
                {
                    number += x.Count;
                }
            }
            ViewBag.Two = number;
            number = 0;
            foreach (var x in ret)
            {
                if (x.Town == "东风村")
                {
                    number += x.Count;
                }
            }
            ViewBag.Three = number;
            number = 0;
            foreach (var x in ret)
            {
                if (x.Town == "民利村")
                {
                    number += x.Count;
                }
            }
            ViewBag.Four = number;
            number = 0;
            foreach (var x in ret)
            {
                if (x.Town == "龙泉村")
                {
                    number += x.Count;
                }
            }
            ViewBag.Five = number;
            number = 0;
            foreach (var x in ret)
            {
                if (x.Town == "福德村")
                {
                    number += x.Count;
                }
            }
            ViewBag.Six = number;
            number = 0;
            foreach (var x in ret)
            {
                if (x.Town == "和乐村")
                {
                    number += x.Count;
                }
            }
            ViewBag.Seven = number;
            number = 0;
            foreach (var x in ret)
            {
                if (x.Town == "德宝村")
                {
                    number += x.Count;
                }
            }
            ViewBag.Eight = number;
            number = 0;
            foreach (var x in ret)
            {
                if (x.Town == "祥顺村")
                {
                    number += x.Count;
                }
            }
            ViewBag.Nine = number;
            number = 0;
            foreach (var x in ret)
            {
                if (x.Town == "诚顺村")
                {
                    number += x.Count;
                }
            }
            ViewBag.Ten = number;
            number = 0;
            return View();
        }
        /// <summary>
        /// 全镇：马
        /// </summary>
        /// <param name="selectyear"></param>
        /// <param name="selectmonth"></param>
        /// <returns></returns>
        [HttpGet]
        public IActionResult GetHorse(int selectyear, int selectmonth)
        {
            var town = DB.Towns
                .OrderBy(x => x.Id)
                .ToList();
            var ret = new List<SituationPie>();
            foreach (var x in town)
            {
                var person = DB.Familys
                    .Where(y => y.TownId == x.Id)
                    .OrderBy(y => y.TownId)
                    .ToList();
                foreach (var y in person)
                {
                    var horse = DB.FamilySituations
                        .Include(z => z.Family)
                        .Where(z => z.FamilyId == y.Id)
                        .OrderBy(z => z.Family.TownId)
                        .ToList();
                    foreach (var z in horse)
                    {
                        if (z.CreateTime.Year == selectyear && z.CreateTime.Month == selectmonth)
                        {
                            ret.Add(new SituationPie
                            {
                                Id = z.Id,
                                Type = "马",
                                Time = selectyear + "/" + selectmonth,
                                Town = DB.Towns.Where(i => i.Id == z.Family.TownId).SingleOrDefault().Title,
                                Count = z.Horse,
                            });
                        }
                    }
                }
            }
            ViewBag.Time = selectyear + "/" + selectmonth;
            ViewBag.Ret = ret;
            var number = 0;
            foreach (var x in ret)
            {
                if (x.Town == "长安村")
                {
                    number += x.Count;
                }
            }
            ViewBag.One = number;
            number = 0;
            foreach (var x in ret)
            {
                if (x.Town == "精进村")
                {
                    number += x.Count;
                }
            }
            ViewBag.Two = number;
            number = 0;
            foreach (var x in ret)
            {
                if (x.Town == "东风村")
                {
                    number += x.Count;
                }
            }
            ViewBag.Three = number;
            number = 0;
            foreach (var x in ret)
            {
                if (x.Town == "民利村")
                {
                    number += x.Count;
                }
            }
            ViewBag.Four = number;
            number = 0;
            foreach (var x in ret)
            {
                if (x.Town == "龙泉村")
                {
                    number += x.Count;
                }
            }
            ViewBag.Five = number;
            number = 0;
            foreach (var x in ret)
            {
                if (x.Town == "福德村")
                {
                    number += x.Count;
                }
            }
            ViewBag.Six = number;
            number = 0;
            foreach (var x in ret)
            {
                if (x.Town == "和乐村")
                {
                    number += x.Count;
                }
            }
            ViewBag.Seven = number;
            number = 0;
            foreach (var x in ret)
            {
                if (x.Town == "德宝村")
                {
                    number += x.Count;
                }
            }
            ViewBag.Eight = number;
            number = 0;
            foreach (var x in ret)
            {
                if (x.Town == "祥顺村")
                {
                    number += x.Count;
                }
            }
            ViewBag.Nine = number;
            number = 0;
            foreach (var x in ret)
            {
                if (x.Town == "诚顺村")
                {
                    number += x.Count;
                }
            }
            ViewBag.Ten = number;
            number = 0;
            return View();
        }
        /// <summary>
        /// 全镇：羊
        /// </summary>
        /// <param name="selectyear"></param>
        /// <param name="selectmonth"></param>
        /// <returns></returns>
        [HttpGet]
        public IActionResult GetSheep(int selectyear, int selectmonth)
        {
            var town = DB.Towns
                .OrderBy(x => x.Id)
                .ToList();
            var ret = new List<SituationPie>();
            foreach (var x in town)
            {
                var person = DB.Familys
                    .Where(y => y.TownId == x.Id)
                    .OrderBy(y => y.TownId)
                    .ToList();
                foreach (var y in person)
                {
                    var sheep = DB.FamilySituations
                        .Include(z => z.Family)
                        .Where(z => z.FamilyId == y.Id)
                        .OrderBy(z => z.Family.TownId)
                        .ToList();
                    foreach (var z in sheep)
                    {
                        if (z.CreateTime.Year == selectyear && z.CreateTime.Month == selectmonth)
                        {
                            ret.Add(new SituationPie
                            {
                                Id = z.Id,
                                Type = "羊",
                                Time = selectyear + "/" + selectmonth,
                                Town = DB.Towns.Where(i => i.Id == z.Family.TownId).SingleOrDefault().Title,
                                Count = z.Sheep,
                            });
                        }
                    }
                }
            }
            ViewBag.Time = selectyear + "/" + selectmonth;
            ViewBag.Ret = ret;
            var number = 0;
            foreach (var x in ret)
            {
                if (x.Town == "长安村")
                {
                    number += x.Count;
                }
            }
            ViewBag.One = number;
            number = 0;
            foreach (var x in ret)
            {
                if (x.Town == "精进村")
                {
                    number += x.Count;
                }
            }
            ViewBag.Two = number;
            number = 0;
            foreach (var x in ret)
            {
                if (x.Town == "东风村")
                {
                    number += x.Count;
                }
            }
            ViewBag.Three = number;
            number = 0;
            foreach (var x in ret)
            {
                if (x.Town == "民利村")
                {
                    number += x.Count;
                }
            }
            ViewBag.Four = number;
            number = 0;
            foreach (var x in ret)
            {
                if (x.Town == "龙泉村")
                {
                    number += x.Count;
                }
            }
            ViewBag.Five = number;
            number = 0;
            foreach (var x in ret)
            {
                if (x.Town == "福德村")
                {
                    number += x.Count;
                }
            }
            ViewBag.Six = number;
            number = 0;
            foreach (var x in ret)
            {
                if (x.Town == "和乐村")
                {
                    number += x.Count;
                }
            }
            ViewBag.Seven = number;
            number = 0;
            foreach (var x in ret)
            {
                if (x.Town == "德宝村")
                {
                    number += x.Count;
                }
            }
            ViewBag.Eight = number;
            number = 0;
            foreach (var x in ret)
            {
                if (x.Town == "祥顺村")
                {
                    number += x.Count;
                }
            }
            ViewBag.Nine = number;
            number = 0;
            foreach (var x in ret)
            {
                if (x.Town == "诚顺村")
                {
                    number += x.Count;
                }
            }
            ViewBag.Ten = number;
            number = 0;
            return View();
        }
        /// <summary>
        /// 全镇：鸡
        /// </summary>
        /// <param name="selectyear"></param>
        /// <param name="selectmonth"></param>
        /// <returns></returns>
        [HttpGet]
        public IActionResult GetChicken(int selectyear, int selectmonth)
        {
            var town = DB.Towns
                .OrderBy(x => x.Id)
                .ToList();
            var ret = new List<SituationPie>();
            foreach (var x in town)
            {
                var person = DB.Familys
                    .Where(y => y.TownId == x.Id)
                    .OrderBy(y => y.TownId)
                    .ToList();
                foreach (var y in person)
                {
                    var chicken = DB.FamilySituations
                        .Include(z => z.Family)
                        .Where(z => z.FamilyId == y.Id)
                        .OrderBy(z => z.Family.TownId)
                        .ToList();
                    foreach (var z in chicken)
                    {
                        if (z.CreateTime.Year == selectyear && z.CreateTime.Month == selectmonth)
                        {
                            ret.Add(new SituationPie
                            {
                                Id = z.Id,
                                Type = "鸡",
                                Time = selectyear + "/" + selectmonth,
                                Town = DB.Towns.Where(i => i.Id == z.Family.TownId).SingleOrDefault().Title,
                                Count = z.Chicken,
                            });
                        }
                    }
                }
            }
            ViewBag.Time = selectyear + "/" + selectmonth;
            ViewBag.Ret = ret;
            var number = 0;
            foreach (var x in ret)
            {
                if (x.Town == "长安村")
                {
                    number += x.Count;
                }
            }
            ViewBag.One = number;
            number = 0;
            foreach (var x in ret)
            {
                if (x.Town == "精进村")
                {
                    number += x.Count;
                }
            }
            ViewBag.Two = number;
            number = 0;
            foreach (var x in ret)
            {
                if (x.Town == "东风村")
                {
                    number += x.Count;
                }
            }
            ViewBag.Three = number;
            number = 0;
            foreach (var x in ret)
            {
                if (x.Town == "民利村")
                {
                    number += x.Count;
                }
            }
            ViewBag.Four = number;
            number = 0;
            foreach (var x in ret)
            {
                if (x.Town == "龙泉村")
                {
                    number += x.Count;
                }
            }
            ViewBag.Five = number;
            number = 0;
            foreach (var x in ret)
            {
                if (x.Town == "福德村")
                {
                    number += x.Count;
                }
            }
            ViewBag.Six = number;
            number = 0;
            foreach (var x in ret)
            {
                if (x.Town == "和乐村")
                {
                    number += x.Count;
                }
            }
            ViewBag.Seven = number;
            number = 0;
            foreach (var x in ret)
            {
                if (x.Town == "德宝村")
                {
                    number += x.Count;
                }
            }
            ViewBag.Eight = number;
            number = 0;
            foreach (var x in ret)
            {
                if (x.Town == "祥顺村")
                {
                    number += x.Count;
                }
            }
            ViewBag.Nine = number;
            number = 0;
            foreach (var x in ret)
            {
                if (x.Town == "诚顺村")
                {
                    number += x.Count;
                }
            }
            ViewBag.Ten = number;
            number = 0;
            return View();
        }
        /// <summary>
        /// 全镇：鸭
        /// </summary>
        /// <param name="selectyear"></param>
        /// <param name="selectmonth"></param>
        /// <returns></returns>
        [HttpGet]
        public IActionResult GetDuck(int selectyear, int selectmonth)
        {
            var town = DB.Towns
                .OrderBy(x => x.Id)
                .ToList();
            var ret = new List<SituationPie>();
            foreach (var x in town)
            {
                var person = DB.Familys
                    .Where(y => y.TownId == x.Id)
                    .OrderBy(y => y.TownId)
                    .ToList();
                foreach (var y in person)
                {
                    var duck = DB.FamilySituations
                        .Include(z => z.Family)
                        .Where(z => z.FamilyId == y.Id)
                        .OrderBy(z => z.Family.TownId)
                        .ToList();
                    foreach (var z in duck)
                    {
                        if (z.CreateTime.Year == selectyear && z.CreateTime.Month == selectmonth)
                        {
                            ret.Add(new SituationPie
                            {
                                Id = z.Id,
                                Type = "鸭",
                                Time = selectyear + "/" + selectmonth,
                                Town = DB.Towns.Where(i => i.Id == z.Family.TownId).SingleOrDefault().Title,
                                Count = z.Duck,
                            });
                        }
                    }
                }
            }
            ViewBag.Time = selectyear + "/" + selectmonth;
            ViewBag.Ret = ret;
            var number = 0;
            foreach (var x in ret)
            {
                if (x.Town == "长安村")
                {
                    number += x.Count;
                }
            }
            ViewBag.One = number;
            number = 0;
            foreach (var x in ret)
            {
                if (x.Town == "精进村")
                {
                    number += x.Count;
                }
            }
            ViewBag.Two = number;
            number = 0;
            foreach (var x in ret)
            {
                if (x.Town == "东风村")
                {
                    number += x.Count;
                }
            }
            ViewBag.Three = number;
            number = 0;
            foreach (var x in ret)
            {
                if (x.Town == "民利村")
                {
                    number += x.Count;
                }
            }
            ViewBag.Four = number;
            number = 0;
            foreach (var x in ret)
            {
                if (x.Town == "龙泉村")
                {
                    number += x.Count;
                }
            }
            ViewBag.Five = number;
            number = 0;
            foreach (var x in ret)
            {
                if (x.Town == "福德村")
                {
                    number += x.Count;
                }
            }
            ViewBag.Six = number;
            number = 0;
            foreach (var x in ret)
            {
                if (x.Town == "和乐村")
                {
                    number += x.Count;
                }
            }
            ViewBag.Seven = number;
            number = 0;
            foreach (var x in ret)
            {
                if (x.Town == "德宝村")
                {
                    number += x.Count;
                }
            }
            ViewBag.Eight = number;
            number = 0;
            foreach (var x in ret)
            {
                if (x.Town == "祥顺村")
                {
                    number += x.Count;
                }
            }
            ViewBag.Nine = number;
            number = 0;
            foreach (var x in ret)
            {
                if (x.Town == "诚顺村")
                {
                    number += x.Count;
                }
            }
            ViewBag.Ten = number;
            number = 0;
            return View();
        }
        /// <summary>
        /// 全镇：鹅
        /// </summary>
        /// <param name="selectyear"></param>
        /// <param name="selectmonth"></param>
        /// <returns></returns>
        [HttpGet]
        public IActionResult GetGoose(int selectyear, int selectmonth)
        {
            var town = DB.Towns
                .OrderBy(x => x.Id)
                .ToList();
            var ret = new List<SituationPie>();
            foreach (var x in town)
            {
                var person = DB.Familys
                    .Where(y => y.TownId == x.Id)
                    .OrderBy(y => y.TownId)
                    .ToList();
                foreach (var y in person)
                {
                    var goose = DB.FamilySituations
                        .Include(z => z.Family)
                        .Where(z => z.FamilyId == y.Id)
                        .OrderBy(z => z.Family.TownId)
                        .ToList();
                    foreach (var z in goose)
                    {
                        if (z.CreateTime.Year == selectyear && z.CreateTime.Month == selectmonth)
                        {
                            ret.Add(new SituationPie
                            {
                                Id = z.Id,
                                Type = "鹅",
                                Time = selectyear + "/" + selectmonth,
                                Town = DB.Towns.Where(i => i.Id == z.Family.TownId).SingleOrDefault().Title,
                                Count = z.Goose,
                            });
                        }
                    }
                }
            }
            ViewBag.Time = selectyear + "/" + selectmonth;
            ViewBag.Ret = ret;
            var number = 0;
            foreach (var x in ret)
            {
                if (x.Town == "长安村")
                {
                    number += x.Count;
                }
            }
            ViewBag.One = number;
            number = 0;
            foreach (var x in ret)
            {
                if (x.Town == "精进村")
                {
                    number += x.Count;
                }
            }
            ViewBag.Two = number;
            number = 0;
            foreach (var x in ret)
            {
                if (x.Town == "东风村")
                {
                    number += x.Count;
                }
            }
            ViewBag.Three = number;
            number = 0;
            foreach (var x in ret)
            {
                if (x.Town == "民利村")
                {
                    number += x.Count;
                }
            }
            ViewBag.Four = number;
            number = 0;
            foreach (var x in ret)
            {
                if (x.Town == "龙泉村")
                {
                    number += x.Count;
                }
            }
            ViewBag.Five = number;
            number = 0;
            foreach (var x in ret)
            {
                if (x.Town == "福德村")
                {
                    number += x.Count;
                }
            }
            ViewBag.Six = number;
            number = 0;
            foreach (var x in ret)
            {
                if (x.Town == "和乐村")
                {
                    number += x.Count;
                }
            }
            ViewBag.Seven = number;
            number = 0;
            foreach (var x in ret)
            {
                if (x.Town == "德宝村")
                {
                    number += x.Count;
                }
            }
            ViewBag.Eight = number;
            number = 0;
            foreach (var x in ret)
            {
                if (x.Town == "祥顺村")
                {
                    number += x.Count;
                }
            }
            ViewBag.Nine = number;
            number = 0;
            foreach (var x in ret)
            {
                if (x.Town == "诚顺村")
                {
                    number += x.Count;
                }
            }
            ViewBag.Ten = number;
            number = 0;
            return View();
        }
        /// <summary>
        /// 全镇：猪
        /// </summary>
        /// <param name="selectyear"></param>
        /// <param name="selectmonth"></param>
        /// <returns></returns>
        [HttpGet]
        public IActionResult GetPig(int selectyear, int selectmonth)
        {
            var town = DB.Towns
                .OrderBy(x => x.Id)
                .ToList();
            var ret = new List<SituationPie>();
            foreach (var x in town)
            {
                var person = DB.Familys
                    .Where(y => y.TownId == x.Id)
                    .OrderBy(y => y.TownId)
                    .ToList();
                foreach (var y in person)
                {
                    var pig = DB.FamilySituations
                        .Include(z => z.Family)
                        .Where(z => z.FamilyId == y.Id)
                        .OrderBy(z => z.Family.TownId)
                        .ToList();
                    foreach (var z in pig)
                    {
                        if (z.CreateTime.Year == selectyear && z.CreateTime.Month == selectmonth)
                        {
                            ret.Add(new SituationPie
                            {
                                Id = z.Id,
                                Type = "猪",
                                Time = selectyear + "/" + selectmonth,
                                Town = DB.Towns.Where(i => i.Id == z.Family.TownId).SingleOrDefault().Title,
                                Count = z.Pig,
                            });
                        }
                    }
                }
            }
            ViewBag.Time = selectyear + "/" + selectmonth;
            ViewBag.Ret = ret;
            var number = 0;
            foreach (var x in ret)
            {
                if (x.Town == "长安村")
                {
                    number += x.Count;
                }
            }
            ViewBag.One = number;
            number = 0;
            foreach (var x in ret)
            {
                if (x.Town == "精进村")
                {
                    number += x.Count;
                }
            }
            ViewBag.Two = number;
            number = 0;
            foreach (var x in ret)
            {
                if (x.Town == "东风村")
                {
                    number += x.Count;
                }
            }
            ViewBag.Three = number;
            number = 0;
            foreach (var x in ret)
            {
                if (x.Town == "民利村")
                {
                    number += x.Count;
                }
            }
            ViewBag.Four = number;
            number = 0;
            foreach (var x in ret)
            {
                if (x.Town == "龙泉村")
                {
                    number += x.Count;
                }
            }
            ViewBag.Five = number;
            number = 0;
            foreach (var x in ret)
            {
                if (x.Town == "福德村")
                {
                    number += x.Count;
                }
            }
            ViewBag.Six = number;
            number = 0;
            foreach (var x in ret)
            {
                if (x.Town == "和乐村")
                {
                    number += x.Count;
                }
            }
            ViewBag.Seven = number;
            number = 0;
            foreach (var x in ret)
            {
                if (x.Town == "德宝村")
                {
                    number += x.Count;
                }
            }
            ViewBag.Eight = number;
            number = 0;
            foreach (var x in ret)
            {
                if (x.Town == "祥顺村")
                {
                    number += x.Count;
                }
            }
            ViewBag.Nine = number;
            number = 0;
            foreach (var x in ret)
            {
                if (x.Town == "诚顺村")
                {
                    number += x.Count;
                }
            }
            ViewBag.Ten = number;
            number = 0;
            return View();
        }
        /// <summary>
        /// 全镇：其它牲口
        /// </summary>
        /// <param name="selectyear"></param>
        /// <param name="selectmonth"></param>
        /// <returns></returns>
        [HttpGet]
        public IActionResult GetOthersAnimal(int selectyear, int selectmonth)
        {
            var town = DB.Towns
                .OrderBy(x => x.Id)
                .ToList();
            var ret = new List<SituationPie>();
            foreach (var x in town)
            {
                var person = DB.Familys
                    .Where(y => y.TownId == x.Id)
                    .OrderBy(y => y.TownId)
                    .ToList();
                foreach (var y in person)
                {
                    var othersAnimal = DB.FamilySituations
                        .Include(z => z.Family)
                        .Where(z => z.FamilyId == y.Id)
                        .OrderBy(z => z.Family.TownId)
                        .ToList();
                    foreach (var z in othersAnimal)
                    {
                        if (z.CreateTime.Year == selectyear && z.CreateTime.Month == selectmonth)
                        {
                            ret.Add(new SituationPie
                            {
                                Id = z.Id,
                                Type = "其它牲口",
                                Time = selectyear + "/" + selectmonth,
                                Town = DB.Towns.Where(i => i.Id == z.Family.TownId).SingleOrDefault().Title,
                                Count = z.OthersAnimal,
                            });
                        }
                    }
                }
            }
            ViewBag.Time = selectyear + "/" + selectmonth;
            ViewBag.Ret = ret;
            var number = 0;
            foreach (var x in ret)
            {
                if (x.Town == "长安村")
                {
                    number += x.Count;
                }
            }
            ViewBag.One = number;
            number = 0;
            foreach (var x in ret)
            {
                if (x.Town == "精进村")
                {
                    number += x.Count;
                }
            }
            ViewBag.Two = number;
            number = 0;
            foreach (var x in ret)
            {
                if (x.Town == "东风村")
                {
                    number += x.Count;
                }
            }
            ViewBag.Three = number;
            number = 0;
            foreach (var x in ret)
            {
                if (x.Town == "民利村")
                {
                    number += x.Count;
                }
            }
            ViewBag.Four = number;
            number = 0;
            foreach (var x in ret)
            {
                if (x.Town == "龙泉村")
                {
                    number += x.Count;
                }
            }
            ViewBag.Five = number;
            number = 0;
            foreach (var x in ret)
            {
                if (x.Town == "福德村")
                {
                    number += x.Count;
                }
            }
            ViewBag.Six = number;
            number = 0;
            foreach (var x in ret)
            {
                if (x.Town == "和乐村")
                {
                    number += x.Count;
                }
            }
            ViewBag.Seven = number;
            number = 0;
            foreach (var x in ret)
            {
                if (x.Town == "德宝村")
                {
                    number += x.Count;
                }
            }
            ViewBag.Eight = number;
            number = 0;
            foreach (var x in ret)
            {
                if (x.Town == "祥顺村")
                {
                    number += x.Count;
                }
            }
            ViewBag.Nine = number;
            number = 0;
            foreach (var x in ret)
            {
                if (x.Town == "诚顺村")
                {
                    number += x.Count;
                }
            }
            ViewBag.Ten = number;
            number = 0;
            return View();
        }
        /// <summary>
        /// 全镇：玉米
        /// </summary>
        /// <param name="selectyear"></param>
        /// <param name="selectmonth"></param>
        /// <returns></returns>
        [HttpGet]
        public IActionResult GetCorn(int selectyear, int selectmonth)
        {
            var town = DB.Towns
                .OrderBy(x => x.Id)
                .ToList();
            var ret = new List<SituationPie>();
            foreach (var x in town)
            {
                var person = DB.Familys
                    .Where(y => y.TownId == x.Id)
                    .OrderBy(y => y.TownId)
                    .ToList();
                foreach (var y in person)
                {
                    var corn = DB.FamilySituations
                        .Include(z => z.Family)
                        .Where(z => z.FamilyId == y.Id)
                        .OrderBy(z => z.Family.TownId)
                        .ToList();
                    foreach (var z in corn)
                    {
                        if (z.CreateTime.Year == selectyear && z.CreateTime.Month == selectmonth)
                        {
                            ret.Add(new SituationPie
                            {
                                Id = z.Id,
                                Type = "玉米",
                                Time = selectyear + "/" + selectmonth,
                                Town = DB.Towns.Where(i => i.Id == z.Family.TownId).SingleOrDefault().Title,
                                Count = z.Corn,
                            });
                        }
                    }
                }
            }
            ViewBag.Time = selectyear + "/" + selectmonth;
            ViewBag.Ret = ret;
            var number = 0;
            foreach (var x in ret)
            {
                if (x.Town == "长安村")
                {
                    number += x.Count;
                }
            }
            ViewBag.One = number;
            number = 0;
            foreach (var x in ret)
            {
                if (x.Town == "精进村")
                {
                    number += x.Count;
                }
            }
            ViewBag.Two = number;
            number = 0;
            foreach (var x in ret)
            {
                if (x.Town == "东风村")
                {
                    number += x.Count;
                }
            }
            ViewBag.Three = number;
            number = 0;
            foreach (var x in ret)
            {
                if (x.Town == "民利村")
                {
                    number += x.Count;
                }
            }
            ViewBag.Four = number;
            number = 0;
            foreach (var x in ret)
            {
                if (x.Town == "龙泉村")
                {
                    number += x.Count;
                }
            }
            ViewBag.Five = number;
            number = 0;
            foreach (var x in ret)
            {
                if (x.Town == "福德村")
                {
                    number += x.Count;
                }
            }
            ViewBag.Six = number;
            number = 0;
            foreach (var x in ret)
            {
                if (x.Town == "和乐村")
                {
                    number += x.Count;
                }
            }
            ViewBag.Seven = number;
            number = 0;
            foreach (var x in ret)
            {
                if (x.Town == "德宝村")
                {
                    number += x.Count;
                }
            }
            ViewBag.Eight = number;
            number = 0;
            foreach (var x in ret)
            {
                if (x.Town == "祥顺村")
                {
                    number += x.Count;
                }
            }
            ViewBag.Nine = number;
            number = 0;
            foreach (var x in ret)
            {
                if (x.Town == "诚顺村")
                {
                    number += x.Count;
                }
            }
            ViewBag.Ten = number;
            number = 0;
            return View();
        }

        /// <summary>
        /// 大豆
        /// </summary>
        /// <param name="selectyear"></param>
        /// <param name="selectmonth"></param>
        /// <returns></returns>
        [HttpGet]
        public IActionResult GetSoyBeans(int selectyear, int selectmonth)
        {
            var town = DB.Towns
                .OrderBy(x => x.Id)
                .ToList();
            var ret = new List<SituationPie>();
            foreach (var x in town)
            {
                var person = DB.Familys
                    .Where(y => y.TownId == x.Id)
                    .OrderBy(y => y.TownId)
                    .ToList();
                foreach (var y in person)
                {
                    var soyBeans = DB.FamilySituations
                        .Include(z => z.Family)
                        .Where(z => z.FamilyId == y.Id)
                        .OrderBy(z => z.Family.TownId)
                        .ToList();
                    foreach (var z in soyBeans)
                    {
                        if (z.CreateTime.Year == selectyear && z.CreateTime.Month == selectmonth)
                        {
                            ret.Add(new SituationPie
                            {
                                Id = z.Id,
                                Type = "大豆",
                                Time = selectyear + "/" + selectmonth,
                                Town = DB.Towns.Where(i => i.Id == z.Family.TownId).SingleOrDefault().Title,
                                Area = z.SoyBeans,
                            });
                        }
                    }
                }
            }
            ViewBag.Ret = ret;
            ViewBag.Time = selectyear + "/" + selectmonth;
            Double number = 0;
            foreach (var x in ret)
            {
                if (x.Town == "长安村")
                {
                    number += x.Area;
                }
            }
            ViewBag.One = number;
            number = 0;
            foreach (var x in ret)
            {
                if (x.Town == "精进村")
                {
                    number += x.Area;
                }
            }
            ViewBag.Two = number;
            number = 0;
            foreach (var x in ret)
            {
                if (x.Town == "东风村")
                {
                    number += x.Area;
                }
            }
            ViewBag.Three = number;
            number = 0;
            foreach (var x in ret)
            {
                if (x.Town == "民利村")
                {
                    number += x.Area;
                }
            }
            ViewBag.Four = number;
            number = 0;
            foreach (var x in ret)
            {
                if (x.Town == "龙泉村")
                {
                    number += x.Area;
                }
            }
            ViewBag.Five = number;
            number = 0;
            foreach (var x in ret)
            {
                if (x.Town == "福德村")
                {
                    number += x.Area;
                }
            }
            ViewBag.Six = number;
            number = 0;
            foreach (var x in ret)
            {
                if (x.Town == "和乐村")
                {
                    number += x.Area;
                }
            }
            ViewBag.Seven = number;
            number = 0;
            foreach (var x in ret)
            {
                if (x.Town == "德宝村")
                {
                    number += x.Area;
                }
            }
            ViewBag.Eight = number;
            number = 0;
            foreach (var x in ret)
            {
                if (x.Town == "祥顺村")
                {
                    number += x.Area;
                }
            }
            ViewBag.Nine = number;
            number = 0;
            foreach (var x in ret)
            {
                if (x.Town == "诚顺村")
                {
                    number += x.Area;
                }
            }
            ViewBag.Ten = number;
            number = 0;
            return View();
        }

        /// <summary>
        /// 马铃薯扇形图
        /// </summary>
        /// <param name="selectyear"></param>
        /// <param name="selectmonth"></param>
        /// <returns></returns>
        [HttpGet]
        public IActionResult GetPotato(int selectyear, int selectmonth)
        {
            var town = DB.Towns
                .OrderBy(x => x.Id)
                .ToList();
            var ret = new List<SituationPie>();
            foreach (var x in town)
            {
                var person = DB.Familys
                    .Where(y => y.TownId == x.Id)
                    .OrderBy(y => y.TownId)
                    .ToList();
                foreach (var y in person)
                {
                    var potato = DB.FamilySituations
                        .Include(z => z.Family)
                        .Where(z => z.FamilyId == y.Id)
                        .OrderBy(z => z.Family.TownId)
                        .ToList();
                    foreach (var z in potato)
                    {
                        if (z.CreateTime.Year == selectyear && z.CreateTime.Month == selectmonth)
                        {
                            ret.Add(new SituationPie
                            {
                                Id = z.Id,
                                Type = "马铃薯",
                                Time = selectyear + "/" + selectmonth,
                                Town = DB.Towns.Where(i => i.Id == z.Family.TownId).SingleOrDefault().Title,
                                Area = z.Potato,
                            });
                        }
                    }
                }
            }
            ViewBag.Ret = ret;
            ViewBag.Time = selectyear + "/" + selectmonth;
            Double number = 0;
            foreach (var x in ret)
            {
                if (x.Town == "长安村")
                {
                    number += x.Area;
                }
            }
            ViewBag.One = number;
            number = 0;
            foreach (var x in ret)
            {
                if (x.Town == "精进村")
                {
                    number += x.Area;
                }
            }
            ViewBag.Two = number;
            number = 0;
            foreach (var x in ret)
            {
                if (x.Town == "东风村")
                {
                    number += x.Area;
                }
            }
            ViewBag.Three = number;
            number = 0;
            foreach (var x in ret)
            {
                if (x.Town == "民利村")
                {
                    number += x.Area;
                }
            }
            ViewBag.Four = number;
            number = 0;
            foreach (var x in ret)
            {
                if (x.Town == "龙泉村")
                {
                    number += x.Area;
                }
            }
            ViewBag.Five = number;
            number = 0;
            foreach (var x in ret)
            {
                if (x.Town == "福德村")
                {
                    number += x.Area;
                }
            }
            ViewBag.Six = number;
            number = 0;
            foreach (var x in ret)
            {
                if (x.Town == "和乐村")
                {
                    number += x.Area;
                }
            }
            ViewBag.Seven = number;
            number = 0;
            foreach (var x in ret)
            {
                if (x.Town == "德宝村")
                {
                    number += x.Area;
                }
            }
            ViewBag.Eight = number;
            number = 0;
            foreach (var x in ret)
            {
                if (x.Town == "祥顺村")
                {
                    number += x.Area;
                }
            }
            ViewBag.Nine = number;
            number = 0;
            foreach (var x in ret)
            {
                if (x.Town == "诚顺村")
                {
                    number += x.Area;
                }
            }
            ViewBag.Ten = number;
            number = 0;
            return View();
        }
        /// <summary>
        /// 葵花扇形图
        /// </summary>
        /// <param name="selectyear"></param>
        /// <param name="selectmonth"></param>
        /// <returns></returns>
        [HttpGet]
        public IActionResult GetSunflower(int selectyear, int selectmonth)
        {
            var town = DB.Towns
                .OrderBy(x => x.Id)
                .ToList();
            var ret = new List<SituationPie>();
            foreach (var x in town)
            {
                var person = DB.Familys
                    .Where(y => y.TownId == x.Id)
                    .OrderBy(y => y.TownId)
                    .ToList();
                foreach (var y in person)
                {
                    var sunflower = DB.FamilySituations
                        .Include(z => z.Family)
                        .Where(z => z.FamilyId == y.Id)
                        .OrderBy(z => z.Family.TownId)
                        .ToList();
                    foreach (var z in sunflower)
                    {
                        if (z.CreateTime.Year == selectyear && z.CreateTime.Month == selectmonth)
                        {
                            ret.Add(new SituationPie
                            {
                                Id = z.Id,
                                Type = "葵花",
                                Time = selectyear + "/" + selectmonth,
                                Town = DB.Towns.Where(i => i.Id == z.Family.TownId).SingleOrDefault().Title,
                                Area = z.Sunflower,
                            });
                        }
                    }
                }
            }
            ViewBag.Ret = ret;
            ViewBag.Time = selectyear + "/" + selectmonth;
            Double number = 0;
            foreach (var x in ret)
            {
                if (x.Town == "长安村")
                {
                    number += x.Area;
                }
            }
            ViewBag.One = number;
            number = 0;
            foreach (var x in ret)
            {
                if (x.Town == "精进村")
                {
                    number += x.Area;
                }
            }
            ViewBag.Two = number;
            number = 0;
            foreach (var x in ret)
            {
                if (x.Town == "东风村")
                {
                    number += x.Area;
                }
            }
            ViewBag.Three = number;
            number = 0;
            foreach (var x in ret)
            {
                if (x.Town == "民利村")
                {
                    number += x.Area;
                }
            }
            ViewBag.Four = number;
            number = 0;
            foreach (var x in ret)
            {
                if (x.Town == "龙泉村")
                {
                    number += x.Area;
                }
            }
            ViewBag.Five = number;
            number = 0;
            foreach (var x in ret)
            {
                if (x.Town == "福德村")
                {
                    number += x.Area;
                }
            }
            ViewBag.Six = number;
            number = 0;
            foreach (var x in ret)
            {
                if (x.Town == "和乐村")
                {
                    number += x.Area;
                }
            }
            ViewBag.Seven = number;
            number = 0;
            foreach (var x in ret)
            {
                if (x.Town == "德宝村")
                {
                    number += x.Area;
                }
            }
            ViewBag.Eight = number;
            number = 0;
            foreach (var x in ret)
            {
                if (x.Town == "祥顺村")
                {
                    number += x.Area;
                }
            }
            ViewBag.Nine = number;
            number = 0;
            foreach (var x in ret)
            {
                if (x.Town == "诚顺村")
                {
                    number += x.Area;
                }
            }
            ViewBag.Ten = number;
            number = 0;
            return View();
        }
        /// <summary>
        /// 高粱扇形图
        /// </summary>
        /// <param name="selectyear"></param>
        /// <param name="selectmonth"></param>
        /// <returns></returns>
        [HttpGet]
        public IActionResult GetSorghum(int selectyear, int selectmonth)
        {
            var town = DB.Towns
                .OrderBy(x => x.Id)
                .ToList();
            var ret = new List<SituationPie>();
            foreach (var x in town)
            {
                var person = DB.Familys
                    .Where(y => y.TownId == x.Id)
                    .OrderBy(y => y.TownId)
                    .ToList();
                foreach (var y in person)
                {
                    var sorghum = DB.FamilySituations
                        .Include(z => z.Family)
                        .Where(z => z.FamilyId == y.Id)
                        .OrderBy(z => z.Family.TownId)
                        .ToList();
                    foreach (var z in sorghum)
                    {
                        if (z.CreateTime.Year == selectyear && z.CreateTime.Month == selectmonth)
                        {
                            ret.Add(new SituationPie
                            {
                                Id = z.Id,
                                Type = "高粱",
                                Time = selectyear + "/" + selectmonth,
                                Town = DB.Towns.Where(i => i.Id == z.Family.TownId).SingleOrDefault().Title,
                                Area = z.Sorghum,
                            });
                        }
                    }
                }
            }
            ViewBag.Ret = ret;
            ViewBag.Time = selectyear + "/" + selectmonth;
            Double number = 0;
            foreach (var x in ret)
            {
                if (x.Town == "长安村")
                {
                    number += x.Area;
                }
            }
            ViewBag.One = number;
            number = 0;
            foreach (var x in ret)
            {
                if (x.Town == "精进村")
                {
                    number += x.Area;
                }
            }
            ViewBag.Two = number;
            number = 0;
            foreach (var x in ret)
            {
                if (x.Town == "东风村")
                {
                    number += x.Area;
                }
            }
            ViewBag.Three = number;
            number = 0;
            foreach (var x in ret)
            {
                if (x.Town == "民利村")
                {
                    number += x.Area;
                }
            }
            ViewBag.Four = number;
            number = 0;
            foreach (var x in ret)
            {
                if (x.Town == "龙泉村")
                {
                    number += x.Area;
                }
            }
            ViewBag.Five = number;
            number = 0;
            foreach (var x in ret)
            {
                if (x.Town == "福德村")
                {
                    number += x.Area;
                }
            }
            ViewBag.Six = number;
            number = 0;
            foreach (var x in ret)
            {
                if (x.Town == "和乐村")
                {
                    number += x.Area;
                }
            }
            ViewBag.Seven = number;
            number = 0;
            foreach (var x in ret)
            {
                if (x.Town == "德宝村")
                {
                    number += x.Area;
                }
            }
            ViewBag.Eight = number;
            number = 0;
            foreach (var x in ret)
            {
                if (x.Town == "祥顺村")
                {
                    number += x.Area;
                }
            }
            ViewBag.Nine = number;
            number = 0;
            foreach (var x in ret)
            {
                if (x.Town == "诚顺村")
                {
                    number += x.Area;
                }
            }
            ViewBag.Ten = number;
            number = 0;
            return View();
        }
        /// <summary>
        /// 杂粮扇形图
        /// </summary>
        /// <param name="selectyear"></param>
        /// <param name="selectmonth"></param>
        /// <returns></returns>
        [HttpGet]
        public IActionResult GetGrains(int selectyear, int selectmonth)
        {
            var town = DB.Towns
                .OrderBy(x => x.Id)
                .ToList();
            var ret = new List<SituationPie>();
            foreach (var x in town)
            {
                var person = DB.Familys
                    .Where(y => y.TownId == x.Id)
                    .OrderBy(y => y.TownId)
                    .ToList();
                foreach (var y in person)
                {
                    var grains = DB.FamilySituations
                        .Include(z => z.Family)
                        .Where(z => z.FamilyId == y.Id)
                        .OrderBy(z => z.Family.TownId)
                        .ToList();
                    foreach (var z in grains)
                    {
                        if (z.CreateTime.Year == selectyear && z.CreateTime.Month == selectmonth)
                        {
                            ret.Add(new SituationPie
                            {
                                Id = z.Id,
                                Type = "杂粮",
                                Time = selectyear + "/" + selectmonth,
                                Town = DB.Towns.Where(i => i.Id == z.Family.TownId).SingleOrDefault().Title,
                                Area = z.Grains,
                            });
                        }
                    }
                }
            }
            ViewBag.Ret = ret;
            ViewBag.Time = selectyear + "/" + selectmonth;
            Double number = 0;
            foreach (var x in ret)
            {
                if (x.Town == "长安村")
                {
                    number += x.Area;
                }
            }
            ViewBag.One = number;
            number = 0;
            foreach (var x in ret)
            {
                if (x.Town == "精进村")
                {
                    number += x.Area;
                }
            }
            ViewBag.Two = number;
            number = 0;
            foreach (var x in ret)
            {
                if (x.Town == "东风村")
                {
                    number += x.Area;
                }
            }
            ViewBag.Three = number;
            number = 0;
            foreach (var x in ret)
            {
                if (x.Town == "民利村")
                {
                    number += x.Area;
                }
            }
            ViewBag.Four = number;
            number = 0;
            foreach (var x in ret)
            {
                if (x.Town == "龙泉村")
                {
                    number += x.Area;
                }
            }
            ViewBag.Five = number;
            number = 0;
            foreach (var x in ret)
            {
                if (x.Town == "福德村")
                {
                    number += x.Area;
                }
            }
            ViewBag.Six = number;
            number = 0;
            foreach (var x in ret)
            {
                if (x.Town == "和乐村")
                {
                    number += x.Area;
                }
            }
            ViewBag.Seven = number;
            number = 0;
            foreach (var x in ret)
            {
                if (x.Town == "德宝村")
                {
                    number += x.Area;
                }
            }
            ViewBag.Eight = number;
            number = 0;
            foreach (var x in ret)
            {
                if (x.Town == "祥顺村")
                {
                    number += x.Area;
                }
            }
            ViewBag.Nine = number;
            number = 0;
            foreach (var x in ret)
            {
                if (x.Town == "诚顺村")
                {
                    number += x.Area;
                }
            }
            ViewBag.Ten = number;
            number = 0;
            return View();
        }
        /// <summary>
        /// 水稻扇形图
        /// </summary>
        /// <param name="selectyear"></param>
        /// <param name="selectmonth"></param>
        /// <returns></returns>
        [HttpGet]
        public IActionResult GetRice(int selectyear, int selectmonth)
        {
            var town = DB.Towns
                .OrderBy(x => x.Id)
                .ToList();
            var ret = new List<SituationPie>();
            foreach (var x in town)
            {
                var person = DB.Familys
                    .Where(y => y.TownId == x.Id)
                    .OrderBy(y => y.TownId)
                    .ToList();
                foreach (var y in person)
                {
                    var rice = DB.FamilySituations
                        .Include(z => z.Family)
                        .Where(z => z.FamilyId == y.Id)
                        .OrderBy(z => z.Family.TownId)
                        .ToList();
                    foreach (var z in rice)
                    {
                        if (z.CreateTime.Year == selectyear && z.CreateTime.Month == selectmonth)
                        {
                            ret.Add(new SituationPie
                            {
                                Id = z.Id,
                                Type = "水稻",
                                Time = selectyear + "/" + selectmonth,
                                Town = DB.Towns.Where(i => i.Id == z.Family.TownId).SingleOrDefault().Title,
                                Area = z.Rice,
                            });
                        }
                    }
                }
            }
            ViewBag.Ret = ret;
            ViewBag.Time = selectyear + "/" + selectmonth;
            Double number = 0;
            foreach (var x in ret)
            {
                if (x.Town == "长安村")
                {
                    number += x.Area;
                }
            }
            ViewBag.One = number;
            number = 0;
            foreach (var x in ret)
            {
                if (x.Town == "精进村")
                {
                    number += x.Area;
                }
            }
            ViewBag.Two = number;
            number = 0;
            foreach (var x in ret)
            {
                if (x.Town == "东风村")
                {
                    number += x.Area;
                }
            }
            ViewBag.Three = number;
            number = 0;
            foreach (var x in ret)
            {
                if (x.Town == "民利村")
                {
                    number += x.Area;
                }
            }
            ViewBag.Four = number;
            number = 0;
            foreach (var x in ret)
            {
                if (x.Town == "龙泉村")
                {
                    number += x.Area;
                }
            }
            ViewBag.Five = number;
            number = 0;
            foreach (var x in ret)
            {
                if (x.Town == "福德村")
                {
                    number += x.Area;
                }
            }
            ViewBag.Six = number;
            number = 0;
            foreach (var x in ret)
            {
                if (x.Town == "和乐村")
                {
                    number += x.Area;
                }
            }
            ViewBag.Seven = number;
            number = 0;
            foreach (var x in ret)
            {
                if (x.Town == "德宝村")
                {
                    number += x.Area;
                }
            }
            ViewBag.Eight = number;
            number = 0;
            foreach (var x in ret)
            {
                if (x.Town == "祥顺村")
                {
                    number += x.Area;
                }
            }
            ViewBag.Nine = number;
            number = 0;
            foreach (var x in ret)
            {
                if (x.Town == "诚顺村")
                {
                    number += x.Area;
                }
            }
            ViewBag.Ten = number;
            number = 0;
            return View();
        }
        /// <summary>
        /// 瓜菜扇形图
        /// </summary>
        /// <param name="selectyear"></param>
        /// <param name="selectmonth"></param>
        /// <returns></returns>
        [HttpGet]
        public IActionResult GetVegetables(int selectyear, int selectmonth)
        {
            var town = DB.Towns
                .OrderBy(x => x.Id)
                .ToList();
            var ret = new List<SituationPie>();
            foreach (var x in town)
            {
                var person = DB.Familys
                    .Where(y => y.TownId == x.Id)
                    .OrderBy(y => y.TownId)
                    .ToList();
                foreach (var y in person)
                {
                    var vegetables = DB.FamilySituations
                        .Include(z => z.Family)
                        .Where(z => z.FamilyId == y.Id)
                        .OrderBy(z => z.Family.TownId)
                        .ToList();
                    foreach (var z in vegetables)
                    {
                        if (z.CreateTime.Year == selectyear && z.CreateTime.Month == selectmonth)
                        {
                            ret.Add(new SituationPie
                            {
                                Id = z.Id,
                                Type = "瓜菜",
                                Time = selectyear + "/" + selectmonth,
                                Town = DB.Towns.Where(i => i.Id == z.Family.TownId).SingleOrDefault().Title,
                                Area = z.Vegetables,
                            });
                        }
                    }
                }
            }
            ViewBag.Ret = ret;
            ViewBag.Time = selectyear + "/" + selectmonth;
            Double number = 0;
            foreach (var x in ret)
            {
                if (x.Town == "长安村")
                {
                    number += x.Area;
                }
            }
            ViewBag.One = number;
            number = 0;
            foreach (var x in ret)
            {
                if (x.Town == "精进村")
                {
                    number += x.Area;
                }
            }
            ViewBag.Two = number;
            number = 0;
            foreach (var x in ret)
            {
                if (x.Town == "东风村")
                {
                    number += x.Area;
                }
            }
            ViewBag.Three = number;
            number = 0;
            foreach (var x in ret)
            {
                if (x.Town == "民利村")
                {
                    number += x.Area;
                }
            }
            ViewBag.Four = number;
            number = 0;
            foreach (var x in ret)
            {
                if (x.Town == "龙泉村")
                {
                    number += x.Area;
                }
            }
            ViewBag.Five = number;
            number = 0;
            foreach (var x in ret)
            {
                if (x.Town == "福德村")
                {
                    number += x.Area;
                }
            }
            ViewBag.Six = number;
            number = 0;
            foreach (var x in ret)
            {
                if (x.Town == "和乐村")
                {
                    number += x.Area;
                }
            }
            ViewBag.Seven = number;
            number = 0;
            foreach (var x in ret)
            {
                if (x.Town == "德宝村")
                {
                    number += x.Area;
                }
            }
            ViewBag.Eight = number;
            number = 0;
            foreach (var x in ret)
            {
                if (x.Town == "祥顺村")
                {
                    number += x.Area;
                }
            }
            ViewBag.Nine = number;
            number = 0;
            foreach (var x in ret)
            {
                if (x.Town == "诚顺村")
                {
                    number += x.Area;
                }
            }
            ViewBag.Ten = number;
            number = 0;
            return View();
        }
        /// <summary>
        /// 杂豆扇形图
        /// </summary>
        /// <param name="selectyear"></param>
        /// <param name="selectmonth"></param>
        /// <returns></returns>
        [HttpGet]
        public IActionResult GetMixedBeans(int selectyear, int selectmonth)
        {
            var town = DB.Towns
                .OrderBy(x => x.Id)
                .ToList();
            var ret = new List<SituationPie>();
            foreach (var x in town)
            {
                var person = DB.Familys
                    .Where(y => y.TownId == x.Id)
                    .OrderBy(y => y.TownId)
                    .ToList();
                foreach (var y in person)
                {
                    var mixedBeans = DB.FamilySituations
                        .Include(z => z.Family)
                        .Where(z => z.FamilyId == y.Id)
                        .OrderBy(z => z.Family.TownId)
                        .ToList();
                    foreach (var z in mixedBeans)
                    {
                        if (z.CreateTime.Year == selectyear && z.CreateTime.Month == selectmonth)
                        {
                            ret.Add(new SituationPie
                            {
                                Id = z.Id,
                                Type = "杂豆",
                                Time = selectyear + "/" + selectmonth,
                                Town = DB.Towns.Where(i => i.Id == z.Family.TownId).SingleOrDefault().Title,
                                Area = z.MixedBeans,
                            });
                        }
                    }
                }
            }
            ViewBag.Ret = ret;
            ViewBag.Time = selectyear + "/" + selectmonth;
            Double number = 0;
            foreach (var x in ret)
            {
                if (x.Town == "长安村")
                {
                    number += x.Area;
                }
            }
            ViewBag.One = number;
            number = 0;
            foreach (var x in ret)
            {
                if (x.Town == "精进村")
                {
                    number += x.Area;
                }
            }
            ViewBag.Two = number;
            number = 0;
            foreach (var x in ret)
            {
                if (x.Town == "东风村")
                {
                    number += x.Area;
                }
            }
            ViewBag.Three = number;
            number = 0;
            foreach (var x in ret)
            {
                if (x.Town == "民利村")
                {
                    number += x.Area;
                }
            }
            ViewBag.Four = number;
            number = 0;
            foreach (var x in ret)
            {
                if (x.Town == "龙泉村")
                {
                    number += x.Area;
                }
            }
            ViewBag.Five = number;
            number = 0;
            foreach (var x in ret)
            {
                if (x.Town == "福德村")
                {
                    number += x.Area;
                }
            }
            ViewBag.Six = number;
            number = 0;
            foreach (var x in ret)
            {
                if (x.Town == "和乐村")
                {
                    number += x.Area;
                }
            }
            ViewBag.Seven = number;
            number = 0;
            foreach (var x in ret)
            {
                if (x.Town == "德宝村")
                {
                    number += x.Area;
                }
            }
            ViewBag.Eight = number;
            number = 0;
            foreach (var x in ret)
            {
                if (x.Town == "祥顺村")
                {
                    number += x.Area;
                }
            }
            ViewBag.Nine = number;
            number = 0;
            foreach (var x in ret)
            {
                if (x.Town == "诚顺村")
                {
                    number += x.Area;
                }
            }
            ViewBag.Ten = number;
            number = 0;
            return View();
        }
        /// <summary>
        /// 其它农作物扇形图
        /// </summary>
        /// <param name="selectyear"></param>
        /// <param name="selectmonth"></param>
        /// <returns></returns>
        [HttpGet]
        public IActionResult GetOthersArea(int selectyear, int selectmonth)
        {
            var town = DB.Towns
                .OrderBy(x => x.Id)
                .ToList();
            var ret = new List<SituationPie>();
            foreach (var x in town)
            {
                var person = DB.Familys
                    .Where(y => y.TownId == x.Id)
                    .OrderBy(y => y.TownId)
                    .ToList();
                foreach (var y in person)
                {
                    var othersArea = DB.FamilySituations
                        .Include(z => z.Family)
                        .Where(z => z.FamilyId == y.Id)
                        .OrderBy(z => z.Family.TownId)
                        .ToList();
                    foreach (var z in othersArea)
                    {
                        if (z.CreateTime.Year == selectyear && z.CreateTime.Month == selectmonth)
                        {
                            ret.Add(new SituationPie
                            {
                                Id = z.Id,
                                Type = "其它农作物",
                                Time = selectyear + "/" + selectmonth,
                                Town = DB.Towns.Where(i => i.Id == z.Family.TownId).SingleOrDefault().Title,
                                Area = z.OthersArea,
                            });
                        }
                    }
                }
            }
            ViewBag.Ret = ret;
            ViewBag.Time = selectyear + "/" + selectmonth;
            Double number = 0;
            foreach (var x in ret)
            {
                if (x.Town == "长安村")
                {
                    number += x.Area;
                }
            }
            ViewBag.One = number;
            number = 0;
            foreach (var x in ret)
            {
                if (x.Town == "精进村")
                {
                    number += x.Area;
                }
            }
            ViewBag.Two = number;
            number = 0;
            foreach (var x in ret)
            {
                if (x.Town == "东风村")
                {
                    number += x.Area;
                }
            }
            ViewBag.Three = number;
            number = 0;
            foreach (var x in ret)
            {
                if (x.Town == "民利村")
                {
                    number += x.Area;
                }
            }
            ViewBag.Four = number;
            number = 0;
            foreach (var x in ret)
            {
                if (x.Town == "龙泉村")
                {
                    number += x.Area;
                }
            }
            ViewBag.Five = number;
            number = 0;
            foreach (var x in ret)
            {
                if (x.Town == "福德村")
                {
                    number += x.Area;
                }
            }
            ViewBag.Six = number;
            number = 0;
            foreach (var x in ret)
            {
                if (x.Town == "和乐村")
                {
                    number += x.Area;
                }
            }
            ViewBag.Seven = number;
            number = 0;
            foreach (var x in ret)
            {
                if (x.Town == "德宝村")
                {
                    number += x.Area;
                }
            }
            ViewBag.Eight = number;
            number = 0;
            foreach (var x in ret)
            {
                if (x.Town == "祥顺村")
                {
                    number += x.Area;
                }
            }
            ViewBag.Nine = number;
            number = 0;
            foreach (var x in ret)
            {
                if (x.Town == "诚顺村")
                {
                    number += x.Area;
                }
            }
            ViewBag.Ten = number;
            number = 0;
            return View();
        }
        /// <summary>
        /// 种植业收入扇形图
        /// </summary>
        /// <param name="selectyear"></param>
        /// <param name="selectmonth"></param>
        /// <returns></returns>
        [HttpGet]
        public IActionResult GetFarmingIncome(int selectyear, int selectmonth)
        {
            var town = DB.Towns
                .OrderBy(x => x.Id)
                .ToList();
            var ret = new List<SituationPie>();
            foreach (var x in town)
            {
                var person = DB.Familys
                    .Where(y => y.TownId == x.Id)
                    .OrderBy(y => y.TownId)
                    .ToList();
                foreach (var y in person)
                {
                    var farmingIncome = DB.FamilySituations
                        .Include(z => z.Family)
                        .Where(z => z.FamilyId == y.Id)
                        .OrderBy(z => z.Family.TownId)
                        .ToList();
                    foreach (var z in farmingIncome)
                    {
                        if (z.CreateTime.Year == selectyear && z.CreateTime.Month == selectmonth)
                        {
                            ret.Add(new SituationPie
                            {
                                Id = z.Id,
                                Type = "种植业收入",
                                Time = selectyear + "/" + selectmonth,
                                Town = DB.Towns.Where(i => i.Id == z.Family.TownId).SingleOrDefault().Title,
                                Area = z.FarmingIncome,
                            });
                        }
                    }
                }
            }
            ViewBag.Ret = ret;
            ViewBag.Time = selectyear + "/" + selectmonth;
            Double number = 0;
            foreach (var x in ret)
            {
                if (x.Town == "长安村")
                {
                    number += x.Area;
                }
            }
            ViewBag.One = number;
            number = 0;
            foreach (var x in ret)
            {
                if (x.Town == "精进村")
                {
                    number += x.Area;
                }
            }
            ViewBag.Two = number;
            number = 0;
            foreach (var x in ret)
            {
                if (x.Town == "东风村")
                {
                    number += x.Area;
                }
            }
            ViewBag.Three = number;
            number = 0;
            foreach (var x in ret)
            {
                if (x.Town == "民利村")
                {
                    number += x.Area;
                }
            }
            ViewBag.Four = number;
            number = 0;
            foreach (var x in ret)
            {
                if (x.Town == "龙泉村")
                {
                    number += x.Area;
                }
            }
            ViewBag.Five = number;
            number = 0;
            foreach (var x in ret)
            {
                if (x.Town == "福德村")
                {
                    number += x.Area;
                }
            }
            ViewBag.Six = number;
            number = 0;
            foreach (var x in ret)
            {
                if (x.Town == "和乐村")
                {
                    number += x.Area;
                }
            }
            ViewBag.Seven = number;
            number = 0;
            foreach (var x in ret)
            {
                if (x.Town == "德宝村")
                {
                    number += x.Area;
                }
            }
            ViewBag.Eight = number;
            number = 0;
            foreach (var x in ret)
            {
                if (x.Town == "祥顺村")
                {
                    number += x.Area;
                }
            }
            ViewBag.Nine = number;
            number = 0;
            foreach (var x in ret)
            {
                if (x.Town == "诚顺村")
                {
                    number += x.Area;
                }
            }
            ViewBag.Ten = number;
            number = 0;
            return View();
        }
        /// <summary>
        /// 养殖业收入扇形图
        /// </summary>
        /// <param name="selectyear"></param>
        /// <param name="selectmonth"></param>
        /// <returns></returns>
        [HttpGet]
        public IActionResult GetBreedingIncome(int selectyear, int selectmonth)
        {
            var town = DB.Towns
                .OrderBy(x => x.Id)
                .ToList();
            var ret = new List<SituationPie>();
            foreach (var x in town)
            {
                var person = DB.Familys
                    .Where(y => y.TownId == x.Id)
                    .OrderBy(y => y.TownId)
                    .ToList();
                foreach (var y in person)
                {
                    var breedingIncome = DB.FamilySituations
                        .Include(z => z.Family)
                        .Where(z => z.FamilyId == y.Id)
                        .OrderBy(z => z.Family.TownId)
                        .ToList();
                    foreach (var z in breedingIncome)
                    {
                        if (z.CreateTime.Year == selectyear && z.CreateTime.Month == selectmonth)
                        {
                            ret.Add(new SituationPie
                            {
                                Id = z.Id,
                                Type = "养殖业收入",
                                Time = selectyear + "/" + selectmonth,
                                Town = DB.Towns.Where(i => i.Id == z.Family.TownId).SingleOrDefault().Title,
                                Area = z.BreedingIncome,
                            });
                        }
                    }
                }
            }
            ViewBag.Ret = ret;
            ViewBag.Time = selectyear + "/" + selectmonth;
            Double number = 0;
            foreach (var x in ret)
            {
                if (x.Town == "长安村")
                {
                    number += x.Area;
                }
            }
            ViewBag.One = number;
            number = 0;
            foreach (var x in ret)
            {
                if (x.Town == "精进村")
                {
                    number += x.Area;
                }
            }
            ViewBag.Two = number;
            number = 0;
            foreach (var x in ret)
            {
                if (x.Town == "东风村")
                {
                    number += x.Area;
                }
            }
            ViewBag.Three = number;
            number = 0;
            foreach (var x in ret)
            {
                if (x.Town == "民利村")
                {
                    number += x.Area;
                }
            }
            ViewBag.Four = number;
            number = 0;
            foreach (var x in ret)
            {
                if (x.Town == "龙泉村")
                {
                    number += x.Area;
                }
            }
            ViewBag.Five = number;
            number = 0;
            foreach (var x in ret)
            {
                if (x.Town == "福德村")
                {
                    number += x.Area;
                }
            }
            ViewBag.Six = number;
            number = 0;
            foreach (var x in ret)
            {
                if (x.Town == "和乐村")
                {
                    number += x.Area;
                }
            }
            ViewBag.Seven = number;
            number = 0;
            foreach (var x in ret)
            {
                if (x.Town == "德宝村")
                {
                    number += x.Area;
                }
            }
            ViewBag.Eight = number;
            number = 0;
            foreach (var x in ret)
            {
                if (x.Town == "祥顺村")
                {
                    number += x.Area;
                }
            }
            ViewBag.Nine = number;
            number = 0;
            foreach (var x in ret)
            {
                if (x.Town == "诚顺村")
                {
                    number += x.Area;
                }
            }
            ViewBag.Ten = number;
            number = 0;
            return View();
        }
        /// <summary>
        /// 其它收入扇形图
        /// </summary>
        /// <param name="selectyear"></param>
        /// <param name="selectmonth"></param>
        /// <returns></returns>
        [HttpGet]
        public IActionResult GetOthersIncome(int selectyear, int selectmonth)
        {
            var town = DB.Towns
                .OrderBy(x => x.Id)
                .ToList();
            var ret = new List<SituationPie>();
            foreach (var x in town)
            {
                var person = DB.Familys
                    .Where(y => y.TownId == x.Id)
                    .OrderBy(y => y.TownId)
                    .ToList();
                foreach (var y in person)
                {
                    var othersIncome = DB.FamilySituations
                        .Include(z => z.Family)
                        .Where(z => z.FamilyId == y.Id)
                        .OrderBy(z => z.Family.TownId)
                        .ToList();
                    foreach (var z in othersIncome)
                    {
                        if (z.CreateTime.Year == selectyear && z.CreateTime.Month == selectmonth)
                        {
                            ret.Add(new SituationPie
                            {
                                Id = z.Id,
                                Type = "其它收入",
                                Time = selectyear + "/" + selectmonth,
                                Town = DB.Towns.Where(i => i.Id == z.Family.TownId).SingleOrDefault().Title,
                                Area = z.OthersIncome,
                            });
                        }
                    }
                }
            }
            ViewBag.Ret = ret;
            ViewBag.Time = selectyear + "/" + selectmonth;
            Double number = 0;
            foreach (var x in ret)
            {
                if (x.Town == "长安村")
                {
                    number += x.Area;
                }
            }
            ViewBag.One = number;
            number = 0;
            foreach (var x in ret)
            {
                if (x.Town == "精进村")
                {
                    number += x.Area;
                }
            }
            ViewBag.Two = number;
            number = 0;
            foreach (var x in ret)
            {
                if (x.Town == "东风村")
                {
                    number += x.Area;
                }
            }
            ViewBag.Three = number;
            number = 0;
            foreach (var x in ret)
            {
                if (x.Town == "民利村")
                {
                    number += x.Area;
                }
            }
            ViewBag.Four = number;
            number = 0;
            foreach (var x in ret)
            {
                if (x.Town == "龙泉村")
                {
                    number += x.Area;
                }
            }
            ViewBag.Five = number;
            number = 0;
            foreach (var x in ret)
            {
                if (x.Town == "福德村")
                {
                    number += x.Area;
                }
            }
            ViewBag.Six = number;
            number = 0;
            foreach (var x in ret)
            {
                if (x.Town == "和乐村")
                {
                    number += x.Area;
                }
            }
            ViewBag.Seven = number;
            number = 0;
            foreach (var x in ret)
            {
                if (x.Town == "德宝村")
                {
                    number += x.Area;
                }
            }
            ViewBag.Eight = number;
            number = 0;
            foreach (var x in ret)
            {
                if (x.Town == "祥顺村")
                {
                    number += x.Area;
                }
            }
            ViewBag.Nine = number;
            number = 0;
            foreach (var x in ret)
            {
                if (x.Town == "诚顺村")
                {
                    number += x.Area;
                }
            }
            ViewBag.Ten = number;
            number = 0;
            return View();
        }
        /// <summary>
        /// 补贴扇形图
        /// </summary>
        /// <param name="selectyear"></param>
        /// <param name="selectmonth"></param>
        /// <returns></returns>
        [HttpGet]
        public IActionResult GetTipsIncome(int selectyear, int selectmonth)
        {
            var town = DB.Towns
                .OrderBy(x => x.Id)
                .ToList();
            var ret = new List<SituationPie>();
            foreach (var x in town)
            {
                var person = DB.Familys
                    .Where(y => y.TownId == x.Id)
                    .OrderBy(y => y.TownId)
                    .ToList();
                foreach (var y in person)
                {
                    var tipsIncome = DB.FamilySituations
                        .Include(z => z.Family)
                        .Where(z => z.FamilyId == y.Id)
                        .OrderBy(z => z.Family.TownId)
                        .ToList();
                    foreach (var z in tipsIncome)
                    {
                        if (z.CreateTime.Year == selectyear && z.CreateTime.Month == selectmonth)
                        {
                            ret.Add(new SituationPie
                            {
                                Id = z.Id,
                                Type = "补贴",
                                Time = selectyear + "/" + selectmonth,
                                Town = DB.Towns.Where(i => i.Id == z.Family.TownId).SingleOrDefault().Title,
                                Area = z.TipsIncome,
                            });
                        }
                    }
                }
            }
            ViewBag.Ret = ret;
            ViewBag.Time = selectyear + "/" + selectmonth;
            Double number = 0;
            foreach (var x in ret)
            {
                if (x.Town == "长安村")
                {
                    number += x.Area;
                }
            }
            ViewBag.One = number;
            number = 0;
            foreach (var x in ret)
            {
                if (x.Town == "精进村")
                {
                    number += x.Area;
                }
            }
            ViewBag.Two = number;
            number = 0;
            foreach (var x in ret)
            {
                if (x.Town == "东风村")
                {
                    number += x.Area;
                }
            }
            ViewBag.Three = number;
            number = 0;
            foreach (var x in ret)
            {
                if (x.Town == "民利村")
                {
                    number += x.Area;
                }
            }
            ViewBag.Four = number;
            number = 0;
            foreach (var x in ret)
            {
                if (x.Town == "龙泉村")
                {
                    number += x.Area;
                }
            }
            ViewBag.Five = number;
            number = 0;
            foreach (var x in ret)
            {
                if (x.Town == "福德村")
                {
                    number += x.Area;
                }
            }
            ViewBag.Six = number;
            number = 0;
            foreach (var x in ret)
            {
                if (x.Town == "和乐村")
                {
                    number += x.Area;
                }
            }
            ViewBag.Seven = number;
            number = 0;
            foreach (var x in ret)
            {
                if (x.Town == "德宝村")
                {
                    number += x.Area;
                }
            }
            ViewBag.Eight = number;
            number = 0;
            foreach (var x in ret)
            {
                if (x.Town == "祥顺村")
                {
                    number += x.Area;
                }
            }
            ViewBag.Nine = number;
            number = 0;
            foreach (var x in ret)
            {
                if (x.Town == "诚顺村")
                {
                    number += x.Area;
                }
            }
            ViewBag.Ten = number;
            number = 0;
            return View();
        }
    }

}
