using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using DIYComputer.Config.StaticSource;
namespace DIYComputer.Entity.ComputerWareEntity
{
    [Table("C_HardDisk")]
    public class HardDisk :CGroutBaseEntity
    {
        /// <summary>
        /// 适用类型
        /// </summary>
        [Display(Name = "适用类型")]
        [Required(ErrorMessage = "不能为空")]
        public string HDSuitable { get; set; } 
        /// <summary>
        /// 接口
        /// </summary>
        [Display(Name = "接口")]
        [Required(ErrorMessage = "不能为空")]
        public string HDInterface { get; set; }
        /// <summary>
        /// 转速
        /// </summary>
        [Display(Name = "转速")]
        [Required(ErrorMessage = "不能为空")]
        public string HDRotateSpeed { get; set; }  
        /// <summary>
        /// 缓存容量
        /// </summary>
        [Display(Name = "缓存容量")]
        [Required(ErrorMessage = "不能为空")]
        public string HDCache { get; set; } 
        /// 容量
        /// </summary>
        [Display(Name = "硬盘容量")]
        [Required(ErrorMessage = "不能为空")]
        public string HDCapacity { get; set; } 

        public HardDisk()
        {
            HardWareEnum = HardWareEnum.硬盘;
        }
    }
}
