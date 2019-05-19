using DIYComputer.DtoModel.SysDto;
using DIYComputer.Entity.DBContext;
using DIYComputer.Service.VierificationCodeService;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualBasic.CompilerServices;
using System;
using DIYComputer.Util;

namespace DIYComputer.WebFrontend.Controllers
{
    [ApiController]
    [AllowAnonymous]
    [Produces("application/json")]
    [Route("api/[controller]")]
    public class BaseController :Controller
    {


        private readonly EFDBContext _context;
        private readonly VierificationCodeServices _codeServices;
        public BaseController(EFDBContext context, VierificationCodeServices codeServices)
        {
            _codeServices = codeServices;
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
        [Route("GetVCode")]
        public JsonResult GetVCode()
        {
          
            var codemodel= _codeServices.GetVCode();
            codemodel.Code = "";
            DataVCode dataVCode = new DataVCode
            {
                Imgstr = Convert.ToBase64String(codemodel.Data.ToArray()),
                Id = codemodel.Id
            };

             return Json(Util.ResultToJson.GetJsonResult(dataVCode));
            


        }

    }
}
