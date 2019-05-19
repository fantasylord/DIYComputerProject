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
    public class HardDisksAPIController : Controller
    {
        private readonly EFDBContext _context;
        private readonly ICGRepositor<HardDisk> _HardDiskRepositor;
        public HardDisksAPIController(EFDBContext context, ICGRepositor<HardDisk> HardDiskRepositor)
        {
            _HardDiskRepositor = HardDiskRepositor;
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
        [Route("HardDiskGetByName")]
        public JsonResult HardDiskGetByName(string name, int indexPage = 1, int size = 30)
        {

            if (name == null)
            {
                return Json(ResultToJson.GetJsonResult());
            }
            else
            {
                //List<HardDisk> list = _HardDiskRepositor.GetByName(name, indexPage, size).ToList();
                PageSplitModel<HardDisk> listmodel = _HardDiskRepositor.GetByName(name, indexPage, size);

                return Json(ResultToJson.GetJsonResult(listmodel));
            }


        }

        [HttpGet]
        [Route("HardDiskGetById")]
        public JsonResult HardDiskGetById(int id)
        {
            if (id < 1)
            {
                return Json(ResultToJson.GetJsonResult());

            }
            HardDisk HardDisk = _HardDiskRepositor.GetById(id);

            return Json(ResultToJson.GetJsonResult(HardDisk));
        }

        [HttpGet]
        [Route("HardDiskGetByValue")]
        public JsonResult HardDiskGetByValue(decimal value1=0,decimal value2=9999,int indexPage=-1,int size = -1)
        {
        
            PageSplitModel<HardDisk> listmodel = _HardDiskRepositor.GetByValue(value1, value2, indexPage, size);

            return Json(ResultToJson.GetJsonResult(listmodel));
        }
        
        [HttpGet]
        [Route("HardDiskGetByBrand")]
        public JsonResult HardDiskGetByBrand(string brand = "", int indexPage = -1, int size = -1)
        {
            if (string.IsNullOrEmpty(brand))
                return Json(ResultToJson.GetJsonResult());
          
            PageSplitModel<HardDisk> listmodel = _HardDiskRepositor.GetByBrand(brand, indexPage, size);

            return Json(ResultToJson.GetJsonResult(listmodel));
        }


        [HttpGet]
        [Route("HardDiskGetByAll")]
        public JsonResult HardDiskGetByAll(string brand = "", decimal value1 = 0, decimal value2 = 9999, string name = "", int indexPage = -1, int size = -1, int id = -1)
        {
            var myenum = HardWareEnum.硬盘;

           
            PageSplitModel<HardDisk> listmodel = _HardDiskRepositor.GetByAll(brand, value1, value2, myenum, name, indexPage, size,id);

            return Json(ResultToJson.GetJsonResult(listmodel));
        }


        [HttpGet]
        [Route("HardDiskGetByAny")]
        public JsonResult HardDiskGetByAny(string brand = "", decimal value1 = 0, decimal value2 = 9999, string name = "", int indexPage = -1, int size = -1)
        {
            var myenum = HardWareEnum.硬盘;

   
            PageSplitModel<HardDisk> listmodel = _HardDiskRepositor.GetByAny(brand, value1, value2, myenum, name, indexPage, size);

            return Json(ResultToJson.GetJsonResult(listmodel));
        }

        [HttpGet]
        [Route("HardDiskList")]
        public JsonResult HardDiskList(int indexPage=-1,int size = -1)
        {
    
            PageSplitModel<HardDisk> listmodel = _HardDiskRepositor.List(indexPage, size);

            return Json(ResultToJson.GetJsonResult(listmodel));
        }

    }
}