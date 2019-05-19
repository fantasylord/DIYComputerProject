using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace DIYComputer.DtoModel.SysDto
{
    public class AdminLogin
    {
        [MaxLength(30)]
        [Display(Name = "管理员ID")]
        // [RegularExpression("^[a-zA-Z0-9_]{6,20}$", ErrorMessage = "管理员由字母或数字组成。")]
        [Required]
        public string Account { set; get; }
        [Display(Name = "管理员密码")]
        //[DataType(DataType.Password)]
        [Required]
        public string PW { set; get; }

        [NotMapped]
        public string Message { set; get; }
    }
}
