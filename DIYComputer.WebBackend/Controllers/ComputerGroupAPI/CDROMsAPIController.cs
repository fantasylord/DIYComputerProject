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
    public class CDROMsAPIController : Controller
    {
        private readonly EFDBContext _context;
        private readonly ICGRepositor<CDROM> _CDROMRepositor;
        public CDROMsAPIController(EFDBContext context, ICGRepositor<CDROM> CDROMRepositor)
        {
            _CDROMRepositor = CDROMRepositor;
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
        [Route("CDROMGetByName")]
        public JsonResult CDROMGetByName(string name, int indexPage = 1, int size = 30)
        {

            if (name == null)
            {
                return Json(ResultToJson.GetJsonResult());
            }
            else
            {
              
                PageSplitModel<CDROM> listmodel = _CDROMRepositor.GetByName(name, indexPage, size);
                return Json(ResultToJson.GetJsonResult(listmodel));
            }


        }

        [HttpGet]
        [Route("CDROMGetById")]
        public JsonResult CDROMGetById(int id)
        {
            if (id < 1)
            {
                return Json(ResultToJson.GetJsonResult());

            }
            CDROM CDROM = _CDROMRepositor.GetById(id);
            return Json(ResultToJson.GetJsonResult(CDROM));

        }

        [HttpGet]
        [Route("CDROMGetByValue")]
        public JsonResult CDROMGetByValue(decimal value1=0,decimal value2=9999,int indexPage=-1,int size = -1)
        {
          
            PageSplitModel<CDROM> listmodel = _CDROMRepositor.GetByValue(value1, value2, indexPage, size);

            return Json(ResultToJson.GetJsonResult(listmodel));
        }
        
        [HttpGet]
        [Route("CDROMGetByBrand")]
        public JsonResult CDROMGetByBrand(string brand = "", int indexPage = -1, int size = -1)
        {
            if (string.IsNullOrEmpty(brand))
                return Json(ResultToJson.GetJsonResult());
        
            PageSplitModel<CDROM> listmodel = _CDROMRepositor.GetByBrand(brand, indexPage, size);

            return Json(ResultToJson.GetJsonResult(listmodel));
        }


        [HttpGet]
        [Route("CDROMGetByAll")]
        public JsonResult CDROMGetByAll(string brand = "", decimal value1 = 0, decimal value2 = 9999, string name = "", int indexPage = -1, int size = -1, int id = -1)
        {
            var myenum = HardWareEnum.光驱;

        
            PageSplitModel<CDROM> listmodel = _CDROMRepositor.GetByAll(brand, value1, value2, myenum, name, indexPage, size,id);

            return Json(ResultToJson.GetJsonResult(listmodel));
        }


        [HttpGet]
        [Route("CDROMGetByAny")]
        public JsonResult CDROMGetByAny(string brand = "", decimal value1 = 0, decimal value2 = 9999, string name = "", int indexPage = -1, int size = -1)
        {
            var myenum = HardWareEnum.光驱;

           
            PageSplitModel<CDROM> listmodel = _CDROMRepositor.GetByAny(brand, value1, value2, myenum, name, indexPage, size);

            return Json(ResultToJson.GetJsonResult(listmodel));
        }

        [HttpGet]
        [Route("CDROMList")]
        public JsonResult CDROMList(int indexPage=-1,int size = -1)
        {
           
            PageSplitModel<CDROM> listmodel = _CDROMRepositor.List(indexPage, size);

            return Json(ResultToJson.GetJsonResult(listmodel));
        }

    }
}