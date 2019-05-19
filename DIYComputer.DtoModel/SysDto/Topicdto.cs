using DIYComputer.Entity.SysEntity;
using System;
using System.ComponentModel.DataAnnotations;

namespace DIYComputer.DtoModel.SysDto
{
    /// <summary>
    /// 列表model
    /// </summary>
    public class TopicListModel : BaseEntity
    {

        public TopicListModel()
        {
            EditTime = DateTime.Now;
        }

        [Display(Name = "文章标题")]
        [MaxLength(50, ErrorMessage = "长度超过50字符")]
        public string Title { get; set; }

        [Display(Name = "文章存储路径")]
        public string ContentURL { get; set; }

        [Display(Name = "创建时间")]
        public new DateTime CreateTime { get; set; } = System.DateTime.Now;

        [Display(Name = "修改时间")]
        public new DateTime EditTime { get; set; }
        [Display(Name = "概要")]
        public string Outline { get; set; }


        [Display(Name = "发布时IP地址")]
        public string IP { get; set; }

        [Display(Name = "所属类别")]
        public int TopicClassID { get; set; }

        [Display(Name = "账户名称")]
        public string Account { get; set; }

        [Display(Name ="用户昵称")]
        public string UserName { get; set; }
        [Display(Name = "编号")]
        public int UserID { get; set; }

        [Display(Name ="文章评论数")]
        public int Replies { get; set; }


    }
    /// <summary>
    /// 详情model
    /// </summary>
    public class TopicContentModel : BaseEntity
    {
        public TopicContentModel()
        {
            EditTime = System.DateTime.Now;
        }

        [Display(Name = "文章标题")]
        [MaxLength(50, ErrorMessage = "长度超过50字符")]
        [Required]
        public string Title { get; set; }

        [Display(Name = "文章存储路径")]
        [MaxLength(512)]
        [Required]
        public string ContentURL { get; set; }

        [Display(Name = "创建时间")]
        public new DateTime CreateTime { get; set; } = System.DateTime.Now;

        [Display(Name = "修改时间")]
        public new DateTime EditTime { get; set; }


        [Display(Name = "发布时IP地址")]
        public string IP { get; set; }

        [Display(Name = "所属类别")]
        public int TopicClassID { get; set; }

        [Display(Name = "账户名称")]
        public string Account { get; set; }
        [Display(Name = "编号")]
        public int UserID { get; set; }
        [Display (Name ="概要")]
        public string Outline { get; set; }

        public string htmlstr { get; set; }
    }
}
