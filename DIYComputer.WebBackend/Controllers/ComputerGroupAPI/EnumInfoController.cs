using DIYComputer.Config.StaticSource;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Threading.Tasks;

namespace DIYComputer.WebBackend.Controllers.ComputerGroupAPI
{
    [Route("api/[controller]")]
    [ApiController]
    public class EnumInfoController : Controller
    {


        [HttpGet]
        [Route("GetEnumInfo")]
        public async Task<IActionResult> GetEnumInfo(string name)
        {

            Type type = EnumInfo.GetInstace().GetType();

           var ret =EnumInfo.GetInstace().EnumMBIntelChip;
            PropertyInfo[] props = type.GetProperties();
            
            foreach (PropertyInfo p in props)
            {
                Console.WriteLine(p.Name);
                if (p.Name == name)
                {
                    ret = p.GetValue(EnumInfo.GetInstace(), null) as Dictionary<string,string>;
                    break;
                }
            }
            return Ok(ret);
        }
        [HttpGet]
        [Route("GetEnumInfos")]
        public IActionResult GetEnumInfos(string name)
        {

            Type type = EnumInfo.GetInstace().GetType();
          
           var ret = EnumInfo.GetInstace().EnumMBIntelChip;
            PropertyInfo[] props = type.GetProperties();
            foreach (PropertyInfo p in props)
            {
                Console.WriteLine(p.Name);
                if (p.Name == name)
                {
                    ret = p.GetValue(p, null) as Dictionary<string,string>;
                    break;
                }
            }
            return Ok(ret);
        }
    }
}
