using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DIYComputer.Entity.SysEntity
{
    [Table("TopicClass")]
    public class TopicClass:BaseEntity
    {
        /// <summary>
        /// 节点名称
        /// </summary>
        [StringLength(30)]
        [MaxLength(30)]
        [Display(Name = "类别名称")]
        public string Name { get; set; }

        /// <summary>
        /// 父节点
        /// </summary>
        [Display(Name = "上级类别Id")]
        public int? ParentNodeId { get; set; }

        [ForeignKey("ParentNodeId")]
        [Display(Name = "上级类别")]
        public virtual TopicClass ParentNode { get; set; }


        public virtual ICollection<TopicClass> Childnodes { get; set; }

        public ICollection<Topic> Topics { get; set; }

        public TopicClass()
        {
            CreateTime = DateTime.Now;
            EditTime = DateTime.Now;
        }
    

    }
}
