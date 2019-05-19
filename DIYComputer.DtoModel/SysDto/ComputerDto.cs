using DIYComputer.Entity.ComputerWareEntity;
using DIYComputer.Entity.SysEntity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DIYComputer.DtoModel.SysDto
{
   public class ComputerDto:BaseEntity
    {

        [Display(Name = "机箱")]
        [Required(ErrorMessage = "请选择机箱")]
        public int CaseId { get; set; }

        [Display(Name = "光驱")]
        [Required(ErrorMessage = "请选择光驱")]
        public int CDROMId { get; set; }

        [Display(Name = "处理器")]
        [Required(ErrorMessage = "请选择处理器")]
        public int CPUId { get; set; }

        [Display(Name = "处理器风扇")]
        [Required(ErrorMessage = "请选择处理器风扇")]
        public int CPUHSId { get; set; }

        [Display(Name = "显示器")]
        [Required(ErrorMessage = "显示器")]
        public int DisplayId { get; set; }

        [Display(Name = "显卡")]
        [Required(ErrorMessage = "请选择显卡")]
        public int GraphyicId { get; set; }

        [Display(Name = "机械硬盘")]
        [Required(ErrorMessage = "请选择机械硬盘")]
        public int HardDiskId { get; set; }

        [Display(Name = "主板")]
        [Required(ErrorMessage = "请选择主板")]
        public int MainboardId { get; set; }

        [Display(Name = "网卡")]
        [Required(ErrorMessage = "请选择网卡")]
        public int NetWorkId { get; set; }

        [Display(Name = "电源")]
        [Required(ErrorMessage = "请选择电源")]
        public int PowerId { get; set; }

        [Display(Name = "光驱")]
        [Required(ErrorMessage = "请选择光驱")]
        public int ROMId { get; set; }

        [Display(Name = "固态硬盘")]
        [Required(ErrorMessage = "请选择固态硬盘")]
        public int SSDId { get; set; }
        [Display(Name = "方案名称")]
        [Required(ErrorMessage = "装机方案名称不能为空")]
        public string PlanName { get; set; } = DateTime.Now.ToShortDateString() + "装机方案";

        [Display(Name = "作者ID")]
        public int UserID { get; set; }

        [Display(Name = "估计价格")]
        public int ValueSum { get; set; } = 0;

        //[ForeignKey(("UserID"))]
        public User User { get; set; }

        //[ForeignKey(("CaseId"))]
        public Case Case { get; set; }

        //[ForeignKey(("CDROMId"))]
        public CDROM CDROM { get; set; }

        //[ForeignKey(("CPUId"))]
        public CPU CPU { get; set; }

        //[ForeignKey(("CPUHSId"))]
        public CPUHS CPUHS { get; set; }

        //[ForeignKey(("DisplayId"))]
        public Display Display { get; set; }

        //[ForeignKey(("GraphyicId"))]
        public Graphyic Graphyic { get; set; }

        //[ForeignKey(("HardDiskId"))]
        public HardDisk HardDisk { get; set; }

        //[ForeignKey(("MainboardId"))]
        public Mainboard Mainboard { get; set; }

        //[ForeignKey(("NetWorkId"))]
        public NetWork NetWork { get; set; }

        //[ForeignKey(("PowerId"))]
        public Power Power { get; set; }

        //[ForeignKey(("ROMId"))]
        public ROM ROM { get; set; }

        //[ForeignKey(("SSDId"))]
        public SSD SSD { get; set; }

      
        public UserDisplayModel UserDisplay { get; set; }
        public ComputerDto()
        {
            CreateTime = DateTime.Now;
            EditTime = DateTime.Now;
        }
    }
}
