﻿
namespace TurkcellPasajApp.DataTransferObjects.Responses
{
    public class BasketDisplayResponseDto
    {
        public int Id { get; set; }
        public int CustomerId { get; set; }
        public decimal Amount { get; set; }
        public CustomerDisplayResponseDto Customer { get; set; }
        public List<BasketProductsDisplayResponseDto> BasketProducts { get; set; }
    }
}

