using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using DIYComputer.Config.StaticSource;
namespace DIYComputer.Entity.ComputerWareEntity
{
    [Table("C_NetWork")]
    public class NetWork:CGroutBaseEntity
    {
        /// <summary>
        /// 网络适用类型 万兆 百兆
        /// </summary>
        [Display(Name="网络适用类别")]
        [Required(ErrorMessage = "不能为空")]
        public string NetWokrSuitable
        {
            get
            {
                return GetStrs(NetWokrSuitables);
            }


            set
            {
                if (value != null)
                    NetWokrSuitables = value.Split(';');
                value = GetStrs(NetWokrSuitables);
            }
        }
        [NotMapped]
        public string[] NetWokrSuitables { get; set; } = new string[] { };
        public NetWork()
        {
            HardWareEnum =  HardWareEnum.网卡;
        }
    }
}
