using DIYComputer.Entity.DBContext;
using DIYComputer.Entity.SysEntity;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace DIYComputer.WebBackend.Controllers
{
    public class RepliesController : Controller
    {
        private readonly EFDBContext _context;
        private readonly IHttpContextAccessor _accessor;
        public RepliesController(EFDBContext context,IHttpContextAccessor accessor)
        {
            _context = context;
            _accessor = accessor;
        }

        // GET: Replies
        public async Task<IActionResult> Index()
        {

            return View(await _context.Reply.ToListAsync());
          //  return View(await _context.Reply.Where(o=>o.User.Account.Equals(UsersController.GetUser(_context, _accessor).Account)).ToListAsync());
        }

        // GET: Replies/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var reply = await _context.Reply
                .FirstOrDefaultAsync(m => m.Id == id);
            if (reply == null)
            {
                return NotFound();
            }

            return View(reply);
        }

        // GET: Replies/Create
        public IActionResult Create(int topicid=0)
        {
            if (topicid>0&&_context.Topics.Where(o => o.Id == topicid).Count() > 0)
            {

                Reply model = new Reply
                {
                    User = UsersController.GetUser(_context, _accessor),
                    Topic = _context.Topics.Find(topicid),
                   
                    
                };
                model.TopicId = model.Topic.TopicClassId;
                return View(model);



            }
            return View();
           
        }

        // POST: Replies/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Content,IP,Id,CreateTime,EditTime,Remarks,TopicId")] Reply reply)
        {
            reply.User = UsersController.GetUser(_context,_accessor);
            reply.Topic = _context.Topics.Find(reply.TopicId);
            
            if (ModelState.IsValid)
            {
                _context.Add(reply);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(reply);
        }

        // GET: Replies/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var reply = await _context.Reply.FindAsync(id);
            if (reply == null)
            {
                return NotFound();
            }
            return View(reply);
        }

        // POST: Replies/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Content,IP,Id,CreateTime,EditTime,Remarks")] Reply reply)
        {
            if (id != reply.Id)
            {
                return NotFound();
            }
            reply.User = UsersController.GetUser(_context, _accessor);
            reply.Topic = _context.Topics.Find(reply.TopicId);


            var dbmodel = _context.Reply.Find(reply.Id);
            if (ModelState.IsValid)
            {
                try
                {
                    dbmodel.Content = reply.Content;
                    dbmodel.IP = reply.IP;
                    dbmodel.EditTime = DateTime.Now;
                    dbmodel.Remarks = reply.Remarks;
                    _context.Update(dbmodel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ReplyExists(reply.Id))
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
            return View(reply);
        }

        // GET: Replies/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var reply = await _context.Reply
                .FirstOrDefaultAsync(m => m.Id == id);
            if (reply == null)
            {
                return NotFound();
            }

            return View(reply);
        }

        // POST: Replies/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var reply = await _context.Reply.FindAsync(id);
            _context.Reply.Remove(reply);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ReplyExists(int id)
        {
            return _context.Reply.Any(e => e.Id == id);
        }
    }
}
