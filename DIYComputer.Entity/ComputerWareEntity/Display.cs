using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using DIYComputer.Config.StaticSource;
namespace DIYComputer.Entity.ComputerWareEntity
{
    [Table("C_Display")]
    public class Display:CGroutBaseEntity
    {

        /// <summary>
        /// 尺寸
        /// </summary>
        [Display(Name = "尺寸")]
        [Required(ErrorMessage = "不能为空")]
        public string DisplaySize { get; set; }
        /// <summary>
        /// 输入类型 多选
        /// </summary>
        [Display(Name="视频输入")]
        public string  DisplayInputType
        {
            get
            {
                return GetStrs(DisplayInputTypes);
            }


            set
            {
                if (value != null)
                    DisplayInputTypes = value.Split(';');
                value = GetStrs(DisplayInputTypes);
            }
        }
        [NotMapped]
        public string[] DisplayInputTypes { get; set; } = new string[] { };  
        /// <summary>
        /// 其他功能 多选
        /// </summary>
        [Display(Name= "其他功能")]
        [Required(ErrorMessage = "不能为空")]
        public string DisplayOtherFunction
        {
            get
            {
                return GetStrs(DisplayOtherFunctions);
            }


            set
            {
                if (value != null)
                    DisplayOtherFunctions = value.Split(';');
                value = GetStrs(DisplayOtherFunctions);
            }
        }
        [NotMapped]
        public string[]  DisplayOtherFunctions { get; set; } = new string[] { };
        /// <summary>
        /// 产品定位
        /// </summary>
        [Display(Name= "产品定位")]
        [Required(ErrorMessage = "不能为空")]
        public string DisplayUseWay { get; set; } 
        /// <summary>
        /// 外观颜色
        /// </summary>
        [Display(Name= "外观颜色")]
        [Required(ErrorMessage = "不能为空")]
        public string DisplayColor
        {
            get
            {
                return GetStrs(DisplayColors);
            }


            set
            {
                if (value != null)
                    DisplayColors = value.Split(';');
                value = GetStrs(DisplayColors);
            }
        }
        [NotMapped]
        public string[]  DisplayColors { get; set; } = new string[] { };
        /// <summary>
        /// 背光灯类型
        /// </summary>
        [Display(Name= "背光灯类型")]
        public string DisplayBackLED { get; set; }  
        /// <summary>
        /// 面板类型
        /// </summary>
        [Display(Name= "面板类型")]
        public string DisplayBoard { get; set; }  
        /// <summary>
        /// 可视角度
        /// </summary>
        [Display(Name= "可视角度")]
        public string DisplayVisualAngle { get; set; }  
        /// <summary>
        /// 亮度
        /// </summary>
        [Display(Name= "亮度")]
        public string DisplayLuminance { get; set; }  
        /// <summary>
        /// 分辨率
        /// </summary>
        [Display(Name= "分辨率")]
        [Required(ErrorMessage = "不能为空")]
        public string DisplayDpi { get; set; }  
        /// <summary>
        /// 点距
        /// </summary>
        [Display(Name= "点距")]
        public string DisplayDotPitch { get; set; }  
        /// <summary>
        /// 屏幕比例
        /// </summary>
        [Display(Name= "屏幕比例")]
        [Required(ErrorMessage = "不能为空")]
        public string DisplayRatio { get; set; }  

        public Display()
        {
            HardWareEnum =  HardWareEnum.显示器;
        }
    }
}
