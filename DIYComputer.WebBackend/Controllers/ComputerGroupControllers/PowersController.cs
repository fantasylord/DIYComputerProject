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
    public class PowersController : Controller
    {
        private readonly EFDBContext _context;
         
        public PowersController(EFDBContext context)
        {
            _context = context;
        }

        // GET: Powers
        public async Task<IActionResult> Index()
        {
            return View(await _context.Powers.ToListAsync());
        }

        private void Injection()
        {
            ViewData["EnumPowerFunction"] = new SelectList(EnumInfo.GetInstace().EnumPowerFunction, "Value", "Value");
        }
        private void Injection(Power model)
        {
            ViewData["EnumPowerFunction"] = new SelectList(EnumInfo.GetInstace().EnumPowerFunction, "Value", "Value",model.PowerFunction);
        }
        // GET: Powers/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var power = await _context.Powers
                .FirstOrDefaultAsync(m => m.ID == id);
            if (power == null)
            {
                return NotFound();
            }

            return View(power);
        }

        // GET: Powers/Create
        public IActionResult Create()
        {
            Injection();
            return View();
        }

        // POST: Powers/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("PowerFunction,PowerFunctions,PowerRange,Power80PLus,PowerFanSize,Power44CPU,Power4PCPU,Power62P,PowerType,PowerCase,Brand,Name,Value,Imgurl")] Power power)
        {
            if (ModelState.IsValid)
            {
                _context.Add(power);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            Injection(power);
            return View(power);
        }

        // GET: Powers/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var power = await _context.Powers.FindAsync(id);
            if (power == null)
            {
                return NotFound();
            }
            Injection(power);

            return View(power);
        }

        // POST: Powers/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("PowerFunction,PowerFunctions,PowerRange,Power80PLus,PowerFanSize,Power44CPU,Power4PCPU,Power62P,PowerType,PowerCase,ID,Brand,Name,Value,Imgurl")] Power power)
        {
            if (id != power.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(power);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PowerExists(power.ID))
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
            Injection(power);

            return View(power);
        }

        // GET: Powers/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var power = await _context.Powers
                .FirstOrDefaultAsync(m => m.ID == id);
            if (power == null)
            {
                return NotFound();
            }

            return View(power);
        }

        // POST: Powers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var power = await _context.Powers.FindAsync(id);
            _context.Powers.Remove(power);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PowerExists(int id)
        {
            return _context.Powers.Any(e => e.ID == id);
        }
    }
}
