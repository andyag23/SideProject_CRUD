using Microsoft.AspNetCore.Mvc;
using MVC_SliedProject.Models;
using System.Diagnostics;

namespace MVC_SliedProject.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IAssetRepository _assetRepository;

        public HomeController(ILogger<HomeController> logger, IAssetRepository assetRepository)
        {
            _logger = logger;
            _assetRepository = assetRepository;
        }

        public async Task<IActionResult> Index(string category = null)
        {
            try
            {
                var assets = await _assetRepository.GetAssetsAsync(category);
                var categories = assets.Select(a => a.Category).Distinct().ToList();

                var model = new AssetViewModel
                {
                    Assets = assets.ToList(),
                    Categories = categories,
                    SelectedCategory = category
                };

                return View(model);
            }
            catch (Exception ex)
            {
                // 靜態資產數據
                var assets = new List<Asset>
                {
                    new Asset { Name = "Asset1", Category = "Category1", ImageUrl = "/images/asset1.jpg" },
                    new Asset { Name = "Asset2", Category = "Category1", ImageUrl = "/images/asset2.jpg" },
                    new Asset { Name = "Asset3", Category = "Category2", ImageUrl = "/images/asset3.jpg" },
                    // 更多資產...
                };

                // 獲取所有類別
                var categories = assets.Select(a => a.Category).Distinct().ToList();

                // 根據選擇的類別進行過濾
                if (!string.IsNullOrEmpty(category))
                {
                    assets = assets.Where(a => a.Category == category).ToList();
                }

                var model = new AssetViewModel
                {
                    Assets = assets,
                    Categories = categories,
                    SelectedCategory = category
                };

                return View(model);
            }
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Logout()
        {
            Response.Cookies.Delete("Username");
            return RedirectToAction("Login", "Login");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}