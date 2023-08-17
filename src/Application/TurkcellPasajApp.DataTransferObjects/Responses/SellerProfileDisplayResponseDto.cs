using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TurkcellPasajApp.DataTransferObjects.Responses
{
    public class SellerProfileDisplayResponseDto
    {
        public SellerDisplayResponseDto Seller { get; set; }
        public IEnumerable<ProductDisplayResponseDto> Products { get; set; }
    }
}
