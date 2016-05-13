using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;

namespace YIAN.Models
{
    public class FamilySituation
    {
        public int Id { get; set; }

        public int FourTurbines { get; set; }//农用四轮机
        public int AgriculturalMachinery { get; set; }//农机具
        public double ArableLand { get; set; }//耕地面积
        public double HousingArea { get; set; }//住房面积
        public string BuildingStructure { get; set; }//房屋结构

        public int Cow { get; set; }//牛
        public int Horse { get; set; }//马
        public int Sheep { get; set; }//羊
        public int Chicken { get; set; }//鸡
        public int Duck { get; set; }//鸭
        public int Goose { get; set; }//鹅
        public int Pig { get; set; }//猪
        public int OthersAnimal{ get; set; }//其它牲口

        public int Corn { get; set; }//玉米
        public double SoyBeans { get; set; }//大豆
        public double Potato { get; set; }//马铃薯
        public double Sunflower { get; set; }//葵花
        public double Sorghum { get; set; }//高粱
        public double Grains { get; set; }//杂粮
        public double Rice { get; set; }//水稻
        public double Vegetables { get; set; }//瓜菜
        public double MixedBeans { get; set; }//杂豆
        public double OthersArea { get; set; }//其它农作物

        public double YearTotalIncome { get; set; }//年总收入
        public double YearAnnualPerCapitaIncome { get; set; }//年人均收入

        public double FarmingIncome { get; set; }//种植业收入
        public double BreedingIncome { get; set; }//养殖业收入
        public double OthersIncome { get; set; }//其它收入
        public double TipsIncome { get; set; }//补贴

        public string PoorReason { get; set; }//贫困原因
        public string SupportMeasures { get; set; }//帮扶措施

        public DateTime CreateTime { get; set; }//创建时间

        [ForeignKey("Family")]
        public int FamilyId { get; set; }
        public virtual Family Family { get; set; }
    }
}
