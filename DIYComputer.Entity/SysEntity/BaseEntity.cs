using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DIYComputer.Entity.SysEntity
{
    public class BaseEntity
    {
        /// <summary>
        /// 唯一整型标识
        /// </summary>
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int Id { get; set; }
        [Display(Name = "创建日期")]
        [ReadOnly(true)]
        public DateTime CreateTime { get; set; } = System.DateTime.Now;
        
        [ReadOnly(true)]
        [Display(Name = "修改日期")]
        public DateTime EditTime { get; set; } = System.DateTime.Now;

        [MaxLength(256)]
        public string Remarks { get; set; } = "";
    }
}
