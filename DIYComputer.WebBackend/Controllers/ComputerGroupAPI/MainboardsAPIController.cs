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
    public class MainboardsAPIController : Controller
    {
        private readonly EFDBContext _context;
        private readonly ICGRepositor<Mainboard> _MainboardRepositor;
        public MainboardsAPIController(EFDBContext context, ICGRepositor<Mainboard> MainboardRepositor)
        {
            _MainboardRepositor = MainboardRepositor;
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
        [Route("MainboardGetByName")]
        public JsonResult MainboardGetByName(string name, int indexPage = 1, int size = 30)
        {

            if (name == null)
            {
                return Json(ResultToJson.GetJsonResult());
            }
            else
            {
            
                PageSplitModel<Mainboard> listmodel = _MainboardRepositor.GetByName(name, indexPage, size);

                return Json(ResultToJson.GetJsonResult(listmodel));
            }


        }

        [HttpGet]
        [Route("MainboardGetById")]
        public JsonResult MainboardGetById(int id)
        {
            if (id < 1)
            {
                return Json(ResultToJson.GetJsonResult());

            }
            Mainboard Mainboard = _MainboardRepositor.GetById(id);
    
            return Json(ResultToJson.GetJsonResult(Mainboard));
        }

        [HttpGet]
        [Route("MainboardGetByValue")]
        public JsonResult MainboardGetByValue(decimal value1=0,decimal value2=9999,int indexPage=-1,int size = -1)
        {
         
            PageSplitModel<Mainboard> listmodel = _MainboardRepositor.GetByValue(value1, value2, indexPage, size);

            return Json(ResultToJson.GetJsonResult(listmodel));
        }
        
        [HttpGet]
        [Route("MainboardGetByBrand")]
        public JsonResult MainboardGetByBrand(string brand = "", int indexPage = -1, int size = -1)
        {
            if (string.IsNullOrEmpty(brand))
                return Json(ResultToJson.GetJsonResult());
 
            PageSplitModel<Mainboard> listmodel = _MainboardRepositor.GetByBrand(brand, indexPage, size);

            return Json(ResultToJson.GetJsonResult(listmodel));
        }


        [HttpGet]
        [Route("MainboardGetByAll")]
        public JsonResult MainboardGetByAll(string brand = "", decimal value1 = 0, decimal value2 = 9999, string name = "", int indexPage = -1, int size = -1, int id = -1)
        {
            var myenum = HardWareEnum.主板;

            
            PageSplitModel<Mainboard> listmodel = _MainboardRepositor.GetByAll(brand, value1, value2, myenum, name, indexPage, size,id);

            return Json(ResultToJson.GetJsonResult(listmodel));
        }


        [HttpGet]
        [Route("MainboardGetByAny")]
        public JsonResult MainboardGetByAny(string brand = "", decimal value1 = 0, decimal value2 = 9999, string name = "", int indexPage = -1, int size = -1)
        {
            var myenum = HardWareEnum.主板;

         
            PageSplitModel<Mainboard> listmodel = _MainboardRepositor.GetByAny(brand, value1, value2, myenum, name, indexPage, size);

            return Json(ResultToJson.GetJsonResult(listmodel));
        }

        [HttpGet]
        [Route("MainboardList")]
        public JsonResult MainboardList(int indexPage=-1,int size = -1)
        {
           
            PageSplitModel<Mainboard> listmodel = _MainboardRepositor.List(indexPage, size);

            return Json(ResultToJson.GetJsonResult(listmodel));
        }

    }
}