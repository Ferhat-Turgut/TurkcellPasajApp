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
            CreateMap<Product, ProductDisplayResponseDto>().ReverseMap();
            CreateMap<Customer, CustomerDisplayResponseDto>().ReverseMap();
            CreateMap<Seller, SellerDisplayResponseDto>();

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

            CreateMap<UpdateProductRequestDto, Product>().ReverseMap();
            CreateMap<UpdateCategoryRequestDto, Category>().ReverseMap();
            CreateMap<UpdateCustomerRequestDto, Customer>().ReverseMap();
            CreateMap<UpdateSellerRequestDto, Seller>().ReverseMap();
            CreateMap<UpdateCreditCardRequestDto, CreditCard>().ReverseMap();

            CreateMap<UpdateCustomerRequestDto, CustomerDisplayResponseDto>().ReverseMap();


            CreateMap<CreateNewCustomerRequestDto,IdentityUser>().ReverseMap();

        }
    }

}

