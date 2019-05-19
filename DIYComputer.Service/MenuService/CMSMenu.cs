using DIYComputer.Config.StaticSource;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace DIYComputer.Service.MenuService
{
    public class CMSMenuModel
    {

        public static readonly CMSMenuModel instance = new CMSMenuModel();
        public static CMSMenuModel GetInstance()
        {
            return instance;
        }
        public List<CMSMenu> Menus { get; set; }
        private CMSMenuModel()
        {
            Menus = new List<CMSMenu>();
            Menuset();
        }

        public string GetListToJson()
        {

            //List<Student> twoList = JsonConvert.DeserializeObject<List<Student>>(jsonData);
            // List<CMSMenu> results = JsonConvert.DeserializeObject<List<CMSMenu>>(Menus);
            // var json = JArray.Parse(content).ToString();
            // return Ok(new { value = content });

            string json = JsonConvert.SerializeObject(Menus);
            return json;
        }
        public void Menuset()
        {
        

            //动态节点管理
            var item = new CMSMenu() { MenuName = "节点管理", Controller = "MenuNodes" };
            item.ChildNodes.Add(new CMSMenu() { MenuName = "节点列表", Controller = item.Controller, Action = "Index" });
            item.ChildNodes.Add(new CMSMenu() { MenuName = "节点创建", Controller = item.Controller, Action = "Create" });
            Menus.Add(item);


            item = new CMSMenu() { MenuName = "管理员列表", Controller = "Admins" };
            item.ChildNodes.Add(new CMSMenu() { MenuName = "用户列表", Controller = item.Controller, Action = "Index" });
            item.ChildNodes.Add(new CMSMenu() { MenuName = "用户创建", Controller = item.Controller, Action = "Create" });
            Menus.Add(item);

            item = new CMSMenu() { MenuName = "用户管理", Controller = "Users" };
            item.ChildNodes.Add(new CMSMenu() { MenuName = "用户列表", Controller = item.Controller, Action = "Index" });
            item.ChildNodes.Add(new CMSMenu() { MenuName = "用户创建", Controller = item.Controller, Action = "Create" });
            Menus.Add(item);

            item = new CMSMenu() { MenuName = "文章类别管理", Controller = "TopicClass" };
            item.ChildNodes.Add(new CMSMenu() { MenuName = "文章类别列表", Controller = item.Controller, Action = "Index" });
            item.ChildNodes.Add(new CMSMenu() { MenuName = "文章类别创建", Controller = item.Controller, Action = "Create" });
            Menus.Add(item);
            item = new CMSMenu() { MenuName = "装机方案管理", Controller = "Computers" };
            item.ChildNodes.Add(new CMSMenu() { MenuName = "方案列表", Controller = item.Controller, Action = "Index" });
            item.ChildNodes.Add(new CMSMenu() { MenuName = "方案创建", Controller = item.Controller, Action = "Create" });
            Menus.Add(item);
            item = new CMSMenu() { MenuName = "评论管理", Controller = "Replies" };
            item.ChildNodes.Add(new CMSMenu() { MenuName = "评论列表", Controller = item.Controller, Action = "Index" });
            
            Menus.Add(item);
            item = new CMSMenu() { MenuName = "用户反馈", Controller = "feedbacks" };
            item.ChildNodes.Add(new CMSMenu() { MenuName = "反馈列表", Controller = item.Controller, Action = "Index" });

            Menus.Add(item);

            var items = new CMSMenu() { MenuName = "硬件列表", Controller = "" };

            item = new CMSMenu() { MenuName = "CPU管理", Controller = "CPUs" };
            item.ChildNodes.Add(new CMSMenu() { MenuName = "CPU类别管理列表", Controller = item.Controller, Action = "Index" });
            items.ChildNodes.Add(item);

            item = new CMSMenu() { MenuName = "主板管理", Controller = "Mainboards" };
            item.ChildNodes.Add(new CMSMenu() { MenuName = "主板类别管理", Controller = item.Controller, Action = "Index" });
            items.ChildNodes.Add(item);

            item = new CMSMenu() { MenuName = "内存管理", Controller = "ROMs" };
            item.ChildNodes.Add(new CMSMenu() { MenuName = "内存管理", Controller = item.Controller, Action = "Index" });
            items.ChildNodes.Add(item);

            item = new CMSMenu() { MenuName = "显卡管理", Controller = "Graphyics" };
            item.ChildNodes.Add(new CMSMenu() { MenuName = "显卡管理", Controller = item.Controller, Action = "Index" });
            items.ChildNodes.Add(item);

            item = new CMSMenu() { MenuName = "硬盘管理", Controller = "HardDisks" };
            item.ChildNodes.Add(new CMSMenu() { MenuName = "硬盘管理", Controller = item.Controller, Action = "Index" });
            items.ChildNodes.Add(item);

            item = new CMSMenu() { MenuName = "固态硬盘管理", Controller = "SSDs" };
            item.ChildNodes.Add(new CMSMenu() { MenuName = "固态硬盘管理", Controller = item.Controller, Action = "Index" });
            items.ChildNodes.Add(item);

            item = new CMSMenu() { MenuName = "光驱管理", Controller = "CDROMs" };
            item.ChildNodes.Add(new CMSMenu() { MenuName = "光驱管理", Controller = item.Controller, Action = "Index" });
            items.ChildNodes.Add(item);

            item = new CMSMenu() { MenuName = "显示器管理", Controller = "Displays" };
            item.ChildNodes.Add(new CMSMenu() { MenuName = "显示器管理", Controller = item.Controller, Action = "Index" });
            items.ChildNodes.Add(item);

            item = new CMSMenu() { MenuName = "机箱管理", Controller = "Cases" };
            item.ChildNodes.Add(new CMSMenu() { MenuName = "机箱管理", Controller = item.Controller, Action = "Index" });
            items.ChildNodes.Add(item);

            item = new CMSMenu() { MenuName = "电源管理", Controller = "Powers" };
            item.ChildNodes.Add(new CMSMenu() { MenuName = "电源管理", Controller = item.Controller, Action = "Index" });
            items.ChildNodes.Add(item);

            item = new CMSMenu() { MenuName = "CPU散热器管理", Controller = "CPUHS" };
            item.ChildNodes.Add(new CMSMenu() { MenuName = "CPU散热器管理", Controller = item.Controller, Action = "Index" });
            items.ChildNodes.Add(item);

            item = new CMSMenu() { MenuName = "网卡管理", Controller = "NetWorks" };
            item.ChildNodes.Add(new CMSMenu() { MenuName = "网卡管理", Controller = item.Controller, Action = "Index" });
            items.ChildNodes.Add(item);

            Menus.Add(items);

            //var item2 = new CMSMenu() { MenuName = "用户管理", Controller = "Users" };
            //item.ChildNodes.Add(new CMSMenu() { MenuName = "用户列表", Controller = item.Controller, Action = "Index" });
            //item.ChildNodes.Add(new CMSMenu() { MenuName = "用户创建", Controller = item.Controller, Action = "Create" });
            //Menus.Add(item);

        }

    }

    public class CMSMenu
    {

        public string MenuName { get; set; } = "一级节点";

        public string Imgcss { get; set; } = "fa fa-circle-o";

        public string Area { get; set; } = "";

        public string Action { get; set; } = Enum.GetName(typeof(ActionEnum), 0);

        public string Controller { get; set; } = "Home";

        public List<CMSMenu> ChildNodes { get; set; }

        public CMSMenu()
        {
            ChildNodes = new List<CMSMenu>();
        }
    }

    ///// <summary>
    ///// 主机硬件分类
    ///// </summary>
    //public enum HardWareEnum
    //{
    //    其他分类,
    //    CPU,
    //    主板,
    //    内存,
    //    显卡,
    //    硬盘,
    //    固态硬盘,
    //    光驱,
    //    显示器,
    //    机箱,
    //    电源,
    //    键鼠套装,
    //    CPU散热器,
    //    机箱风扇,
    //    网卡,
        
    //}

    //public enum ActionEnum
    //{
    //    Index = 0,
    //    Create = 1,
    //    Delete,
    //    Details,
    //    Edit,
    //    Search
    //}


}
