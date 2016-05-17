using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Mvc;
using YIAN.Models;
using YIAN.ViewModels;
using Microsoft.Data.Entity;
using Microsoft.AspNet.Authorization;

namespace YIAN.Controllers
{
    [Authorize]
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
        #region 低保线管理
        /// <summary>
        /// 低保线显示
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult LowLine()
        {
            var line = DB.LowLines.ToList();
            return View(line);
        }
        /// <summary>
        /// 低保线修改
        /// </summary>
        /// <param name="id"></param>
        /// <param name="lowline"></param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult EditLowLine(int id, LowLine lowline)
        {
            var oldline = DB.LowLines
                .Where(x => x.Id == id)
                .SingleOrDefault();
            if (oldline == null)
            {
                return RedirectToAction("Error", "Home");
            }
            else
            {
                oldline.Line = lowline.Line;
                oldline.Time = DateTime.Now;
                DB.SaveChanges();
                return RedirectToAction("LowLine", "Admin");
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
                return Content("success");
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
        //编辑户主信息
        [HttpGet]
        public IActionResult EditFamily(int id)
        {
            var oldfamily = DB.Familys
                .Where(x => x.Id == id)
                .SingleOrDefault();
            if (oldfamily == null)
            {
                return RedirectToAction("Error", "Home");
            }
            else
            {
                return View(oldfamily);
            }
            
        }
        [HttpPost]
        public IActionResult EditFamily(int id,Family family)
        {
            var NewFamily = DB.Familys
                .Where(x => x.Id == id)
                .SingleOrDefault();
            NewFamily.PoorNo = family.PoorNo;
            NewFamily.PhoneNumber = family.PhoneNumber;
            NewFamily.Name = family.Name;
            NewFamily.Age = family.Age;
            NewFamily.Sex = family.Sex;
            NewFamily.Address = family.Address;
            NewFamily.CardNo = family.CardNo;
            NewFamily.IsDisability = family.IsDisability;
            NewFamily.RelationShip = family.RelationShip;
            NewFamily.Education = family.Education;
            NewFamily.IsOnSchool = family.IsOnSchool;
            NewFamily.Ability = family.Ability;
            NewFamily.IsHealth = family.IsHealth;
            NewFamily.Work = family.Work;
            NewFamily.IsLow = family.IsLow;
            NewFamily.IsNewFarm = family.IsNewFarm;
            NewFamily.IsOldInsurance = family.IsOldInsurance;
            NewFamily.IsWorkInsurance = family.IsWorkInsurance;
            NewFamily.Skills = family.Skills;
            NewFamily.Helper = family.Helper;
            NewFamily.Measures = family.Measures;
      
            DB.SaveChanges();
            return Content("success");
        }
        //编辑家庭成员信息
        [HttpGet]
        public IActionResult EditFamilyMember(int id)
        {
            var member = DB.FamilyMembers
                .Where(x => x.Id == id)
                .SingleOrDefault();
            if(member == null)
            {
                return RedirectToAction("Error", "Home");
            }
            else
            {
                return View(member);
            }
        }
        [HttpPost]
        public IActionResult EditFamilyMember(int id,FamilyMember familyMember)
        {
            var NewFamilyMember = DB.FamilyMembers
                .Where(x => x.Id == id)
                .SingleOrDefault();
            NewFamilyMember.PhoneNumber = familyMember.PhoneNumber;
            NewFamilyMember.Name = familyMember.Name;
            NewFamilyMember.Age = familyMember.Age;
            NewFamilyMember.Sex = familyMember.Sex;
            NewFamilyMember.Address = familyMember.Address;
            NewFamilyMember.CardNo = familyMember.CardNo;
            NewFamilyMember.IsDisability = familyMember.IsDisability;
            NewFamilyMember.RelationShip = familyMember.RelationShip;
            NewFamilyMember.Education = familyMember.Education;
            NewFamilyMember.IsOnSchool = familyMember.IsOnSchool;
            NewFamilyMember.Ability = familyMember.Ability;
            NewFamilyMember.IsHealth = familyMember.IsHealth;
            NewFamilyMember.Work = familyMember.Work;
            NewFamilyMember.IsLow = familyMember.IsLow;
            NewFamilyMember.IsNewFarm = familyMember.IsNewFarm;
            NewFamilyMember.IsOldInsurance = familyMember.IsOldInsurance;
            NewFamilyMember.IsWorkInsurance = familyMember.IsWorkInsurance;
            NewFamilyMember.Skills = familyMember.Skills;

            DB.SaveChanges();
            return Content("success");
        }
        [HttpGet]
        public IActionResult Situation(int id)
        {
            var ret = DB.FamilySituations
                .Where(x => x.FamilyId == id)
                .ToList();
            ViewBag.Family = DB.Familys
                .Where(x => x.Id == id)
                .SingleOrDefault();
            return View(ret);
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
        public IActionResult CreateSituation(int id,int FourTurbines, int AgriculturalMachinery, double ArableLand, double HousingArea,string BuildingStructure,int Cow,
            int Horse,int Sheep,int Chicken,int Duck,int Goose,int Pig,int OthersAnimal,int Corn, double SoyBeans, double Potato, double Sunflower, double Sorghum, double Grains,
            double Rice, double Vegetables, double MixedBeans, double OthersArea, double FarmingIncome, double BreedingIncome, double OthersIncome, double TipsIncome, string PoorReason,
            string SupportMeasures)
        {
            var oldsituation = DB.FamilySituations
                .Where(x => x.FamilyId == id)
                .Where(x=>x.CreateTime.Month==DateTime.Now.Month && x.CreateTime.Year == DateTime.Now.Year)
                .SingleOrDefault();
            if (oldsituation!=null)
            {
                if(oldsituation.CreateTime.Year == DateTime.Now.Year && oldsituation.CreateTime.Month == DateTime.Now.Month)
                {
                    return Content("created");
                }
                else
                {
                    var PCount = DB.FamilyMembers.Where(x => x.FamilyId == id).Count() + DB.Familys.Where(x => x.Id == id).Count();
                    var situation = new FamilySituation
                    {
                        FourTurbines=FourTurbines,
                        ArableLand = ArableLand,
                        AgriculturalMachinery = AgriculturalMachinery,
                        HousingArea= HousingArea,
                        BuildingStructure= BuildingStructure,
                        Cow=Cow,
                        Horse=Horse,
                        Sheep=Sheep,
                        Chicken=Chicken,
                        Duck=Duck,
                        Goose=Goose,
                        Pig=Pig,
                        OthersAnimal=OthersAnimal,
                        Corn=Corn,
                        SoyBeans=SoyBeans,
                        Potato=Potato,
                        Sunflower=Sunflower,
                        Sorghum=Sorghum,
                        Grains=Grains,
                        Rice=Rice,
                        Vegetables=Vegetables,
                        MixedBeans=MixedBeans,
                        OthersArea = OthersArea,
                        FarmingIncome =FarmingIncome,
                        BreedingIncome=BreedingIncome,
                        OthersIncome=OthersIncome,
                        TipsIncome=TipsIncome,
                        PoorReason=PoorReason,
                        SupportMeasures=SupportMeasures,
                    };
                    DB.FamilySituations.Add(situation);
                    situation.FamilyId = id;
                    situation.CreateTime = DateTime.Now;
                    situation.YearTotalIncome = Math.Round((situation.FarmingIncome + situation.BreedingIncome + situation.OthersIncome + situation.TipsIncome) * 12, 2);
                    situation.YearAnnualPerCapitaIncome = Math.Round(situation.YearTotalIncome / PCount, 2);
                    DB.SaveChanges();
                    return Content("success");
                }
            }
            else
            {
                var PCount = DB.FamilyMembers.Where(x => x.FamilyId == id).Count() + DB.Familys.Where(x => x.Id == id).Count();
                var situation = new FamilySituation
                {
                    FourTurbines = FourTurbines,
                    ArableLand = ArableLand,
                    AgriculturalMachinery = AgriculturalMachinery,
                    HousingArea = HousingArea,
                    BuildingStructure = BuildingStructure,
                    Cow = Cow,
                    Horse = Horse,
                    Sheep = Sheep,
                    Chicken = Chicken,
                    Duck = Duck,
                    Goose = Goose,
                    Pig = Pig,
                    OthersAnimal = OthersAnimal,
                    Corn = Corn,
                    SoyBeans = SoyBeans,
                    Potato = Potato,
                    Sunflower = Sunflower,
                    Sorghum = Sorghum,
                    Grains = Grains,
                    Rice = Rice,
                    Vegetables = Vegetables,
                    MixedBeans = MixedBeans,
                    OthersArea = OthersArea,
                    FarmingIncome = FarmingIncome,
                    BreedingIncome = BreedingIncome,
                    OthersIncome = OthersIncome,
                    TipsIncome = TipsIncome,
                    PoorReason = PoorReason,
                    SupportMeasures = SupportMeasures,
                };
                DB.FamilySituations.Add(situation);
                situation.FamilyId = id;
                situation.CreateTime = DateTime.Now;
                situation.YearTotalIncome = (situation.FarmingIncome + situation.BreedingIncome + situation.OthersIncome + situation.TipsIncome) * 12;
                situation.YearAnnualPerCapitaIncome = situation.YearTotalIncome / PCount;
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
            ViewBag.FamilyHost = DB.Familys
                .Where(x => x.Id == id)
                .SingleOrDefault();
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
        /// <summary>
        /// 创建家庭成员
        /// </summary>
        /// <param name="id"></param>
        /// <param name="Name"></param>
        /// <param name="Age"></param>
        /// <param name="Sex"></param>
        /// <param name="Address"></param>
        /// <param name="PhoneNumber"></param>
        /// <param name="CardNo"></param>
        /// <param name="IsDisability"></param>
        /// <param name="RelationShip"></param>
        /// <param name="Education"></param>
        /// <param name="IsOnShool"></param>
        /// <param name="Ability"></param>
        /// <param name="IsHealth"></param>
        /// <param name="Work"></param>
        /// <param name="IsLow"></param>
        /// <param name="IsNewFarm"></param>
        /// <param name="IsOldInurance"></param>
        /// <param name="IsWorkInsurance"></param>
        /// <param name="Skills"></param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult CreateFamilyMember(int id,string Name,int Age,string Sex,string Address,string PhoneNumber,
            string CardNo,string IsDisability,string RelationShip,string Education,string IsOnSchool,int Ability,string IsHealth,
            string Work,string IsLow,string IsNewFarm,string IsOldInurance,string IsWorkInsurance,string Skills,string Helper,string Measures)
        {

            var member = new FamilyMember
            {
                Name = Name,
                Age = Age,
                Sex = Sex,
                Address = Address,
                PhoneNumber = PhoneNumber,
                CardNo = CardNo,
                IsDisability = IsDisability,
                RelationShip = RelationShip,
                Education = Education,
                IsOnSchool = IsOnSchool,
                Ability = Ability,
                IsHealth = IsHealth,
                Work = Work,
                IsLow = IsLow,
                IsNewFarm = IsNewFarm,
                IsOldInsurance = IsOldInurance,
                IsWorkInsurance = IsWorkInsurance,
                Skills = Skills,
                FamilyId=id,
                Helper = Helper,
                Measures = Measures,
            };
            DB.FamilyMembers.Add(member);
            DB.SaveChanges();
            return Content("success");
        }
        [HttpGet]
        public IActionResult Search()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Search(string key)
        {
            var host = DB.Familys
                .Where(x => x.Name.Contains(key) || x.Address.Contains(key))
                .ToList();
            var Member = DB.FamilyMembers
                .Where(x => x.Name.Contains(key) || x.Address.Contains(key))
                .Count();
            var poorno = DB.Familys
                .Where(x => x.PoorNo.ToString() == key)
                .SingleOrDefault();
            if (host.Count() != 0 || Member != 0||poorno!=null)
            {
                return Content("success");
            }
            else
            {
                return Content("error");
            }
        }
        [HttpGet]
        public IActionResult GetSearch(string key)
        {
            var host = DB.Familys
                .Where(x => x.Name.Contains(key) || x.Address.Contains(key))
                .ToList();
            var Member = DB.FamilyMembers
                .Include(x=>x.Family)
                .Where(x => x.Name.Contains(key) || x.Address.Contains(key))
                .ToList();
            var p = DB.Familys
                .Where(x => x.PoorNo.ToString() == key)
                .SingleOrDefault();
            ViewBag.Member = Member;
            ViewBag.PoorMember = p;
            return View(host);
        }
    }
}
