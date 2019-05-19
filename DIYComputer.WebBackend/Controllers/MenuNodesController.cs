using DIYComputer.Config.StaticSource;
using DIYComputer.Entity.ComputerWareEntity;
using DIYComputer.Entity.DBContext;
using DIYComputer.Entity.SysEntity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;
namespace DIYComputer.WebBackend.Controllers
{
    public class MenuNodesController : Controller
    {
        private readonly EFDBContext _context;

        public MenuNodesController(EFDBContext context)
        {
            _context = context;
        }

        // GET: MenuNodes
        public async Task<IActionResult> Index()
        {
            var eFDBContext = _context.MenuNodes.Include(m => m.ParentNode);
            return View(await eFDBContext.ToListAsync());
        }

        // GET: MenuNodes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var menuNode = await _context.MenuNodes
                .Include(m => m.ParentNode)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (menuNode == null)
            {
                return NotFound();
            }

            return View(menuNode);
        }

        // GET: MenuNodes/Create
        public IActionResult Create()
        {
            ViewData["ParentNodeId"] = new SelectList(_context.MenuNodes, "Id", "Name");
    
            return View();
        }

        // POST: MenuNodes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Name,ParentNodeId,Area,Action,Id")] MenuNode menuNode)
        {
            if (ModelState.IsValid)
            {
                _context.Add(menuNode);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ParentNodeId"] = new SelectList(_context.MenuNodes, "Id", "Name", menuNode.ParentNodeId);
            return View(menuNode);
        }

        // GET: MenuNodes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var menuNode = await _context.MenuNodes.FindAsync(id);
            if (menuNode == null)
            {
                return NotFound();
            }
            ViewData["ParentNodeId"] = new SelectList(_context.MenuNodes, "Id", "Name", menuNode.ParentNodeId);
            return View(menuNode);
        }

        // POST: MenuNodes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Name,ParentNodeId,Area,Action,Id")] MenuNode menuNode)
        {
            if (id != menuNode.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(menuNode);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MenuNodeExists(menuNode.Id))
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
 
            return View(menuNode);
        }

        // GET: MenuNodes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var menuNode = await _context.MenuNodes
                .Include(m => m.ParentNode)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (menuNode == null)
            {
                return NotFound();
            }

            return View(menuNode);
        }

        // POST: MenuNodes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var menuNode = await _context.MenuNodes.FindAsync(id);
            _context.MenuNodes.Remove(menuNode);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MenuNodeExists(int id)
        {
            return _context.MenuNodes.Any(e => e.Id == id);
        }
    }
}
