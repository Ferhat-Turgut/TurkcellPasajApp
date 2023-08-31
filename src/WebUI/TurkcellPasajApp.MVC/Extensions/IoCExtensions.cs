using Microsoft.EntityFrameworkCore;
using TurkcellPasajApp.Infrastructure.Data;
using TurkcellPasajApp.Infrastructure.Repositories;
using TurkcellPasajApp.Services;

namespace TurkcellPasajApp.MVC.Extensions
{
    public static class IoCExtensions
    {
        public static IServiceCollection AddInjections(this IServiceCollection services, string connectionString)
        {

            services.AddScoped<ICustomerService, CustomerService>();
            services.AddScoped<ICustomerRepository, EFCustomerRepository>();
            services.AddScoped<IProductService, ProductService>();
            services.AddScoped<IProductRepository, EFProductRepository>();
            services.AddScoped<ISellerService, SellerService>();
            services.AddScoped<ISellerRepository, EFSellerRepository>();
            services.AddScoped<IFavouriteService, FavouriteService>();
            services.AddScoped<IFavouriteRepository, EFFavouriteRepository>();
            services.AddScoped<IBasketService, BasketService>();
            services.AddScoped<IBasketRepository, EFBasketRepository>();
            services.AddScoped<ICategoryService, CategoryService>();
            services.AddScoped<ICategoryRepository, EFCategoryRepository>();
            services.AddScoped<IOrderRepository, EFOrderRepository>();
            services.AddScoped<IOrderService, OrderService>();
            services.AddScoped<IOrderDetailRepository, EFOrderDetailRepository>();
            services.AddScoped<IOrderDetailService, OrderDetailService>();
            services.AddScoped<ICreditCardRepository, EFCreditCardRepository>();
            services.AddScoped<ICreditCardService, CreditCardService>();

            //IoC
            services.AddDbContext<TurkcellPasajAppDbContext>(opt => opt.UseSqlServer(connectionString));

            return services;
        }
    }
}
