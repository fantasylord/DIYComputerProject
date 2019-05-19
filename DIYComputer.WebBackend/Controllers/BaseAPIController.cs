using DIYComputer.Entity.DBContext;
using DIYComputer.Entity.SysEntity;
using DIYComputer.Util;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace DIYComputer.WebBackend.Controllers
{
    [Route("api/[controller]")]
    [Produces("application/json")]
    public class BaseAPIController:Controller
    {


        private readonly EFDBContext _context;
        private readonly IHttpContextAccessor _accessor;
       public BaseAPIController(EFDBContext eFDBContext,IHttpContextAccessor accessor)
        {
            _context = eFDBContext;
            _accessor = accessor;
        }


        [HttpGet]
        [AllowAnonymous]
        [Route("TestAPI")]
        public async Task<JsonResult> TestAPI()
        {
            return Json("");
        }

        [HttpPost]
        [AllowAnonymous]
        [Route("PostFeedback")]
        public async Task<JsonResult> PostFeedback([Bind("FeedContent,PostMan,Id,Remarks")] Feedback feedback)
        {

            _context.Add(feedback);
            await _context.SaveChangesAsync();

            return Json(ResultToJson.GetJsonResult("提交成功"));

        }

    }
}
