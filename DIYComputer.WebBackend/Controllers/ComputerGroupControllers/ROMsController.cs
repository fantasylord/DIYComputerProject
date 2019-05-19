using System;
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
    public class ROMsController : Controller
    {
        private readonly EFDBContext _context;

        public ROMsController(EFDBContext context)
        {
            _context = context;
        }

        // GET: ROMs
        public async Task<IActionResult> Index()
        {
            return View(await _context.ROMs.ToListAsync());
        }

        // GET: ROMs/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var rOM = await _context.ROMs
                .FirstOrDefaultAsync(m => m.ID == id);
            if (rOM == null)
            {
                return NotFound();
            }

            return View(rOM);
        }

        // GET: ROMs/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: ROMs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ROMCapacity,ROMMHz,ROMClass,ROMSuitable,ROMDDRType,ROMCheckout,ID,Brand,Name,Value,HardWareEnum,Imgurl")] ROM rOM)
        {
            if (ModelState.IsValid)
            {
                _context.Add(rOM);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(rOM);
        }

        // GET: ROMs/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var rOM = await _context.ROMs.FindAsync(id);
            if (rOM == null)
            {
                return NotFound();
            }
            return View(rOM);
        }

        // POST: ROMs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ROMCapacity,ROMMHz,ROMClass,ROMSuitable,ROMDDRType,ROMCheckout,Brand,Name,Value,Imgurl")] ROM rOM)
        {
            if (id != rOM.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(rOM);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ROMExists(rOM.ID))
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
            return View(rOM);
        }

        // GET: ROMs/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var rOM = await _context.ROMs
                .FirstOrDefaultAsync(m => m.ID == id);
            if (rOM == null)
            {
                return NotFound();
            }

            return View(rOM);
        }

        // POST: ROMs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var rOM = await _context.ROMs.FindAsync(id);
            _context.ROMs.Remove(rOM);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ROMExists(int id)
        {
            return _context.ROMs.Any(e => e.ID == id);
        }
    }
}
