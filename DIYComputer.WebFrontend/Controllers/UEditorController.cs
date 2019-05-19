using DIYComputer.Entity.DBContext;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UEditorNetCore;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace DIYComputer.WebFrontend.Controllers
{
    //[Authorize(Policy = "Admin")]
    [Route("api/[controller]")]
    public class UEditorController : Controller
    {
        private UEditorService ue;
         
        private IHttpContextAccessor _accessor;
        private readonly EFDBContext dbContext;
        // GET: /<controller>/
        public UEditorController(UEditorService ue,IHttpContextAccessor accessor, EFDBContext _dbContext )
        {
            dbContext = _dbContext;
            _accessor = accessor;
            this.ue = ue;
            


        }

        [HttpGet,HttpPost]
        public void Upload()
        {
            ue.DoAction(HttpContext);
        }

    }
}
