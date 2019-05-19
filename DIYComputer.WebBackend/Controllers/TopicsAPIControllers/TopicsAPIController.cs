 
using DIYComputer.DtoModel.SysDto;
using DIYComputer.Entity.DBContext;
using DIYComputer.Entity.SysEntity;
using DIYComputer.Util;
using DIYComputer.Util.CommonModel;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace DIYComputer.WebBackend.Controllers.TopicsAPIControllers
{
    [Route("api/[controller]")]
    [Produces("application/json")]
    public class TopicsAPIController : Controller
    {
        private readonly EFDBContext _context;
   
        public TopicsAPIController(EFDBContext eFDBContext)
        {
            _context = eFDBContext;
        }

        /// <summary>
        /// 获取文章类别
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("GetTopicClass")]
        public  JsonResult GetTopicClass()
        {
            
            var listmd = _context.TopicClasses.AsQueryable().ToList();
            List<TopicClassDisplay> retmo = new List<TopicClassDisplay>();
             foreach(var item in listmd)
            {
                retmo.Add(new TopicClassDisplay {
                    Name = item.Name,
                    Id = item.Id,
                });
            }
           
            return Json(ResultToJson.GetJsonResult(retmo));
        }

        [HttpGet]
        [Route("GetTopicByID")]
        public JsonResult GetTopicByID(int id)
        {

            
            var model = _context.Topics.Where(o => o.Id == id).FirstOrDefault();

            User user = _context.Users.FirstOrDefault(o => o.Id == model.UserId);

            var remodel = new TopicListModel()
            {
                Account = user.Account,
                UserName=user.Name,
                ContentURL = model.ContentURL,
                CreateTime = model.CreateTime,
                EditTime = model.EditTime,
                Id = model.Id,
                IP = model.IP,
                Remarks = model.Remarks,
                Title = model.Title,
                Outline=model.Outline,
                TopicClassID = model.TopicClassId,
                UserID = model.UserId,
            };
            return Json(ResultToJson.GetJsonResult(remodel));

        }

        [HttpGet]
        [Route("GetTopicsByClassID")]
        public  JsonResult GetTopicsByClass(int id)
        {
            var dbmodels = _context.Topics.Where(o => o.TopicClass.Id == id).AsQueryable().ToList();
            var remodels = new List<TopicListModel>();
            foreach(var model in dbmodels)
            {
               remodels.Add(new TopicListModel()
                {
                    Account = model.User.Account,
                    ContentURL = model.ContentURL,
                    CreateTime = model.CreateTime,
                    EditTime = model.EditTime,
                    Id = model.Id,
                    IP = model.IP,
                    Remarks = model.Remarks,
                    Title = model.Title,
                    Outline=model.Outline,
                    TopicClassID = model.TopicClassId,
                    UserID = model.UserId,
                });
            }

            return Json(ResultToJson.GetJsonResult(remodels));
        }


        [HttpGet]
        [Route("GetTopicsAll")]
        public JsonResult GetTopicsByTitle(string title = "",int topicclassid=-1,string username="")
        {

            var dbmodels = _context.Topics.Where(o => o.Title.Contains(title)).AsQueryable().ToList();
            
            var remodels = new List<TopicListModel>();
            try
            {
                foreach (var model in dbmodels)
                {
                    User user = _context.Users.FirstOrDefault(o => o.Id == model.UserId);
                    remodels.Add(new TopicListModel()
                    {
                        Account = model.User.Account,
                        ContentURL = model.ContentURL,
                        CreateTime = model.CreateTime,
                        EditTime = model.EditTime,
                        Id = model.Id,
                        IP = model.IP,
                        Remarks = model.Remarks,
                        Title = model.Title,
                        Outline = model.Outline,
                        TopicClassID = model.TopicClassId,
                        UserID = model.UserId,
                        UserName = model.User.Name,
                        Replies = _context.Reply.Where(o => o.TopicId == model.Id).Count()
                        
                    });
                }
                PageSplitModel<TopicListModel> result = new PageSplitModel<TopicListModel>(remodels,0, remodels.Count, remodels.Count);
                return Json(ResultToJson.GetJsonResult(result));
            }
            catch (Exception)
            {

                return Json(ResultToJson.GetJsonResult());
            }
             
        }

        [HttpGet]
        [Route("GetTopicsByAuthorID")]
        public JsonResult GetTopicsByAuthorID(int  authorid)
        {
         
            var dbmodels = _context.Topics.Where(o => o.User.Id== authorid).AsQueryable().ToList();
            var remodels = new List<TopicListModel>();
            foreach (var model in dbmodels)
            {
                remodels.Add(new TopicListModel()
                {
                    Account = model.User.Account,
                    ContentURL = model.ContentURL,
                    CreateTime = model.CreateTime,
                    EditTime = model.EditTime,
                    Id = model.Id,
                    IP = model.IP,
                    Remarks = model.Remarks,
                    Title = model.Title,
                    TopicClassID = model.TopicClassId,
                    UserID = model.UserId,
                    Outline = model.Outline
                });
            }
            return Json(ResultToJson.GetJsonResult());
        }
        [HttpGet]
        [Route("GetRepliesForID")]
        public JsonResult GetReplies(int topicid = -1)
        {

            var result = _context.Reply.Where(o => o.TopicId == topicid).ToList();
            List<ReplyDisplay> redto = new List<ReplyDisplay>();
            foreach (var item in result)
            {
                var user = _context.Users.FirstOrDefault(o => o.Id == item.UserId);
                var topic = _context.Topics.FirstOrDefault(o => o.Id == item.TopicId);
                redto.Add(new ReplyDisplay()
                {
                   

                    Content = item.Content,
                    CreateTime = item.CreateTime,
                    EditTime = item.EditTime,
                    Remarks = item.Remarks,
                    TopicTitle = item.Topic.Title,
                    TopicId = item.TopicId,
                    Id = item.Id,
                    UserAccount = user.Account,
                    UserName = user.Name,


                });
            }
            PageSplitModel<ReplyDisplay> resultdt = new PageSplitModel<ReplyDisplay>(redto, 0, redto.Count, redto.Count);

            return Json(ResultToJson.GetJsonResult( resultdt));
              

        }

    }
}
