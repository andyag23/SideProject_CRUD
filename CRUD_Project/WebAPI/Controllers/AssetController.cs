using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    public class AssetController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
