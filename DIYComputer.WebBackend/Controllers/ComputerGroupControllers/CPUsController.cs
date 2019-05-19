using DIYComputer.Config.StaticSource;
using DIYComputer.Entity.ComputerWareEntity;
using DIYComputer.Entity.DBContext;
using DIYComputer.Entity.SysEntity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace DIYComputer.WebBackend.Controllers.ComputerGroupControllers
{
    [Authorize(Policy = "Admin")]
    public class CPUsController : Controller
    {
        private readonly EFDBContext _context;
        

        public CPUsController(EFDBContext context)
        {
            _context = context;
         
        }

        // GET: CPUs
        public async Task<IActionResult> Index()
        {
            return View(await _context.CPUs.ToListAsync());
        }

        // GET: CPUs/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cPU = await _context.CPUs
                .FirstOrDefaultAsync(m => m.ID == id);
            if (cPU == null)
            {
                return NotFound();
            }

            return View(cPU);
        }

        /// <summary>
        /// 填充枚举数据
        /// </summary>
        private bool Injection()
        {

            ViewData["EnumCPUBrand"]        =new SelectList(EnumInfo.GetInstace().EnumCPUBrand ,"Value","Value");
            ViewData["EnumCPUClass"]        =new SelectList(EnumInfo.GetInstace().EnumCPUClass, "Value", "Value");
            ViewData["EnumCPUCoreCount"]    =new SelectList(EnumInfo.GetInstace().EnumCPUCoreCount, "Value", "Value");
            ViewData["EnumCpuSuitable"]     =new SelectList(EnumInfo.GetInstace().EnumCpuSuitable, "Value", "Value");
            ViewData["EnumCPUType"]         =new SelectList(EnumInfo.GetInstace().EnumCPUType, "Value", "Value");
            ViewData["EnumCPUIsCase"]       =new SelectList(EnumInfo.GetInstace().EnumCPUIsCase, "Value", "Value");
            ViewData["EnumCPUTechnology"]   =new SelectList(EnumInfo.GetInstace().EnumCPUTechnology, "Value", "Value");


            return true;
        }
        private bool Injection(CPU model)
        {

            ViewData["EnumCPUBrand"] = new SelectList(EnumInfo.GetInstace().EnumCPUBrand, "Value", "Value"          ,model.Brand        );
            ViewData["EnumCPUClass"] = new SelectList(EnumInfo.GetInstace().EnumCPUClass, "Value", "Value"          ,model.CPUClass     );
            ViewData["EnumCPUCoreCount"] = new SelectList(EnumInfo.GetInstace().EnumCPUCoreCount, "Value", "Value"  ,model.CPUCoreCount );   
            ViewData["EnumCpuSuitable"] = new SelectList(EnumInfo.GetInstace().EnumCpuSuitable, "Value", "Value"    ,model.CpuSuitable  );
            ViewData["EnumCPUType"] = new SelectList(EnumInfo.GetInstace().EnumCPUType, "Value", "Value"            ,model.CPUType      );
            ViewData["EnumCPUIsCase"] = new SelectList(EnumInfo.GetInstace().EnumCPUIsCase, "Value", "Value"        ,model.CPUIsCase    );
            ViewData["EnumCPUTechnology"] = new SelectList(EnumInfo.GetInstace().EnumCPUTechnology, "Value", "Value", model.CPUTechnology);


            return true;
        }

        // GET: CPUs/Create
        public IActionResult Create()
        {

            Injection();
            //ViewData["ParentNodeId"] = new SelectList(_context.MenuNodes, "Id", "Name", menuNode.ParentNodeId);
            return View();
        }

        // POST: CPUs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CPUClass,CPUCoreCount,CpuSuitable,CPUType,CPUIsCase,CPUTechnology,ID,Brand,Name,Value,HardWareEnum,,Imgurl")] CPU cPU)
        {
            if (ModelState.IsValid)
            {
                _context.Add(cPU);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            Injection(cPU);
            return View(cPU);
        }

        // GET: CPUs/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cPU = await _context.CPUs.FindAsync(id);
            if (cPU == null)
            {
                return NotFound();
            }
            Injection(cPU);
            return View(cPU);
        }

        // POST: CPUs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("CPUClass,CPUCoreCount,CpuSuitable,CPUType,CPUIsCase,CPUTechnology,ID,Brand,Name,Value,HardWareEnum,,Imgurl")] CPU cPU)
        {
            if (id != cPU.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(cPU);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CPUExists(cPU.ID))
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
            return View(cPU);
        }

        // GET: CPUs/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cPU = await _context.CPUs
                .FirstOrDefaultAsync(m => m.ID == id);
            if (cPU == null)
            {
                return NotFound();
            }

            return View(cPU);
        }

        // POST: CPUs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var cPU = await _context.CPUs.FindAsync(id);
            _context.CPUs.Remove(cPU);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CPUExists(int id)
        {
            return _context.CPUs.Any(e => e.ID == id);
        }
    }
}
