using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using DIYComputer.Config.StaticSource;
namespace DIYComputer.Entity.ComputerWareEntity
{
    /// <summary>
    /// 机箱
    /// </summary>
    [Table("C_Case")]
    public class Case:CGroutBaseEntity
    {

        /// <summary>
        /// 适用环境 可多选
        /// </summary>
        [Display(Name ="适用环境")]
        public string CaseCondition
        {
            get
            {
                return GetStrs(CaseConditions);
            }


            set
            {
                if (value != null)
                    CaseConditions = value.Split(';');
                value = GetStrs(CaseConditions);
            }
        }
        [NotMapped]
        public string[] CaseConditions { get; set; } = new string[] { };
        /// <summary>
        /// 支持功能 可多选
        /// </summary>
        [Display(Name = "支持功能")]

        public string CaseFunction {
            get
            {
                return GetStrs(CaseFunctions);
            }


            set
            {
                if (value != null)
                    CaseFunctions = value.Split(';');
                value = GetStrs(CaseFunctions);
            }
        }
        [NotMapped]
        public string[] CaseFunctions { get; set; } = new string[] { };
        /// <summary>
        /// 类型
        /// </summary>
        [Display(Name = "类型")]

        public string CaseType { get; set; }
        /// <summary>
        /// 结构
        /// </summary>
        [Display(Name = "结构")]

        public string CaseStruct { get; set; }
        /// <summary>
        /// 样式
        /// </summary>
        [Display(Name = "样式")]

        public string CaseStyle { get; set; }
        /// <summary>
        /// 可选颜色
        /// </summary>
        [Display(Name = "可选颜色")]

        public string CaseColor {
            get
            {
                return GetStrs(CaseColors);
            }


            set
            {
                if (value != null)
                    CaseColors = value.Split(';');
                value = GetStrs(CaseColors);
            }
        }
        [NotMapped]
        public string[] CaseColors { get; set; } = new string[] { };

        public Case()
        {
            HardWareEnum =  HardWareEnum.机箱;
        }
    }
}
