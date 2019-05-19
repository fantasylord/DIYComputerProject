using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using DIYComputer.Config.StaticSource;
namespace DIYComputer.Entity.ComputerWareEntity
{
    [Table("C_Graphyic")]
    public class Graphyic : CGroutBaseEntity
    {


        /// <summary>
        /// 显卡型号（厂商）
        /// </summary>
        [Display(Name = "显卡厂商")]
        [Required(ErrorMessage = "不能为空")]
        public string GraphicFactory { get; set; }

        /// <summary>
        /// 显卡型号
        /// </summary>
        [Display(Name = "显卡型号")]
        [Required(ErrorMessage = "不能为空")]
        public string GraphicType { get; set; }

        /// <summary>
        /// 容量
        /// </summary>
        [Display(Name = "容量")]
        [Required(ErrorMessage = "不能为空")]
        public string GraphicsCapacity { get; set; }
        /// <summary>
        /// 位宽
        /// </summary>
        [Display(Name = "位宽")]
        public string GraphicsBits { get; set; }
        /// <summary>
        /// 接口类型 可多选
        /// </summary>
        [Display(Name = "接口类型")]
        public string GraphicsInterface
        {
            get
            {
                return GetStrs(GraphicsInterfaces);
            }


            set
            {
                if (value != null)
                    GraphicsInterfaces = value.Split(';');
                value = GetStrs(GraphicsInterfaces);
            }
        }
        [NotMapped]
        public string[] GraphicsInterfaces { get; set; } = new string[] { };

        /// <summary>
        /// 定义级别
        /// </summary>
        [Display(Name = "定义级别")]
        public string GraphicsClass { get; set; }
        /// <summary>
        /// 是否盒装
        /// </summary>
        [Display(Name = "是否盒装")]
        public string GraphicsCase { get; set; }

        public Graphyic()
        {
            HardWareEnum =  HardWareEnum.显卡;
        }
    }
}
