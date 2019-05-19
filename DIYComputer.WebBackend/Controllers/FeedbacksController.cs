using DIYComputer.Entity.DBContext;
using DIYComputer.Entity.SysEntity;
using DIYComputer.Util;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace DIYComputer.WebBackend.Controllers
{
    [Authorize(Policy = "Admin")]
   
    public class FeedbacksController : Controller
    {
        private readonly EFDBContext _context;

        public FeedbacksController(EFDBContext context)
        {
            _context = context;
        }

        // GET: Feedbacks
        public async Task<IActionResult> Index()
        {
            var modellist = await _context.Feedbacks.ToListAsync();
         
            return View(modellist);
        }


        // GET: Feedbacks/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var feedback = await _context.Feedbacks
                .FirstOrDefaultAsync(m => m.Id == id);
            if (feedback == null)
            {
                return NotFound();
            }

            return View(feedback);
        }

        
        public async Task<IActionResult> PostOK(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var feedback = await _context.Feedbacks
                .FirstOrDefaultAsync(m => m.Id == id);


            if (feedback == null)
            {
                return NotFound("未找到相关信息");
            }

            feedback.Ishandle = "已处理";
            _context.Update(feedback);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        // GET: Feedbacks/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Feedbacks/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [AllowAnonymous]
        public async Task<JsonResult> Create([Bind("FeedContent,Ishandle,PostMan,Id,CreateTime,EditTime,Remarks")] Feedback feedback)
        {
          
                _context.Add(feedback);
                await _context.SaveChangesAsync();

            return Json(ResultToJson.GetJsonResult("提交成功"));
        
        }

      

        // GET: Feedbacks/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var feedback = await _context.Feedbacks
                .FirstOrDefaultAsync(m => m.Id == id);
            if (feedback == null)
            {
                return NotFound();
            }

            return View(feedback);
        }

        // POST: Feedbacks/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var feedback = await _context.Feedbacks.FindAsync(id);
            _context.Feedbacks.Remove(feedback);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool FeedbackExists(int id)
        {
            return _context.Feedbacks.Where(o=>o.Id==id).Count()>0?true:false;
        }
    }
}
