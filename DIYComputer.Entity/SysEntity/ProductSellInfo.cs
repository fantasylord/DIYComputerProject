using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace DIYComputer.Entity.SysEntity
{
    public class ProductSellInfo
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int Id { get; set; }

        

        [Display(Name ="月排行")]
        public int TopMouth { get; set; }

        [Display(Name = "收藏数")]
        public int AddLover { get; set; }

        [Display(Name ="总点击数")]
        public int ClickCount { get; set; }

    }
}
