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
    public class CasesAPIController : Controller
    {
        private readonly EFDBContext _context;
        private readonly ICGRepositor<Case> _CaseRepositor;
        public CasesAPIController(EFDBContext context, ICGRepositor<Case> CaseRepositor)
        {
            _CaseRepositor = CaseRepositor;
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
        [Route("CaseGetByName")]
        public JsonResult CaseGetByName(string name, int indexPage = 1, int size = 30)
        {

            if (name == null)
            {
                return Json(ResultToJson.GetJsonResult());
            }
            else
            {

                PageSplitModel<Case> listmodel = _CaseRepositor.GetByName(name, indexPage, size);

                return Json(ResultToJson.GetJsonResult(listmodel));
            }


        }

        [HttpGet]
        [Route("CaseGetById")]
        public JsonResult CaseGetById(int id)
        {
            if (id < 1)
            {
                return Json(ResultToJson.GetJsonResult());

            }
            Case Case = _CaseRepositor.GetById(id);
            return Json(ResultToJson.GetJsonResult(Case));

        }

        [HttpGet]
        [Route("CaseGetByValue")]
        public JsonResult CaseGetByValue(decimal value1=0,decimal value2=9999,int indexPage=-1,int size = -1)
        {
           
            PageSplitModel<Case> listmodel = _CaseRepositor.GetByValue(value1, value2, indexPage, size);

            return Json(ResultToJson.GetJsonResult(listmodel));
        }
        
        [HttpGet]
        [Route("CaseGetByBrand")]
        public JsonResult CaseGetByBrand(string brand = "", int indexPage = -1, int size = -1)
        {
            if (string.IsNullOrEmpty(brand))
                return Json(ResultToJson.GetJsonResult());
       
            PageSplitModel<Case> listmodel = _CaseRepositor.GetByBrand(brand, indexPage, size);

            return Json(ResultToJson.GetJsonResult(listmodel));
        }


        [HttpGet]
        [Route("CaseGetByAll")]
        public JsonResult CaseGetByAll(string brand = "", decimal value1 = 0, decimal value2 = 9999, string name = "", int indexPage = -1, int size = -1, int id = -1)
        {
            var myenum = HardWareEnum.机箱;

         
            PageSplitModel<Case> listmodel = _CaseRepositor.GetByAll(brand, value1, value2, myenum, name, indexPage, size,id);

            return Json(ResultToJson.GetJsonResult(listmodel));
        }


        [HttpGet]
        [Route("CaseGetByAny")]
        public JsonResult CaseGetByAny(string brand = "", decimal value1 = 0, decimal value2 = 9999, string name = "", int indexPage = -1, int size = -1)
        {
            var myenum = HardWareEnum.机箱;

    
            PageSplitModel<Case> listmodel = _CaseRepositor.GetByAny(brand, value1, value2, myenum, name, indexPage, size);

            return Json(ResultToJson.GetJsonResult(listmodel));
        }

        [HttpGet]
        [Route("CaseList")]
        public JsonResult CaseList(int indexPage=-1,int size = -1)
        {
         
            PageSplitModel<Case> listmodel = _CaseRepositor.List(indexPage, size);

            return Json(ResultToJson.GetJsonResult(listmodel));
        }

    }
}