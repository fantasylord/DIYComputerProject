using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace DIYComputer.Config.FrontEndConfig
{
    public class ServiceConfig
    {
        public static void Set(string wwwroot)
        {
            wwwrootDirectory = wwwroot;
            HtmlUpDirectory = @"\htmlpages";
            ImageUpDirectory = @"\images";
            ImageUpUrlDirectory = @"~\images";
        }

        public static string APIServices = "http://47.95.197.57:5500";
        /// <summary>
        /// wwwroot根目录
        /// </summary>
        public static string wwwrootDirectory = "C://Frontend";
        /// <summary>   
        ///html网页存放文件夹
        /// </summary>
        public static string HtmlUpDirectory = wwwrootDirectory + @"\htmlpages";
        /// <summary>
        /// xxx\images 文件夹
        /// </summary>
        public static string ImageUpDirectory = wwwrootDirectory + @"\images";
        /// <summary>
        /// 相对路径 文件夹
        /// </summary>
        public static string ImageUpUrlDirectory = @"~\images";


        
    }
}
