using DIYComputer.Service.VierificationCodeService;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace DIYComputer.WebFrontend.ViewComponents
{

    [ViewComponent(Name = "VierificationCode")]
    public class VierificationCodeVC :ViewComponent
    {
        private VierificationCodeServices _codeServices;

        public VierificationCodeVC(VierificationCodeServices codeServices)
        {
            _codeServices = codeServices;
        }

     
        public async Task<IViewComponentResult> InvokeAsync()
        {
            //   VierificationCodeModel vc = new VierificationCodeModel();
            var model = _codeServices.GetVCode();
            model.Code = "";
            return View(model);
        }
    }
}
