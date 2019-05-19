using DIYComputer.Config.StaticSource;
using DIYComputer.Entity.ComputerWareEntity;
using DIYComputer.Entity.DBContext;
using DIYComputer.Repository.IRepository;
using DIYComputer.Util;
using DIYComputer.Util.CommonModel;
using Microsoft.AspNetCore.Mvc;

namespace DIYComputer.WebBackend.Controllers.ComputerGroupAPI
{
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json")]
    public class CPUAPIController : Controller
    {
        private readonly EFDBContext _context;
        private readonly ICGRepositor<CPU> _cpuRepositor;
        public CPUAPIController(EFDBContext context, ICGRepositor<CPU> cpuRepositor)
        {
            _cpuRepositor = cpuRepositor;
            _context = context;
        }
        /// <summary>
        /// 通过名字查询
        /// </summary>
        /// <param name="name"></param>
        /// <param name="indexPage"></param>
        /// <param name="size"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("CPUGetByName")]
        public JsonResult CPUGetByName(string name, int indexPage = 1, int size = 30)
        {

            if (name == null)
            {
                return Json(ResultToJson.GetJsonResult());
            }
            else
            {
           
                PageSplitModel<CPU> listmodel = _cpuRepositor.GetByName(name, indexPage, size);

                return Json(ResultToJson.GetJsonResult(listmodel));
            }


        }

        [HttpGet]
        [Route("CPUGetById")]
        public JsonResult CPUGetById(int id)
        {
            if (id < 1)
            {
                return Json(ResultToJson.GetJsonResult());

            }
            CPU cPU = _cpuRepositor.GetById(id);
            return Json(ResultToJson.GetJsonResult(cPU));

        }

        [HttpGet]
        [Route("CPUGetByValue")]
        public JsonResult CPUGetByValue(decimal value1=0,decimal value2=9999,int indexPage=-1,int size = -1)
        {
         
            PageSplitModel<CPU> listmodel = _cpuRepositor.GetByValue(value1, value2, indexPage, size);

            return Json(ResultToJson.GetJsonResult(listmodel));
        }
        
        [HttpGet]
        [Route("CPUGetByBrand")]
        public JsonResult CPUGetByBrand(string brand = "", int indexPage = -1, int size = -1)
        {
            if (string.IsNullOrEmpty(brand))
                return Json(ResultToJson.GetJsonResult());
      
            PageSplitModel<CPU> listmodel = _cpuRepositor.GetByBrand(brand, indexPage, size);

            return Json(ResultToJson.GetJsonResult(listmodel));
        }


        [HttpGet]
        [Route("CPUGetByAll")]
        public JsonResult CPUGetByAll(string brand = "", decimal value1 = 0, decimal value2 = 9999, string name = "", int indexPage = -1, int size = -1,int id=-1)
        {
            var myenum = HardWareEnum.CPU;
            PageSplitModel<CPU> listmodel = _cpuRepositor.GetByAll(brand, value1, value2, myenum, name, indexPage, size,id);
            return Json(ResultToJson.GetJsonResult(listmodel));
        }


        [HttpGet]
        [Route("CPUGetByAny")]
        public JsonResult CPUGetByAny(string brand = "", decimal value1 = 0, decimal value2 = 9999, string name = "", int indexPage = -1, int size = -1)
        {
            var myenum = HardWareEnum.CPU;

          
            PageSplitModel<CPU> listmodel = _cpuRepositor.GetByAny(brand, value1, value2, myenum, name, indexPage, size);

            return Json(ResultToJson.GetJsonResult(listmodel));
        }

        [HttpGet]
        [Route("CPUList")]
        public JsonResult CPUList(int indexPage=-1,int size = -1)
        {
         
            PageSplitModel<CPU> listmodel = _cpuRepositor.List(indexPage, size);

            return Json(ResultToJson.GetJsonResult(listmodel));
        }

    }
}