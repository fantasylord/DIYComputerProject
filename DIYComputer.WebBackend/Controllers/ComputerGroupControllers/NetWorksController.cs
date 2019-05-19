using DIYComputer.Config.StaticSource;
using DIYComputer.Entity.ComputerWareEntity;
using DIYComputer.Entity.DBContext;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace DIYComputer.WebBackend.Controllers.ComputerGroupControllers
{
    [Authorize(Policy = "Admin")]
    public class NetWorksController : Controller
    {
        private readonly EFDBContext _context;

        public NetWorksController(EFDBContext context)
        {
            _context = context;
        }

        private void Injection(NetWork model)
        {
            ViewData["NetWokrSuitable"] = new SelectList(EnumInfo.GetInstace().EnumNetWokrSuitable, "Value", "Value", model.NetWokrSuitable);
        }
        private void Injection()
        {
            ViewData["NetWokrSuitable"] = new SelectList(EnumInfo.GetInstace().EnumNetWokrSuitable, "Value", "Value");
        }
        // GET: NetWorks
        public async Task<IActionResult> Index()
        {
            return View(await _context.NetWorks.ToListAsync());
        }

        // GET: NetWorks/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var netWork = await _context.NetWorks
                .FirstOrDefaultAsync(m => m.ID == id);
            if (netWork == null)
            {
                return NotFound();
            }
            Injection(netWork);
            return View(netWork);
        }

        // GET: NetWorks/Create
        public IActionResult Create()
        {
            Injection();

            return View();
        }

        // POST: NetWorks/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("NetWokrSuitable,NetWokrSuitables,ID,Brand,Name,Value,Imgurl")] NetWork netWork)
        {
            if (ModelState.IsValid)
            {
                _context.Add(netWork);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            Injection(netWork);

            return View(netWork);
        }

        // GET: NetWorks/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var netWork = await _context.NetWorks.FindAsync(id);
            if (netWork == null)
            {
                return NotFound();
            }
            Injection(netWork);

            return View(netWork);
        }
      
        // POST: NetWorks/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("NetWokrSuitable,NetWokrSuitables,ID,Brand,Name,Value,Imgurl")] NetWork netWork)
        {
            if (id != netWork.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(netWork);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!NetWorkExists(netWork.ID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            Injection(netWork);

            return View(netWork);
        }

        // GET: NetWorks/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var netWork = await _context.NetWorks
                .FirstOrDefaultAsync(m => m.ID == id);
            if (netWork == null)
            {
                return NotFound();
            }

            return View(netWork);
        }

        // POST: NetWorks/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var netWork = await _context.NetWorks.FindAsync(id);
            _context.NetWorks.Remove(netWork);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool NetWorkExists(int id)
        {
            return _context.NetWorks.Any(e => e.ID == id);
        }
    }
}
