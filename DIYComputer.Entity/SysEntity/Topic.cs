using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace DIYComputer.Entity.SysEntity
{
    /// <summary>
    /// 文章实体
    /// </summary>
    [Table("Topic")]
    public class Topic : BaseEntity
    {


        public Topic()
        {
            UserId = 0;
            EditTime = DateTime.Now;
        }

        [Display(Name = "文章标题")]
        [MaxLength(50, ErrorMessage = "长度超过50字符")]
        [Required]
        public string Title { get; set; } = "";

        [Display(Name = "文章存储路径")]
        [MaxLength(512)]
        [Required]
        [ReadOnly(true)]
        public string ContentURL { get; set; } = "";

        [Display(Name = "创建时间")]
        public new DateTime CreateTime { get; set; } = System.DateTime.Now;

        [Display(Name = "修改时间")]
        public new DateTime EditTime { get; set; }


        [Display(Name = "发布时IP地址")]
        public string IP { get; set; } = "";

        [ForeignKey("Id")]
        [Display(Name = "所属类别")]
        [NotMapped]
        public int TopicClassId { get; set; }

        public TopicClass TopicClass { get; set; }

        [Display(Name = "用户编号")]
        public int UserId { get; set; }

        [Display(Name = "概要")]
        public string Outline { get; set; } = "用户很懒，没有概要";

        [ForeignKey("UserId")]
        public User User { get; set; }


        public ICollection<Reply> Replies { get; set; }
        [NotMapped]
        public string htmlstr { get; set; } = "";

    }
    public class TopicConfigruation : IEntityTypeConfiguration<Topic>
    {
        public void Configure(EntityTypeBuilder<Topic> builder)
        {
            builder.HasKey(x => new { x.Id, x.Title });
            builder.Property(x => x.ContentURL).HasMaxLength(512);
            builder.Property(x => x.CreateTime);
            builder.Property(x => x.IP).HasMaxLength(50);

        }
    }
}

