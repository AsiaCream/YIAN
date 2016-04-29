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
    public class AdminController : BaseController
    {
        #region 村庄管理
        /// <summary>
        /// 展示村庄列表
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult Town()
        {
            var town = DB.Towns
                .OrderByDescending(x => x.Id)
                .ToList();
            return View(town);
        }
        /// <summary>
        /// 执行创建村庄方法
        /// </summary>
        /// <param name="town"></param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult CreateTown(Town town)
        {
            DB.Towns.Add(town);
            town.CreateTime = DateTime.Now;
            DB.SaveChanges();
            return RedirectToAction("Town", "Admin");
        }
        /// 执行创建村庄方法
        /// </summary>
        /// <param name="id"></param>
        /// <param name="newtown"></param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult EditTown(int id, Town newtown)
        {
            var oldtown = DB.Towns
                .Where(x => x.Id == id)
                .SingleOrDefault();
            if (oldtown == null)
            {
                return Content("404");
            }
            else
            {
                oldtown.CreateTime = DateTime.Now;
                oldtown.Title = newtown.Title;
                DB.SaveChanges();
                return RedirectToAction("Town", "Admin");
            }
        }
        /// <summary>
        /// 删除村庄方法
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult DeleteTown(int id)
        {
            var town = DB.Towns
                .Where(x => x.Id == id)
                .SingleOrDefault();
            if (town == null)
            {
                return Content("error");
            }
            else
            {
                DB.Towns.Remove(town);
                DB.SaveChanges();
                return Content("success");
            }
        } 
        #endregion
        /// <summary>
        /// 创建户主视图
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult CreateFamily()
        {
            var town = DB.Towns
                .OrderBy(x => x.Id)
                .ToList();
            return View(town);
        }
        /// <summary>
        /// 执行创建户主方法
        /// </summary>
        /// <param name="family"></param>
        /// <param name="townname">村名</param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult CreateFamily(Family family,string townname)
        {
            var town = DB.Towns
                .Where(x => x.Title == townname)
                .SingleOrDefault();
            if (town == null)
            {
                return Content("404");
            }
            else
            {
                family.TownId = town.Id;
                DB.Familys.Add(family);
                DB.SaveChanges();
                return RedirectToAction("HostDetails","Admin");
            }
            
        }
        /// <summary>
        /// 户主列表
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult HostDetails()
        {
            var host = DB.Familys
                .Include(x=>x.Town)
                .OrderByDescending(x => x.Id)
                .ToList();
            if (host.Count != 0)
            {
                var ret = new List<FamilyTown>();
                foreach (var x in host)
                {
                    ret.Add(new FamilyTown
                    {
                        Id = x.Id,
                        TownName = DB.Towns.Where(y => y.Id == x.TownId).SingleOrDefault().Title,
                        HostName = x.Name,
                        Address = x.Address,
                        CardNo = x.CardNo,
                        PoorNo = x.PoorNo,
                        MemberCount = DB.FamilyMembers.Where(y => y.FamilyId == x.Id).Count()+DB.Familys.Where(y=>y.Id==x.Id).Count(),
                    });
                }

                return View(ret);
            }
            else
            {
                return RedirectToAction("Error", "Home");
            }
            
        }
        /// <summary>
        /// 户主对应家庭情况创建
        /// </summary>
        /// <param name="id">户主Id</param>
        /// <returns></returns>
        [HttpGet]
        public IActionResult CreateSituation(int id)
        {
            if (id.ToString() == null)
            {
                return RedirectToAction("Error", "Home");
            }
            else
            {
                var family = DB.Familys.Where(x => x.Id == id).SingleOrDefault();
                return View(family);
            }
        }
        /// <summary>
        /// 创建户主对应家庭状况
        /// </summary>
        /// <param name="id">户主Id</param>
        /// <param name="situation">家庭情况对象</param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult CreateSituation(int id,FamilySituation situation)
        {
            var oldsituation = DB.FamilySituations
                .Where(x => x.Id == id)
                .SingleOrDefault();
            if (oldsituation!=null)
            {
                if(oldsituation.CreateTime.Month == DateTime.Now.Month)
                {
                    return Content("本月已经创建过");
                }
                else
                {
                    return Content("error");
                }
            }
            else
            {
                DB.FamilySituations.Add(situation);
                situation.FamilyId = id;
                situation.CreateTime = DateTime.Now;
                DB.SaveChanges();
                return Content("success");
            }
        }
        [HttpGet]
        public IActionResult FamilyDetails(int id)
        {
            var familymember = DB.FamilyMembers
                .Where(x => x.FamilyId == id)
                .OrderByDescending(x=>x.Id)
                .ToList();
            ViewBag.FamilyHost = DB.Familys.Where(x => x.Id == id).SingleOrDefault();
            return View(familymember);
        }
        [HttpGet]
        public IActionResult CreateFamilyMember(int id)
        {
            var host = DB.Familys
                .Include(x=>x.Town)
                .Where(x => x.Id == id)
                .SingleOrDefault();
            ViewBag.FamilyCount = DB.Familys.Where(x => x.Id == id).Count() + DB.FamilyMembers.Where(x => x.FamilyId == id).Count();
            return View(host);
        }
        [HttpPost]
        public IActionResult CreateFamilyMember(int id,FamilyMember member)
        {
            DB.FamilyMembers.Add(member);
            member.FamilyId = id;
            DB.SaveChanges();
            return RedirectToAction("HostDetails", "Admin");
        }
    }
}
