using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using TurkcellPasajApp.DataTransferObjects.Requests;
using TurkcellPasajApp.MVC.ViewModels;
using TurkcellPasajApp.Services;

namespace TurkcellPasajApp.MVC.Controllers
{
    public class SellerController : Controller
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly IProductService _productService;
        private readonly ISellerService _sellerService;
        private readonly IOrderDetailService _orderDetailService;
        private readonly IMapper _mapper;

        public SellerController(UserManager<IdentityUser> userManager, RoleManager<IdentityRole> roleManager, IProductService productService, ISellerService sellerService, IOrderDetailService orderDetailService, IMapper mapper)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _productService = productService;
            _sellerService = sellerService;
            _orderDetailService = orderDetailService;
            _mapper = mapper;
        }

        public async Task<IActionResult> Index(int Id)
        {
            var products =await _productService.GetAllProductsBySelleryIdAsync(Id);
            return View(products);
        }
        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Register(CreateNewSellerRequestDto createNewSellerRequestDto)
        {

            if (ModelState.IsValid)
            {
                var user = new IdentityUser
                {
                    UserName = createNewSellerRequestDto.Username,
                    Email = createNewSellerRequestDto.Email,
                    PhoneNumber= createNewSellerRequestDto.PhoneNumber
                };

                var result = await _userManager.CreateAsync(user, createNewSellerRequestDto.Password);
                if (result.Succeeded)
                {
                    if (!await _roleManager.RoleExistsAsync("seller"))
                    {
                        await _roleManager.CreateAsync(new IdentityRole("seller"));
                    }
                    await _userManager.AddToRoleAsync(user, "seller");

                    // Kayıt başarılı, Seller tablosuna kayıt yap.
                    await _sellerService.CreateSellerAsync(createNewSellerRequestDto);
                    // Kayıt başarılı, giriş sayfasına yönlendir.
                    TempData["SuccessRegisterMessage"] = "Kayıt başarılı.Lütfen giriş yapınız.";
                    return RedirectToAction("Login", "Home");
                }


            }

            // Kayıt işlemi başarısız oldu, formu tekrar gösterin.
            return RedirectToAction("Register", "Seller", createNewSellerRequestDto);
        }
        [HttpGet]
        public async Task<IActionResult> Profile()
        {
            var sellerId = HttpContext.Session.GetInt32("SellerId");
            var sellersProfile =await _sellerService.GetSellerForProfileAsync((int)sellerId);

            SellerProfileViewModel sellerProfileViewModel = new SellerProfileViewModel
            {
                SellerDisplayResponseDto= sellersProfile.Seller,
                ProductDisplayResponseDto=sellersProfile.Products,
                orderDetailsDisplayResponseDtos=sellersProfile.OrderDetails
            };
            return View(sellerProfileViewModel);
           
        }
        [HttpGet]
        public async Task<IActionResult> ShowStores()
        {
           
            return View();
        }
    }
}
