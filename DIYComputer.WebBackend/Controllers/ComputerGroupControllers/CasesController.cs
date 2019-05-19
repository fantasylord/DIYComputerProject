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
    public class CasesController : Controller
    {
        private readonly EFDBContext _context;

        private void Injection()
        {
            ViewData["EnumCaseCondition"] = new SelectList(EnumInfo.GetInstace().EnumCaseCondition, "Value", "Value");
            ViewData["EnumCaseFunction"] = new SelectList(EnumInfo.GetInstace().EnumCaseFunction, "Value", "Value");
            ViewData["EnumCaseType"] = new SelectList(EnumInfo.GetInstace().EnumCaseType, "Value", "Value");
            ViewData["EnumCaseStruct"] = new SelectList(EnumInfo.GetInstace().EnumCaseStruct, "Value", "Value");
            ViewData["EnumCaseStyle"] = new SelectList(EnumInfo.GetInstace().EnumCaseStyle, "Value", "Value");
            ViewData["EnumCaseColor"] = new SelectList(EnumInfo.GetInstace().EnumCaseColor, "Value", "Value");


        }
        private void Injection(Case model)
        {
            ViewData["EnumCaseCondition"] = new SelectList(EnumInfo.GetInstace().EnumCaseCondition, "Value", "Value",model.CaseCondition);
            ViewData["EnumCaseFunction"] = new SelectList(EnumInfo.GetInstace().EnumCaseFunction, "Value", "Value",model.CaseFunction);
            ViewData["EnumCaseType"] = new SelectList(EnumInfo.GetInstace().EnumCaseType, "Value", "Value",model.CaseType);
            ViewData["EnumCaseStruct"] = new SelectList(EnumInfo.GetInstace().EnumCaseStruct, "Value", "Value",model.CaseStruct);
            ViewData["EnumCaseStyle"] = new SelectList(EnumInfo.GetInstace().EnumCaseStyle, "Value", "Value",model.CaseStyle);
            ViewData["EnumCaseColor"] = new SelectList(EnumInfo.GetInstace().EnumCaseColor, "Value", "Value",model.CaseColor);

        }

        public CasesController(EFDBContext context)
        {
            _context = context;
        }

        // GET: Cases
        public async Task<IActionResult> Index()
        {
            return View(await _context.Cases.ToListAsync());
        }

        // GET: Cases/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var @case = await _context.Cases
                .FirstOrDefaultAsync(m => m.ID == id);
            if (@case == null)
            {
                return NotFound();
            }

            return View(@case);
        }

        // GET: Cases/Create
        public IActionResult Create()
        {
            Injection();
            return View();
        }

        // POST: Cases/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CaseCondition,CaseCondition,CaseFunction,CaseFunction,CaseType,CaseStruct,CaseStyle,CaseColor,Brand,Name,Value,HardWareEnum,Imgurl")] Case @case)
        {
            if (ModelState.IsValid)
            {
                _context.Add(@case);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            Injection(@case);
            return View(@case);
        }

        // GET: Cases/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var @case = await _context.Cases.FindAsync(id);
            if (@case == null)
            {
                return NotFound();
            }
            Injection(@case);

            return View(@case);
        }

        // POST: Cases/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("CaseCondition,CaseCondition,CaseFunction,CaseFunction,CaseType,CaseStruct,CaseStyle,CaseColor,ID,Brand,Name,Value,HardWareEnum,Imgurl")] Case @case)
        {
            if (id != @case.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(@case);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CaseExists(@case.ID))
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
            return View(@case);
        }

        // GET: Cases/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var @case = await _context.Cases
                .FirstOrDefaultAsync(m => m.ID == id);
            if (@case == null)
            {
                return NotFound();
            }

            return View(@case);
        }

        // POST: Cases/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var @case = await _context.Cases.FindAsync(id);
            _context.Cases.Remove(@case);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CaseExists(int id)
        {
            return _context.Cases.Any(e => e.ID == id);
        }
    }
}
