using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using DIYComputer.Config.StaticSource;
namespace DIYComputer.Entity.ComputerWareEntity
{
    [Table("C_SSD")]
    public class SSD:CGroutBaseEntity
    {

        /// <summary>
        /// 接口类型
        /// </summary>
        [Display(Name = "接口类型")]
        public string SSDInterface { get; set; }
        /// <summary>
        /// 存储容量
        /// </summary>
        [Display(Name ="存储容量")]
        public string SSDCapacity { get; set; }
        /// <summary>
        /// 读取速度
        /// </summary>
        [Display(Name = "读取速度")]
        public string OutSpeed { get; set; }
        /// <summary>
        /// 写入速度
        /// </summary>
        [Display(Name = "写入速度")]
        public string InputSpeed { get; set; }
        public SSD()
        {
            HardWareEnum = HardWareEnum.固态硬盘;
        }

    }
}
