using Microsoft.AspNetCore.Mvc;
using DIYComputer.Util.CommonModel;
namespace DIYComputer.WebBackend.Controllers
{
    public class SharedController:Controller
    {
        [HttpGet]
       
        public IActionResult Error()
        {
            ErrorViewModel errorViewModel = new ErrorViewModel();
            return View(errorViewModel);
        }
    }
}
