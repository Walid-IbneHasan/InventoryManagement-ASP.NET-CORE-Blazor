using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTO.Response.Orders
{
    public class GetOrderedProductsWithQuantityResponseDTO
    {
        public string ProductName { get; set; }
        public int QuantityOrdered { get; set; }
    }
}
