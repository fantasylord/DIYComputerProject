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
    public class CDROMsController : Controller
    {
        private readonly EFDBContext _context;

        public CDROMsController(EFDBContext context)
        {
            _context = context;
        }

        // GET: CDROMs
        public async Task<IActionResult> Index()
        {
            return View(await _context.CDROMs.ToListAsync());
        }

        // GET: CDROMs/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cDROM = await _context.CDROMs
                .FirstOrDefaultAsync(m => m.ID == id);
            if (cDROM == null)
            {
                return NotFound();
            }

            return View(cDROM);
        }

        // GET: CDROMs/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: CDROMs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CDROMType,Brand,Name,Value,Imgurl")] CDROM cDROM)
        {
            if (ModelState.IsValid)
            {
                _context.Add(cDROM);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(cDROM);
        }

        // GET: CDROMs/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cDROM = await _context.CDROMs.FindAsync(id);
            if (cDROM == null)
            {
                return NotFound();
            }
            return View(cDROM);
        }

        // POST: CDROMs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("CDROMType,ID,Brand,Name,Value,Imgurl")] CDROM cDROM)
        {
            if (id != cDROM.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(cDROM);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CDROMExists(cDROM.ID))
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
            return View(cDROM);
        }

        // GET: CDROMs/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cDROM = await _context.CDROMs
                .FirstOrDefaultAsync(m => m.ID == id);
            if (cDROM == null)
            {
                return NotFound();
            }

            return View(cDROM);
        }

        // POST: CDROMs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var cDROM = await _context.CDROMs.FindAsync(id);
            _context.CDROMs.Remove(cDROM);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CDROMExists(int id)
        {
            return _context.CDROMs.Any(e => e.ID == id);
        }
    }
}
