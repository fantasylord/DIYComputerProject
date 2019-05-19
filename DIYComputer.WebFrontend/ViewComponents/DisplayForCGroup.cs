using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace DIYComputer.WebFrontend.ViewComponents
{
    [ViewComponent(Name = "DisplayForCGroup")]
    public class DisplayForCGroup:ViewComponent
    {

        public DisplayForCGroup()
        {

        }

        public async Task<IViewComponentResult> InvokeAsync()
        {

            return View();
        }
    }
}
