using AutoMapper;
using DIYComputer.DtoModel.SysDto;
using DIYComputer.Entity.DBContext;
using DIYComputer.Entity.SysEntity;
using DIYComputer.Service.VierificationCodeService;
using DIYComputer.WebBackend.MiddleWare.MyMapper;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
 

namespace DIYComputer.WebFrontend.Controllers.UserDo
{
    [Authorize(Policy  = "User")]
    [Route("Client/[Controller]")]
    public class UsersController : Controller
    {
        private readonly IHttpContextAccessor _accessor;
        private  readonly EFDBContext _context;
        private readonly IMapper _mapper;
         private readonly VierificationCodeServices _codeServices;
        // public readonly UsersController instance;
        public UsersController(EFDBContext context,
                                IHttpContextAccessor accessor,
                                [FromServices]IMapper mapper,
                                VierificationCodeServices codeServices)
        {
            _accessor = accessor;
            _context = context;
            _mapper = mapper;
            _codeServices = codeServices;           
        }
        [Route("Details")]
        // GET: Users/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }
        [Route("Register")]
        [AllowAnonymous]
        // GET: Users/Create
        public ActionResult Register()
        {
            UserRegisterModel model = new UserRegisterModel();
            return View(model);
        }

        [HttpGet]
        [Route("Index")]
        public ActionResult Index()
        {
            var dbmodle =  GetUser(_context, _accessor);
            UserDisplayModel remodel = new UserDisplayModel
            {
                
                Account = dbmodle.Account,
                CreateTime = dbmodle.CreateTime,
                EditTime = dbmodle.EditTime,
                Id = dbmodle.Id,
                Name = dbmodle.Name,
                Remarks = dbmodle.Remarks,
                Tell = dbmodle.Tell,
                Mail = dbmodle.Mail,
                Integral = dbmodle.Integral,
                Message = "登陆成功"
            };

            return RedirectToAction("Edit", "Users");
            //return View(remodel);
        }
        // POST: Users/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        [AllowAnonymous]
        [Route("Register")]
        public ActionResult Register([FromForm] UserRegisterModel modelIn)
        {
            if (!ModelState.IsValid)
            {
                modelIn.Message = "验证值失败 检查是否输入正确";
                return View(modelIn);
            }
            if (UserExists(modelIn.Account))
            {
                modelIn.Message = "已存在同名用户";
                return View(modelIn);
            }

            try
            {
                var modeldb = _mapper.Map<User>(modelIn);
              
                _context.Add(modeldb);
                _context.SaveChanges();
                return RedirectToAction("Index", "Home");
            }
            catch
            {
                modelIn.Message = "注册失败";
                return View(modelIn);
            }
        }
        [Route("Edit")]
        [HttpGet]
        // GET: Users/Edit/5
        public ActionResult Edit()
        {

            var modeldb = GetUser(_context, _accessor);
            if(modeldb == null)
            {
                return RedirectToAction("index", "Home");
            }
            
          
            UserEditModel remodel = new UserEditModel()
            {
                Account = modeldb.Account,
                ConfirmPassword = modeldb.ConfirmPassword,
                PW = modeldb.PW,
                Id = modeldb.Id,
                Mail = modeldb.Mail,
                Name = modeldb.Name,
                Tell = modeldb.Tell
            };
               
            return View(remodel);
        }

        // POST: Users/Edit/5
        [Route("Edit")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([FromForm] UserEditModel userIn)
        {


            var usermodel = GetUser(_context,_accessor);
            if (usermodel == null)
                return RedirectToAction("Index", "Home");
            if(!usermodel.PW.Equals(userIn.PWLast))
            {
                userIn.Message = "之前密码输入错误，请确认是否正确";
                return View(userIn);
            }
            try
            {

           
                    if (usermodel.Id.Equals(userIn.Id))
                    {
                        //Mapper.Map(buyerDto, model);赋值 buyerdto 源 model 目标
                        var modeldb = _context.Users.Find(userIn.Id);
                        modeldb = _mapper.Map(userIn, modeldb);
                        modeldb.EditTime = DateTime.Now;
                        _context.Users.Update(modeldb);
                        _context.SaveChanges();
                        return RedirectToAction("Index", "Home");
                    }
                    userIn.Message = "修改信息出错";
                    return View(userIn);
                }
                catch
                {
                    userIn.Message = "未知错误";
                    return View(userIn);
                }
            
           

        }

        [AllowAnonymous]
        [Route("Login")]
        public IActionResult Login()
        {
            UserLoginModel adminLogin = new UserLoginModel();
            return View(adminLogin);
        }

        [HttpPost]
        [Route("Login")]
        [ValidateAntiForgeryToken]
        [AllowAnonymous]
        public async Task<IActionResult> Login([FromForm] UserLoginModel model)
        {
            if (model.Codeid > 0)
            {
                if (!_codeServices.IsValidation(model.Code, model.Codeid))
                {

                    model.Message = "验证码输入错误，请重新登录";
                    _codeServices.RemoveCode(model.Codeid);
                    return View(model);
                }
                _codeServices.RemoveCode(model.Codeid);
            }

           
            if (model.Account != null && UserExists(model.Account))
            {
                if (_context.Users.Where(o => (o.Account.Equals(model.Account) && o.PW.Equals(model.PW))).Count() > 0 ? true : false)
                {
                    //允许登陆
                    var Admodel = _context.Users.Where(o => o.Account == model.Account).FirstOrDefault();
                    Admodel.LastTime = DateTime.Now;
                    _context.Update(Admodel);
                    var claims = new List<Claim>
                {
                    new Claim("ID", Admodel.Id+""),
                   
                    new Claim("Account", Admodel.Account),
                    new Claim("Role", "User"),
                    new Claim("UserType", "User"),
                    new Claim("ClientType", "Client"),
                    new Claim("Tell", Admodel.Tell),
                    new Claim("Mail", Admodel.Mail),
                    new Claim("Name", Admodel.Name),
                };
 
                    await HttpContext.SignInAsync(new ClaimsPrincipal(new ClaimsIdentity(claims, "Cookies", "User", "User")));
                    //TokenModel tokenModel = new TokenModel()
                    //{
                    //    Name = Admodel.Name,
                    //    Sub = "Admin",
                    //    UserID = Admodel.Id,
                    //    Level = Admodel.Level,

                    //};
                    //var tokenstr = MyNetCorePIToken.IssueJWT(tokenModel, new TimeSpan(System.DateTime.Now.AddHours(24).Ticks), new TimeSpan(System.DateTime.Now.AddDays(15).Ticks));

                    //Response.Cookies.Append("Authorization", "Bearer "+tokenstr);
                    ////var cokstr = Request.Cookies["Authorization"];
                    //// Request.Cookies["Authorization"] = "Bearer " + tokenstr;


                    _context.SaveChanges();
              
                    return RedirectToAction("Index", "Home");

                }
            }
            model.Message = "登陆失败请检查用户名与密码";
            return View(model);

        }

        [HttpGet]
        [Route("LoginOut")]
        [AllowAnonymous]
        public async Task<IActionResult> LoginOut()
        {
           // HttpContext.Response.Cookies.Delete("divuser");
            await HttpContext.SignOutAsync();
            return RedirectToAction("Index", "Home");
           
        }


        [ValidateAntiForgeryToken]
        private bool UserExists(int? ID)
        {
            return _context.Users.Where(o => o.Id.Equals(ID)).Count() > 0 ? true : false;
        }


        public bool UserExists(string Account)
        {
            return _context.Users.Where(o => o.Account.Equals(Account)).Count() > 0 ? true:false ;

        }

        /// <summary>
        /// 获取当前登录的用户信息
        /// </summary>
        /// <returns></returns>
        [NonAction]
        public static User GetUser(EFDBContext context,
                                IHttpContextAccessor accessor)
        {

            var claimsPrincipal = accessor.HttpContext.User;
            string accountID = claimsPrincipal.Claims.Where(o => o.Type == "ID").Count() > 0 ?
                claimsPrincipal.Claims.Where(o => o.Type.ToUpper() == "ID".ToUpper()).FirstOrDefault().Value.ToString() : "";
            int a_id = int.Parse(accountID);
         
            var model = context.Users.Where(o=>o.Id==a_id).First();
            return a_id > 0 ? model : null;
        }
    }
}