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
    public class GraphyicsController : Controller
    {
        private readonly EFDBContext _context;

        public GraphyicsController(EFDBContext context)
        {
            _context = context;
        }

        // GET: Graphyics
        public async Task<IActionResult> Index()
        {
            return View(await _context.Graphyics.ToListAsync());
        }

        // GET: Graphyics/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var graphyic = await _context.Graphyics
                .FirstOrDefaultAsync(m => m.ID == id);
            if (graphyic == null)
            {
                return NotFound();
            }

            return View(graphyic);
        }
        private bool Injection()
        {

            ViewData["EnumGraphicsAMD"] = new SelectList(EnumInfo.GetInstace().EnumGraphicsAMD, "Value", "Value");
            ViewData["EnumGraphicsBits"] = new SelectList(EnumInfo.GetInstace().EnumGraphicsBits, "Value", "Value");
            ViewData["EnumGraphicsBrand"] = new SelectList(EnumInfo.GetInstace().EnumGraphicsBrand, "Value", "Value");
            ViewData["EnumGraphicsCapacity"] = new SelectList(EnumInfo.GetInstace().EnumGraphicsCapacity, "Value", "Value");
            ViewData["EnumGraphicsCase"] = new SelectList(EnumInfo.GetInstace().EnumGraphicsCase, "Value", "Value");
            ViewData["EnumGraphicsClass"] = new SelectList(EnumInfo.GetInstace().EnumGraphicsClass, "Value", "Value");
            ViewData["EnumGraphicsInterface"] = new SelectList(EnumInfo.GetInstace().EnumGraphicsInterface, "Value", "Value");
            Dictionary<string, string>  graphydics = new Dictionary<string, string>() { };
            graphydics.Add("AMD", "EnumGraphicsAMD");
            graphydics.Add("NIVDA", "EnumGraphicsNIVDA");
            graphydics.Add("专业级图像显卡", "EnumGraphicsOther");
            ViewData["EnumGraphicFactory"] = new SelectList(graphydics, "Value", "Key");
            ViewData["EnumGraphicsNIVDA"] = new SelectList(EnumInfo.GetInstace().EnumGraphicsNIVDA, "Value", "Value");
            ViewData["EnumGraphicsOther"] = new SelectList(EnumInfo.GetInstace().EnumGraphicsOther, "Value", "Value");
            return true;
        }
        private bool Injection(Graphyic model)
        {

            ViewData["EnumGraphicsAMD"] = new SelectList(EnumInfo.GetInstace().EnumGraphicsAMD, "Value", "Value", model.GraphicType);
            ViewData["EnumGraphicsBits"] = new SelectList(EnumInfo.GetInstace().EnumGraphicsBits, "Value", "Value", model.GraphicsBits);
            ViewData["EnumGraphicsBrand"] = new SelectList(EnumInfo.GetInstace().EnumGraphicsBrand, "Value", "Value", model.Brand);
            ViewData["EnumGraphicsCapacity"] = new SelectList(EnumInfo.GetInstace().EnumGraphicsCapacity, "Value", "Value", model.GraphicsCapacity);
            ViewData["EnumGraphicsCase"] = new SelectList(EnumInfo.GetInstace().EnumGraphicsCase, "Value", "Value", model.GraphicsCase);
            ViewData["EnumGraphicsClass"] = new SelectList(EnumInfo.GetInstace().EnumGraphicsClass, "Value", "Value", model.GraphicsClass);
            ViewData["EnumGraphicsInterface"] = new SelectList(EnumInfo.GetInstace().EnumGraphicsInterface, "Value", "Value", model.GraphicsInterface);
            var graphydics = new Dictionary<string, string>() { };
            graphydics.Add("AMD", "EnumGraphicsAMD");
            graphydics.Add("NIVDA", "EnumGraphicsNIVDA");
            graphydics.Add("专业级图像显卡", "EnumGraphicsOther");
            ViewData["EnumGraphicFactory"] = new SelectList(graphydics, "Value", "Key");
            ViewData["EnumGraphicsNIVDA"] = new SelectList(EnumInfo.GetInstace().EnumGraphicsNIVDA, "Value", "Value", model.GraphicType);
            ViewData["EnumGraphicsOther"] = new SelectList(EnumInfo.GetInstace().EnumGraphicsOther, "Value", "Value", model.GraphicType);
            return true;
        }
        // GET: Graphyics/Create
        public IActionResult Create()
        {
            Injection();
          
            return View();
        }

        // POST: Graphyics/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("GraphicFactory,GraphicType,GraphicsCapacity,GraphicsBits,GraphicsInterface,EnumGraphicsInterfaces,GraphicsClass,GraphicsCase,ID,Brand,Name,Value,HardWareEnum,Imgurl")] Graphyic graphyic)
        {
            if (ModelState.IsValid)
            {
                _context.Add(graphyic);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            Injection(graphyic);
            return View(graphyic);
        }

        // GET: Graphyics/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var graphyic = await _context.Graphyics.FindAsync(id);
            if (graphyic == null)
            {
                return NotFound();
            }
            Injection(graphyic);
            return View(graphyic);
        }

        // POST: Graphyics/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("GraphicFactory,GraphicType,GraphicsCapacity,GraphicsBits,GraphicsInterface,EnumGraphicsInterfaces,GraphicsClass,GraphicsCase,ID,Brand,Name,Value,HardWareEnum,Imgurl")] Graphyic graphyic)
        {
            if (id != graphyic.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(graphyic);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!GraphyicExists(graphyic.ID))
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
            return View(graphyic);
        }

        // GET: Graphyics/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var graphyic = await _context.Graphyics
                .FirstOrDefaultAsync(m => m.ID == id);
            if (graphyic == null)
            {
                return NotFound();
            }

            return View(graphyic);
        }

        // POST: Graphyics/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var graphyic = await _context.Graphyics.FindAsync(id);
            _context.Graphyics.Remove(graphyic);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool GraphyicExists(int id)
        {
            return _context.Graphyics.Any(e => e.ID == id);
        }
    }
}
