using Microsoft.AspNetCore.Mvc;
using MVC_SliedProject.Models;

namespace MVC_SliedProject.Controllers
{
    public class LoginController : Controller
    {
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(LoginModel model)
        {
            if (ModelState.IsValid)
            {
                // 實際應用中，你應該驗證用戶名和密碼
                if (model.Username == "admin" && model.Password == "password")
                {
                    // 設置 Cookie
                    var cookieOptions = new CookieOptions
                    {
                        Expires = DateTime.Now.AddMinutes(30) // Cookie 30 分鐘後過期
                    };

                    Response.Cookies.Append("Username", model.Username, cookieOptions);

                    return RedirectToAction("Index", "Home");
                }
                ModelState.AddModelError("", "無效的登入嘗試。");
            }

            return View(model);
        }
    }
}
