using DIYComputer.Entity.DBContext;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace DIYComputer.WebBackend.ViewComponents
{
    [ViewComponent(Name = "FileUp")]
    public class FileUpViewComponent : ViewComponent
    {
        private readonly EFDBContext _context;

        public FileUpViewComponent(EFDBContext context)
        {
            _context = context;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            return View();
        }
    }
}
