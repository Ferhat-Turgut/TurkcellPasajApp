using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using TurkcellPasajApp.Services;

namespace TurkcellPasajApp.MVC.Controllers
{
    public class ProductController : Controller
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly IProductService _productService;

        public ProductController(UserManager<IdentityUser> userManager, RoleManager<IdentityRole> roleManager, IProductService productService)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _productService = productService;
        }

        public IActionResult Index()
        {
            return View();
        }
        public async Task<IActionResult> EditProduct(int id)
        {
            var product=await _productService.GetProductByIdAsync(id);
            return View(product);
        }
    }
}
