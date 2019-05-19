using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using DIYComputer.Config.StaticSource;
namespace DIYComputer.Entity.ComputerWareEntity
{
    [Table("C_Mainboard")]
    public class Mainboard : CGroutBaseEntity
    {
  
        /// <summary>
        /// 芯片类别
        /// </summary>
        [Display(Name ="芯片类别")]
       // [BindProperty]
        [Required(ErrorMessage = "不能为空")]
        public string MBChipClass {get;set;}
        /// <summary>
        /// 芯片型号
        /// </summary>
        [Display(Name ="芯片型号")]
        [Required(ErrorMessage = "不能为空")]
        public string MBAMDChip {get;set;}
        /// <summary>
        /// CPU插槽
        /// </summary>
        [Display(Name ="CPU插槽类别")]
        [Required(ErrorMessage = "不能为空")]
        public string MBCPUType {get;set;}
        /// <summary>
        /// 主板集成功能 可多选,由mbintergrations自动生成
        /// </summary>
        [Display(Name = "主板集成功能")]
        [Required(ErrorMessage = "不能为空")]
        public string MBIntegration
        {
            get {
                return GetStrs(MBIntegrations); }


            set {
                if(value!=null)
                MBIntegrations = value.Split(';');
                value = GetStrs(MBIntegrations);
            }
        }

        /// <summary>
        /// 多字段获取
        /// </summary>
        [NotMapped]
        public string[] MBIntegrations { get; set; } = new string[] { };

        /// <summary>
        /// 主板显示输出 可多选
        /// </summary>
        [Display(Name = "主板显示输出")]
        public string MBDisplayOut{
            get
            {
                return GetStrs(MBDisplayOuts);
            }


            set
            {
                if (value != null)
                    MBDisplayOuts = value.Split(';');
                value = GetStrs(MBDisplayOuts);
            }
        }
        [NotMapped]
        public string[] MBDisplayOuts { get; set; } = new string[] { };
        /// <summary>
        /// 主板PCI-E X16
        /// </summary>
        [Display(Name = "主板PCI-E X16")]
        public string MBDPCIE{get;set;}
        /// <summary>
        /// 主板PIC插槽个数
        /// </summary>
        [Display(Name = "主板PIC插槽个数")]
        public string MBDPICCount{get;set;}
        /// <summary>
        /// 适用类型
        /// </summary>
        [Display(Name = "适用类型")]
        public string MBSuitable{get;set;}
        /// <summary>
        /// 主板类型
        /// </summary>
        [Display(Name = "主板类型")]
        public string MBType{get;set;}
        /// <summary>
        /// 包装类型
        /// </summary>
        [Display(Name = "包装类型")]
        public string MBCase{get;set;}
        public Mainboard()
        {
            this.HardWareEnum =  HardWareEnum.主板;
        }
    }
}
