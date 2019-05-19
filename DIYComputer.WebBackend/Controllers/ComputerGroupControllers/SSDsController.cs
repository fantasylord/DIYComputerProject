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
    public class SSDsController : Controller
    {
        private readonly EFDBContext _context;

        public SSDsController(EFDBContext context)
        {
            _context = context;
        }

        // GET: SSDs
        public async Task<IActionResult> Index()
        {
            return View(await _context.SSDs.ToListAsync());
        }

        // GET: SSDs/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sSD = await _context.SSDs
                .FirstOrDefaultAsync(m => m.ID == id);
            if (sSD == null)
            {
                return NotFound();
            }

            return View(sSD);
        }

        // GET: SSDs/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: SSDs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("SSDInterface,SSDCapacity,OutSpeed,InputSpeed,ID,Brand,Name,Value,HardWareEnum,Imgurl")] SSD sSD)
        {
            if (ModelState.IsValid)
            {
                _context.Add(sSD);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(sSD);
        }

        // GET: SSDs/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sSD = await _context.SSDs.FindAsync(id);
            if (sSD == null)
            {
                return NotFound();
            }
            return View(sSD);
        }

        // POST: SSDs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("SSDInterface,SSDCapacity,OutSpeed,InputSpeed,ID,Brand,Name,Value,HardWareEnum,Imgurl")] SSD sSD)
        {
            if (id != sSD.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(sSD);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SSDExists(sSD.ID))
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
            return View(sSD);
        }

        // GET: SSDs/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sSD = await _context.SSDs
                .FirstOrDefaultAsync(m => m.ID == id);
            if (sSD == null)
            {
                return NotFound();
            }

            return View(sSD);
        }

        // POST: SSDs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var sSD = await _context.SSDs.FindAsync(id);
            _context.SSDs.Remove(sSD);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SSDExists(int id)
        {
            return _context.SSDs.Any(e => e.ID == id);
        }
    }
}
