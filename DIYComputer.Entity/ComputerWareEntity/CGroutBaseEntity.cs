
using DIYComputer.Config.ServiceConfig;
using DIYComputer.Config.StaticSource;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace DIYComputer.Entity.ComputerWareEntity
{

    /// <summary>
    /// 品牌，名字，价格，硬件分类HardWareEnum
    /// </summary>
    public class CGroutBaseEntity 
    {
    

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int ID { get; set; }
        [Display(Name = "品牌")]
        [Required(ErrorMessage = "不能为空")]
        public string Brand { get; set; }
 
        [Display(Name = "名字")]
        [Required(ErrorMessage = "不能为空")]
        public string Name {
            get {
                if (name == "硬件名称")
                    return Brand + " " + HardWareEnum;
                return name;
                    }
            set {
                name = value;
            }
        }
        private string name;
        [Display(Name ="参考价格")]
        [Required(ErrorMessage = "不能为空")]
        public decimal Value { get; set; }

        [Display(Name = "硬件分类")]
        public HardWareEnum HardWareEnum { get; set; }
        [ReadOnly(true)]
        [NotMapped]
        public string DisplayImg => Imgurls.FirstOrDefault();

        [Display(Name = "图片存放路径")]
     
        public string Imgurl
        {
            get
            {
                return GetStrs(Imgurls);
            }


            set
            {
                if (value != null)
                    Imgurls = value.Split(';');
                value = GetStrs(Imgurls);
            }
        }
        [NotMapped]
        public string[] Imgurls { get; set; } = new string[] { };

        /// <summary>
        /// 月点击
        /// </summary>
        [Display(Name = "月点击")]
        public int MounthCount { get; set; } = 0;

        [Display(Name = "收藏")]
        public int AddCount { get; set; } = 0;

        /// <summary>
        /// 暂空
        /// </summary>
        [Display(Name = "评论数目")]
        public int ReplyCount { get; set; } = 0;

        public CGroutBaseEntity()
        {
            Imgurl= ServiceConfig.ImageUpUrlDirectory + @"\1.png";
            Name = "硬件名称";
            HardWareEnum= HardWareEnum.其他分类;
            Value = 9999;
            Brand = "默认品牌";
            
        }

        public string GetStrs(string[] strs)
        {
            string str = "";

            foreach (var item in strs)
            {
                str += item + ";";
            }
            return str;
        }
    }
}
