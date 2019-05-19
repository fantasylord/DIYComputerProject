using AutoMapper;
using DIYComputer.Config.ServiceConfig;
using DIYComputer.DtoModel.SysDto;
using DIYComputer.Entity.DBContext;
using DIYComputer.Entity.SysEntity;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static DIYComputer.Util.FileUpHelper.FileStreamPandO;

namespace DIYComputer.WebBackend.Controllers
{


    public class TopicsByUserController : Controller
    {


        private readonly IHttpContextAccessor _accessor;
        private readonly EFDBContext _dbcontext;
        private readonly IMapper _mapper;

        public TopicsByUserController(EFDBContext context, 
                                IHttpContextAccessor accessor,
                                [FromServices]IMapper mapper)
        {
            _dbcontext = context;
            _accessor = accessor;
            _mapper = mapper;
        }

        // GET: Topics
      
        public async Task<ActionResult> Index()
        {
            List<Topic> list = new List<Topic>();
            foreach (var item in await _dbcontext.Topics.ToListAsync())
            {
                list.Add(item);
            }
            var modellist = _mapper.Map<List<TopicListModel>>(list);
            return View(modellist);
        }

        // GET: Topics/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var topic = await _dbcontext.Topics
                .FirstOrDefaultAsync(m => m.Id == id);
            if (topic == null)
            {
                return NotFound();
            }

            return View(topic);
        }

        // GET: Topics/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Topics/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Title,ContentURL,CreateTime,EditTime,IP,Id,Remarks")] Topic topic)
        {
            if (ModelState.IsValid)
            {
                _dbcontext.Add(topic);
                await _dbcontext.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(topic);
        }

        // GET: Topics/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var topic = await _dbcontext.Topics.FindAsync(id);
            if (topic == null)
            {
                return NotFound();
            }
            return View(topic);
        }

        // POST: Topics/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Title,ContentURL,CreateTime,EditTime,IP,Id,Remarks")] Topic topic)
        {
            if (id>0&& id != topic.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    var dbmodel = _dbcontext.Topics.Find(id);
                    dbmodel.Title = topic.Title;
                    dbmodel.ContentURL = topic.ContentURL;
                    dbmodel.CreateTime = topic.CreateTime;
                    dbmodel.Remarks = topic.Remarks;
                    //dbmodel.User = UsersController.GetUser();
                    _dbcontext.Update(dbmodel);
                    await _dbcontext.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TopicExists(topic.Id))
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
            return View(topic);
        }

        // GET: Topics/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var topic = await _dbcontext.Topics
                .FirstOrDefaultAsync(m => m.Id == id);
            if (topic == null)
            {
                return NotFound();
            }

            return View(topic);
        }

        // POST: Topics/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }


        [Route("CreateTopic")]
        [HttpGet]
        public IActionResult CreateTopic()
        {

            return View(new Topic());
        }
        [Route("CreateTopic")]
        [HttpPost]
        public async Task<IActionResult> CreateTopic(Topic topic = null)
        {
            var claimsPrincipal = HttpContext.User;
            string accountID = claimsPrincipal.Claims.Where(o => o.Type == "ID").Count() > 0 ?
                claimsPrincipal.Claims.Where(o => o.Type.ToUpper() == "ID".ToUpper()).FirstOrDefault().Value.ToString() : "";
            int a_id = int.Parse(accountID);
            
  
                topic.User = await _dbcontext.Users.FindAsync(a_id);
                topic.IP = _accessor.HttpContext.Connection.RemoteIpAddress.ToString();
                topic.CreateTime = System.DateTime.Now;
                topic.EditTime = System.DateTime.Now;
                FilesPrint fp = new FilesPrint();
                topic.ContentURL = await fp.PrintFileCreate(ServiceConfig.wwwrootDirectory, ServiceConfig.HtmlUpDirectory, topic.htmlstr);
                if (!string.IsNullOrEmpty(topic.ContentURL))
                    _dbcontext.Add(topic);
                else
                    return StatusCode(505, "添加文件失败");
                if (_dbcontext.SaveChanges() > 0)
                    return Ok();
 
            return NoContent();
        }


        [Route("UserEditorTopic")]
        public IActionResult EditorTopic(int Id = 0)
        {
            var claimsPrincipal = HttpContext.User;
            string accountID = claimsPrincipal.Claims.Where(o => o.Type == "ID").Count() > 0 ?
                claimsPrincipal.Claims.Where(o => o.Type.ToUpper() == "ID".ToUpper()).FirstOrDefault().Value.ToString() : "";


            if (!string.IsNullOrEmpty(accountID))
            {
                int a_id = int.Parse(accountID);
                Topic datamodel = _dbcontext.Topics.Where(o => o.Id == Id).FirstOrDefault();
                FilesPrint fp = new FilesPrint();

                if (datamodel != null &&
                    datamodel.UserId > 0)
                {
                    if (_dbcontext.Users.Where(m => m.Id == datamodel.UserId).DefaultIfEmpty() == null)
                        return RedirectToAction("index");
                    datamodel.User = _dbcontext.Users.Find(datamodel.UserId);
                    TopicContentModel remodel = new TopicContentModel()
                    {
                        Id = Id,
                        ContentURL = datamodel.ContentURL,
                        CreateTime = datamodel.CreateTime,
                        Remarks = datamodel.Remarks,
                        IP = datamodel.IP,

                        TopicClassID = Id,
                        UserID = datamodel.UserId,
                        Account = datamodel.User.Account,
                        Title = datamodel.Title
                    };
                    remodel.htmlstr = fp.ReadFileByStr(ServiceConfig.wwwrootDirectory + datamodel.ContentURL);
                    return View(remodel);
                }


            }

            return BadRequest();
        }

        [Route("UserEditorTopic")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditorTopic(int Id = 0, TopicContentModel datamodel = null)
        {
            
            if (datamodel != null &&
                     datamodel.UserID > 0)
            {
                var claimsPrincipal = HttpContext.User;
                string accountID = claimsPrincipal.Claims.Where(o => o.Type == "ID").Count() > 0 ?
                    claimsPrincipal.Claims.Where(o => o.Type.ToUpper() == "ID".ToUpper()).FirstOrDefault().Value.ToString() : "";


                Topic model = new Topic()
                {
                    Id = Id,
                    ContentURL = datamodel.ContentURL,
                    UserId = datamodel.UserID,
                    Remarks = datamodel.Remarks,
                    IP = datamodel.IP,
                    TopicClassId = datamodel.TopicClassID,
                    TopicClass = _dbcontext.TopicClasses.Where(o => o.Id == datamodel.TopicClassID).FirstOrDefault(),
                    User = _dbcontext.Users.Where(o => o.Id == datamodel.UserID).FirstOrDefault(),
                    Title = datamodel.Title,
                    htmlstr = datamodel.htmlstr,

                };
                FilesPrint fp = new FilesPrint();
                model.ContentURL = await fp.PrintFileCreate(ServiceConfig.wwwrootDirectory, ServiceConfig.HtmlUpDirectory, model.htmlstr);
                if (!string.IsNullOrEmpty(model.ContentURL))
                    _dbcontext.Update(model);
                else
                    return StatusCode(505, "添加文件失败");
                if (_dbcontext.SaveChanges() > 0)
                    return Ok();


            }

            return RedirectToAction("EditorTopic");
        }


        [Route("UserCreateTopic")]
        [HttpGet]
        public IActionResult CreateUserTopic()
        {

            return View(new Topic());
        }
        [Route("UserCreateTopic")]
        [HttpPost]
        public async Task<IActionResult> CreateUserTopic(Topic topic = null)
        {
            var claimsPrincipal = HttpContext.User;
            string accountID = claimsPrincipal.Claims.Where(o => o.Type == "ID").Count() > 0 ?
                claimsPrincipal.Claims.Where(o => o.Type.ToUpper() == "ID".ToUpper()).FirstOrDefault().Value.ToString() : "";
            int a_id = int.Parse(accountID);


            topic.User = await _dbcontext.Users.FindAsync(a_id);
            topic.IP = _accessor.HttpContext.Connection.RemoteIpAddress.ToString();
            topic.CreateTime = System.DateTime.Now;
            topic.EditTime = System.DateTime.Now;
            FilesPrint fp = new FilesPrint();
            topic.ContentURL = await fp.PrintFileCreate(ServiceConfig.wwwrootDirectory, ServiceConfig.HtmlUpDirectory, topic.htmlstr);
            if (!string.IsNullOrEmpty(topic.ContentURL))
                _dbcontext.Add(topic);
            else
                return StatusCode(505, "添加文件失败");
            if (_dbcontext.SaveChanges() > 0)
                return Ok();

            return NoContent();
        }


        [Route("UserEditorTopic")]
        public IActionResult EditorUserTopic(int Id = 0)
        {
            var claimsPrincipal = HttpContext.User;
            string accountID = claimsPrincipal.Claims.Where(o => o.Type == "ID").Count() > 0 ?
                claimsPrincipal.Claims.Where(o => o.Type.ToUpper() == "ID".ToUpper()).FirstOrDefault().Value.ToString() : "";


            if (!string.IsNullOrEmpty(accountID))
            {
                int a_id = int.Parse(accountID);
                Topic datamodel = _dbcontext.Topics.Where(o => o.Id == Id).FirstOrDefault();

                if (datamodel != null &&
                    datamodel.UserId > 0)
                {
                    if (_dbcontext.Users.Where(m => m.Id == datamodel.UserId).DefaultIfEmpty() == null)
                        return RedirectToAction("index");
                    datamodel.User = _dbcontext.Users.Find(datamodel.UserId);
                    TopicContentModel remodel = new TopicContentModel()
                    {
                        Id = Id,
                        ContentURL = datamodel.ContentURL,
                        CreateTime = datamodel.CreateTime,
                        Remarks = datamodel.Remarks,
                        IP = datamodel.IP,

                        TopicClassID = datamodel.TopicClass.Id,
                        UserID = datamodel.UserId,
                        Account = datamodel.User.Account,
                        Title = datamodel.Title
                    };
                    return View(remodel);
                }


            }

            return BadRequest();
        }

        [Route("UserEditorTopic")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditorUserTopic(int Id = 0, TopicContentModel datamodel = null)
        {

            if (datamodel != null &&
                     datamodel.UserID > 0)
            {
                var claimsPrincipal = HttpContext.User;
                string accountID = claimsPrincipal.Claims.Where(o => o.Type == "ID").Count() > 0 ?
                    claimsPrincipal.Claims.Where(o => o.Type.ToUpper() == "ID".ToUpper()).FirstOrDefault().Value.ToString() : "";


                Topic model = new Topic()
                {
                    Id = Id,
                    ContentURL = datamodel.ContentURL,
                    UserId = datamodel.UserID,
                    Remarks = datamodel.Remarks,
                    IP = datamodel.IP,
                    TopicClassId = datamodel.TopicClassID,
                    TopicClass = _dbcontext.TopicClasses.Where(o => o.Id == datamodel.TopicClassID).FirstOrDefault(),
                    User = _dbcontext.Users.Where(o => o.Id == datamodel.UserID).FirstOrDefault(),
                    Title = datamodel.Title,
                    htmlstr = datamodel.htmlstr,

                };
                FilesPrint fp = new FilesPrint();
                model.ContentURL = await fp.PrintFileCreate(ServiceConfig.wwwrootDirectory, ServiceConfig.HtmlUpDirectory, model.htmlstr);
                if (!string.IsNullOrEmpty(model.ContentURL))
                    _dbcontext.Update(model);
                else
                    return StatusCode(505, "添加文件失败");
                if (_dbcontext.SaveChanges() > 0)
                    return Ok();


            }

            return RedirectToAction("EditorTopic");
        }


        [Route("Gethtml")]
        public ActionResult GetHtml(string url)
        {
            FilesPrint fp = new FilesPrint();

            return Redirect(@"../" + fp.ReadSRC(url));
        }


        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var topic = await _dbcontext.Topics.FindAsync(id);
            _dbcontext.Topics.Remove(topic);
            await _dbcontext.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TopicExists(int id)
        {
            return _dbcontext.Topics.Where(o=>o.Id==id).Count()>0?true:false;
        }

        /// <summary>
        /// 获取当前登录的admin信息
        /// </summary>
        /// <returns></returns>
        [NonAction]
        public Admin GetUser()
        {
            var claimsPrincipal = HttpContext.User;
            string accountID = claimsPrincipal.Claims.Where(o => o.Type == "ID").Count() > 0 ?
                claimsPrincipal.Claims.Where(o => o.Type.ToUpper() == "ID".ToUpper()).FirstOrDefault().Value.ToString() : "";
            int a_id = int.Parse(accountID);

            return int.Parse(accountID) > 0 ? _dbcontext.Admins.Find(a_id) : null;
        }
    }
}
