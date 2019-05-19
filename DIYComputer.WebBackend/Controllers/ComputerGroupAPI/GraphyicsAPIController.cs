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
    public class GraphyicsAPIController : Controller
    {
        private readonly EFDBContext _context;
        private readonly ICGRepositor<Graphyic> _GraphyicRepositor;
        public GraphyicsAPIController(EFDBContext context, ICGRepositor<Graphyic> GraphyicRepositor)
        {
            _GraphyicRepositor = GraphyicRepositor;
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
        [Route("GraphyicGetByName")]
        public JsonResult GraphyicGetByName(string name, int indexPage = 1, int size = 30)
        {

            if (name == null)
            {
                return Json(ResultToJson.GetJsonResult());
            }
            else
            {
                 PageSplitModel<Graphyic> listmodel = _GraphyicRepositor.GetByName(name, indexPage, size);

                return Json(ResultToJson.GetJsonResult(listmodel));
            }


        }

        [HttpGet]
        [Route("GraphyicGetById")]
        public JsonResult GraphyicGetById(int id)
        {
            if (id < 1)
            {
                return Json(ResultToJson.GetJsonResult());

            }
            Graphyic Graphyic = _GraphyicRepositor.GetById(id);
        return Json(ResultToJson.GetJsonResult(Graphyic));
        }

        [HttpGet]
        [Route("GraphyicGetByValue")]
        public JsonResult GraphyicGetByValue(decimal value1=0,decimal value2=9999,int indexPage=-1,int size = -1)
        {
        
            PageSplitModel<Graphyic> listmodel = _GraphyicRepositor.GetByValue(value1, value2, indexPage, size);

            return Json(ResultToJson.GetJsonResult(listmodel));
        }
        
        [HttpGet]
        [Route("GraphyicGetByBrand")]
        public JsonResult GraphyicGetByBrand(string brand = "", int indexPage = -1, int size = -1)
        {
            if (string.IsNullOrEmpty(brand))
                return Json(ResultToJson.GetJsonResult());
           
            PageSplitModel<Graphyic> listmodel = _GraphyicRepositor.GetByBrand(brand, indexPage, size);

            return Json(ResultToJson.GetJsonResult(listmodel));
        }


        [HttpGet]
        [Route("GraphyicGetByAll")]
        public JsonResult GraphyicGetByAll(string brand = "", decimal value1 = 0, decimal value2 = 9999, string name = "", int indexPage = -1, int size = -1, int id = -1)
        {
            var myenum = HardWareEnum.显卡;

            PageSplitModel<Graphyic> listmodel =
                _GraphyicRepositor.GetByAll(brand, value1, value2, myenum, name, indexPage, size,id);

            return Json(ResultToJson.GetJsonResult(listmodel));
        }


        [HttpGet]
        [Route("GraphyicGetByAny")]
        public JsonResult GraphyicGetByAny(string brand = "", decimal value1 = 0, decimal value2 = 9999, string name = "", int indexPage = -1, int size = -1)
        {
            var myenum = HardWareEnum.显卡;

             
            PageSplitModel<Graphyic> listmodel = _GraphyicRepositor.GetByAny(brand, value1, value2, myenum, name, indexPage, size);

            return Json(ResultToJson.GetJsonResult(listmodel));
        }

        [HttpGet]
        [Route("GraphyicList")]
        public JsonResult GraphyicList(int indexPage=-1,int size = -1)
        {
        
            PageSplitModel<Graphyic> listmodel = _GraphyicRepositor.List(indexPage, size);

            return Json(ResultToJson.GetJsonResult(listmodel));
        }

    }
}