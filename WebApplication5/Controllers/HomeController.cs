using Microsoft.AspNetCore.Mvc;


namespace WebApplication5.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        
        [HttpPost]
        public IActionResult SetCookie(string value, DateTime expiration)
        {
            Response.Cookies.Append("MyCookie", value, new CookieOptions { Expires = expiration, Path = "/", HttpOnly = false, IsEssential = true});
            return RedirectToAction("Index");
        }
        
        public IActionResult CheckCookie()
        {
            if (Request.Cookies.TryGetValue("MyCookie", out string cookieValue))
            {
                ViewData["CookieValue"] = cookieValue;
            }
            return View();
        }
    }
}