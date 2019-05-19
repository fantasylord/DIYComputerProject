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
    [Authorize(Policy = "Admin")]
    public class TopicClassController : Controller
    {
        private readonly EFDBContext _context;

        public TopicClassController(EFDBContext context)
        {
            _context = context;
        }

        // GET: TopicClass
        public async Task<IActionResult> Index()
        {
            var eFDBContext = _context.TopicClasses.Include(t => t.ParentNode);
            return View(await eFDBContext.ToListAsync());
        }

        // GET: TopicClass/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var topicClass = await _context.TopicClasses
                .Include(t => t.ParentNode)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (topicClass == null)
            {
                return NotFound();
            }

            return View(topicClass);
        }

        // GET: TopicClass/Create
        public IActionResult Create()
        {
            ViewData["ParentNodeId"] = new SelectList(_context.TopicClasses, "Id", "Name");
            return View();
        }

        // POST: TopicClass/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Name,ParentNodeId,Id")] TopicClass topicClass)
        {
            if (ModelState.IsValid)
            {
                _context.Add(topicClass);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ParentNodeId"] = new SelectList(_context.TopicClasses, "Id", "Name", topicClass.ParentNodeId);
            return View(topicClass);
        }

        // GET: TopicClass/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var topicClass = await _context.TopicClasses.FindAsync(id);
            if (topicClass == null)
            {
                return NotFound();
            }
            ViewData["ParentNodeId"] = new SelectList(_context.TopicClasses, "Id", "Name", topicClass.ParentNodeId);
            return View(topicClass);
        }

        // POST: TopicClass/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Name,ParentNodeId,Id")] TopicClass topicClass)
        {
            if (id != topicClass.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(topicClass);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TopicClassExists(topicClass.Id))
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
            ViewData["ParentNodeId"] = new SelectList(_context.TopicClasses, "Id", "Name", topicClass.ParentNodeId);
            return View(topicClass);
        }

        // GET: TopicClass/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var topicClass = await _context.TopicClasses
                .Include(t => t.ParentNode)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (topicClass == null)
            {
                return NotFound();
            }

            return View(topicClass);
        }

        // POST: TopicClass/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var topicClass = await _context.TopicClasses.FindAsync(id);
            _context.TopicClasses.Remove(topicClass);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TopicClassExists(int id)
        {
            return _context.TopicClasses.Where(e => e.Id == id).Count()>0?true:false;
        }
    }
}
