using Application.DTO.Response.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTO.Request.Products
{
    public class UpdateProductRequestDTO:ProductBaseDTO
    {
        public Guid Id { get; set; }
    }
}
