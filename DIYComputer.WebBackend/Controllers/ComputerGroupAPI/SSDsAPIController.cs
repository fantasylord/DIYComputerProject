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
    public class SSDsAPIController : Controller
    {
        private readonly EFDBContext _context;
        private readonly ICGRepositor<SSD> _SSDRepositor;
        public SSDsAPIController(EFDBContext context, ICGRepositor<SSD> SSDRepositor)
        {
            _SSDRepositor = SSDRepositor;
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
        [Route("SSDGetByName")]
        public JsonResult SSDGetByName(string name, int indexPage = 1, int size = 30)
        {

            if (name == null)
            {
                return Json(ResultToJson.GetJsonResult());
            }
            else
            {
         
                PageSplitModel<SSD> listmodel = _SSDRepositor.GetByName(name, indexPage, size);

                return Json(ResultToJson.GetJsonResult(listmodel));
            }


        }

        [HttpGet]
        [Route("SSDGetById")]
        public JsonResult SSDGetById(int id)
        {
            if (id < 1)
            {
                return Json(ResultToJson.GetJsonResult());

            }
            SSD SSD = _SSDRepositor.GetById(id);
            return Json(ResultToJson.GetJsonResult(SSD));

        }

        [HttpGet]
        [Route("SSDGetByValue")]
        public JsonResult SSDGetByValue(decimal value1=0,decimal value2=9999,int indexPage=-1,int size = -1)
        {
            
            PageSplitModel<SSD> listmodel = _SSDRepositor.GetByValue(value1, value2, indexPage, size);

            return Json(ResultToJson.GetJsonResult(listmodel));
        }
        
        [HttpGet]
        [Route("SSDGetByBrand")]
        public JsonResult SSDGetByBrand(string brand = "", int indexPage = -1, int size = -1)
        {
            if (string.IsNullOrEmpty(brand))
                return Json(ResultToJson.GetJsonResult());
           
            PageSplitModel<SSD> listmodel = _SSDRepositor.GetByBrand(brand, indexPage, size);

            return Json(ResultToJson.GetJsonResult(listmodel));
        }


        [HttpGet]
        [Route("SSDGetByAll")]
        public JsonResult SSDGetByAll(string brand = "", decimal value1 = 0, decimal value2 = 9999, string name = "", int indexPage = -1, int size = -1, int id = -1)
        {
            var myenum = HardWareEnum.固态硬盘;

             
            PageSplitModel<SSD> listmodel = _SSDRepositor.GetByAll(brand, value1, value2, myenum, name, indexPage, size,id);

            return Json(ResultToJson.GetJsonResult(listmodel));
        }


        [HttpGet]
        [Route("SSDGetByAny")]
        public JsonResult SSDGetByAny(string brand = "", decimal value1 = 0, decimal value2 = 9999, string name = "", int indexPage = -1, int size = -1)
        {
            var myenum = HardWareEnum.固态硬盘;

            
            PageSplitModel<SSD> listmodel = _SSDRepositor.GetByAny(brand, value1, value2, myenum, name, indexPage, size);

            return Json(ResultToJson.GetJsonResult(listmodel));
        }

        [HttpGet]
        [Route("SSDList")]
        public JsonResult SSDList(int indexPage=-1,int size = -1)
        {
          
            PageSplitModel<SSD> listmodel = _SSDRepositor.List(indexPage, size);

            return Json(ResultToJson.GetJsonResult(listmodel));
        }

    }
}