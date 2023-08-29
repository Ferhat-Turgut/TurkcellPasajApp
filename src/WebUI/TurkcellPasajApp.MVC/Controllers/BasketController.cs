using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TurkcellPasajApp.DataTransferObjects.Requests;
using TurkcellPasajApp.Entities;
using TurkcellPasajApp.Services;

namespace TurkcellPasajApp.MVC.Controllers
{
    public class BasketController : Controller
    {
        private readonly IBasketService _basketService;

        public BasketController(IBasketService basketService)
        {
            _basketService = basketService;
        }

        [HttpPost]
        [Authorize(Roles = "customer")]
        public async Task<IActionResult> AddToBasket(int productId)
        {
            var customerId = HttpContext.Session.GetInt32("CustomerId");
            if (await _basketService.IsCustomerHaveBasketAsync((int)customerId))
            {
                var basketId = await _basketService.GetCustomerBasketIdAsync((int)customerId);
                var existingBasketProduct = await _basketService.GetBasketProductAsync(basketId, productId);
                if (existingBasketProduct != null)
                {
                    UpdateBasketProductsRequestDto basketProduct = new UpdateBasketProductsRequestDto
                    {
                        BasketId = basketId,
                        ProductId = productId,
                        Quantity = existingBasketProduct.Quantity + 1
                    };

                    await _basketService.UpdateBasketProductsAsync(basketProduct);
                }
                else
                {
                    CreateNewBasketProductRequestDto basketProduct = new CreateNewBasketProductRequestDto
                    {
                        BasketId = basketId,
                        ProductId = productId,
                        Quantity = 1
                    };

                    await _basketService.AddProductToBasketAsync(basketProduct);
                }

            }
            else
            {
                var newBasket = new CreateNewBasketRequestDto
                {
                    CustomerId = (int)customerId
                };
                await _basketService.CreateBasketAsync(newBasket);
                var basketId= await _basketService.GetCustomerBasketIdAsync((int)customerId);
                CreateNewBasketProductRequestDto basketProduct = new CreateNewBasketProductRequestDto
                {
                    BasketId = basketId,
                    ProductId = productId,
                    Quantity = 1
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
                BasketId = await _basketService.GetCustomerBasketIdAsync((int)customerId),
                ProductId = productId
            };
            await _basketService.RemoveProductToBasketProductAsync(basketProduct);
            return Json(new { success = true });
        }
        [Authorize(Roles = "customer")]
        public async Task<IActionResult> Basket()
        {
            var userId = HttpContext.Session.GetInt32("CustomerId");
            var basket = await _basketService.GetBasketAsync((int)userId);
            return View(basket);
        }
    }
}
