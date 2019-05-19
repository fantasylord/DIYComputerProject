using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace DIYComputer.Entity.SysEntity
{
    public class Reply:BaseEntity
    {
        [ForeignKey("UserId")]
        public User User { get; set; }

        [Display(Name ="用户")]
        public int UserId { get; set; }
        public int? TopicId { get; set; }

        [ForeignKey("TopicId")]
        public Topic Topic { get; set; }

        [Display(Name ="评论内容")]
        public string Content { get; set; } = "";


        [Display(Name = "IP地址")]

        public string IP { get; set; } = "";

    }
}
