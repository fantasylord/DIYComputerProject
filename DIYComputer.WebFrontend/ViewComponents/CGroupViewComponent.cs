using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace DIYComputer.WebFrontend.ViewComponents
{
    [ViewComponent(Name = "CGroup")]
    public class CGroupViewComponent:ViewComponent
    {
       // private VierificationCodeServices _codeServices;

        public CGroupViewComponent()
        {
            ;
        }
            

        public async Task<IViewComponentResult> InvokeAsync(string port, string ip,string controller,string actionname)
        {  
            ViewData["port"] = port;
            ViewData["ip"] = ip;
            ViewData["controller"] = controller;
            ViewData["actionname"] = actionname;
            return View();
        }
    }
}
