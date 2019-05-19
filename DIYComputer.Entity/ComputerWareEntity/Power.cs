using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using DIYComputer.Config.StaticSource;
namespace DIYComputer.Entity.ComputerWareEntity
{
    [Table("C_Power")]
    public class Power:CGroutBaseEntity
    {

        /// <summary>
        /// 功能
        /// </summary>
        [Display(Name="功能")]
        public string PowerFunction
        {
            get
            {
                return GetStrs(PowerFunctions);
            }


            set
            {
                if (value != null)
                    PowerFunctions = value.Split(';');
                value = GetStrs(PowerFunctions);
            }
        }
        [NotMapped]
        [BindProperty]
        public string[] PowerFunctions { get; set; } = new string[] { };

        /// <summary>
        /// 功率区间 额度功率
        /// </summary>
        [Display(Name= "功率")]
        [Required(ErrorMessage = "不能为空")]
        public string PowerRange { get; set; } 

        /// <summary>
        /// 80PLUS认证
        /// </summary>
        [Display(Name= "80PLUS认证")]
        public string Power80PLus { get; set; } 

        /// <summary>
        /// 风扇尺寸
        /// </summary>
        [Display(Name= "风扇尺寸")]
        [Required(ErrorMessage = "不能为空")]
        public string PowerFanSize { get; set; } 
        /// <summary>
        /// 4+4CPU接口
        /// </summary>
        [Display(Name= "4+4CPU接口")]
        public string Power44CPU { get; set; } 
        /// <summary>
        /// 4P CPU接口
        /// </summary>
        [Display(Name= "4P CPU接口")]
        public string Power4PCPU { get; set; } 
        /// <summary>
        /// 6+2P显卡
        /// </summary>
        [Display(Name= "6+2P显卡")]
        public string Power62P { get; set; } 
        /// <summary>
        /// 电源类型
        /// </summary>
        [Display(Name= "电源类型")]
        [Required(ErrorMessage = "不能为空")]
        public string PowerType { get; set; } 

        /// <summary>
        /// 包装类型
        /// </summary>
        [Display(Name= "包装类型")]
        public string PowerCase { get; set; } 

        [Display(Name="SATA硬盘接口")]
        public string PowerSATA { get; set; }
        public Power()
        {
            HardWareEnum = HardWareEnum.电源;
        }
    }
}
