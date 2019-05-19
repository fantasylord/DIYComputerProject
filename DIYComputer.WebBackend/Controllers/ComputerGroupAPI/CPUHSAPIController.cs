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
    public class CPUHSAPIController : Controller
    {
        private readonly EFDBContext _context;
        private readonly ICGRepositor<CPUHS> _CPUHSRepositor;
        public CPUHSAPIController(EFDBContext context, ICGRepositor<CPUHS> CPUHSRepositor)
        {
            _CPUHSRepositor = CPUHSRepositor;
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
        [Route("CPUHSGetByName")]
        public JsonResult CPUHSGetByName(string name, int indexPage = 1, int size = 30)
        {

            if (name == null)
            {
                return Json(ResultToJson.GetJsonResult());
            }
            else
            {
            
                PageSplitModel<CPUHS> listmodel = _CPUHSRepositor.GetByName(name, indexPage, size);

                return Json(ResultToJson.GetJsonResult(listmodel));
            }


        }

        [HttpGet]
        [Route("CPUHSGetById")]
        public JsonResult CPUHSGetById(int id)
        {
            if (id < 1)
            {
                return Json(ResultToJson.GetJsonResult());

            }
            CPUHS CPUHS = _CPUHSRepositor.GetById(id);
            return Json(ResultToJson.GetJsonResult(CPUHS));

        }

        [HttpGet]
        [Route("CPUHSGetByValue")]
        public JsonResult CPUHSGetByValue(decimal value1=0,decimal value2=9999,int indexPage=-1,int size = -1)
        {
            
            PageSplitModel<CPUHS> listmodel = _CPUHSRepositor.GetByValue(value1, value2, indexPage, size);

            return Json(ResultToJson.GetJsonResult(listmodel));
        }
        
        [HttpGet]
        [Route("CPUHSGetByBrand")]
        public JsonResult CPUHSGetByBrand(string brand = "", int indexPage = -1, int size = -1)
        {
            if (string.IsNullOrEmpty(brand))
                return Json(ResultToJson.GetJsonResult());
           
            PageSplitModel<CPUHS> listmodel = _CPUHSRepositor.GetByBrand(brand, indexPage, size);

            return Json(ResultToJson.GetJsonResult(listmodel));
        }


        [HttpGet]
        [Route("CPUHSGetByAll")]
        public JsonResult CPUHSGetByAll(string brand = "", decimal value1 = 0, decimal value2 = 9999, string name = "", int indexPage = -1, int size = -1, int id = -1)
        {
            var myenum = HardWareEnum.CPU散热器;

 
            PageSplitModel<CPUHS> listmodel = _CPUHSRepositor.GetByAll(brand, value1, value2, myenum, name, indexPage, size,id);

            return Json(ResultToJson.GetJsonResult(listmodel));
        }


        [HttpGet]
        [Route("CPUHSGetByAny")]
        public JsonResult CPUHSGetByAny(string brand = "", decimal value1 = 0, decimal value2 = 9999, string name = "", int indexPage = -1, int size = -1)
        {
            var myenum = HardWareEnum.CPU散热器;

       
            PageSplitModel<CPUHS> listmodel = _CPUHSRepositor.GetByAny(brand, value1, value2, myenum, name, indexPage, size);

            return Json(ResultToJson.GetJsonResult(listmodel));
        }

        [HttpGet]
        [Route("CPUHSList")]
        public JsonResult CPUHSList(int indexPage=-1,int size = -1)
        {
        
            PageSplitModel<CPUHS> listmodel = _CPUHSRepositor.List(indexPage, size);

            return Json(ResultToJson.GetJsonResult(listmodel));
        }

    }
}