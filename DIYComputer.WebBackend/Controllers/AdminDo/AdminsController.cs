using DIYComputer.DtoModel.SysDto;
using DIYComputer.Entity.DBContext;
using DIYComputer.Entity.SysEntity;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace DIYComputer.WebBackend.Controllers.AdminDo
{

    [Authorize(Policy = "Admin")]
    public class AdminsController : Controller
    {
        private readonly EFDBContext _context;

        public AdminsController(EFDBContext context)
        {
            _context = context;
        }

        // GET: Admins
        public async Task<IActionResult> Index()
        {

            return View(await _context.Admins.ToListAsync());
        }

        // GET: Admins/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var admin = await _context.Admins
                .FirstOrDefaultAsync(m => m.Id == id);
            if (admin == null)
            {
                return NotFound();
            }

            return View(admin);
        }

        // GET: Admins/Create
        public IActionResult Create()
        {
            return View();
        }

        [AllowAnonymous]
        [Route("Login")]
        public IActionResult Login()
        {
            AdminLogin adminLogin = new AdminLogin();
            return View(adminLogin);
        }

        [HttpPost]
        [Route("Login")]
        [AllowAnonymous]
        public async Task<IActionResult> Login([Bind("Account,PW")]  AdminLogin model)
        {

            if (model.Account != null && AdminExists(model.Account))
                if (_context.Admins.Where(o=>(o.Account.Equals(model.Account)&&o.PW.Equals(model.PW))).Count()>0?true:false)
                {
                    //允许登陆
                    var Admodel = _context.Admins.Where(o => o.Account == model.Account).FirstOrDefault();
                    Admodel.LastTime = DateTime.Now;
                    _context.Update(Admodel);
                    var claims = new List<Claim>
                {
                    new Claim("ID", Admodel.Id+""),
                    new Claim("Level",Admodel.Level+""),
                    new Claim("User", Admodel.Account),
                    new Claim("Name", Admodel.Name),
                    new Claim("Role", "Admin"),
                    new Claim("AdminType", "Admin"),
                };
                    ClaimsIdentity c= new ClaimsIdentity();          
                    await HttpContext.SignInAsync(new ClaimsPrincipal(new ClaimsIdentity(claims, "Cookies", "Admin", "Admin")));
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
                  //  HttpContext.Response.Cookies.Append("divadmin", Admodel.Account);
                    return RedirectToAction(nameof(Index));

                }
             model.Message = "登陆失败请检查用户名与密码";
            return View(model);

        }

        [HttpGet]
        [Route("LoginOut")]
        [AllowAnonymous]
        public async Task<IActionResult> LoginOut()
        {
            //if (Request.Cookies["Authorization"] != null)
            //{
            //    string tokenstr = Request.Cookies["Authorization"].Substring("Bearer".Length).Trim();
            //    if (MyNetCoreMemoryCache.Exists(tokenstr))
            //    {
            //        if(MyNetCoreMemoryCache.RemoveMemoryCache(tokenstr))
            //        {
            //            return RedirectToAction("login","Admins");
            //        }
            //    }
            //}
            //Response.Cookies.Delete("Authorization");
            //HttpContext.Response.Cookies.Delete("divadmin");
            await HttpContext.SignOutAsync();
            return RedirectToAction("login", "Admins");
        }
        // POST: Admins/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Account,Name,Level,PW,LastTime,Id")] AdminLogin admin)
        {
            if (ModelState.IsValid)
            {
                if (AdminExists(admin.Account))
                    return View();
                _context.Add(admin);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(admin);
        }

        // GET: Admins/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var admin = await _context.Admins.FindAsync(id);
            if (admin == null)
            {
                return NotFound();
            }
            return View(admin);
        }

        // POST: Admins/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Account,Name,Level,PW,LastTime,Id")] Admin admin)
        {
            if (id != admin.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(admin);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AdminExists(admin.Id))
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
            return View(admin);
        }

        // GET: Admins/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var admin = await _context.Admins
                .FirstOrDefaultAsync(m => m.Id == id);
            if (admin == null)
            {
                return NotFound();
            }

            return View(admin);
        }

        // POST: Admins/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var admin = await _context.Admins.FindAsync(id);
            _context.Admins.Remove(admin);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        private bool AdminExists(string account)
        {

            return _context.Admins.Where(o => o.Account.Equals(account)).Count() > 0 ? true : false;
         
        }

        private bool AdminExists(int id)
        {
            return _context.Admins.Where(o => o.Id==id).Count() > 0 ? true : false;
        }

    }
}
