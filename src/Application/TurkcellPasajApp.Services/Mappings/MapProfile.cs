using AutoMapper;
using Microsoft.AspNetCore.Identity;
using TurkcellPasajApp.DataTransferObjects.Requests;
using TurkcellPasajApp.DataTransferObjects.Responses;
using TurkcellPasajApp.Entities;

namespace TurkcellPasajApp.Services.Mappings
{
    public class MapProfile : Profile
    {
        public MapProfile()
        {
            CreateMap<Category, CategoryDisplayResponseDto>().ReverseMap();
            CreateMap<CreditCard, CreditCardDisplayResponseDto>().ReverseMap();
            CreateMap<Favourite, FavouriteDisplayResponseDto>().ReverseMap();
            CreateMap<Message, MessageDisplayResponseDto>().ReverseMap();
            CreateMap<Order, OrderDisplayResponseDto>().ReverseMap();
            CreateMap<Customer, CustomerDisplayResponseDto>().ReverseMap();
            CreateMap<Seller, SellerDisplayResponseDto>().ReverseMap();


            CreateMap<Product, ProductDisplayResponseDto>()
                   .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                  .ForMember(dest => dest.Category, opt => opt.MapFrom(src => src.Category))
                  .ForMember(dest => dest.Seller, opt => opt.MapFrom(src => src.Seller))
                  .ReverseMap();

           

            CreateMap<OrderDetail, OrderDetailsDisplayResponseDto>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.OrderId, opt => opt.MapFrom(src => src.OrderId))
                .ForMember(dest => dest.Order, opt => opt.MapFrom(src => src.Order))
                .ForMember(dest => dest.OrderDetailsProductId, opt => opt.MapFrom(src => src.OrderDetailsProductId))
                .ForMember(dest => dest.OrderDetailsProduct, opt => opt.MapFrom(src => src.OrderDetailsProduct))
                .ForMember(dest => dest.Quantity, opt => opt.MapFrom(src => src.Quantity))
                .ReverseMap();


            CreateMap<Seller, SellerProfileDisplayResponseDto>()
               .ForMember(dest => dest.Seller, opt => opt.MapFrom(src => src))
               .ForMember(dest => dest.Products, opt => opt.MapFrom(src => src.Products))
               .ForMember(dest => dest.OrderDetails, opt => opt.MapFrom(src => src.SellersOrderDetails))
               .ReverseMap();



            CreateMap<Customer, CustomerDisplayResponseDto>()
                    .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                    .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
                    .ForMember(dest => dest.Surname, opt => opt.MapFrom(src => src.Surname))
                    .ForMember(dest => dest.Username, opt => opt.MapFrom(src => src.UserName))
                    .ForMember(dest => dest.BirthDate, opt => opt.MapFrom(src => src.BirthDate))
                    .ForMember(dest => dest.Gender, opt => opt.MapFrom(src => src.Gender))
                    .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.Email))
                    .ForMember(dest => dest.PhoneNumber, opt => opt.MapFrom(src => src.PhoneNumber))
                    .ForMember(dest => dest.Address, opt => opt.MapFrom(src => src.Address))
                    .ForMember(dest => dest.IsActive, opt => opt.MapFrom(src => src.IsActive))
                    .ForMember(dest => dest.creditCards, opt => opt.MapFrom(src => src.CreditCards));

            CreateMap<Customer, CustomerProfileDisplayResponseDto>()
                .ForMember(dest => dest.Customer, opt => opt.MapFrom(src => src))
                .ForMember(dest => dest.Orders, opt => opt.MapFrom(src => src.Orders))
                .ForMember(dest => dest.FavouriteProducts, opt => opt.MapFrom(src => src.Favourites.Where(f => f.IsFavourite).Select(f => f.FavouriteProduct)));






            CreateMap<CreateNewCategoryRequestDto, Category>().ReverseMap();
            CreateMap<CreateNewCommetRequestDto, Comment>().ReverseMap();
            CreateMap<CreateNewCreditCardRequestDto, CreditCard>().ReverseMap();
            CreateMap<CreateNewCustomerRequestDto, Customer>().ReverseMap();
            CreateMap<CreateNewFavouriteRequestDto, Favourite>().ReverseMap();
            CreateMap<CreateNewMessageRequestDto, Message>().ReverseMap();
            CreateMap<CreateNewOrderDetailRequestDto, OrderDetail>().ReverseMap();
            CreateMap<CreateNewOrderRequestDto, Order>().ReverseMap();
            CreateMap<CreateNewProductRequestDto, Product>().ReverseMap();
            CreateMap<CreateNewSellerRequestDto, Seller>().ReverseMap();

            CreateMap<UpdateProductRequestDto, Product>()
                 .ForMember(dest => dest.CategoryId, opt => opt.MapFrom(src => src.CategoryId))
                 .ReverseMap();

            CreateMap<UpdateCategoryRequestDto, Category>().ReverseMap();
            CreateMap<UpdateCustomerRequestDto, Customer>().ReverseMap();
            CreateMap<UpdateSellerRequestDto, Seller>().ReverseMap();
            CreateMap<UpdateCreditCardRequestDto, CreditCard>().ReverseMap();

            CreateMap<UpdateCustomerRequestDto, CustomerDisplayResponseDto>().ReverseMap();


            CreateMap<CreateNewCustomerRequestDto, IdentityUser>().ReverseMap();

        }
    }

}

