using DIYComputer.Entity.ComputerWareEntity;
using DIYComputer.Entity.DBContext;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace DIYComputer.WebBackend.Controllers.ComputerGroupControllers
{
    [Authorize(Policy = "Admin")]
    public class HardDisksController : Controller
    {
        private readonly EFDBContext _context;

        public HardDisksController(EFDBContext context)
        {
            _context = context;
        }

        // GET: HardDisks
        public async Task<IActionResult> Index()
        {
            return View(await _context.HardDisks.ToListAsync());
        }

        // GET: HardDisks/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var hardDisk = await _context.HardDisks
                .FirstOrDefaultAsync(m => m.ID == id);
            if (hardDisk == null)
            {
                return NotFound();
            }

            return View(hardDisk);
        }

        // GET: HardDisks/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: HardDisks/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("HDSuitable,HDInterface,HDRotateSpeed,HDCache,HDCapacity,Brand,Name,Value,Imgurl")] HardDisk hardDisk)
        {
            if (ModelState.IsValid)
            {
                _context.Add(hardDisk);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(hardDisk);
        }

        // GET: HardDisks/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var hardDisk = await _context.HardDisks.FindAsync(id);
            if (hardDisk == null)
            {
                return NotFound();
            }
            return View(hardDisk);
        }

        // POST: HardDisks/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("HDSuitable,HDInterface,HDRotateSpeed,HDCache,HDCapacity,ID,Brand,Name,Value,Imgurl")] HardDisk hardDisk)
        {
            if (id != hardDisk.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(hardDisk);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!HardDiskExists(hardDisk.ID))
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
            return View(hardDisk);
        }

        // GET: HardDisks/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var hardDisk = await _context.HardDisks
                .FirstOrDefaultAsync(m => m.ID == id);
            if (hardDisk == null)
            {
                return NotFound();
            }

            return View(hardDisk);
        }

        // POST: HardDisks/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var hardDisk = await _context.HardDisks.FindAsync(id);
            _context.HardDisks.Remove(hardDisk);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool HardDiskExists(int id)
        {
            return _context.HardDisks.Any(e => e.ID == id);
        }
    }
}
