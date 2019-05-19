using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DIYComputer.Entity.SysEntity
{


    /// <summary>
    /// 用户实体模型
    /// </summary>
    public class User:BaseEntity
    {
        //[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        //public int BuyerID { set; get; }
        [MaxLength(30)]
        [Display(Name= "用户ID")]
        [RegularExpression("^[a-zA-Z0-9_]{6,20}$", ErrorMessage = "用户名由字母或数字组成。")]
        [Required]
        public string Account { set; get; }
        [Display(Name = "用户姓名")]
        [Required]
        public string Name { set; get; }
        /// <summary>
        /// 积分
        /// </summary>
        public int Integral { set; get; }

        [Display(Name = "用户密码")]
        [DataType(DataType.Password)]
        [Required]
        public string PW { set; get; }

        [DataType(DataType.Password)]
        [Display(Name = "确认密码")]
        [Compare("PW", ErrorMessage = "请确保和用户密码一致。")]
        [NotMapped]
        public  string ConfirmPassword { get; set; } 

        [Display(Name = "联系方式")]
        public string Tell { set; get; }
        [Display(Name ="邮箱")]
        public string Mail { set; get; }
     
        public DateTime LastTime { get; set; }

        public ICollection<Topic> Topics { get; set; }

        public ICollection<Reply> Replies { get; set; }

    }
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            //  builder.HasKey(x => new { x.BuyerID });

            builder.HasKey(x =>new { x.Id});
            
            builder.Property(x => x.Account).IsRequired().HasMaxLength(30);

            builder.Property(x => x.Name).IsRequired().HasMaxLength(30);

            builder.Property(x => x.Integral).IsRequired();

            builder.Property(x => x.PW).IsRequired().HasMaxLength(30);

            builder.Property(x => x.Tell).IsRequired().HasMaxLength(30);

            builder.Property(x => x.Mail).IsRequired().HasMaxLength(30);

            builder.Property(x => x.LastTime).IsRequired().HasMaxLength(30);
            //builder.Property(x => x.LastTime).IsRequired().HasMaxLength(30);


        }
    }

}


