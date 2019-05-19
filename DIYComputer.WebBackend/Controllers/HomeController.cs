using DIYComputer.Util.CommonModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Threading.Tasks;


namespace DIYComputer.WebBackend.Controllers
{
    //public class UserController : Controller
    //{
    //    // GET: /<controller>/
    //    public async Task<IActionResult> Index()
    //    {
    //        //await RefreshTokensAsync();
    //        //var token = await HttpContext.GetTokenAsync("access_token");
    //        using (var client = new HttpClient())
    //        {
    //            // client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
    //            var content = await client.GetStringAsync("http://47.95.197.57:5000/api/Buyer/GetAccounts");
    //            //List<Student> twoList = JsonConvert.DeserializeObject<List<Student>>(jsonData);
    //            ICollection<BuyerDto> results = JsonConvert.DeserializeObject<List<BuyerDto>>(content);
    //            // var json = JArray.Parse(content).ToString();
    //            // return Ok(new { value = content });
    //            ViewData["datas"] = results;
    //            if (results != null)
    //                return View(results);

    //        }

    //        return NotFound();
    //    }
    //    public async Task<IActionResult> About()
    //    {
    //        //await RefreshTokensAsync();
    //        //var token = await HttpContext.GetTokenAsync("access_token");
    //        using (var client = new HttpClient())
    //        {
    //            // client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
    //            var content = await client.GetStringAsync("http://47.95.197.57:5000/api/Buyer/GetAccounts");
    //            //List<Student> twoList = JsonConvert.DeserializeObject<List<Student>>(jsonData);
    //            ICollection<BuyerDto> results = JsonConvert.DeserializeObject<List<BuyerDto>>(content);
    //            // var json = JArray.Parse(content).ToString();
    //            // return Ok(new { value = content });
    //            ViewData["datas"] = results;
    //            if (results != null)
    //                return View(results);

    //        }

    //        return NotFound();
    //    }
    //}

    [Authorize(Policy = "Admin")]
    public class HomeController : Controller
    {
        /// <summary>
        /// ueditor编辑器
        /// </summary>
        /// <returns></returns>
        public IActionResult Ueditorup()
        {
            return View();
        }

        public IActionResult Index()
        {
            return RedirectToAction("index","Admins");
        }
     //  [ValidateAntiForgeryToken]
        public async Task<IActionResult> About()
        {
            //await RefreshTokensAsync();
            //var token = await HttpContext.GetTokenAsync("access_token");
            //using (var client = new HttpClient())
            //{
            //   // client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            //    var content = await client.GetStringAsync("http://47.95.197.57:5000/api/Buyer/GetAccounts");
            //    //List<Student> twoList = JsonConvert.DeserializeObject<List<Student>>(jsonData);
            //    ICollection<BuyerDto> results=JsonConvert.DeserializeObject<List<BuyerDto>>(content);
            //   // var json = JArray.Parse(content).ToString();
            //   // return Ok(new { value = content });
            //    ViewData["datas"] = results;
            //if(results!=null)
            //    return View(results);

            //}

            return NotFound();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
