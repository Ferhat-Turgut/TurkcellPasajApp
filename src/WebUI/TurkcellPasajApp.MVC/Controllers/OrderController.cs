using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TurkcellPasajApp.DataTransferObjects.Requests;
using TurkcellPasajApp.MVC.ViewModels;
using TurkcellPasajApp.Services;

namespace TurkcellPasajApp.MVC.Controllers
{
    public class OrderController : Controller
    {
       
        private readonly IBasketService _basketService;
        private readonly ICustomerService _customerService;
        private readonly IOrderService _orderService;
        private readonly IOrderDetailService _orderDetailService;
        private readonly ICreditCardService _creditCardService;
        private readonly IMapper _mapper;

        public OrderController(IBasketService basketService, ICustomerService customerService, IOrderService orderService, IOrderDetailService orderDetailService, ICreditCardService creditCardService, IMapper mapper)
        {
            _basketService = basketService;
            _customerService = customerService;
            _orderService = orderService;
            _orderDetailService = orderDetailService;
            _creditCardService = creditCardService;
            _mapper = mapper;
        }
        [HttpGet]
        [Authorize(Roles = "customer")]
        public async Task<IActionResult> Index()
        {
            var customerId = HttpContext.Session.GetInt32("CustomerId");
            var basket = await _basketService.GetBasketAsync((int)customerId);
            var customer = await _customerService.GetCustomerByIdAsync((int)customerId);
            OrderViewModel orderViewModel = new OrderViewModel
            {
                Basket= basket,
                Customer=customer
            };
            return View(orderViewModel);
        }
        [HttpPost]
        [Authorize(Roles = "customer")]
        public async Task<IActionResult> CreateNewOrder()
        {
            var customerId = HttpContext.Session.GetInt32("CustomerId");
            var basket = await _basketService.GetBasketAsync((int)customerId);
            var customer = await _customerService.GetCustomerByIdAsync((int)customerId);
           
                CreateNewOrderRequestDto createNewOrder = new CreateNewOrderRequestDto
                {
                    CustomerId = (int)customerId,
                    Date = DateTime.Now
                };
                int orderId = await _orderService.CreateOrderAndReturnIdAsync(createNewOrder);

                foreach (var product in basket.BasketProducts)
                {
                    CreateNewOrderDetailRequestDto createNewOrderDetailRequest = new CreateNewOrderDetailRequestDto
                    {
                        Quantity = 1,
                        OrderId = orderId,
                        OrderProductId = product.ProductId
                    };
                    await _orderDetailService.CreateNewOrderDetailAsync(createNewOrderDetailRequest);
                }
                await _basketService.DeleteBasketAsync(basket.Id);
                return RedirectToAction("Index", "Customer");
           

           
        }
 

    }
}
