using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using TurkcellPasajApp.DataTransferObjects.Requests;
using TurkcellPasajApp.MVC.ViewModels;
using TurkcellPasajApp.Services;

namespace TurkcellPasajApp.MVC.Controllers
{
    public class ProductController : Controller
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly IProductService _productService;
        private readonly IWebHostEnvironment _webHostEnvironment;
        private readonly ICategoryService _categoryService;

        public ProductController(UserManager<IdentityUser> userManager, RoleManager<IdentityRole> roleManager, IProductService productService, IWebHostEnvironment webHostEnvironment, ICategoryService categoryService)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _productService = productService;
            _webHostEnvironment = webHostEnvironment;
            _categoryService = categoryService;
        }

        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        [Authorize(Roles = "seller")]
        public async Task<IActionResult> AddProduct()
        {
            AddProductViewModel addProductViewModel = new AddProductViewModel
            {
                Categories =await _categoryService.GetAllCategoryDisplayResponsesAsync(),
                CreateProduct=new CreateNewProductRequestDto() 
            };
            return View(addProductViewModel);
        }
        [HttpGet]
        [Authorize(Roles = "seller")]
        public async Task<IActionResult> EditProduct(int id)
        {
            var product = await _productService.GetProductByIdAsync(id);
            return View(product);
        }
        [HttpPost]
        [Authorize(Roles = "seller")]
        public async Task<IActionResult> EditProduct(UpdateProductRequestDto updateProductRequestDto, IFormFile PhotoFile)
        {
            try
            {
                // Eğer yeni fotoğraf yüklendiyse eski fotoğrafı sil
                if (PhotoFile != null && PhotoFile.Length > 0)
                {
                    // Eski fotoğrafın yolu
                    var oldPhotoPath = Path.Combine(_webHostEnvironment.WebRootPath, "ProductPhotos", updateProductRequestDto.PhotoUrl);

                    if (System.IO.File.Exists(oldPhotoPath))
                    {
                        System.IO.File.Delete(oldPhotoPath);
                    }

                    // Yeni fotoğrafı kaydet
                    var newFileName = Path.GetFileName(PhotoFile.FileName);
                    var newFilePath = Path.Combine(_webHostEnvironment.WebRootPath, "ProductPhotos", newFileName);

                    using (var stream = new FileStream(newFilePath, FileMode.Create))
                    {
                        await PhotoFile.CopyToAsync(stream);
                    }

                    // Fotoğraf URL'sini güncelle
                    updateProductRequestDto.PhotoUrl = newFileName;
                }

                updateProductRequestDto.SellerId = (int)HttpContext.Session.GetInt32("SellerId");
                await _productService.UpdateProductAsync(updateProductRequestDto);

                TempData["EditProductSuccessMessage"] = "Ürün güncelleme işlemi başarıyla tamamlandı.";
            }
            catch (Exception ex)
            {
                TempData["EditProductErrorMessage"] = "Ürün güncelleme işlemi sırasında bir hata oluştu.";
            }

            return RedirectToAction("Profile", "Seller");
        }


    }
}
