 
using DIYComputer.DtoModel.SysDto;
using DIYComputer.Entity.DBContext;
using DIYComputer.Entity.SysEntity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DIYComputer.WebFrontend.Controllers.UserDo
{
    [Authorize(Policy = "User")]
    [Route("Client/[Controller]")]
    public class RepliesController : Controller
    {
        private readonly EFDBContext _context;
        private readonly IHttpContextAccessor _accessor;
        public RepliesController(EFDBContext context, IHttpContextAccessor accessor)
        {
            _context = context;
            _accessor = accessor;
        }

        [HttpGet]
        // GET: Replies
        public async Task<IActionResult> Index()
        {
            var user = UsersController.GetUser(_context, _accessor);
            var dbmodel = await _context.Reply.ToListAsync();
            List<ReplyDisplay> redtomodel = new List<ReplyDisplay>();
            foreach (var item in dbmodel)
            {
                Topic topic = _context.Topics.FirstOrDefault(o => o.Id == item.TopicId);
                redtomodel.Add(new ReplyDisplay()
                {
                    Content=item.Content,
                    CreateTime=item.CreateTime,
                    EditTime=item.EditTime,
                    Id=item.Id,
                    Remarks=item.Remarks,
                    Topic=item.Topic,
                    UserAccount=item.User.Account,
                    UserName=item.User.Name,
                    TopicId=item.Topic.Id,
                    TopicTitle=item.Topic.Title,
                });

            }
            return View(  redtomodel );
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
        public IActionResult Create(int topicid = 0)
        {
            if (topicid > 0 && _context.Topics.Where(o => o.Id == topicid).Count() > 0)
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
        public async Task<IActionResult> Create([Bind("Content,Id,TopicId")] Reply reply)
        {

            if (ModelState.IsValid)
            {
                reply.User = UsersController.GetUser(_context, _accessor);
                reply.UserId = reply.User.Id;
                reply.Topic = _context.Topics.Find(reply.TopicId);
                reply.IP = HttpContext.Connection.RemoteIpAddress.ToString();

                _context.Add(reply);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(reply);
        }


        [HttpPost]
        [Route("ReplieForID")]
        public async Task<IActionResult> ReplieForID(string Rcontent="", int Id=-1)
        {

            Reply reply = new Reply();
            var retopic = _context.Topics.FirstOrDefault(o => o.Id == Id);
            User user= UsersController.GetUser(_context, _accessor);
            if (user!=null&&retopic!=null)
            {
                reply.User =user;
                reply.UserId = reply.User.Id;
                reply.Topic = retopic;
                reply.TopicId = retopic.Id;
                reply.Content = Rcontent;
                reply.IP = HttpContext.Connection.RemoteIpAddress.ToString();
                _context.Add(reply);
                await _context.SaveChangesAsync();
                return RedirectToAction("TopicDetails","Topics", new {id=reply.TopicId});
            }
            return View(nameof(Index));
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
        public async Task<IActionResult> Edit(int id, [Bind("Content,Remarks")] Reply reply)
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
