using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using DIYComputer.Config.StaticSource;
namespace DIYComputer.Entity.ComputerWareEntity
{
    [Table("C_CPUHS")]
    public class CPUHS :CGroutBaseEntity
    {

        /// <summary>
        /// 风扇适应CPU类别
        /// </summary>
        [Display(Name ="适用芯片类别")]
        [Required(ErrorMessage = "不能为空")]
        public string CPUHSType { get; set; }  
        /// <summary>
        /// 功能
        /// </summary>
        [Display(Name = "功能")]
        [Required(ErrorMessage = "不能为空")]
        public string CPUHSFunction
        {
            get
            {
                return GetStrs(CPUHSFunctions);
            }


            set
            {
                if (value != null)
                    CPUHSFunctions = value.Split(';');
                value = GetStrs(CPUHSFunctions);
            }
        }
        [NotMapped]
        public string[] CPUHSFunctions { get; set; } = new string[] { };
        /// <summary>
        /// 散热适用类别
        /// </summary>
        [Display(Name = "散热适用类别")]
        [Required(ErrorMessage = "不能为空")]
        public string CPUHSSuitable { get; set; }  

        /// <summary>
        /// 热管数量
        /// </summary>
        [Display(Name = "热管数量")]
        [Required(ErrorMessage = "不能为空")]
        public string CPUHSHeatPipes { get; set; }  

        /// <summary>
        /// 热管材质
        /// </summary>
        [Display(Name = "热管材质")]
        [Required(ErrorMessage = "不能为空")]
        public string CPUHSClass { get; set; }  

        public CPUHS()
        {
            HardWareEnum =  HardWareEnum.CPU散热器;
        }
    }
}
