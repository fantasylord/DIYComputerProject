using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using DIYComputer.Config.StaticSource;
namespace DIYComputer.Entity.ComputerWareEntity
{
    [Table("C_CDROM")]
    public class CDROM:CGroutBaseEntity
    {
        /// <summary>
        /// 光驱类型
        /// </summary>
        [Display(Name ="光驱类型")]
        [Required(ErrorMessage = "不能为空")]
        public string CDROMType { get; set; }

        public CDROM()
        {
            HardWareEnum =  HardWareEnum.光驱;
        }
    }
}
