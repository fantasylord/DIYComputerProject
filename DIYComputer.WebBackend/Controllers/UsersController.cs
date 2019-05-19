using DIYComputer.Entity.DBContext;
using DIYComputer.Entity.SysEntity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace DIYComputer.WebBackend.Controllers
{
    [Authorize(Policy = "Admin")]
    public class UsersController : Controller
    {
        private readonly EFDBContext _context;

        private readonly  IHttpContextAccessor _httpContext;
        public UsersController(EFDBContext context, IHttpContextAccessor httpContext)
        {
            _httpContext = httpContext;
            _context = context;
        }

        // GET: Users
        public async Task<IActionResult> Index()
        {
            
            return View(await _context.Users.ToListAsync());
        }

        // GET: Users/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var user = await _context.Users
                .FirstOrDefaultAsync(m => m.Id == id);
            if (user == null)
            {
                return NotFound();
            }

            return View(user);
        }

        // GET: Users/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Users/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Account,Name,PW,ConfirmPassword,Tell,Mail,LastTime,Id")] User user)
        {
            if (ModelState.IsValid)
            {
                user.LastTime = System.DateTime.Now;
                user.Integral = 0;
                if (_context.Users.Where(o => o.Account == user.Account).Count() > 0)
                    return View(user);
                _context.Add(user);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(user);
        }

        // GET: Users/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var user = await _context.Users.Where(x => x.Id == id).FirstOrDefaultAsync();
            if (user == null)
            {
                return NotFound();
            }
            return View(user);
        }

        // POST: Users/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Account,Name,Integral,PW,Tell,Mail,LastTime,Id")] User user)
        {
            if (id != user.Id)
            {
                return NotFound();
            }
            if (_context.Users.Where(o => o.Account == user.Account).Count() > 0)
                return NotFound();

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(user);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!UserExists(user.Id))
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
            return View(user);
        }

        // GET: Users/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var user = await _context.Users
                .FirstOrDefaultAsync(m => m.Id == id);
            if (user == null)
            {
                return NotFound();
            }

            return View(user);
        }

        // POST: Users/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var user = await _context.Users.FindAsync(id);
            _context.Users.Remove(user);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        private bool UserExists(string account)
        {
            return _context.Users.Where(o => o.Account.Equals(account)).Count() > 0 ? true : false;
        }
        private bool UserExists(int id)
        {
            return _context.Users.Where(e => e.Id == id).Count() > 0 ? true : false;
        }

        /// <summary>
        /// 获取当前登录的用户信息
        /// </summary>
        /// <returns></returns>
        [NonAction]
        public static User GetUser(EFDBContext context ,IHttpContextAccessor accessor)
        {

            var claimsPrincipal = accessor.HttpContext.User;
            string accountID = claimsPrincipal.Claims.Where(o => o.Type == "ID").Count() > 0 ?
                claimsPrincipal.Claims.Where(o => o.Type.ToUpper() == "ID".ToUpper()).FirstOrDefault().Value.ToString() : "";
            int a_id = int.Parse(accountID);
            return int.Parse(accountID) > 0 ? context.Users.Find(a_id) : null;
        }
    }
}
