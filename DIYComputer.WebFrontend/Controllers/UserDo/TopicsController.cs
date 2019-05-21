using AutoMapper;
using DIYComputer.Config.ServiceConfig;
using DIYComputer.DtoModel.SysDto;
using DIYComputer.Entity.DBContext;
using DIYComputer.Entity.SysEntity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static DIYComputer.Util.FileUpHelper.FileStreamPandO;

namespace DIYComputer.WebFrontend.Controllers.UserDo
{
    [Authorize(Policy = "User")]
    public class TopicsController : Controller
    {


        private readonly IHttpContextAccessor _accessor;
        private readonly EFDBContext _dbcontext;
        private readonly IMapper _mapper;

        public TopicsController(EFDBContext context, 
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
            //var dblist =   (from o in _dbcontext.TopicClasses.AsNoTracking()
            //                    orderby o.CreateTime descending
            //                    select new TopicClass
            //                    {
            //                        Childnodes = o.Childnodes,
            //                        CreateTime = o.CreateTime,
            //                        EditTime = o.EditTime,
            //                        Id = o.Id,
            //                        Name = o.Name,
            //                        ParentNode = o.ParentNode,
            //                    }
            //                 ).ToList();

            List<Topic> list = new List<Topic>();
            var user = UsersController.GetUser(_dbcontext, _accessor);
            var dbmodellist= _dbcontext.Topics.Where(o=>o.User.Id==user.Id).ToList();
           var modellist = _mapper.Map<List<TopicListModel>>(dbmodellist);
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
            User user = UsersController.GetUser(_dbcontext, _accessor);
            if(user!=null)
            try
            {
                    Topic model = _dbcontext.Topics.Where(o => o.Id == id).FirstOrDefault();
                    if (model != null)
                    {
                        _dbcontext.Remove(model);
                    }
                    // TODO: Add delete logic here

                    return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
            return View();
        }
        [HttpGet]
        [Route("TopicIndex")]
        [AllowAnonymous]
        public IActionResult TopicIndex()
        {
            return View();
        }


        [HttpGet]
        [Route("TopicDetails")]
        [AllowAnonymous]
        public IActionResult TopicDetails(int id=-1)
        {
            TopicContentModel remodel = new TopicContentModel();
            if (id > 0)
            {
                var datamodel = _dbcontext.Topics.FirstOrDefault(o => o.Id == id);
               if(datamodel != null)
                {
                    User user = _dbcontext.Users.FirstOrDefault(o => o.Id == datamodel.UserId);
                    remodel = new TopicContentModel()
                    {
                        Id = datamodel.Id,
                        ContentURL = datamodel.ContentURL,
                        CreateTime = datamodel.CreateTime,
                        Remarks = datamodel.Remarks,
                        IP = datamodel.IP,
                        Outline = datamodel.Outline,
                        TopicClassID = datamodel.TopicClassId,
                        UserID = datamodel.UserId,
                        Account = user.Account,
                        Title = datamodel.Title
                    };
                }

            }
            return View(remodel);

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
                topic.htmlstr= fp.ReadFileByStr(ServiceConfig.wwwrootDirectory + topic.ContentURL);
                topic.ContentURL = await fp.PrintFileCreate(ServiceConfig.wwwrootDirectory, ServiceConfig.HtmlUpDirectory, topic.htmlstr);
                if (!string.IsNullOrEmpty(topic.ContentURL))
                    _dbcontext.Add(topic);
                else
                    return StatusCode(505, "添加文件失败");
                if (_dbcontext.SaveChanges() > 0)
                    return RedirectToAction("Index");


            return NoContent();
        }


        [Route("EditorTopic")]
        public IActionResult EditorTopic(int Id = 0)
        {
            var claimsPrincipal = HttpContext.User;
            string  accountID = claimsPrincipal.Claims.Where(o => o.Type == "ID").Count() > 0 ?
                claimsPrincipal.Claims.Where(o => o.Type.ToUpper() == "ID".ToUpper()).FirstOrDefault().Value.ToString() : "";
          
            
            if (!string.IsNullOrEmpty(accountID))
            {
                int a_id = int.Parse(accountID);
                Topic datamodel = _dbcontext.Topics.Where(o => o.Id == Id).FirstOrDefault();
                FilesPrint fp = new FilesPrint();
                    
                if (datamodel != null &&
                    datamodel.UserId > 0 )
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
                        Outline = datamodel.Outline,
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

        [Route("EditorTopic")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditorTopic(int Id = 0, TopicContentModel datamodel = null)
        {
            if (!TopicExists(Id))
            {
                return BadRequest();
            }

            User  u= UserDo.UsersController.GetUser(_dbcontext,_accessor);

            Topic dbmodel = _dbcontext.Topics.First(o => o.Id == Id);
            if (u.Id == dbmodel.UserId) { 
         

               
                    dbmodel.Id = Id;
                    dbmodel.Remarks = datamodel.Remarks;
                    dbmodel.IP = datamodel.IP;
                    dbmodel.TopicClassId = datamodel.TopicClassID;
                    dbmodel.TopicClass = _dbcontext.TopicClasses.Where(o => o.Id == datamodel.TopicClassID).FirstOrDefault();
                    dbmodel.Title = datamodel.Title;
                    dbmodel.htmlstr = datamodel.htmlstr;

                 
                FilesPrint fp = new FilesPrint();
                dbmodel.ContentURL = await fp.PrintFileCreate(ServiceConfig.wwwrootDirectory, ServiceConfig.HtmlUpDirectory, dbmodel.htmlstr);
                if (!string.IsNullOrEmpty(dbmodel.ContentURL))
                    _dbcontext.Update(dbmodel);
                else
                    return StatusCode(505, "添加文件失败");
                if (_dbcontext.SaveChanges() > 0)
                    return RedirectToAction("Index");



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
        public User GetUser()
        {
            var claimsPrincipal = HttpContext.User;
            string accountID = claimsPrincipal.Claims.Where(o => o.Type == "ID").Count() > 0 ?
                claimsPrincipal.Claims.Where(o => o.Type.ToUpper() == "ID".ToUpper()).FirstOrDefault().Value.ToString() : "";
            int a_id = int.Parse(accountID);

            return int.Parse(accountID) > 0 ? _dbcontext.Users.Find(a_id) : null;
        }
    }
}
