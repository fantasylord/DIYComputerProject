 
using DIYComputer.Config.StaticSource;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DIYComputer.Entity.SysEntity
{
    [Table("MenuNode")]
    public class MenuNode : BaseEntity
    {
        /// <summary>
        /// 节点名称
        /// </summary>
        [StringLength(256)]
        [Display(Name="节点名称")]
        public string Name { get; set; }

        /// <summary>
        /// 父节点
        /// </summary>
        [Display(Name="父节点")]
        public int? ParentNodeId { get; set; }

        [ForeignKey("ParentNodeId")]
        [Display(Name="父节点")]
        public virtual MenuNode ParentNode { get; set; }

        [Display(Name ="控制器名称")]
        [MaxLength(30)]
        public string Controller { get; set; }

        public virtual ICollection<MenuNode> Childnodes { get; set; }
        [Display(Name = "请求域")]
        public string Area { get; set; }
        [Display(Name = "请求方法")]
        public ActionEnum Action { get; set; }



    }
}
