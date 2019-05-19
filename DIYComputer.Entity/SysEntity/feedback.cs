using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DIYComputer.Entity.SysEntity
{

    public class Feedback:BaseEntity
    {
        [Display(Name ="反馈内容")]
        public string FeedContent { get; set; }

        [Display(Name = "是否处理")]
        public string Ishandle { get; set; } = "未处理";
 
        [Display(Name ="提出人账户")]
        public string PostMan { get; set; }

    }
}
