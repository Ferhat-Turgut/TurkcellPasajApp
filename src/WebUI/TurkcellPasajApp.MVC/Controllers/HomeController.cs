﻿using AutoMapper;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using TurkcellPasajApp.Entities;
using TurkcellPasajApp.MVC.Models;
using TurkcellPasajApp.Services;

namespace TurkcellPasajApp.MVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IProductService _productService;
        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly ICustomerService _customerService;
        private readonly ISellerService _sellerService;
        private readonly IMapper _mapper;
        private readonly ICategoryService _categoryService;
       

        public HomeController(ILogger<HomeController> logger, IProductService productService, SignInManager<IdentityUser> signInManager, UserManager<IdentityUser> userManager, ICustomerService customerService, ISellerService sellerService, IMapper mapper, ICategoryService categoryService)
        {
            _logger = logger;
            _productService = productService;
            _signInManager = signInManager;
            _userManager = userManager;
            _customerService = customerService;
            _sellerService = sellerService;
            _mapper = mapper;
            _categoryService = categoryService;
        }

        public async Task<IActionResult> Index()
        {
            var products=await _productService.GetAllProductsDisplayResponsesAsync();
            return View(products);
        }
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Login(string username, string password)
        {
            var result = await _signInManager.PasswordSignInAsync(username, password, false, lockoutOnFailure: false);
            if (result.Succeeded)
            {
                var user = await _signInManager.UserManager.FindByNameAsync(username);
                if (user != null)
                {
                    var roles = await _signInManager.UserManager.GetRolesAsync(user);

                    if (roles.Contains("customer"))
                    {
                        var customer = _customerService.GetCustomerByUsername(user.UserName);
                        if (customer != null)
                        {
                            HttpContext.Session.SetInt32("CustomerId", customer.Id);
                            HttpContext.Session.SetString("Username", customer.UserName);
                            return RedirectToAction("Index", "Customer", new { id = customer.Id });
                        }

                    }
                    else if (roles.Contains("seller"))
                    {
                        var seller =await _sellerService.GetSellerByUsernameAsync(user.UserName);
                        if (seller != null)
                        {
                            HttpContext.Session.SetInt32("SellerId", seller.Id);
                            HttpContext.Session.SetString("Username", seller.Username);
                            return RedirectToAction("Index", "Seller", new { id = seller.Id });
                        }
                    }
                }
            }

            return RedirectToAction("Login");
        }
       
        [HttpGet]
        public  IActionResult ProductDetail(int productId)
        {
            var product=_productService.GetProductById(productId);
            
            return View(_mapper.Map<Product>(product));
        }
        [HttpGet]
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }
        public async Task<IActionResult> Categories()
        {
            var categories=await _categoryService.GetAllCategoryDisplayResponsesAsync();
            return View(categories);
        }
        public async Task<IActionResult> ProductByCategory(int Id)
        {
            var products = await _productService.GetAllProductsByCategoryIdAsync(Id);
            return View(products);
        }
        [HttpPost]
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