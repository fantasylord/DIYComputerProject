using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DIYComputer.Config.StaticSource
{
     /// <summary>
        /// 主机硬件分类
        /// </summary>
        public enum HardWareEnum
        {
            其他分类,
            CPU,
            主板,
            内存,
            显卡,
            硬盘,
            固态硬盘,
            光驱,
            显示器,
            机箱,
            电源,
            键鼠套装,
            CPU散热器,
            机箱风扇,
            网卡,

        }

        public enum ActionEnum
        {
            Index = 0,
            Create = 1,
            Delete,
            Details,
            Edit,
            Search
        }

    #region 自定义枚举类
    public class KeyValue
    {
        public string Key { get; set; }
        public string Value { get; set; }
    }
    public class EnumInfo
    {
        private static readonly EnumInfo instance = new EnumInfo();
        public static EnumInfo GetInstace()
        {
            if (instance != null)
                return instance;
            else
                return new EnumInfo();
        }


        #region 主板信息枚举类EnumMB
        /// <summary>
        /// 主板品牌
        /// </summary>
        public Dictionary<string, string> EnumMBBrand { get; set; } = new Dictionary<string, string>();
        /// <summary>
        /// intel芯片
        /// </summary>
        public Dictionary<string, string> EnumMBIntelChip { get; set; } = new Dictionary<string, string>();
        /// <summary>
        /// AMD芯片
        /// </summary>
        public Dictionary<string, string> EnumMBAMDChip { get; set; } = new Dictionary<string, string>();
        /// <summary>
        /// CPU插槽
        /// </summary>
        public Dictionary<string, string> EnumMBCPUType { get; set; } = new Dictionary<string, string>();
        /// <summary>
        /// 主板集成功能MainBoard
        /// </summary>
        public Dictionary<string, string> EnumMBIntegration { get; set; } = new Dictionary<string, string>();
        /// <summary>
        /// 主板显示输出
        /// </summary>
        public Dictionary<string, string> EnumMBDisplayOut { get; set; } = new Dictionary<string, string>();
        /// <summary>
        /// 主板PCI-E X16
        /// </summary>
        public Dictionary<string, string> EnumMBDPCIE { get; set; } = new Dictionary<string, string>();
        /// <summary>
        /// 主板PIC插槽个数
        /// </summary>
        public Dictionary<string, string> EnumMBDPICCount { get; set; } = new Dictionary<string, string>();
        /// <summary>
        /// 适用类型
        /// </summary>
        public Dictionary<string, string> EnumMBSuitable { get; set; } = new Dictionary<string, string>();
        /// <summary>
        /// 主板类型
        /// </summary>
        public Dictionary<string, string> EnumMBType { get; set; } = new Dictionary<string, string>();
        /// <summary>
        /// 包装类型
        /// </summary>
        public Dictionary<string, string> EnumMBCase { get; set; } = new Dictionary<string, string>();

        #endregion
        #region CPU信息枚举类EnumCPU
        /// <summary>
        /// CPU品牌
        /// </summary>
        public Dictionary<string, string> EnumCPUBrand { get; set; } = new Dictionary<string, string>();
        /// <summary>
        /// CPU系列
        /// </summary>
        public Dictionary<string, string> EnumCPUClass { get; set; } = new Dictionary<string, string>();
        /// <summary>
        /// CPU核心数目
        /// </summary>
        public Dictionary<string, string> EnumCPUCoreCount { get; set; } = new Dictionary<string, string>();
        /// <summary>
        /// CPU适用类型
        /// </summary>
        public Dictionary<string, string> EnumCpuSuitable { get; set; } = new Dictionary<string, string>();
        /// <summary>
        /// CPU插槽类型
        /// </summary>
        public Dictionary<string, string> EnumCPUType { get; set; } = new Dictionary<string, string>();
        /// <summary>
        /// CPU是否盒装
        /// </summary>
        public Dictionary<string, string> EnumCPUIsCase { get; set; } = new Dictionary<string, string>();
        /// <summary>
        /// CPU制造工艺
        /// </summary>
        public Dictionary<string, string> EnumCPUTechnology { get; set; } = new Dictionary<string, string>();

        #endregion
        #region 内存信息枚举类EnumROM
        /// <summary>
        /// 品牌
        /// </summary>
        public Dictionary<string, string> EnumROMBrand { get; set; } = new Dictionary<string, string>();
        /// <summary>
        /// 容量
        /// </summary>
        public Dictionary<string, string> EnumROMCapacity { get; set; } = new Dictionary<string, string>();
        /// <summary>
        /// 主频
        /// </summary>
        public Dictionary<string, string> EnumROMMHz { get; set; } = new Dictionary<string, string>();
        /// <summary>
        /// 类别
        /// </summary>
        public Dictionary<string, string> EnumROMClass { get; set; } = new Dictionary<string, string>();
        /// <summary>
        /// 适用
        /// </summary>
        public Dictionary<string, string> EnumROMSuitable { get; set; } = new Dictionary<string, string>();
        /// <summary>
        /// 类型
        /// </summary>
        public Dictionary<string, string> EnumROMDDRType { get; set; } = new Dictionary<string, string>();
        /// <summary>
        /// 校验
        /// </summary>
        public Dictionary<string, string> EnumROMCheckout { get; set; } = new Dictionary<string, string>();
        #endregion
        #region 显卡信息枚举类型EnumGraphyic
        /// <summary>
        /// 品牌
        /// </summary>
        public Dictionary<string, string> EnumGraphicsBrand { get; set; } = new Dictionary<string, string>();
        /// <summary>
        /// N卡
        /// </summary>
        public Dictionary<string, string> EnumGraphicsNIVDA { get; set; } = new Dictionary<string, string>();
        /// <summary>
        /// A卡
        /// </summary>
        public Dictionary<string, string> EnumGraphicsAMD { get; set; } = new Dictionary<string, string>();
        /// <summary>
        /// 其他类别显卡
        /// </summary>
        public Dictionary<string, string> EnumGraphicsOther { get; set; } = new Dictionary<string, string>();
        /// <summary>
        /// 容量
        /// </summary>
        public Dictionary<string, string> EnumGraphicsCapacity { get; set; } = new Dictionary<string, string>();
        /// <summary>
        /// 位宽
        /// </summary>
        public Dictionary<string, string> EnumGraphicsBits { get; set; } = new Dictionary<string, string>();
        /// <summary>
        /// 接口类型 可多选
        /// </summary>
        public Dictionary<string, string> EnumGraphicsInterface { get; set; } = new Dictionary<string, string>();
        /// <summary>
        /// 定义级别
        /// </summary>
        public Dictionary<string, string> EnumGraphicsClass { get; set; } = new Dictionary<string, string>();
        /// <summary>
        /// 是否盒装
        /// </summary>
        public Dictionary<string, string> EnumGraphicsCase { get; set; } = new Dictionary<string, string>();

        #endregion
        #region 硬盘信息枚举类型EnumHD
        /// <summary>
        /// 硬盘品牌
        /// </summary>
        public Dictionary<string, string> EnumHDBrand { get; set; } = new Dictionary<string, string>();
        /// <summary>
        /// 适用类型
        /// </summary>
        public Dictionary<string, string> EnumHDSuitable { get; set; } = new Dictionary<string, string>();
        /// <summary>
        /// 接口
        /// </summary>
        public Dictionary<string, string> EnumHDInterface { get; set; } = new Dictionary<string, string>();
        /// <summary>
        /// 转速
        /// </summary>
        public Dictionary<string, string> EnumHDRotateSpeed { get; set; } = new Dictionary<string, string>();
        /// <summary>
        /// 缓存容量
        /// </summary>
        public Dictionary<string, string> EnumHDCache { get; set; } = new Dictionary<string, string>();
        /// <summary>
        /// 容量
        /// </summary>
        public Dictionary<string, string> EnumHDCapacity { get; set; } = new Dictionary<string, string>();
        #endregion
        #region 固态信息枚举类型EnumSSD
        /// <summary>
        /// 品牌
        /// </summary>
        public Dictionary<string, string> EnumSSDBrand { get; set; } = new Dictionary<string, string>();
        /// <summary>
        /// 接口类型
        /// </summary>
        public Dictionary<string, string> EnumSSDInterface { get; set; } = new Dictionary<string, string>();


        #endregion
        #region 光驱信息枚举类EnumCDROM
        /// <summary>
        /// 品牌
        /// </summary>
        public Dictionary<string, string> EnumCDROMBrand { get; set; } = new Dictionary<string, string>();
        /// <summary>
        /// 光驱类型
        /// </summary>
        public Dictionary<string, string> EnumCDROMType { get; set; } = new Dictionary<string, string>();
        #endregion
        #region 显示器信息枚举类EnumDisplay
        /// <summary>
        /// 品牌
        /// </summary>
        public Dictionary<string, string> EnumDisplayBrand { get; set; } = new Dictionary<string, string>();
        /// <summary>
        /// 尺寸
        /// </summary>
        public Dictionary<string, string> EnumDisplaySize { get; set; } = new Dictionary<string, string>();
        /// <summary>
        /// 输入类型 多选
        /// </summary>
        public Dictionary<string, string> EnumDisplayInputType { get; set; } = new Dictionary<string, string>();
        /// <summary>
        /// 其他功能 多选
        /// </summary>
        public Dictionary<string, string> EnumDisplayOtherFunction { get; set; } = new Dictionary<string, string>();
        /// <summary>
        /// 产品定位
        /// </summary>
        public Dictionary<string, string> EnumDisplayUseWay { get; set; } = new Dictionary<string, string>();
        /// <summary>
        /// 外观颜色
        /// </summary>
        public Dictionary<string, string> EnumDisplayColor { get; set; } = new Dictionary<string, string>();
        /// <summary>
        /// 背光灯类型
        /// </summary>
        public Dictionary<string, string> EnumDisplayBackLED { get; set; } = new Dictionary<string, string>();
        /// <summary>
        /// 面板类型
        /// </summary>
        public Dictionary<string, string> EnumDisplayBoard { get; set; } = new Dictionary<string, string>();
        /// <summary>
        /// 可视角度
        /// </summary>
        public Dictionary<string, string> EnumDisplayVisualAngle { get; set; } = new Dictionary<string, string>();
        /// <summary>
        /// 亮度
        /// </summary>
        public Dictionary<string, string> EnumDisplayLuminance { get; set; } = new Dictionary<string, string>();
        /// <summary>
        /// 分辨率
        /// </summary>
        public Dictionary<string, string> EnumDisplayDpi { get; set; } = new Dictionary<string, string>();
        /// <summary>
        /// 点距
        /// </summary>
        public Dictionary<string, string> EnumDisplayDotPitch { get; set; } = new Dictionary<string, string>();
        /// <summary>
        /// 屏幕比例
        /// </summary>
        public Dictionary<string, string> EnumDisplayRatio { get; set; } = new Dictionary<string, string>();


        #endregion
        #region 机箱信息枚举类型EnumCase
        /// <summary>
        /// 品牌
        /// </summary>
        public Dictionary<string, string> EnumCaseBrand { get; set; } = new Dictionary<string, string>();
        /// <summary>
        /// 适用环境
        /// </summary>
        public Dictionary<string, string> EnumCaseCondition { get; set; } = new Dictionary<string, string>();
        /// <summary>
        /// 支持功能
        /// </summary>
        public Dictionary<string, string> EnumCaseFunction { get; set; } = new Dictionary<string, string>();
        /// <summary>
        /// 类型
        /// </summary>
        public Dictionary<string, string> EnumCaseType { get; set; } = new Dictionary<string, string>();
        /// <summary>
        /// 结构
        /// </summary>
        public Dictionary<string, string> EnumCaseStruct { get; set; } = new Dictionary<string, string>();
        /// <summary>
        /// 样式
        /// </summary>
        public Dictionary<string, string> EnumCaseStyle { get; set; } = new Dictionary<string, string>();
        /// <summary>
        /// 可选颜色
        /// </summary>
        public Dictionary<string, string> EnumCaseColor { get; set; } = new Dictionary<string, string>();
        #endregion
        #region 电源信息枚举类型EnumPower
        /// <summary>
        /// 品牌
        /// </summary>
        public Dictionary<string, string> EnumPowerBrand { get; set; } = new Dictionary<string, string>();
        /// <summary>
        /// 功能
        /// </summary>
        public Dictionary<string, string> EnumPowerFunction { get; set; } = new Dictionary<string, string>();

        /// <summary>
        /// 功率区间
        /// </summary>
        public Dictionary<string, string> EnumPowerRange { get; set; } = new Dictionary<string, string>();

        /// <summary>
        /// 80PLUS认证
        /// </summary>
        public Dictionary<string, string> EnumPower80PLus { get; set; } = new Dictionary<string, string>();

        /// <summary>
        /// 风扇尺寸
        /// </summary>
        public Dictionary<string, string> EnumPowerFanSize { get; set; } = new Dictionary<string, string>();
        /// <summary>
        /// 4+4CPU接口
        /// </summary>
        public Dictionary<string, string> EnumPower44CPU { get; set; } = new Dictionary<string, string>();
        /// <summary>
        /// 4P CPU接口
        /// </summary>
        public Dictionary<string, string> EnumPower4PCPU { get; set; } = new Dictionary<string, string>();
        /// <summary>
        /// 6+2P显卡
        /// </summary>
        public Dictionary<string, string> EnumPower62P { get; set; } = new Dictionary<string, string>();
        /// <summary>
        /// 电源类型
        /// </summary>
        public Dictionary<string, string> EnumPowerType { get; set; } = new Dictionary<string, string>();

        /// <summary>
        /// 包装类型
        /// </summary>
        public Dictionary<string, string> EnumPowerCase { get; set; } = new Dictionary<string, string>();

        #endregion
        #region CPU散热器信息枚举类CPUHS
        /// <summary>
        /// 品牌
        /// </summary>
        public Dictionary<string, string> EnumCPUHSBrand { get; set; } = new Dictionary<string, string>();
        /// <summary>
        /// 风扇适应CPU类别
        /// </summary>
        public Dictionary<string, string> EnumCPUHSType { get; set; } = new Dictionary<string, string>();
        /// <summary>
        /// 功能
        /// </summary>
        public Dictionary<string, string> EnumCPUHSFunction { get; set; } = new Dictionary<string, string>();
        /// <summary>
        /// 散热适用类别
        /// </summary>
        public Dictionary<string, string> EnumCPUHSSuitable { get; set; } = new Dictionary<string, string>();

        /// <summary>
        /// 热管数量
        /// </summary>
        public Dictionary<string, string> EnumCPUHSHeatPipes { get; set; } = new Dictionary<string, string>();

        /// <summary>
        /// 热管材质
        /// </summary>
        public Dictionary<string, string> EnumCPUHSClass { get; set; } = new Dictionary<string, string>();
        #endregion
        #region 网卡信息枚举类EnumNetWork
        /// <summary>
        /// 网卡品牌
        /// </summary>
        public Dictionary<string, string> EnumNetWokrBrand { get; set; } = new Dictionary<string, string>();
        /// <summary>
        /// 网络适用类型 万兆 百兆
        /// </summary>
        public Dictionary<string, string> EnumNetWokrSuitable { get; set; } = new Dictionary<string, string>();
        #endregion
        /// <summary>
        /// 主板EnumMB,CPU EnumCPU
        /// </summary>
        private EnumInfo()
        {

            string[] items;

            #region-----------主板--------------
            //品牌
            items = new string[]
            {
                 "华硕  ",
                 "微星  ",
                 "技嘉  ",
                 "七彩虹",
                 "INTEL ",
                 "超微  "
            };

            for (int i = 0; i < items.Count(); i++)
            {
                var ss = items.Count();
                EnumMBBrand.Add(i + "", items[i].TrimEnd());
            }

            //Intel芯片
            items = new string[]
            {
                 "B150",
                 "B250",
                 "C222",
                 "C226",
                 "C232",
                 "C602",
                 "C612",
                 "H110",
                 "H170",
                 "H270",
                 "H61 ",
                 "H81 ",
                 "X299",
                 "X99 ",
                 "Z170",
                 "Z270",
                 "Z370"
            };

            for (int i = 0; i < items.Count(); i++)
            {

                EnumMBIntelChip.Add(i + "", items[i].TrimEnd());


            }
            //AMD芯片
            items = new string[]
            {
                 "970  ",
                 "990FX",
                 "A320 ",
                 "A68H ",
                 "A88X ",
                 "B350 ",
                 "X370 ",
                 "X399 "
            };

            for (int i = 0; i < items.Count(); i++)
            {

                EnumMBAMDChip.Add(i + "", items[i].TrimEnd());
            }
            //CPU插槽
            items = new string[]
            {
                 "LGA 1150"          ,
                 "LGA 1151"          ,
                 "LGA 1155"          ,
                 "LGA 1366"          ,
                 "LGA 2011"          ,
                 "LGA 2011-3"        ,
                 "LGA 2066"          ,
                 "Socket AM3+"       ,
                 "Socket AM3+/AM3"   ,
                 "Socket AM4"        ,
                 "Socket FM2+"       ,
                 "Socket FM2/FM2+"   ,
                 "Socket TR4"
            };

            for (int i = 0; i < items.Count(); i++)
            {

                EnumMBCPUType.Add(i + "", items[i].TrimEnd());
            }
            //集成功能
            items = new string[] {

                "eSATA   ",
                "HIFI    ",
                "Killer  ",
                "M.2     ",
                "PCI     ",
                "SATA    ",
                "Express ",
                "SATA  III",
                "U.2     ",
                "USB3.0  ",
                "USB3.1  ",
                "Wi-Fi   ",
                "串口    ",
                "光纤接口",
                "双CPU   ",
                "双网卡  ",
                "四网卡  ",
                "并口    ",
                "蓝牙    ",
                "雷电    ",
                "魔音USB "
            };

            for (int i = 0; i < items.Count(); i++)
            {

                EnumMBIntegration.Add(i + "", items[i].TrimEnd());
            }
            //显示输出
            items = new string[]
            {

                 "DP      ",
                 "DP×2   ",
                 "DVI     ",
                 "HDMI    ",
                 "HDMI×2 ",
                 "VGA     ",
                 "无      "
            };

            for (int i = 0; i < items.Count(); i++)
            {

                EnumMBDisplayOut.Add(i + "", items[i].TrimEnd());
            }
            //PIC-E X16
            items = new string[]
            {
                 "1个",
                 "2个",
                 "3个",
                 "4个",
                 "5个"
            };

            for (int i = 0; i < items.Count(); i++)
            {

                EnumMBDPCIE.Add(i + "", items[i].TrimEnd());
            }
            //PIC插槽
            items = new string[]
            {
                "1×PCI插槽",
                "2×PCI插槽",
                "3×PCI插槽",
            };

            for (int i = 0; i < items.Count(); i++)
            {

                EnumMBDPICCount.Add(i + "", items[i].TrimEnd());
            }
            //适用类型
            items = new string[]
            {
                "台式机",
                "服务器"
            };

            for (int i = 0; i < items.Count(); i++)
            {

                EnumMBSuitable.Add(i + "", items[i].TrimEnd());
            }
            //主板类型
            items = new string[]
            {
                "ATX",
                "E-ATX",
                "Micro-ATX",
                "Mini-ITX"
            };

            for (int i = 0; i < items.Count(); i++)
            {

                EnumMBType.Add(i + "", items[i].TrimEnd());
            }
            //包装类型
            items = new string[]
            {
                "原厂盒包"
            };

            for (int i = 0; i < items.Count(); i++)
            {

                EnumMBCase.Add(i + "", items[i].TrimEnd());
            }
            #endregion
            #region------------CPU--------------
            //品牌
            items = new string[]
            {
                "AMD",
                "Intel"
            };

            for (int i = 0; i < items.Count(); i++)
            {

                EnumCPUBrand.Add(i + "", items[i].TrimEnd());
            }
            //CPU系列
            items = new string[]
            {
                "A10      ",
                "A4       ",
                "A6       ",
                "A8       ",
                "E3-1200  ",
                "E3-1600  ",
                "E5-2400  ",
                "E5-2600  ",
                "E5-5500  ",
                "E5-5600  ",
                "FX       ",
                "R5       ",
                "R7       ",
                "奔腾双核 ",
                "赛扬双核 ",
                "速龙II X4",
                "酷睿i3   ",
                "酷睿i5   ",
                "酷睿i7   ",
                "酷睿i9   ",
                "锐龙 T   "
            };

            for (int i = 0; i < items.Count(); i++)
            {

                EnumCPUClass.Add(i + "", items[i].TrimEnd());
            }
            //核心数量
            items = new string[]
            {
               "八核  ",
               "六核  ",
               "十二核",
               "十六核",
               "十核  ",
               "双核  ",
               "四核  "
            };

            for (int i = 0; i < items.Count(); i++)
            {

                EnumCPUCoreCount.Add(i + "", items[i].TrimEnd());

            }
            //适用类型
            items = new string[]
            {
                "台式机",
                "服务器"
            };

            for (int i = 0; i < items.Count(); i++)
            {

                EnumCpuSuitable.Add(i + "", items[i].TrimEnd());
            }

            //插槽类型
            items = new string[]
            {
                "LGA 1150   ",
                "LGA 1151   ",
                "LGA 1155   ",
                "LGA 1366   ",
                "LGA 2011   ",
                "LGA 2011-v3",
                "Socket AM3+",
                "Socket AM4 ",
                "Socket FM1 ",
                "Socket FM2 ",
                "Socket FM2+",
                "Socket TR4 ",
            };

            for (int i = 0; i < items.Count(); i++)
            {

                EnumCPUType.Add(i + "", items[i].TrimEnd());
            }
            //是否盒装
            items = new string[]
            {
                "散片(保修一年)",
                "盒装(保修三年)"
            };

            for (int i = 0; i < items.Count(); i++)
            {

                EnumCPUIsCase.Add(i + "", items[i].TrimEnd());
            }
            //制作工艺
            items = new string[]
            {
                "14纳米",
                "22纳米",
                "28纳米",
                "32纳米"
            };

            for (int i = 0; i < items.Count(); i++)
            {

                EnumCPUTechnology.Add(i + "", items[i].TrimEnd());
            }
            #endregion
            #region------------内存--------------
            //品牌
            items = new string[]
            {
               "芝奇  ",
               "三星  ",
               "金士顿",
               "海盗船",
               "宇瞻  ",
               "威刚  ",
               "金邦  "
            };

            for (int i = 0; i < items.Count(); i++)
            {

                EnumROMBrand.Add(i + "", items[i].TrimEnd());
            }
            //容量
            items = new string[]
            {
                "16GB",
                "2GB",
                "32GB",
                "4GB",
                "64GB",
                "6GB",
                "8GB"
            };

            for (int i = 0; i < items.Count(); i++)
            {

                EnumROMCapacity.Add(i + "", items[i].TrimEnd());
            }
            //主频
            items = new string[]
            {
               "1333MHz",
               "1600MHz",
               "1866MHz",
               "2133MHz",
               "2400MHz",
               "2666MHz",
               "3000MHz",
               "3200MHz"
            };

            for (int i = 0; i < items.Count(); i++)
            {

                EnumROMMHz.Add(i + "", items[i].TrimEnd());
            }
            //类别
            items = new string[]
            {
                "单条",
                "双通道套装",
                "四通道套装"
            };

            for (int i = 0; i < items.Count(); i++)
            {

                EnumROMClass.Add(i + "", items[i].TrimEnd());
            }
            //适用
            items = new string[]
            {
                "台式机",
                "服务器",
            };

            for (int i = 0; i < items.Count(); i++)
            {

                EnumROMSuitable.Add(i + "", items[i].TrimEnd());
            }
            //DDR类型
            items = new string[]
            {
                "DDR3",
                "DDR4"
            };

            for (int i = 0; i < items.Count(); i++)
            {

                EnumROMDDRType.Add(i + "", items[i].TrimEnd());
            }
            //校验
            items = new string[]
            {
                "ECC",
                "REG ECC"
            };

            for (int i = 0; i < items.Count(); i++)
            {

                EnumROMCheckout.Add(i + "", items[i].TrimEnd());
            }
            #endregion
            #region-------------显卡--------------
            //品牌
            items = new string[]
            {
                "华硕      ",
                "微星      ",
                "影驰      ",
                "迪兰      ",
                "技嘉      ",
                "索泰      ",
                "蓝宝石    ",
                "映众      ",
                "丽台图形卡",
                "七彩虹    "
            };

            for (int i = 0; i < items.Count(); i++)
            {

                EnumGraphicsBrand.Add(i + "", items[i].TrimEnd());
            }
            //N卡
            items = new string[]
            {
                "GT1030   ",
                "GT610    ",
                "GT630    ",
                "GT720    ",
                "GT730    ",
                "GT740    ",
                "GTX1050  ",
                "GTX1050Ti",
                "GTX1060  ",
                "GTX1070  ",
                "GTX1080  ",
                "GTX1080Ti",
                "GTX650   ",
                "GTX750   ",
                "GTX750Ti ",
                "GTX760   ",
                "GTX960   ",
                "GTXTitan "
            };

            for (int i = 0; i < items.Count(); i++)
            {


                EnumGraphicsNIVDA.Add(i + "", items[i].TrimEnd());
            }

            //A卡
            items = new string[]
            {
               "HD7770  ",
               "R5230   ",
               "R7240   ",
               "R7240X  ",
               "R7260X  ",
               "R7340   ",
               "R7350   ",
               "R7360   ",
               "R9270X  ",
               "R9280X  ",
               "R9295X  ",
               "R9380   ",
               "R9390   ",
               "R9390X  ",
               "R9FURY X",
               "RX460   ",
               "RX470   ",
               "RX560   ",
               "RX570   ",
               "RX580   "
            };

            for (int i = 0; i < items.Count(); i++)
            {

                EnumGraphicsAMD.Add(i + "", items[i].TrimEnd());
            }
            //其他卡
            items = new string[]
         {
            "FX5800",
            "K2000 ",
            "K4000 ",
            "K5000 ",
            "K600  ",
            "Q2000 ",
            "Q4000 ",
            "Q5000 ",
            "Q600  ",
            "V3900 ",
            "V4800 ",
            "V4900 ",
            "V5900 ",
            "V7900 "
         };

            for (int i = 0; i < items.Count(); i++)
            {

                EnumGraphicsOther.Add(i + "", items[i].TrimEnd());
            }
            //容量
            items = new string[]
         {
              "1GB  ",
              "11GB ",
              "12GB ",
              "2GB  ",
              "2560M",
              "3GBM ",
              "4GBM ",
              "512M ",
              "6GB  ",
              "8GB  "
         };

            for (int i = 0; i < items.Count(); i++)
            {

                EnumGraphicsCapacity.Add(i + "", items[i].TrimEnd());
            }
            //位宽
            items = new string[]
         {
             "128bit  ",
             "192bit  ",
             "2*512bit",
             "256bit  ",
             "320bit  ",
             "352bit  ",
             "384bit  ",
             "4096bit ",
             "512bit  ",
             "64bit   "
         };

            for (int i = 0; i < items.Count(); i++)
            {

                EnumGraphicsBits.Add(i + "", items[i].TrimEnd());
            }
            //接口
            items = new string[]
         {
             "DP     ",
             "DP×2  ",
             "DP×3  ",
             "DP×4  ",
             "DP×6  ",
             "DVI    ",
             "DVI×2 ",
             "HDMI   ",
             "HDMI×2",
             "S-video",
             "STEREO ",
             "VGA    "
         };

            for (int i = 0; i < items.Count(); i++)
            {

                EnumGraphicsInterface.Add(i + "", items[i].TrimEnd());
            }
            //类型
            items = new string[]
         {
             "入门级",
             "刀卡",
             "发烧级",
             "主流级"
         };

            for (int i = 0; i < items.Count(); i++)
            {

                EnumGraphicsClass.Add(i + "", items[i].TrimEnd());
            }
            //包装
            items = new string[]
         {
             "原厂包装",
             "工包(无包装盒)"
         };

            for (int i = 0; i < items.Count(); i++)
            {

                EnumGraphicsCase.Add(i + "", items[i].TrimEnd());
            }
            #endregion
            #region------------硬盘------------
            //品牌
            items = new string[]
            {
               "希捷",
               "西部数据 WD",
            };

            for (int i = 0; i < items.Count(); i++)
            {

                EnumHDBrand.Add(i + "", items[i].TrimEnd());
            }
            //适应
            items = new string[]
          {
              "台式机",
              "服务器",
          };

            for (int i = 0; i < items.Count(); i++)
            {

                EnumHDSuitable.Add(i + "", items[i].TrimEnd());
            }
            //接口
            items = new string[]
          {
              "SATA        ",
              "SATA2(3Gbps)",
              "SATA3(6Gbps)",
              "Serial ATA  ",
          };

            for (int i = 0; i < items.Count(); i++)
            {

                EnumHDInterface.Add(i + "", items[i].TrimEnd());
            }
            //转速
            items = new string[]
          {
              "5400r/m",
              "5900r/m",
              "7200r/m",
          };

            for (int i = 0; i < items.Count(); i++)
            {

                EnumHDRotateSpeed.Add(i + "", items[i].TrimEnd());
            }
            //缓存
            items = new string[]
          {
              "32MB",
              "64MB",
          };

            for (int i = 0; i < items.Count(); i++)
            {

                EnumHDCache.Add(i + "", items[i].TrimEnd());
            }
            //容量
            items = new string[]
          {
              "1TB",
              "2TB",
              "3TB",
              "4TB"
          };

            for (int i = 0; i < items.Count(); i++)
            {

                EnumHDCapacity.Add(i + "", items[i].TrimEnd());
            }
            #endregion
            #region------------SSD------------
            //品牌
            items = new string[]
            {
                "华硕  ",
                "三星  ",
                "影驰  ",
                "金士顿",
                "海盗船",
                "INTEL ",
                "镁光  ",
                "OCZ   ",
            };

            for (int i = 0; i < items.Count(); i++)
            {

                EnumSSDBrand.Add(i + "", items[i].TrimEnd());
            }
            //接口类型
            items = new string[]
            {
               "M.2         ",
               "PCIe        ",
               "SATA3(6Gbps)",
            };

            for (int i = 0; i < items.Count(); i++)
            {

                EnumSSDInterface.Add(i + "", items[i].TrimEnd());
            }
            #endregion
            #region-----------CDROM------------
            //品牌
            items = new string[]
            {
                "华硕",
                "先锋",
            };

            for (int i = 0; i < items.Count(); i++)
            {

                EnumCDROMBrand.Add(i + "", items[i].TrimEnd());
            }
            //光驱类型
            items = new string[]
            {
                "DVD光驱",
                "DVD刻录机",
                "蓝光COMBO",
                "蓝光刻录机",
            };

            for (int i = 0; i < items.Count(); i++)
            {

                EnumCDROMType.Add(i + "", items[i].TrimEnd());
            }
            #endregion
            #region------------Display------------
            //品牌
            items = new string[]
            {
                "AOC       ",
                "三星      ",
                "戴尔      ",
                "DELL      ",
                "LG        ",
                "优派      ",
                "飞利浦    ",
                "宏基      ",
                "ACER      ",
                "HKC       ",
                "Eizo(艺卓)",
            };

            for (int i = 0; i < items.Count(); i++)
            {

                EnumDisplayBrand.Add(i + "", items[i].TrimEnd());
            }
            //尺寸
            items = new string[]
          {
             "17寸以下 ",
             "18.5寸   ",
             "19.5寸   ",
             "19寸     ",
             "20.7寸   ",
             "21.5寸   ",
             "22寸     ",
             "23.5寸   ",
             "23.6寸   ",
             "23.8寸   ",
             "23寸     ",
             "24寸     ",
             "25寸     ",
             "27寸     ",
             "28寸     ",
             "30寸以上 ",
          };

            for (int i = 0; i < items.Count(); i++)
            {

                EnumDisplaySize.Add(i + "", items[i].TrimEnd());
            }
            //输入
            items = new string[]
          {
              "DP     "  ,
              "DP×2  "  ,
              "DP×3  "  ,
              "DVI    "  ,
              "HDMI   "  ,
              "HDMI×2"  ,
              "HDMI×3"  ,
              "MHL    "  ,
              "VGA    "  ,
          };

            for (int i = 0; i < items.Count(); i++)
            {

                EnumDisplayInputType.Add(i + "", items[i].TrimEnd());
            }
            //功能
            items = new string[]{
   "2.5K    ",
   "2K      ",
   "4K      ",
   "5K      ",
   "MHL     ",
   "USB     ",
   "内置音箱",
   "分屏    ",
   "广视角  ",
   "旋转升降",
   "无线充电",
   "曲面    ",
   "电视功能",
   "窄边框  ",
   "触摸屏  ",
   "读卡器  ",
   "超薄    ",
};

            for (int i = 0; i < items.Count(); i++)
            {

                EnumDisplayOtherFunction.Add(i + "", items[i].TrimEnd());
            }
            //产品定位
            items = new string[]
{
   "娱乐影音",
   "电子竞技",
   "经济实用",
   "行业应用",
   "设计制图",
};

            for (int i = 0; i < items.Count(); i++)
            {

                EnumDisplayUseWay.Add(i + "", items[i].TrimEnd());
            }
            //显示器颜色
            items = new string[]
{
     "拉丝工艺",
     "白色    ",
     "红色    ",
     "绿色    ",
     "蓝色    ",
     "金色    ",
     "银灰色  ",
     "银色    ",
     "香槟色  ",
     "黑色    ",
};

            for (int i = 0; i < items.Count(); i++)
            {

                EnumDisplayColor.Add(i + "", items[i].TrimEnd());
            }
            //背光类型
            items = new string[]
{
     "CCFL背光",
     "LED背光 ",
     "WLED背光",
};

            for (int i = 0; i < items.Count(); i++)
            {

                EnumDisplayBackLED.Add(i + "", items[i].TrimEnd());
            }
            //面板类型
            items = new string[]
{
     "ADS面板",
     "AH-IPS ",
     "IPS面板",
     "MVA面板",
     "PLS面板",
     "PVA面板",
     "TN面板 ",
     "VA面板 ",
};

            for (int i = 0; i < items.Count(); i++)
            {

                EnumDisplayBoard.Add(i + "", items[i].TrimEnd());
            }
            //可视角度
            items = new string[]
{
    "160/160°",
    "170/160°",
    "170/170°",
    "176/160°",
    "176/170°",
    "176/176°",
    "178/170°",
    "178/178°",
    "90/60°  ",
    "90/65°  ",
};

            for (int i = 0; i < items.Count(); i++)
            {

                EnumDisplayVisualAngle.Add(i + "", items[i].TrimEnd());
            }
            //亮度
            items = new string[]
{
    "200cd/㎡",
    "220cd/㎡",
    "250cd/㎡",
    "270cd/㎡",
    "300cd/㎡",
    "350cd/㎡",
    "360cd/㎡",
    "370cd/㎡",
};

            for (int i = 0; i < items.Count(); i++)
            {

                EnumDisplayLuminance.Add(i + "", items[i].TrimEnd());
            }
            //屏幕比例
            items = new string[]
{
    "16:10(宽屏)",
    "16:9(宽屏) ",
    "21:9(全景) ",
    "4:3(方屏)  ",
    "5:4(方屏)  ",
};

            for (int i = 0; i < items.Count(); i++)
            {

                EnumDisplayRatio.Add(i + "", items[i].TrimEnd());
            }
            //分辨率
            items = new string[]
{
    "1280×1024",
    "1366×768 ",
    "1440×900 ",
    "1600×900 ",
    "1680×1050",
    "1920×1080",
    "1920×1200",
    "2560x1080 ",
    "2560×1440",
    "2560×1600",
    "3440x1440 ",
    "3840x2160 ",
    "5120x2880 ",
};

            for (int i = 0; i < items.Count(); i++)
            {

                EnumDisplayDpi.Add(i + "", items[i].TrimEnd());
            }
            //点距
            items = new string[]
{
       "0.23mm以下",
       "0.23mm级  ",
       "0.24mm级  ",
       "0.25mm级  ",
       "0.26mm级  ",
       "0.27mm级  ",
       "0.28mm级  ",
       "0.29mm级  ",
       "0.30mm级  ",
       "0.31mm级  ",
       "0.31mm以上",
};

            for (int i = 0; i < items.Count(); i++)
            {

                EnumDisplayDotPitch.Add(i + "", items[i].TrimEnd());
            }
            #endregion
            #region------------机箱------------
            //品牌
            items = new string[]
            {
               "NZXT    ",
               "海盗船  ",
               "超频三  ",
               "酷冷至尊",
               "Tt      ",
               "航嘉    ",
               "安钛克  ",
               "迎广    ",
               "银欣    ",
               "鑫谷    ",
               "先马    ",
               "至睿    ",
               "撒哈拉  ",
               "硕一    ",
               "iok     ",
               "游戏悍将",
               "爱国者  ",
               "星宇泉  ",
               "联智    ",
               "乔思伯  ",
            };

            for (int i = 0; i < items.Count(); i++)
            {

                EnumCaseBrand.Add(i + "", items[i].TrimEnd());
            }
            //适用环境
            items = new string[]
            {
                "便宜    ",
                "便携    ",
                "办公    ",
                "发烧    ",
                "客厅    ",
                "服务器  ",
                "游戏    ",
                "设计制图",
                "静音    ",
            };

            for (int i = 0; i < items.Count(); i++)
            {

                EnumCaseCondition.Add(i + "", items[i].TrimEnd());
            }
            //功能
            items = new string[]
            {
               "eSATA      ",
               "HDD热插拔  ",
               "IEEE1394   ",
               "USB3.0     ",
               "侧板透明   ",
               "免工具拆装 ",
               "支持水冷   ",
               "电源下置   ",
               "背部理线   ",
               "读卡器     ",
               "遥控       ",
               "防尘设计   ",
               "风扇调速   ",
               "风扇集线器 ",
            };

            for (int i = 0; i < items.Count(); i++)
            {

                EnumCaseFunction.Add(i + "", items[i].TrimEnd());
            }
            //类型
            items = new string[]
            {
               "HTPC  ",
               "mini  ",
               "中塔式",
               "全塔式",
               "服务器",
            };

            for (int i = 0; i < items.Count(); i++)
            {

                EnumCaseType.Add(i + "", items[i].TrimEnd());
            }
            //结构
            items = new string[]
            {
               "1U            ",
               "2U            ",
               "4U            ",
               "ATX           ",
               "EATX          ",
               "ITX           ",
               "MATX          ",
               "MATX,ATX      ",
               "MATX,ATX,EATX ",
               "RTX           ",
            };

            for (int i = 0; i < items.Count(); i++)
            {

                EnumCaseStruct.Add(i + "", items[i].TrimEnd());
            }
            //样式
            items = new string[] {
               "卧式    ",
               "开放式  ",
               "机架式  ",
               "立卧两用",
               "立式    ",
            };

            for (int i = 0; i < items.Count(); i++)
            {

                EnumCaseStyle.Add(i + "", items[i].TrimEnd());
            }

            //颜色
            items = new string[]
            {
               "军绿色",
               "橙色  ",
               "灰色  ",
               "白色  ",
               "红色  ",
               "绿色  ",
               "蓝色  ",
               "金色  ",
               "银色  ",
               "黄色  ",
               "黑白色",
               "黑紫色",
               "黑红色",
               "黑绿色",
               "黑色  ",
               "黑金色",
               "黑黄色",
            };

            for (int i = 0; i < items.Count(); i++)
            {

                EnumCaseColor.Add(i + "", items[i].TrimEnd());
            }
            #endregion
            #region------------电源------------
            //品牌
            items = new string[]
        {
            "海盗船  ",
            "振华    ",
            "Tt      ",
            "酷冷至尊",
            "海韵    ",
            "航嘉    ",
            "安钛克  ",
            "长城    ",
            "鑫谷    ",
            "银欣    ",
            "安耐美  ",
            "全汉    ",
            "爱国者  ",
            "游戏悍将",
            "百事得  ",
            "骨伽    ",
            "荣盛达  ",
        };

            for (int i = 0; i < items.Count(); i++)
            {

                EnumPowerBrand.Add(i + "", items[i].TrimEnd());
            }
            //功能
            items = new string[]
        {

            "led发光 ",
            "主动PFC ",
            "半模组  ",
            "宽电压  ",
            "延时冷却",
            "模组化  ",
            "温控风扇",
            "背部走线",
            "被动PFC ",
            "非模组  ",
        };

            for (int i = 0; i < items.Count(); i++)
            {

                EnumPowerFunction.Add(i + "", items[i].TrimEnd());
            }
            //功率区间
            items = new string[]
        {
           "1000W以上",
           "299W以内 ",
           "300-399W ",
           "400-499W ",
           "500-599W ",
           "600-799W ",
           "800-999W ",
        };

            for (int i = 0; i < items.Count(); i++)
            {

                EnumPowerRange.Add(i + "", items[i].TrimEnd());
            }
            //80PLUS
            items = new string[]
        {
             "白牌  ",
             "白金牌",
             "金牌  ",
             "钛金牌",
             "铜牌  ",
             "银牌  ",
        };

            for (int i = 0; i < items.Count(); i++)
            {

                EnumPower80PLus.Add(i + "", items[i].TrimEnd());
            }
            //风扇尺寸
            items = new string[]
        {
            "无风扇",
            "12cm  ",
            "13.5cm",
            "14cm  ",
            "4cm   ",
            "6cm   ",
            "8cm   ",
        };

            for (int i = 0; i < items.Count(); i++)
            {

                EnumPowerFanSize.Add(i + "", items[i].TrimEnd());
            }
            //4+4CPU接口
            items = new string[]
        {
            "1个",
            "2个",
        };

            for (int i = 0; i < items.Count(); i++)
            {

                EnumPower44CPU.Add(i + "", items[i].TrimEnd());
            }
            //4P CPU接口
            items = new string[]
        {
            "1个",
            "2个",
            "5个",
        };

            for (int i = 0; i < items.Count(); i++)
            {

                EnumPower4PCPU.Add(i + "", items[i].TrimEnd());
            }
            //6P显卡接口
            items = new string[]
        {
             "10个",
             "1个 ",
             "2个 ",
             "3个 ",
             "4个 ",
             "6个 ",
             "8个 ",
             "9个 ",
        };

            for (int i = 0; i < items.Count(); i++)
            {

                EnumPower62P.Add(i + "", items[i].TrimEnd());
            }
            //SATA硬盘接口
            //    items = new string[]
            //{
            //   "1个",
            //   "2个",
            //   "3个",
            //   "4个",
            //   "6个",
            //};

            //电源类型
            items = new string[]
        {
            "台式机",
            "服务器",
        };

            for (int i = 0; i < items.Count(); i++)
            {

                EnumPowerType.Add(i + "", items[i].TrimEnd());
            }
            //包装类型
            items = new string[]
        {
            "原厂盒包 ",
            "工包（无包装盒） ",
        };

            for (int i = 0; i < items.Count(); i++)
            {

                EnumPowerCase.Add(i + "", items[i].TrimEnd());
            }

            #endregion
            #region------------散热------------
            //品牌
            items = new string[]
          {
             "华硕      ",
             "海盗船    ",
             "九州风神  ",
             "酷冷至尊  ",
             "超频三    ",
             "Tt        ",
             "安钛克    ",
             "INTEL     ",
             "捷豹      ",
             "COOLSERVER",
             "思民      ",
             "猫头鹰    ",
          };

            for (int i = 0; i < items.Count(); i++)
            {

                EnumCPUHSBrand.Add(i + "", items[i].TrimEnd());
            }
            //适用平台
            items = new string[]
          {
                "AMD Intel双平台 ",
                "AMD平台 ",
                "Intel平台",
          };

            for (int i = 0; i < items.Count(); i++)
            {

                EnumCPUHSType.Add(i + "", items[i].TrimEnd());
            }
            //功能
            items = new string[]
          {
              "led发光 ",
              "单热排  ",
              "单风扇  ",
              "卧式    ",
              "双热排  ",
              "双风扇  ",
              "散热片  ",
              "无风扇  ",
              "智能温控",
              "水冷    ",
              "涡轮    ",
              "纯铜    ",
              "非智能  ",
          };

            for (int i = 0; i < items.Count(); i++)
            {

                EnumCPUHSFunction.Add(i + "", items[i].TrimEnd());
            }
            //散热器用途
            items = new string[]
          {
               "CPU      ",
               "服务器CPU",
               "机箱     ",
          };

            for (int i = 0; i < items.Count(); i++)
            {

                EnumCPUHSSuitable.Add(i + "", items[i].TrimEnd());
            }
            //热管数量
            items = new string[]
          {
             "2个",
             "3个",
             "4个",
             "5个",
             "6个",
          };

            for (int i = 0; i < items.Count(); i++)
            {

                EnumCPUHSHeatPipes.Add(i + "", items[i].TrimEnd());
            }
            //散热片材质
            items = new string[]
            {
               "铜    ",
               "铝    ",
               "铝塞铜",
            };

            for (int i = 0; i < items.Count(); i++)
            {

                EnumCPUHSClass.Add(i + "", items[i].TrimEnd());
            }
            #endregion
            #region------------网卡------------
            //品牌
            items = new string[]{
                "INTEL",
                "TP-Link",
            };

            for (int i = 0; i < items.Count(); i++)
            {

                EnumNetWokrBrand.Add(i + "", items[i].TrimEnd());
            }
            //类型
            items = new string[]
            {
                "万兆",
                "百兆",
            };

            for (int i = 0; i < items.Count(); i++)
            {

                EnumNetWokrSuitable.Add(i + "", items[i].TrimEnd());
            }
            //类型
            #endregion



        }
        #endregion

    }



}
