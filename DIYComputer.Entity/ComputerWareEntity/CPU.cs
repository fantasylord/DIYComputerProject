 
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using DIYComputer.Config.StaticSource;
namespace DIYComputer.Entity.ComputerWareEntity
{
    /// <summary>
    /// CPU详细信息
    /// </summary>
    [Table("C_CPU")]
    public class CPU : CGroutBaseEntity
    {
        /// <summary>
        /// CPU系列
        /// </summary>
        [Display(Name = "系列")]
        [Required(ErrorMessage = "不能为空")]
        public string CPUClass { get; set; }
        /// <summary>
        /// CPU核心数目
        /// </summary>
        [Display(Name = "核心数目")]
        [Required(ErrorMessage = "不能为空")]
        public string CPUCoreCount { get; set; }
        /// <summary>
        /// CPU适用类型
        /// </summary>
        [Display(Name = "适用类型")]
        [Required(ErrorMessage = "不能为空")]
        public string CpuSuitable { get; set; }
        /// <summary>
        /// CPU插槽类型
        /// </summary>
        [Display(Name = "插槽类型")]
        [Required(ErrorMessage = "不能为空")]

        public string CPUType { get; set; }
        /// <summary>
        /// CPU是否盒装
        /// </summary>
        [Display(Name = "是否盒装")]
        [Required(ErrorMessage = "不能为空")]
        public string CPUIsCase { get; set; }
        /// <summary>
        /// CPU制造工艺
        /// </summary>
        [Display(Name = "制造工艺")]
        [Required(ErrorMessage = "不能为空")]
        public string CPUTechnology { get; set; }

        public CPU()
        {
            this.HardWareEnum = HardWareEnum.CPU;
        }
    }
}
