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
    public class ROMsAPIController : Controller
    {
        private readonly EFDBContext _context;
        private readonly ICGRepositor<ROM> _ROMRepositor;
        public ROMsAPIController(EFDBContext context, ICGRepositor<ROM> ROMRepositor)
        {
            _ROMRepositor = ROMRepositor;
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
        [Route("ROMGetByName")]
        public JsonResult ROMGetByName(string name, int indexPage = 1, int size = 30)
        {

            if (name == null)
            {
                return Json(ResultToJson.GetJsonResult());
            }
            else
            {
               
                PageSplitModel<ROM> listmodel = _ROMRepositor.GetByName(name, indexPage, size);

                return Json(ResultToJson.GetJsonResult(listmodel));
            }


        }

        [HttpGet]
        [Route("ROMGetById")]
        public JsonResult ROMGetById(int id)
        {
            if (id < 1)
            {
                return Json(ResultToJson.GetJsonResult());

            }
            ROM ROM = _ROMRepositor.GetById(id);
            return Json(ResultToJson.GetJsonResult(ROM));

        }

        [HttpGet]
        [Route("ROMGetByValue")]
        public JsonResult ROMGetByValue(decimal value1=0,decimal value2=9999,int indexPage=-1,int size = -1)
        {
          
            PageSplitModel<ROM> listmodel = _ROMRepositor.GetByValue(value1, value2, indexPage, size);

            return Json(ResultToJson.GetJsonResult(listmodel));
        }
        
        [HttpGet]
        [Route("ROMGetByBrand")]
        public JsonResult ROMGetByBrand(string brand = "", int indexPage = -1, int size = -1)
        {
            if (string.IsNullOrEmpty(brand))
                return Json(ResultToJson.GetJsonResult());
         
            PageSplitModel<ROM> listmodel = _ROMRepositor.GetByBrand(brand, indexPage, size);

            return Json(ResultToJson.GetJsonResult(listmodel));
        }


        [HttpGet]
        [Route("ROMGetByAll")]
        public JsonResult ROMGetByAll(string brand = "", decimal value1 = 0, decimal value2 = 9999, string name = "", int indexPage = -1, int size = -1, int id = -1)
        {
            var myenum = HardWareEnum.内存;

            
            PageSplitModel<ROM> listmodel = _ROMRepositor.GetByAll(brand, value1, value2, myenum, name, indexPage, size,id);

            return Json(ResultToJson.GetJsonResult(listmodel));
        }


        [HttpGet]
        [Route("ROMGetByAny")]
        public JsonResult ROMGetByAny(string brand = "", decimal value1 = 0, decimal value2 = 9999, string name = "", int indexPage = -1, int size = -1)
        {
            var myenum = HardWareEnum.内存;

           
            PageSplitModel<ROM> listmodel =
                _ROMRepositor.GetByAny(brand, value1, value2, myenum, name, indexPage, size);

            return Json(ResultToJson.GetJsonResult(listmodel));
        }

        [HttpGet]
        [Route("ROMList")]
        public JsonResult ROMList(int indexPage=-1,int size = -1)
        {
       
            PageSplitModel<ROM> listmodel = _ROMRepositor.List(indexPage, size);

            return Json(ResultToJson.GetJsonResult(listmodel));
        }

    }
}