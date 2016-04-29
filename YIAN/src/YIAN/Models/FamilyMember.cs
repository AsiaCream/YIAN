using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace YIAN.Models
{
    public class FamilyMember
    {
        //家庭成员
        public int Id { get; set; }
        public string Name { get; set; }//姓名
        public int Age { get; set; }//年龄
        public string Sex { get; set; }//性别
        public string Address { get; set; }//地址
        public int PhoneNumber { get; set; }//联系电话
        [MaxLength(18)]
        public string CardNo { get; set; }//身份证号
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

        [ForeignKey("Family")]
        public int FamilyId { get; set; }
        public virtual Family Family { get; set; }
    }
}
