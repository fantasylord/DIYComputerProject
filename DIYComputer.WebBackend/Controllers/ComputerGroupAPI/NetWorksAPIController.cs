using Microsoft.AspNetCore.Mvc;
using DIYComputer.Entity.ComputerWareEntity;
using DIYComputer.Entity.DBContext;
using DIYComputer.Repository.IRepository;
using DIYComputer.Util;
using DIYComputer.Util.CommonModel;
using Microsoft.AspNetCore.Mvc;
using DIYComputer.Config.StaticSource;

namespace DIYComputer.WebBackend.Controllers.ComputerGroupAPI
{
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json")]
    public class NetWorksAPIController : Controller
    {
        private readonly EFDBContext _context;
        private readonly ICGRepositor<NetWork> _NetWorkRepositor;
        public NetWorksAPIController(EFDBContext context, ICGRepositor<NetWork> NetWorkRepositor)
        {
            _NetWorkRepositor = NetWorkRepositor;
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
        [Route("NetWorkGetByName")]
        public JsonResult NetWorkGetByName(string name, int indexPage = 1, int size = 30)
        {

            if (name == null)
            {
                return Json(ResultToJson.GetJsonResult());
            }
            else
            {
      
                PageSplitModel<NetWork> listmodel = _NetWorkRepositor.GetByName(name, indexPage, size);

                return Json(ResultToJson.GetJsonResult(listmodel));
            }


        }

        [HttpGet]
        [Route("NetWorkGetById")]
        public JsonResult NetWorkGetById(int id)
        {
            if (id < 1)
            {
                return Json(ResultToJson.GetJsonResult());

            }
            NetWork NetWork = _NetWorkRepositor.GetById(id);
    
            return Json(ResultToJson.GetJsonResult(NetWork));
        }

        [HttpGet]
        [Route("NetWorkGetByValue")]
        public JsonResult NetWorkGetByValue(decimal value1=0,decimal value2=9999,int indexPage=-1,int size = -1)
        {
         
            PageSplitModel<NetWork> listmodel = _NetWorkRepositor.GetByValue(value1, value2, indexPage, size);

            return Json(ResultToJson.GetJsonResult(listmodel));
        }
        
        [HttpGet]
        [Route("NetWorkGetByBrand")]
        public JsonResult NetWorkGetByBrand(string brand = "", int indexPage = -1, int size = -1)
        {
            if (string.IsNullOrEmpty(brand))
                return Json(ResultToJson.GetJsonResult());
          
            PageSplitModel<NetWork> listmodel = _NetWorkRepositor.GetByBrand(brand, indexPage, size);

            return Json(ResultToJson.GetJsonResult(listmodel));
        }


        [HttpGet]
        [Route("NetWorkGetByAll")]
        public JsonResult NetWorkGetByAll(string brand = "", decimal value1 = 0, decimal value2 = 9999, string name = "", int indexPage = -1, int size = -1, int id = -1)
        {
            var myenum = HardWareEnum.网卡;

            
            PageSplitModel<NetWork> listmodel = _NetWorkRepositor.GetByAll(brand, value1, value2, myenum, name, indexPage, size,id);

            return Json(ResultToJson.GetJsonResult(listmodel));
        }


        [HttpGet]
        [Route("NetWorkGetByAny")]
        public JsonResult NetWorkGetByAny(string brand = "", decimal value1 = 0, decimal value2 = 9999, string name = "", int indexPage = -1, int size = -1)
        {
            var myenum = HardWareEnum.网卡;

   
            PageSplitModel<NetWork> listmodel = _NetWorkRepositor.GetByAny(brand, value1, value2, myenum, name, indexPage, size);

            return Json(ResultToJson.GetJsonResult(listmodel));
        }

        [HttpGet]
        [Route("NetWorkList")]
        public JsonResult NetWorkList(int indexPage=-1,int size = -1)
        {
            
            PageSplitModel<NetWork> listmodel = _NetWorkRepositor.List(indexPage, size);

            return Json(ResultToJson.GetJsonResult(listmodel));
        }

    }
}