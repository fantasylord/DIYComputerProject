using DIYComputer.Entity.SysEntity;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DIYComputer.DtoModel.SysDto
{
    public class ReplyDisplay : BaseEntity
    {

        public Topic Topic { get; set; }

        [Display(Name = "用户昵称")]
        public string UserName { get; set; }
        [Display(Name = "用户账号")]
        public string UserAccount { set; get; }

        [Display(Name = "文章标题")]
        public string TopicTitle { get; set; }
        [Display(Name = "文章编号")]
        public int? TopicId { get; set; }
        [Display(Name = "评论内容")]
        public string Content { get; set; }

        public int? GoodCount { get; set; }

    }
    public class ReplyList
    {
        public ICollection<ReplyDisplay> Replies { get; set; }


    }
}
