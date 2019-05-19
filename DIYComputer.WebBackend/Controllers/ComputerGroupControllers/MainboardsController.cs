using DIYComputer.Config.StaticSource;
using DIYComputer.Entity.ComputerWareEntity;
using DIYComputer.Entity.DBContext;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DIYComputer.WebBackend.Controllers.ComputerGroupControllers
{
    [Authorize(Policy = "Admin")]
    public class MainboardsController : Controller
    {
        private readonly EFDBContext _context;

        public MainboardsController(EFDBContext context)
        {
            _context = context;
        }

        // GET: Mainboards
        public async Task<IActionResult> Index()
        {
            return View(await _context.Mainboards.ToListAsync());
        }

        // GET: Mainboards/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var mainboard = await _context.Mainboards
                .FirstOrDefaultAsync(m => m.ID == id);
            if (mainboard == null)
            {
                return NotFound();
            }

            return View(mainboard);
        }

        // GET: Mainboards/Create
        public IActionResult Create()
        {
            Injection();
            Mainboard model = new Mainboard();
          
            return View(model);
        }

        // POST: Mainboards/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("MBChipClass,MBAMDChip,MBCPUType,MBIntegration,MBIntegrations,MBDisplayOut,MBDisplayOuts,MBDPCIE,MBDPICCount,MBSuitable,MBType,MBCase,ID,Brand,Name,Value,HardWareEnum,Imgurl")] Mainboard mainboard)
        {
            if (ModelState.IsValid)
            {
                _context.Add(mainboard);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(mainboard);
        }
        private bool Injection()
        {

            ViewData["EnumMBBrand"] = new SelectList(EnumInfo.GetInstace().EnumMBBrand, "Value", "Value");

            ViewData["EnumMBIntelChip"] = new SelectList(EnumInfo.GetInstace().EnumMBIntelChip, "Value", "Value");
            ViewData["EnumMBAMDChip"] = new SelectList(EnumInfo.GetInstace().EnumMBAMDChip, "Value", "Value");
            ViewData["EnumMBChips"] = new SelectList(EnumInfo.GetInstace().EnumMBIntelChip, "Value", "Value");
            Dictionary<string, string> dic = new Dictionary<string, string>() { };
            dic.Add("Intel芯片", "EnumMBIntelChip");
            dic.Add("AMD芯片", "EnumMBAMDChip");
            ViewData["EnumMBChipClass"] = new SelectList(dic, "Value", "Key");
            ViewData["EnumMBCPUType"] = new SelectList(EnumInfo.GetInstace().EnumMBCPUType, "Value", "Value");

          //  var tests = new SelectList(EnumInfo.GetInstace().EnumMBIntegration.AsEnumerable(), "Value", "Value");
            ViewData["EnumMBIntegration"] = new SelectList(EnumInfo.GetInstace().EnumMBIntegration, "Value", "Value");
            ViewData["EnumMBDisplayOut"] = new SelectList(EnumInfo.GetInstace().EnumMBDisplayOut, "Value", "Value");
            ViewData["EnumMBDPCIE"] = new SelectList(EnumInfo.GetInstace().EnumMBDPCIE, "Value", "Value");
            ViewData["EnumMBDPICCount"] = new SelectList(EnumInfo.GetInstace().EnumMBDPICCount, "Value", "Value");
            ViewData["EnumMBSuitable"] = new SelectList(EnumInfo.GetInstace().EnumMBSuitable, "Value", "Value");
            ViewData["EnumMBType"] = new SelectList(EnumInfo.GetInstace().EnumMBType, "Value", "Value");
            ViewData["EnumMBCase"] = new SelectList(EnumInfo.GetInstace().EnumMBCase, "Value", "Value");
            ViewData["EnumMBBrand"] = new SelectList(EnumInfo.GetInstace().EnumMBBrand, "Value", "Value");


            return true;
        }
        private bool Injection(Mainboard model)
        {

            ViewData["EnumMBBrand"] = new SelectList(EnumInfo.GetInstace().EnumMBBrand, "Value", "Value",model.Brand);

            ViewData["EnumMBIntelChip"] = new SelectList(EnumInfo.GetInstace().EnumMBIntelChip, "Value", "Value");
            ViewData["EnumMBAMDChip"] = new SelectList(EnumInfo.GetInstace().EnumMBAMDChip, "Value", "Value");
            //List<string> chiptype = new List<string>();
            //chiptype.Add("Intel芯片");
            //chiptype.Add("AMD芯片");
            ViewData["EnumMBChips"] = new SelectList(EnumInfo.GetInstace().EnumMBIntelChip, "Value", "Value",model.MBAMDChip);
            Dictionary<string, string> dic = new Dictionary<string, string>() { };
            dic.Add("Intel芯片", "EnumMBIntelChip");
            dic.Add("AMD芯片", "EnumMBAMDChip");
            ViewData["EnumMBChipClass"] = new SelectList(dic, "Value", "Key", model.MBChipClass);
            ViewData["EnumMBCPUType"] = new SelectList(EnumInfo.GetInstace().EnumMBCPUType, "Value", "Value", model.MBCPUType);
            ViewData["EnumMBIntegration"] = new SelectList(EnumInfo.GetInstace().EnumMBIntegration, "Value", "Value",model.MBIntegration);
            ViewData["EnumMBDisplayOut"] = new SelectList(EnumInfo.GetInstace().EnumMBDisplayOut, "Value", "Value",model.MBDisplayOut);
            ViewData["EnumMBDPCIE"] = new SelectList(EnumInfo.GetInstace().EnumMBDPCIE, "Value", "Value",model.MBDPCIE);
            ViewData["EnumMBDPICCount"] = new SelectList(EnumInfo.GetInstace().EnumMBDPICCount, "Value", "Value",model.MBDPICCount);
            ViewData["EnumMBSuitable"] = new SelectList(EnumInfo.GetInstace().EnumMBSuitable, "Value", "Value",model.MBSuitable);
            ViewData["EnumMBType"] = new SelectList(EnumInfo.GetInstace().EnumMBType, "Value", "Value",model.MBType);
            ViewData["EnumMBCase"] = new SelectList(EnumInfo.GetInstace().EnumMBCase, "Value", "Value",model.MBCase);
            ViewData["EnumMBBrand"] = new SelectList(EnumInfo.GetInstace().EnumMBBrand, "Value", "Value",model.Brand);


            return true;
        }
        // GET: Mainboards/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var mainboard = await _context.Mainboards.FindAsync(id);
            if (mainboard == null)
            {
                return NotFound();
            }
            Injection(mainboard);
            return View(mainboard);
        }

        // POST: Mainboards/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("MBChipClass,MBAMDChip,MBCPUType,MBIntegration,MBIntegrations，MBDisplayOut,MBDisplayOuts,MBDPCIE,MBDPICCount,MBSuitable,MBType,MBCase,ID,Brand,Name,Value,HardWareEnum,Imgurl")] Mainboard mainboard)
        {
            if (id != mainboard.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(mainboard);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MainboardExists(mainboard.ID))
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
            return View(mainboard);
        }

        // GET: Mainboards/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var mainboard = await _context.Mainboards
                .FirstOrDefaultAsync(m => m.ID == id);
            if (mainboard == null)
            {
                return NotFound();
            }

            return View(mainboard);
        }

        // POST: Mainboards/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var mainboard = await _context.Mainboards.FindAsync(id);
            _context.Mainboards.Remove(mainboard);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MainboardExists(int id)
        {
            return _context.Mainboards.Any(e => e.ID == id);
        }
    }
}
