using DIYComputer.Config.StaticSource;
using DIYComputer.Entity.ComputerWareEntity;
using DIYComputer.Entity.SysEntity;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DIYComputer.Entity.DBContext
{
    /// <summary>
    /// 数据库初始化
    /// </summary>
    public static class EFDBContextExtensions
    {

        /// <summary>
        /// 初始化数据
        /// </summary>
        /// <param name="eFDBContext"></param>
        public /***  async ***/ static void EnsureSeedDataForContext(this EFDBContext _dbcontext)
        {
            List<MenuNode> menuNodes = new List<MenuNode>()
            {
                new MenuNode
                {
                    Name="无子节点",
                    ParentNodeId=1,
                    Action =0,
                },
                new MenuNode
                {

                    Name="用户管理",
                    Action=ActionEnum.Index,
                },
                new MenuNode
                {
                    Name="用户列表",
                    ParentNodeId=2,
                    Area="users",
                    Action=ActionEnum.Details,
                },
                new MenuNode
                {
                    Name="用户创建",
                    ParentNodeId=2,
                    Action=ActionEnum.Index,

                },

            };
            if (_dbcontext.MenuNodes.Count() < 1)
                foreach (var item in menuNodes)
                {
                    _dbcontext.Add(item);
                    /***  await ***/ _dbcontext.SaveChanges/***  async ***/();
                }
          
            List<User> users = new List<User>
            {
                new User
                {
                    Account="test01",
                    Name="Tom",
                    Integral=0,
                    PW="test123",
                    ConfirmPassword="test123",
                    Tell="18888888888",
                    Mail="188888@qq.com",
                    LastTime=System.DateTime.Now

                },
                                new User
                {
                    Account="test02",
                    Name="甲",
                    Integral=0,
                    PW="test123",
                    ConfirmPassword="test123",
                    Tell="18888888888",
                    Mail="188888@qq.com",
                    LastTime=System.DateTime.Now

                },
                                                new User
                {
                    Account="test03",
                    Name="乙",
                    Integral=0,
                    PW="test123",
                    ConfirmPassword="test123",
                    Tell="18888888888",
                    Mail="188888@qq.com",
                    LastTime=System.DateTime.Now

                },
            };
            if (_dbcontext.Users.Count() < 1)
              /***  await ***/ _dbcontext.AddRange/***  async ***/(users);

            List<Admin> admins = new List<Admin>
            {
                new Admin()
                {
                    Account="AdminLogin",
                    PW="123456",
                    LastTime=DateTime.Now,
                    ConfirmPassword="123456",
                    Name="管理员01"

                },
                  new Admin()
                {
                    Account="AdminLogin1",
                    PW="123456",
                    LastTime=DateTime.Now,
                    ConfirmPassword="123456",
                    Name="管理员02"

                },
                    new Admin()
                {
                    Account="AdminLogin2",
                    PW="123456",
                    LastTime=DateTime.Now,
                    ConfirmPassword="123456",
                    Name="管理员03"

                },
            };
            if (_dbcontext.Admins.Count() < 1)
                /***  await ***/ _dbcontext.AddRange/***  async ***/(admins);

            List<CPU> cPUs = new List<CPU>()
            {
                new CPU(){
                    Brand="Intel",
                    Value=1130,
                    CPUClass="酷睿i5",
                    CPUCoreCount="四核",
                    CPUType="台式机",
                    CpuSuitable="LGA 1150",
                    CPUIsCase="盒装(保修三年)",
                    CPUTechnology="22 纳米",
                },
                  new CPU(){
                    Brand="Intel",
                    Value=2140,
                    CPUClass="酷睿i7",
                    CPUCoreCount="四核",
                    CPUType="台式机",
                    CpuSuitable="LGA 1151",
                    CPUIsCase="盒装(保修三年)",
                    CPUTechnology="14 纳米",
                },
                   new CPU(){
                    Brand="Intel",
                    Value=1020,
                    CPUClass="E3-1200",
                    CPUCoreCount="四核",
                    CPUType="服务器",
                    CpuSuitable="LGA 1150",
                    CPUIsCase="散片(保修一年)",
                    CPUTechnology="22 纳米",
                },

                new CPU(){
                    Brand="AMD",
                    Value=850,
                    CPUClass="FX",
                    CPUCoreCount="八核",
                    CPUType="台式机",
                    CpuSuitable="Socket AM3+",
                    CPUIsCase="盒装(保修三年)",
                    CPUTechnology="32 纳米",
                },
                  new CPU(){
                    Brand="AMD",
                    Value=370,
                    CPUClass="A8",
                    CPUCoreCount="四核",
                    CPUType="台式机",
                    CpuSuitable="Socket FM2+",
                    CPUIsCase="盒装(保修三年)",
                    CPUTechnology="28 纳米",
                },
            };
            if (_dbcontext.CPUs.Count() < 1)
                /***  await ***/ _dbcontext.AddRange/***  async ***/(cPUs);

            List<Mainboard> mainboards = new List<Mainboard>()
            {
                new Mainboard(){
                    Brand="华硕",
                    Value=521,
                    MBChipClass="Intel芯片",
                    MBAMDChip="B150",
                    MBCPUType="LGA 1151",
                    MBIntegrations=new string[]{"USB3.0","SATA III"},
                    MBDisplayOuts=new string[]{ "VGA","DVI","HDMI" },
                    MBDPCIE="1个",
                    MBDPICCount="",
                    MBSuitable="台式机",
                    MBType="Micro-ATX",
                    MBCase="原厂盒包",
                },
               new Mainboard(){
                    Brand="技嘉",
                    Value=643,
                    MBChipClass="Intel芯片",
                    MBAMDChip="H110",
                    MBCPUType="LGA 1151",
                    MBIntegrations=new string[]{"USB3.0","SATA III","M.2"},
                    MBDisplayOuts=new string[]{ "VGA","DVI","HDMI" },
                    MBDPCIE="1个",
                    MBDPICCount="",
                    MBSuitable="台式机",
                    MBType="Mini-ITX",
                    MBCase="原厂盒包",
                },
                new Mainboard(){
                    Brand="技嘉",
                    Value=485,
                    MBChipClass="AMD芯片",
                    MBAMDChip="A320",
                    MBCPUType="Socket AM4",
                    MBIntegrations=new string[]{ "USB3.1", "光纤接口"},
                    MBDisplayOuts=new string[]{ "VGA","DVI","HDMI" },
                    MBDPCIE="1个",
                    MBDPICCount="",
                    MBSuitable="台式机",
                    MBType="Micro-ATX",
                    MBCase="原厂盒包",
                },
            };
            if (_dbcontext.Mainboards.Count() < 1)
                /***  await ***/ _dbcontext.AddRange/***  async ***/(mainboards);

            List<ROM> roms = new List<ROM>() {
                new ROM()
                {
                   Brand="三星",
                   Value=540,
                   ROMCapacity="8GB",
                   ROMMHz="2400MHz",
                   ROMSuitable="单条",
                   ROMClass="台式机",
                   ROMDDRType="DDR4",
                   ROMCheckout="ECC"
                },
                               new ROM()
                {
                   Brand="三星",
                   Value=875,
                   ROMCapacity="16GB",
                   ROMMHz="1600MHz",
                   ROMSuitable="单条",
                   ROMClass="服务器",
                   ROMDDRType="DDR3",
                   ROMCheckout="REG ECC"
                },
                   new ROM()
                {
                   Brand="金士顿",
                   Value=416,
                   ROMCapacity="8GB",
                   ROMMHz="1600MHz",
                   ROMSuitable="双通道套装",
                   ROMClass="台式机",
                   ROMDDRType="DDR3",
                   ROMCheckout=""
                }
            };
            if (_dbcontext.ROMs.Count() < 1)
                /***  await ***/ _dbcontext.AddRange/***  async ***/(roms);

            List<Graphyic> graphyics = new List<Graphyic>() {
                new Graphyic(){
                    Brand="蓝宝石",
                    Value=5278,
                    GraphicFactory="专业级图像显卡",
                    GraphicType="V7900",
                    GraphicsCapacity="2GB",
                    GraphicsBits="256bit",
                    GraphicsInterfaces=new string[]{"DP×4"},
                    GraphicsClass="发烧级",
                    GraphicsCase="原厂盒包"
                },
                                new Graphyic(){
                    Brand="华硕",
                    Value=8687,
                    Name="超高性能,N卡旗舰型号",
                    GraphicFactory="NIVDA",
                    GraphicType="GTXTitan",
                    GraphicsCapacity="12GB",
                    GraphicsBits="384bit",
                    GraphicsInterfaces=new string[]{"DP×3", "HDMI", "DVI"},
                    GraphicsClass="发烧级",
                    GraphicsCase="原厂盒包"
                },
                                                                new Graphyic(){
                    Brand="华硕",
                    Value=827,
                    GraphicFactory="NIVDA",
                    GraphicType="GTX750Ti",
                    GraphicsCapacity="2GB",
                    GraphicsBits="128bit",
                    GraphicsInterfaces=new string[]{ "VGA", "DVI×2", "HDMI"},
                    GraphicsClass="主流级",
                    GraphicsCase="原厂盒包"
                },
            };
            if (_dbcontext.Graphyics.Count() < 1)
                /***  await ***/ _dbcontext.AddRange/***  async ***/(graphyics);

            List<HardDisk> hardDisks = new List<HardDisk>() {

                new HardDisk(){
                    Brand="希捷",
                    Value=282,
                    HDSuitable="台式机",
                    HDInterface="SATA3(6Gbps)",
                    HDRotateSpeed="7200",
                    HDCache="64MB",
                    HDCapacity="1TB"
                },
                  new HardDisk(){
                    Brand="希捷",
                    Value=383,
                    HDSuitable="台式机",
                    HDInterface="SATA3(6Gbps)",
                    HDRotateSpeed="7200",
                    HDCache="64MB",
                    HDCapacity="2TB"
                },
                                    new HardDisk(){
                    Brand="希捷",
                    Value=858,
                    Name="企业级硬盘",
                    HDSuitable="台式机",
                    HDInterface="SATA3(6Gbps)",
                    HDRotateSpeed="7200",
                    HDCache="64MB",
                    HDCapacity="4TB"
                },
                  new HardDisk(){
                    Brand="西部数据 WD",
                    Value=282,
                    HDSuitable="台式机",
                    HDInterface="SATA",
                    HDRotateSpeed="7200",
                    HDCache="32MB",
                    HDCapacity="1TB"
                },


            };
            if (_dbcontext.HardDisks.Count() < 1)
                /***  await ***/ _dbcontext.AddRange/***  async ***/(hardDisks);

            List<SSD> sSDs = new List<SSD>() {
                new SSD(){
                    Brand="三星",
                    Value=256,
                    Name="850 EVO系列,简包)",
                    SSDCapacity="120GB",
                    SSDInterface="SATA3(6Gbps)",
                    InputSpeed="520",
                    OutSpeed="540",
                },
                               new SSD(){
                    Brand="三星",
                    Value=368,
                    Name="850 EVO系列,简包)",
                    SSDCapacity="250GB",
                    SSDInterface="SATA3(6Gbps)",
                    InputSpeed="520",
                    OutSpeed="540",
                },               new SSD(){
                    Brand="INTEL",
                    Value=378,
                    Name="",
                    SSDCapacity="120GB",
                    SSDInterface="SATA3(6Gbps)",
                    InputSpeed="480",
                    OutSpeed="540",
                },
            };
            if (_dbcontext.SSDs.Count() < 1)
                /***  await ***/ _dbcontext.AddRange/***  async ***/(sSDs);

            List<CDROM> cDROMs = new List<CDROM>() {
                new CDROM(){
                    Brand="华硕",
                    Name="DRW-24D3ST",
                    Value=133,
                    CDROMType="DVD刻录机",
                },
                                new CDROM(){
                    Brand="华硕",
                    Name="DVD-E818A9T",
                    Value=91,
                    CDROMType="DVD光驱",
                },
                                                                new CDROM(){
                    Brand="先锋",
                    Name="BDR-S09XL",
                    Value=612,
                    CDROMType="蓝光刻录机",
                },
            };
            if (_dbcontext.CDROMs.Count() < 1)
                /***  await ***/ _dbcontext.AddRange/***  async ***/(cDROMs);

            List<Display> displays = new List<Display>() {
                new Display()
                {
                    Brand="三星",
                    Value=533,
                    DisplaySize="21.5寸",
                    DisplayInputTypes=new string[]{"VGA" },
                    DisplayOtherFunctions=new string[]{ "广视角" },
                    DisplayUseWay="经济实用",
                    DisplayColors=new string[]{"黑色" },
                    DisplayBackLED="LED背光",
                    DisplayBoard="VA面板",
                    DisplayVisualAngle="170/170°",
                    DisplayLuminance="200cd/㎡",
                    DisplayRatio="16:9(宽屏)",
                    DisplayDpi="1920×1080",
                    DisplayDotPitch="0.24mm级",

                },
                                new Display()
                {
                    Brand="AOC",
                    Value=1020,
                    DisplaySize="25寸",
                    DisplayInputTypes=new string[]{"VGA","HDMI×2" },
                    DisplayOtherFunctions=new string[]{ "广视角","分屏","窄边框" },
                    DisplayUseWay="娱乐影音",
                    DisplayColors=new string[]{"黑色","拉丝工艺","银色" },
                    DisplayBackLED="LED背光",
                    DisplayBoard="IPS面板",
                    DisplayVisualAngle="178/178°",
                    DisplayLuminance="250cd/㎡",
                    DisplayRatio="16:9(宽屏)",
                    DisplayDpi="1920×1080",
                    DisplayDotPitch="0.28mm级",

                }



            };
            if (_dbcontext.Displays.Count() < 1)
                /***  await ***/ _dbcontext.AddRange/***  async ***/(displays);

            List<Case> cases = new List<Case>() {
                new Case()
                {
                    Brand="游戏悍将",
                    Name="刀锋3豪华版",
                    Value=206,
                    CaseConditions=new string[]{"游戏"},
                    CaseFunctions=new string[]{ "eSATA","支持水冷","USB3.0","背部理线" },
                    CaseType="中塔式",
                    CaseStyle="立式",
                    CaseStruct="MATX,ATX",
                    CaseColors=new string[]{"黑色" },

                },
                                new Case()
                {
                    Brand="游戏悍将",
                    Name="激战3标准黑装",
                    Value=206,
                    CaseConditions=new string[]{"游戏"},
                    CaseFunctions=new string[]{ "免工具拆装", "支持水冷","背部理线" },
                    CaseType="中塔式",
                    CaseStyle="立式",
                    CaseStruct="MATX,ATX",
                    CaseColors=new string[]{"黑色","白色" },

                },
                                                                new Case()
                {
                    Brand="酷冷至尊",
                    Name="剑客 机箱",
                    Value=242,
                    CaseConditions=new string[]{"游戏"},
                    CaseFunctions=new string[]{ "电源下置 ","USB3.0", "防尘设计", "背部理线" },
                    CaseType="中塔式",
                    CaseStyle="立式",
                    CaseStruct="MATX,ATX",
                    CaseColors=new string[]{"黑色" },

                },
            };
            if (_dbcontext.Cases.Count() < 1)
                /***  await ***/ _dbcontext.AddRange/***  async ***/(cases);

            List<Power> powers = new List<Power>() {
                new Power(){
                    Brand="海盗船",
                    Value=524,
                    PowerFunctions=new string[]{
                        "温控风扇","背部走线","宽电压","半模组"
                    },
                    PowerRange="550W",
                    Power80PLus="金牌",
                    PowerFanSize="12cm",
                    Power44CPU="1个",
                    Power4PCPU="",
                    Power62P="2个",
                    PowerSATA="5个",
                    PowerType="台式机",
                    PowerCase="原厂盒包"
                },
                 new Power(){
                    Brand="游戏悍将",
                    Value=297,
                    Name="红星R500M",
                    PowerFunctions=new string[]{
                        "主动PFC","背部走线","宽电压","半模组"
                    },
                    PowerRange="500W",
                    Power80PLus="铜牌",
                    PowerFanSize="12cm",
                    Power44CPU="1个",
                    Power4PCPU="",
                    Power62P="2个",
                    PowerSATA="4个",
                    PowerType="台式机",
                    PowerCase="原厂盒包"
                }

            };
            if (_dbcontext.Powers.Count() < 1)
                /***  await ***/ _dbcontext.AddRange/***  async ***/(powers);

            List<CPUHS> cPUHs = new List<CPUHS>() {

                new CPUHS()
                {
                    Brand="九州风神",
                    Name="玄冰400",
                    Value=100,
                    CPUHSType="AMD Intel双平台",
                    CPUHSFunctions=new string[]{"智能温控","单风扇","单热排" },
                    CPUHSSuitable="CPU",
                    CPUHSHeatPipes="4个",
                    CPUHSClass="铜",
                },
                                new CPUHS()
                {
                    Brand="华硕",
                    Name="海神78",
                    Value=275,
                    CPUHSType="AMD Intel双平台",
                    CPUHSFunctions=new string[]{"智能温控","单风扇","单热排" },
                    CPUHSSuitable="CPU",
                    CPUHSHeatPipes="",
                    CPUHSClass="铝",
                },
            };
            if (_dbcontext.CPUHs.Count() < 1)
                /***  await ***/ _dbcontext.AddRange/***  async ***/(cPUHs);

            List<NetWork> netWorks = new List<NetWork>() {
                new NetWork()
                {
                    Brand="TP-LINK",
                    Value=165,
                    Name="300M无线网卡",
                    NetWokrSuitables=new string[]{"百兆"}
                },
                                new NetWork()
                {
                    Brand="Intel",
                    Value=2985,
                    Name="X540-T2",
                    NetWokrSuitables=new string[]{ "万兆","百兆" }
                },
            };
            if (_dbcontext.NetWorks.Count() < 1)
                /***  await ***/ _dbcontext.AddRange/***  async ***/(netWorks);

            List<TopicClass> topicClasses = new List<TopicClass>()
            {
                new TopicClass()
                {
                    Name="硬件分类",

                },
                  new TopicClass()
                {
                    Name="管理员文章",

                },
              
            };
            foreach(var item in Enum.GetValues(typeof(HardWareEnum)))
            {
                topicClasses.Add(new TopicClass {
                    Name = item.ToString(),
                    ParentNodeId=1,
                });
            }
            if (_dbcontext.TopicClasses.Count() < 1)
            {
                foreach(var item in topicClasses)
                {
                    /***  await ***/ _dbcontext.AddRange/***  async ***/(item);
                }
            }
            _dbcontext.SaveChanges();

            List<Topic> Topics = new List<Topic>()
            {
                new Topic()
                {
                    Title="tre",
                    ContentURL="C:-Users-XH-Source-Repos-MyStudyWork-CoreBackend.CMS-bin-Debug-netcoreapp2.1-htmlpages-2019-2-22-1550825975.html",
                    UserId=1,
                    User=_dbcontext.Users.Find(1),

                },
                                new Topic()
                {
                    Title="tre2",
                    ContentURL="C:-Users-XH-Source-Repos-MyStudyWork-CoreBackend.CMS-bin-Debug-netcoreapp2.1-htmlpages-2019-2-22-1550825975.html",
                    UserId=1,
                    User=_dbcontext.Users.Find(1),

                },
                                                new Topic()
                {
                    Title="tre3",
                    ContentURL="C:-Users-XH-Source-Repos-MyStudyWork-CoreBackend.CMS-bin-Debug-netcoreapp2.1-htmlpages-2019-2-22-1550825975.html",
                    UserId=1,
                    User=_dbcontext.Users.Find(1),

                },
                                                                new Topic()
                {
                    Title="tre4",
                    ContentURL="C:-Users-XH-Source-Repos-MyStudyWork-CoreBackend.CMS-bin-Debug-netcoreapp2.1-htmlpages-2019-2-22-1550825975.html",
                    UserId=1,
                    User=_dbcontext.Users.Find(1),

                },
            };
            if (_dbcontext.Topics.Count() < 1)
                /***  await ***/ _dbcontext.AddRange/***  async ***/(Topics);
            _dbcontext.SaveChanges();

            List<Computer> computers = new List<Computer>(){
                new Computer()
                {
                    CaseId=1,
                    CDROMId=1,
                    CPUHSId=1,
                    CPUId=1,
                    DisplayId=1,
                    GraphyicId=1,
                    HardDiskId=1,
                    MainboardId=1,
                    NetWorkId=1,
                    PowerId=1,
                    ROMId=1,
                    SSDId=1,
                    UserID=1,
                    PlanName="专业配置",
                    ValueSum=9999,
                    Remarks="测试数据"

                },
                  new Computer()
                {
                    CaseId=1,
                    CDROMId=1,
                    CPUHSId=1,
                    CPUId=1,
                    DisplayId=1,
                    GraphyicId=1,
                    HardDiskId=1,
                    MainboardId=1,
                    NetWorkId=1,
                    PowerId=2,
                    ROMId=1,
                    SSDId=1,
                    UserID=1,
                    PlanName="专业配置2",
                    ValueSum=1219,
                    Remarks="测试数据"

                },
                    new Computer()
                {
                    CaseId=1,
                    CDROMId=1,
                    CPUHSId=1,
                    CPUId=1,
                    DisplayId=2,
                    GraphyicId=1,
                    HardDiskId=1,
                    MainboardId=1,
                    NetWorkId=1,
                    PowerId=2,
                    ROMId=1,
                    SSDId=1,
                    UserID=2,
                    PlanName="专业配置3",
                    ValueSum=22299,
                    Remarks="测试数据"

                },

            };
            if (_dbcontext.Computers.Count() < 1)
                _dbcontext.AddRange(computers);
            _dbcontext.SaveChanges();

        }
    }
}
