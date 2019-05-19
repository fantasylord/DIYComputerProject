using DIYComputer.Entity.SysEntity;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace DIYComputer.DtoModel.SysDto
{
    public class UserLoginModel
    {
        //[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        //public int BuyerID { set; get; }
        [MaxLength(30)]
        [Display(Name = "用户ID")]
        [RegularExpression("^[a-zA-Z0-9_]{6,20}$", ErrorMessage = "用户名由字母或数字组成。")]
        [Required(ErrorMessage = "用户账户不能为空")]
        public string Account { set; get; }
        [Display(Name = "用户密码")]
        [DataType(DataType.Password)]
        [Required(ErrorMessage = "用户密码不能为空")]
        public string PW { set; get; }

        public string Message { get; set; }

        public int Codeid { get; set; } = -1;

        public string Code { get; set; } = "";
    }

    public class UserRegisterModel
        {

        [MaxLength(30)]
        [Display(Name = "用户ID")]
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
        public string ConfirmPassword { get; set; }

        [Display(Name = "联系方式")]
        public string Tell { set; get; }
        [Display(Name = "邮箱")]
        public string Mail { set; get; }


        public string Message { get; set; }


    }

    public class UserDisplayModel :BaseEntity
    {
        //public int BuyerID { set; get; }

        [Display(Name = "用户ID")]
        public string Account { set; get; }

        [Display(Name = "用户姓名")]
        public string Name { set; get; }
        /// <summary>
        /// 积分
        /// </summary>
        public int Integral { set; get; }


        [Display(Name = "联系方式")]
        public string Tell { set; get; }
        [Display(Name = "邮箱")]
        public string Mail { set; get; }

        [Display(Name ="提示消息")]
        public string Message { get; set; }
    }

    public class UserEditModel 
    {

        //public int BuyerID { set; get; }
        [Display(Name = "唯一标志")]
        [ReadOnly(true)]
        public int Id { get; set; }
        [Display(Name = "用户ID")]
        public string Account { set; get; }

        [Display(Name = "用户姓名")]
        public string Name { set; get; }
        [Display(Name = "上次密码")]
        [DataType(DataType.Password)]
        [Required]
        public string PWLast { get; set; }

        [Display(Name = "用户密码")]
        [DataType(DataType.Password)]
        [Required]
        public string PW { set; get; }

        [DataType(DataType.Password)]
        [Display(Name = "确认密码")]
        [Compare("PW", ErrorMessage = "请确保和用户密码一致。")]
        [NotMapped]
        public string ConfirmPassword { get; set; }


        [Display(Name = "联系方式")]
        public string Tell { set; get; }
        [Display(Name = "邮箱")]
        public string Mail { set; get; }

        [Display(Name = "提示消息")]
        [NotMapped]
        public string Message { get; set; }
    }

}
