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
    public class PowersAPIController : Controller
    {
        private readonly EFDBContext _context;
        private readonly ICGRepositor<Power> _PowerRepositor;
        public PowersAPIController(EFDBContext context, ICGRepositor<Power> PowerRepositor)
        {
            _PowerRepositor = PowerRepositor;
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
        [Route("PowerGetByName")]
        public JsonResult PowerGetByName(string name, int indexPage = 1, int size = 30)
        {

            if (name == null)
            {
                return Json(ResultToJson.GetJsonResult());
            }
            else
            {
               
                PageSplitModel<Power> listmodel = _PowerRepositor.GetByName(name, indexPage, size);

                return Json(ResultToJson.GetJsonResult(listmodel));
            }


        }

        [HttpGet]
        [Route("PowerGetById")]
        public JsonResult PowerGetById(int id)
        {
            if (id < 1)
            {
                return Json(ResultToJson.GetJsonResult());

            }
            Power Power = _PowerRepositor.GetById(id);
            return Json(ResultToJson.GetJsonResult(Power));

        }

        [HttpGet]
        [Route("PowerGetByValue")]
        public JsonResult PowerGetByValue(decimal value1=0,decimal value2=9999,int indexPage=-1,int size = -1)
        {
            
            PageSplitModel<Power> listmodel = _PowerRepositor.GetByValue(value1, value2, indexPage, size);

            return Json(ResultToJson.GetJsonResult(listmodel));
        }
        
        [HttpGet]
        [Route("PowerGetByBrand")]
        public JsonResult PowerGetByBrand(string brand = "", int indexPage = -1, int size = -1)
        {
            if (string.IsNullOrEmpty(brand))
                return Json(ResultToJson.GetJsonResult());
         
            PageSplitModel<Power> listmodel = _PowerRepositor.GetByBrand(brand, indexPage, size);

            return Json(ResultToJson.GetJsonResult(listmodel));
        }


        [HttpGet]
        [Route("PowerGetByAll")]
        public JsonResult PowerGetByAll(string brand = "", decimal value1 = 0, decimal value2 = 9999, string name = "", int indexPage = -1, int size = -1, int id = -1)
        {
            var myenum = HardWareEnum.电源;

     
            PageSplitModel<Power> listmodel = _PowerRepositor.GetByAll(brand, value1, value2, myenum, name, indexPage, size,id);

            return Json(ResultToJson.GetJsonResult(listmodel));
        }


        [HttpGet]
        [Route("PowerGetByAny")]
        public JsonResult PowerGetByAny(string brand = "", decimal value1 = 0, decimal value2 = 9999, string name = "", int indexPage = -1, int size = -1)
        {
            var myenum = HardWareEnum.电源;

        
            PageSplitModel<Power> listmodel = _PowerRepositor.GetByAny(brand, value1, value2, myenum, name, indexPage, size);

            return Json(ResultToJson.GetJsonResult(listmodel));
        }

        [HttpGet]
        [Route("PowerList")]
        public JsonResult PowerList(int indexPage=-1,int size = -1)
        {
           
            PageSplitModel<Power> listmodel = _PowerRepositor.List(indexPage, size);

            return Json(ResultToJson.GetJsonResult(listmodel));
        }

    }
}