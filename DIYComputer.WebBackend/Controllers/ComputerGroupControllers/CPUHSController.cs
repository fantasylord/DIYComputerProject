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
    public class CPUHSController : Controller
    {
        private readonly EFDBContext _context;

        public CPUHSController(EFDBContext context)
        {
            _context = context;
        }

        private void Injection()
        {
            ViewData["EnumCPUHSFunction"] = new SelectList(EnumInfo.GetInstace().EnumCPUHSFunction, "Value", "Value");
        }
        private void Injection(CPUHS model)
        {
            ViewData["EnumCPUHSFunction"] = new SelectList(EnumInfo.GetInstace().EnumCPUHSFunction, "Value", "Value",model.CPUHSFunction);
        }
        // GET: CPUHS
        public async Task<IActionResult> Index()
        {
            return View(await _context.CPUHs.ToListAsync());
        }

        // GET: CPUHS/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cPUHS = await _context.CPUHs
                .FirstOrDefaultAsync(m => m.ID == id);
            if (cPUHS == null)
            {
                return NotFound();
            }
            Injection(cPUHS);
            return View(cPUHS);
        }

        // GET: CPUHS/Create
        public IActionResult Create()
        {
            Injection();

            return View();
        }

        // POST: CPUHS/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CPUHSType,CPUHSFunction,CPUHSFunctions,CPUHSSuitable,CPUHSHeatPipes,CPUHSClass,Brand,Name,Value,Imgurl")] CPUHS cPUHS)
        {
            if (ModelState.IsValid)
            {
                _context.Add(cPUHS);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            Injection(cPUHS);

            return View(cPUHS);
        }

        // GET: CPUHS/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cPUHS = await _context.CPUHs.FindAsync(id);
            if (cPUHS == null)
            {
                return NotFound();
            }
            Injection(cPUHS);

            return View(cPUHS);
        }

        // POST: CPUHS/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("CPUHSType,CPUHSFunction,CPUHSFunctions,CPUHSSuitable,CPUHSHeatPipes,CPUHSClass,ID,Brand,Name,Value,Imgurl")] CPUHS cPUHS)
        {
            if (id != cPUHS.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(cPUHS);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CPUHSExists(cPUHS.ID))
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
            return View(cPUHS);
        }

        // GET: CPUHS/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cPUHS = await _context.CPUHs
                .FirstOrDefaultAsync(m => m.ID == id);
            if (cPUHS == null)
            {
                return NotFound();
            }

            return View(cPUHS);
        }

        // POST: CPUHS/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var cPUHS = await _context.CPUHs.FindAsync(id);
            _context.CPUHs.Remove(cPUHS);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CPUHSExists(int id)
        {
            return _context.CPUHs.Any(e => e.ID == id);
        }
    }
}
