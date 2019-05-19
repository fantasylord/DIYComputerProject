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
    public class DisplaysController : Controller
    {
        private readonly EFDBContext _context;

        public DisplaysController(EFDBContext context)
        {
            _context = context;
        }

        // GET: Displays
        public async Task<IActionResult> Index()
        {
            return View(await _context.Displays.ToListAsync());
        }

        // GET: Displays/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var display = await _context.Displays
                .FirstOrDefaultAsync(m => m.ID == id);
            if (display == null)
            {
                return NotFound();
            }

            return View(display);
        }

        // GET: Displays/Create
        public IActionResult Create()
        {
            Injection();
            return View();
        }
        private bool Injection()
        {

            ViewData["EnumDisplayBrand"] = new SelectList(EnumInfo.GetInstace().EnumDisplayBrand, "Value", "Value");

            ViewData["EnumDisplaySize"] = new SelectList(EnumInfo.GetInstace().EnumDisplaySize, "Value", "Value");
            ViewData["EnumDisplayInputType"] = new SelectList(EnumInfo.GetInstace().EnumDisplayInputType, "Value", "Value");
            ViewData["EnumDisplayOtherFunction"] = new SelectList(EnumInfo.GetInstace().EnumDisplayOtherFunction, "Value", "Value");
            ViewData["EnumDisplayUseWay"] = new SelectList(EnumInfo.GetInstace().EnumDisplayUseWay, "Value", "Value");

            //  var tests = new SelectList(EnumInfo.GetInstace().EnumMBIntegration.AsEnumerable(), "Value", "Value");
            ViewData["EnumDisplayColor"] = new SelectList(EnumInfo.GetInstace().EnumDisplayColor, "Value", "Value");
            ViewData["EnumDisplayBackLED"] = new SelectList(EnumInfo.GetInstace().EnumDisplayBackLED, "Value", "Value");
            ViewData["EnumDisplayBoard"] = new SelectList(EnumInfo.GetInstace().EnumDisplayBoard, "Value", "Value");
            ViewData["EnumDisplayVisualAngle"] = new SelectList(EnumInfo.GetInstace().EnumDisplayVisualAngle, "Value", "Value");
            ViewData["EnumDisplayLuminance"] = new SelectList(EnumInfo.GetInstace().EnumDisplayLuminance, "Value", "Value");
            ViewData["EnumDisplayDpi"] = new SelectList(EnumInfo.GetInstace().EnumDisplayDpi, "Value", "Value");
            ViewData["EnumDisplayDotPitch"] = new SelectList(EnumInfo.GetInstace().EnumDisplayDotPitch, "Value", "Value");
            ViewData["EnumDisplayRatio"] = new SelectList(EnumInfo.GetInstace().EnumDisplayRatio, "Value", "Value");


            return true;
        }
        private bool Injection(Display model)
        {

            ViewData["EnumDisplayBrand"] = new SelectList(EnumInfo.GetInstace().EnumDisplayBrand, "Value", "Value",model.Brand);

            ViewData["EnumDisplaySize"] = new SelectList(EnumInfo.GetInstace().EnumDisplaySize, "Value", "Value",model.DisplaySize);
            ViewData["EnumDisplayInputType"] = new SelectList(EnumInfo.GetInstace().EnumDisplayInputType, "Value", "Value",model.DisplayInputType);
            ViewData["EnumDisplayOtherFunction"] = new SelectList(EnumInfo.GetInstace().EnumDisplayOtherFunction, "Value", "Value",model.DisplayOtherFunction);
            ViewData["EnumDisplayUseWay"] = new SelectList(EnumInfo.GetInstace().EnumDisplayUseWay, "Value", "Value",model.DisplayUseWay);

            //  var tests = new SelectList(EnumInfo.GetInstace().EnumMBIntegration.AsEnumerable(), "Value", "Value");
            ViewData["EnumDisplayColor"] = new SelectList(EnumInfo.GetInstace().EnumDisplayColor, "Value", "Value",model.DisplayColor);
            ViewData["EnumDisplayBackLED"] = new SelectList(EnumInfo.GetInstace().EnumDisplayBackLED, "Value", "Value",model.DisplayBackLED);
            ViewData["EnumDisplayBoard"] = new SelectList(EnumInfo.GetInstace().EnumDisplayBoard, "Value", "Value",model.DisplayBoard);
            ViewData["EnumDisplayVisualAngle"] = new SelectList(EnumInfo.GetInstace().EnumDisplayVisualAngle, "Value", "Value",model.DisplayVisualAngle);
            ViewData["EnumDisplayLuminance"] = new SelectList(EnumInfo.GetInstace().EnumDisplayLuminance, "Value", "Value",model.DisplayLuminance);
            ViewData["EnumDisplayDpi"] = new SelectList(EnumInfo.GetInstace().EnumDisplayDpi, "Value", "Value",model.DisplayDpi);
            ViewData["EnumDisplayDotPitch"] = new SelectList(EnumInfo.GetInstace().EnumDisplayDotPitch, "Value", "Value",model.DisplayDotPitch);
            ViewData["EnumDisplayRatio"] = new SelectList(EnumInfo.GetInstace().EnumDisplayRatio, "Value", "Value",model.DisplayRatio);


            return true;
        }
        // POST: Displays/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("DisplaySize,DisplayInputType,DisplayInputTypes,DisplayOtherFunction,DisplayOtherFunctions,DisplayUseWay,DisplayColor,DisplayColorsDisplayBackLED,DisplayBoard,DisplayVisualAngle,DisplayLuminance,DisplayDpi,DisplayDotPitch,DisplayRatio,ID,Brand,Name,Value,Imgurl")] Display display)
        {
            if (ModelState.IsValid)
            {
                _context.Add(display);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            Injection(display);
            return View(display);
        }

        // GET: Displays/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var display = await _context.Displays.FindAsync(id);
            if (display == null)
            {
                return NotFound();
            }
            Injection(display);

            return View(display);
        }

        // POST: Displays/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("DisplaySize,DisplayInputType,DisplayInputTypes,DisplayOtherFunction,DisplayOtherFunctions,DisplayUseWay,DisplayColor,DisplayColors,DisplayBackLED,DisplayBoard,DisplayVisualAngle,DisplayLuminance,DisplayDpi,DisplayDotPitch,DisplayRatio,ID,Brand,Name,Value,Imgurl")] Display display)
        {
            if (id != display.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(display);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DisplayExists(display.ID))
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
            return View(display);
        }

        // GET: Displays/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var display = await _context.Displays
                .FirstOrDefaultAsync(m => m.ID == id);
            if (display == null)
            {
                return NotFound();
            }

            return View(display);
        }

        // POST: Displays/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var display = await _context.Displays.FindAsync(id);
            _context.Displays.Remove(display);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DisplayExists(int id)
        {
            return _context.Displays.Any(e => e.ID == id);
        }
    }
}
