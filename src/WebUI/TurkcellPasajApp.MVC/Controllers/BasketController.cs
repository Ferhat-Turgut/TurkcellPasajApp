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
        public async Task<IActionResult> AddToBasket(int productId, int quantity, decimal basketProductAmount)
        {
            if (quantity < 1 || quantity > 10)
            {
                return Json(new { success = false, message = "Geçersiz miktar seçimi." });
            }
            var customerId = HttpContext.Session.GetInt32("CustomerId");
            var customerBasket = await _basketService.GetBasketAsync((int)customerId);

            if (customerBasket != null)
            {
                var ProductInBasket = await _basketService.GetBasketProductAsync(customerBasket.Id, productId);

                if (ProductInBasket != null)
                {
                    var existingBasketProduct = await _basketService.GetBasketProductAsync(customerBasket.Id, productId);
                    UpdateBasketProductsRequestDto updateBasketProductsRequestDto = new UpdateBasketProductsRequestDto
                    {
                        BasketId= customerBasket.Id,
                        ProductId= productId,
                        Quantity= existingBasketProduct.Quantity+quantity,
                        Amount=existingBasketProduct.Amount+basketProductAmount
                    };
                    await _basketService.UpdateBasketProductsAsync(updateBasketProductsRequestDto);
                    await _basketService.UpdateBasketAmountAsync(customerBasket.Id);
                }
                else
                {
                    var createNewBasketProductRequestDto = new CreateNewBasketProductRequestDto
                    {
                        BasketId = customerBasket.Id,
                        ProductId = productId,
                        Quantity = quantity,
                        Amount = basketProductAmount
                    };
                    await _basketService.AddProductToBasketAsync(createNewBasketProductRequestDto);
                    await _basketService.UpdateBasketAmountAsync(customerBasket.Id);
                }
            }
            else
            {
                var createNewBasketRequestDto = new CreateNewBasketRequestDto
                {
                    CustomerId = (int)customerId,
                    Amount = basketProductAmount
                };
                await _basketService.CreateBasketAsync(createNewBasketRequestDto);
                var newBasketId = await _basketService.GetCustomerBasketIdAsync((int)customerId);

                var newBasketProduct = new CreateNewBasketProductRequestDto
                {
                    BasketId = newBasketId,
                    ProductId = productId,
                    Quantity = quantity,
                    Amount = basketProductAmount
                };
                await _basketService.AddProductToBasketAsync(newBasketProduct);
                await _basketService.UpdateBasketAmountAsync(newBasketId);
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
