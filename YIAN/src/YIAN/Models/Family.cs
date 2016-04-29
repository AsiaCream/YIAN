using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace YIAN.Models
{
    public class Family
    {
        //户主
        public int Id { get; set; }
        public int PoorNo { get; set; }//贫困户编号
        public int PhoneNumber { get; set; }//联系电话
        public string Name { get; set; }//姓名
        public int Age { get; set; }//年龄
        public string Sex { get; set; }//性别
        public string Address { get; set; }
        [MaxLength(18)]
        public string CardNo { get; set; }//身份证
        public string IsDisability { get; set; }//是否残疾
        public string RelationShip { get; set; }//与户主关系
        public string Education { get; set; }//教育情况
        public string IsOnSchool { get; set; }//在校生情况
        public int Ability { get; set; }//劳动能力
        public string IsHealth { get; set; }//身体状况
        public string Work { get; set; }//务工情况
        public string IsLow { get; set; }//是否低保
        public string IsNewFarm { get; set; }//是否参加新农合
        public string IsOldInsurance { get; set; }//是否参加养老保险
        public string IsWorkInsurance { get; set; }//是否务工保险
        public string Skills { get; set; }//一技之长

        public string Helper { get; set; }//对接人
        public string Measures { get; set; }//方法

        

        [ForeignKey("Town")]
        public int TownId { get; set; }
        public virtual Town Town { get; set; }
    }
}
