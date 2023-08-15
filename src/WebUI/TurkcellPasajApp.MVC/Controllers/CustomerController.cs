using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using TurkcellPasajApp.DataTransferObjects.Requests;
using TurkcellPasajApp.Entities;
using TurkcellPasajApp.MVC.ViewModels;
using TurkcellPasajApp.Services;

namespace TurkcellPasajApp.MVC.Controllers
{
    public class CustomerController : Controller
    {

        private readonly UserManager<IdentityUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly ICustomerService _customerService;
        private readonly IProductService _productService;
        private readonly IOrderService _orderService;
        private readonly IFavouriteService _favouriteService;
        private readonly IBasketService _basketService;
        private readonly IMapper _mapper;

        public CustomerController(UserManager<IdentityUser> userManager, RoleManager<IdentityRole> roleManager, ICustomerService customerService, IProductService productService, IOrderService orderService, IFavouriteService favouriteService, IBasketService basketService, IMapper mapper)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _customerService = customerService;
            _productService = productService;
            _orderService = orderService;
            _favouriteService = favouriteService;
            _basketService = basketService;
            _mapper = mapper;
        }

        [HttpGet]
        [Authorize(Roles = "customer")]
        public async Task<IActionResult> Index(int id)
        {
            var customerIndexViewModel = new ShowProductsViewModel
            {
                Products = await _productService.GetAllProductsDisplayResponsesAsync(),
                Favourites = await _favouriteService.GetCustomersAllFavouritesAsync(id),
            };
            return View(customerIndexViewModel);
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Register(CreateNewCustomerRequestDto createNewCustomerRequestDto)
        {

            if (ModelState.IsValid)
            {
                var user = new IdentityUser
                {
                    UserName = createNewCustomerRequestDto.Username,
                    Email = createNewCustomerRequestDto.Email,
                    PhoneNumber = createNewCustomerRequestDto.PhoneNumber
                };

                var result = await _userManager.CreateAsync(user, createNewCustomerRequestDto.Password);
                if (result.Succeeded)
                {
                    if (!await _roleManager.RoleExistsAsync("customer"))
                    {
                        await _roleManager.CreateAsync(new IdentityRole("customer"));
                    }
                    await _userManager.AddToRoleAsync(user, "customer");

                    // Kayıt başarılı, Customer tablosuna kayıt yap.
                    await _customerService.CreateCustomerAsync(createNewCustomerRequestDto);
                    // Kayıt başarılı, giriş sayfasına yönlendir.
                    TempData["SuccessRegisterMessage"] = "Kayıt başarılı.Lütfen giriş yapınız.";
                    return RedirectToAction("Login", "Home");
                }


            }
            // Kayıt işlemi başarısız oldu, formu tekrar gösterin.
            return View(createNewCustomerRequestDto);
        }
        [HttpPost]
        [Authorize(Roles = "customer")]
        public async Task<IActionResult> AddToFavorites(int productId)
        {
            var userId=HttpContext.Session.GetInt32("CustomerId");
            var favourites =await _favouriteService.GetCustomersAllFavouritesAsync((int)userId);

            if (favourites.Any(f=>f.FavouriteProductId==productId))
            {
                var favourite = favourites.SingleOrDefault(f=>f.FavouriteProductId==productId);
                await _favouriteService.ChangeFavouriteStatuAsync(favourite.Id);
            }
            else
            {
                var newFavourite = new CreateNewFavouriteRequestDto
                {
                    CustomerId =(int) userId,
                    FavouriteProductId = productId,
                    IsFavourite = true
                };
                await _favouriteService.CreateNewFavouriteAsync(newFavourite);
            }
            return Json(new { success = true });
        }

        [HttpPost]
        [Authorize(Roles = "customer")]
        public async Task<IActionResult> AddToBasket(int productId)
        {
            var customerId= HttpContext.Session.GetInt32("CustomerId");
            if (await _basketService.IsCustomerHaveBasketAsync((int)customerId))
            {
                var basketId = await _basketService.GetCustomerBasketIdAsync((int)customerId);
                BasketProduct basketProduct = new BasketProduct
                {
                    BasketId= basketId,
                    ProductId= productId
                };
                
                await _basketService.AddProductToBasketAsync(basketProduct);
            }
            else
            {
                var newBasket = new Basket
                {
                    CustomerId = (int)customerId
                };
                await _basketService.CreateBasketAsync(newBasket);

                BasketProduct basketProduct = new BasketProduct
                {
                    BasketId = newBasket.Id,
                    ProductId = productId
                };

                await _basketService.AddProductToBasketAsync(basketProduct);
            }
            return Json(new { success = true });
        }
        [HttpPost]
        [Authorize(Roles = "customer")]
        public async Task<IActionResult> RemoveToBasket(int productId)
        {
            var customerId = HttpContext.Session.GetInt32("CustomerId");
            BasketProduct basketProduct = new BasketProduct
            {
                BasketId =await _basketService.GetCustomerBasketIdAsync((int)customerId),
                ProductId=productId
            };
            await _basketService.RemoveProductToBasketProductAsync(basketProduct);
            return Json(new { success = true });
        }
        [Authorize(Roles = "customer")]
        public async Task<IActionResult> Basket()
        {
            var userId = HttpContext.Session.GetInt32("CustomerId");
            var basket=await _basketService.GetBasketAsync((int)userId);
            return View(basket);
        }
        [Authorize(Roles = "customer")]
        public async Task<IActionResult> Profile()
        {
            var customerId = HttpContext.Session.GetInt32("CustomerId");
            var customer = await _customerService.GetCustomerByIdAsync((int)customerId);
            var customerFavourites =await _favouriteService.GetCustomersAllFavouritesAsync((int)customerId);
            var customerOrders =await _orderService.GetAllOrdersByCustomerIdAsync((int)customerId);
            var allProducts =await _productService.GetAllProductsDisplayResponsesAsync();


            CustomerProfileViewModel customerProfileViewModel = new CustomerProfileViewModel
            {
                CustomerDisplayResponseDto= customer,
                Orders=customerOrders,
                showProductsViewModel = new ShowProductsViewModel
                {
                    Favourites = customerFavourites,
                    Products = allProducts
                }
            };
           

            return View(customerProfileViewModel);
            
        }
        [HttpGet]
        [Authorize(Roles = "customer")]
        public async Task<IActionResult> EditProfile()
        {
            var customerId = HttpContext.Session.GetInt32("CustomerId");
            var customerDisplayDto = _customerService.GetCustomerById((int)customerId);
            var updateCustomerDto=_mapper.Map<UpdateCustomerRequestDto>(customerDisplayDto);
            return View(updateCustomerDto);
        }
        [HttpPost]
        [Authorize(Roles = "customer")]
        public async Task<IActionResult> EditProfile(UpdateCustomerRequestDto updateCustomerRequestDto)
        {
            // Identity kullanıcısını bul
            var user = await _userManager.FindByNameAsync(User.Identity.Name);
            if (user == null)
            {
                // Kullanıcı bulunamazsa hata döndür
                return NotFound();
            }
            user.PhoneNumber = updateCustomerRequestDto.PhoneNumber;
            user.Email = updateCustomerRequestDto.Email;
       


            // Identity kullanıcısını güncelle
            var result = await _userManager.UpdateAsync(user);
            if (!result.Succeeded)
            {
                // Güncelleme başarısızsa hata döndür
                return BadRequest(result.Errors);
            }

            // Kullanıcının profili için de güncelleme yap
            var customerId = HttpContext.Session.GetInt32("CustomerId");
            updateCustomerRequestDto.Id = (int)customerId;

            await _customerService.UpdateCustomerAsync(updateCustomerRequestDto);
            return RedirectToAction("Profile");
        }
    
     
    }
}
   