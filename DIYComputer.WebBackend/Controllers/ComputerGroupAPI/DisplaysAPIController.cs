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
    public class DisplaysAPIController : Controller
    {
        private readonly EFDBContext _context;
        private readonly ICGRepositor<Display> _DisplayRepositor;
        public DisplaysAPIController(EFDBContext context, ICGRepositor<Display> DisplayRepositor)
        {
            _DisplayRepositor = DisplayRepositor;
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
        [Route("DisplayGetByName")]
        public JsonResult DisplayGetByName(string name, int indexPage = 1, int size = 30)
        {

            if (name == null)
            {
                return Json(ResultToJson.GetJsonResult());
            }
            else
            {
               
                PageSplitModel<Display> listmodel = _DisplayRepositor.GetByName(name, indexPage, size);

                return Json(ResultToJson.GetJsonResult(listmodel));
            }


        }

        [HttpGet]
        [Route("DisplayGetById")]
        public JsonResult DisplayGetById(int id)
        {
            if (id < 1)
            {
                return Json(ResultToJson.GetJsonResult());

            }
            Display Display = _DisplayRepositor.GetById(id);
  
            return Json(ResultToJson.GetJsonResult(Display));
        }

        [HttpGet]
        [Route("DisplayGetByValue")]
        public JsonResult DisplayGetByValue(decimal value1=0,decimal value2=9999,int indexPage=-1,int size = -1)
        {
 
            PageSplitModel<Display> listmodel = _DisplayRepositor.GetByValue(value1, value2, indexPage, size);

            return Json(ResultToJson.GetJsonResult(listmodel));
        }
        
        [HttpGet]
        [Route("DisplayGetByBrand")]
        public JsonResult DisplayGetByBrand(string brand = "", int indexPage = -1, int size = -1)
        {
            if (string.IsNullOrEmpty(brand))
                return Json(ResultToJson.GetJsonResult());
            
            PageSplitModel<Display> listmodel = _DisplayRepositor.GetByBrand(brand, indexPage, size);

            return Json(ResultToJson.GetJsonResult(listmodel));
        }


        [HttpGet]
        [Route("DisplayGetByAll")]
        public JsonResult DisplayGetByAll(string brand = "", decimal value1 = 0, decimal value2 = 9999, string name = "", int indexPage = -1, int size = -1, int id = -1)
        {
            var myenum = HardWareEnum.显示器;

 
            PageSplitModel<Display> listmodel = _DisplayRepositor.GetByAll(brand, value1, value2, myenum, name, indexPage, size,id);

            return Json(ResultToJson.GetJsonResult(listmodel));
        }


        [HttpGet]
        [Route("DisplayGetByAny")]
        public JsonResult DisplayGetByAny(string brand = "", decimal value1 = 0, decimal value2 = 9999, string name = "", int indexPage = -1, int size = -1)
        {
            var myenum = HardWareEnum.显示器;
 
            PageSplitModel<Display> listmodel = _DisplayRepositor.GetByAny(brand, value1, value2, myenum, name, indexPage, size);

            return Json(ResultToJson.GetJsonResult(listmodel));
        }

        [HttpGet]
        [Route("DisplayList")]
        public JsonResult DisplayList(int indexPage=-1,int size = -1)
        { 
            PageSplitModel<Display> listmodel = _DisplayRepositor.List(indexPage, size);

            return Json(ResultToJson.GetJsonResult(listmodel));
        }

    }
}