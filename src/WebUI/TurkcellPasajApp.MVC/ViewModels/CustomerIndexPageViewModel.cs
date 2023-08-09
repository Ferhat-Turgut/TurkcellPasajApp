﻿using TurkcellPasajApp.DataTransferObjects.Responses;
using TurkcellPasajApp.Entities;

namespace TurkcellPasajApp.MVC.ViewModels
{
    public class CustomerIndexPageViewModel
    {
        public IEnumerable<ProductDisplayResponseDto>? Products { get; set; }
        public IEnumerable<FavouriteDisplayResponseDto>? Favourites { get; set; }
    }
}