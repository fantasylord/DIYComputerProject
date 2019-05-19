using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using DIYComputer.Config.StaticSource;
namespace DIYComputer.Entity.ComputerWareEntity
{
    [Table("C_ROM")]
    public class ROM :CGroutBaseEntity
    {
    
        /// <summary>
        /// 容量
        /// </summary>
        [Display(Name = "容量")]
        public string ROMCapacity { get; set; } 
        /// <summary>
        /// 主频
        /// </summary>
        [Display(Name = "主频")]
        public string ROMMHz { get; set; } 
        /// <summary>
        /// 类别
        /// </summary>
        [Display(Name = "类别")]
        public string ROMClass { get; set; } 
        /// <summary>
        /// 适用
        /// </summary>
        [Display(Name = "适用")]
        public string ROMSuitable { get; set; } 
        /// <summary>
        /// 类型
        /// </summary>
        [Display(Name = "类型")]
        public string ROMDDRType { get; set; } 
        /// <summary>
        /// 校验
        /// </summary>
        [Display(Name = "校验")]
        public string ROMCheckout { get; set; } 

        public ROM()
        {
            HardWareEnum =  HardWareEnum.内存;
        }
    }
}
