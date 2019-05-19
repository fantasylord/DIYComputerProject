using DIYComputer.Config.StaticSource;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using DIYComputer.Config.StaticSource;
namespace DIYComputer.Entity.SysEntity
{
    /// <summary>
    /// 硬件类别
    /// </summary>
    [Table("HDWGroup")]
    public class HDWGroup:BaseEntity
    {

        [MaxLength(30)]
        [Display(Name ="硬件名称")]
        public string Name { get; set; }

        [MaxLength(255)]
        [Display(Name = "简述")]
        public string Description { get; set; } = "简单介绍该部分硬件";

        [MaxLength(1000)]
        [Display(Name = "详细说明")]
        public string Detail { get; set; } = "详细介绍该部分硬件";

        [Display(Name = "硬件分类")]
        public HardWareEnum HardWareEnum { get; set; } =HardWareEnum.其他分类;

    }

    /// <summary>
    /// 硬件字段添加
    /// </summary>
    public class HDWKeyValue
    {

    }
}
