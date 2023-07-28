using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using TurkcellPasajApp.DataTransferObjects.Requests;
using TurkcellPasajApp.Services;

namespace TurkcellPasajApp.MVC.Controllers
{
    public class CustomerController : Controller
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public CustomerController(UserManager<IdentityUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            _userManager = userManager;
            _roleManager = roleManager;
        }

        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public async Task< IActionResult> Register(CreateNewCustomerRequestDto createNewCustomerRequestDto)
        {

            if (ModelState.IsValid)
            {
                var user = new IdentityUser
                {
                    UserName = createNewCustomerRequestDto.Username,
                    Email = createNewCustomerRequestDto.Email
                };

                var result = await _userManager.CreateAsync(user, createNewCustomerRequestDto.Password);
                if (result.Succeeded)
                {
                    if (!await _roleManager.RoleExistsAsync("customer"))
                    {
                        await _roleManager.CreateAsync(new IdentityRole("customer"));
                    }
                    await _userManager.AddToRoleAsync(user, "customer");
                    // Kayıt başarılı, giriş sayfasına yönlendir.
                    return RedirectToAction("Login", "Account");
                }

                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }
            }
            else
            {
                // ModelState geçerli değilse, hataları alıp gösterin.
                var errors = ModelState.Values.SelectMany(v => v.Errors.Select(e => e.ErrorMessage));
                foreach (var error in errors)
                {
                    ModelState.AddModelError(string.Empty, error);
                }
            }

            // Kayıt işlemi başarısız oldu, formu tekrar gösterin.
            return RedirectToAction("Register", "Home", createNewCustomerRequestDto);
        }
      
    }
}
