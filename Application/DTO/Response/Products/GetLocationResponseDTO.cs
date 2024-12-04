using Application.DTO.Request.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Application.DTO.Response.Products
{
    public class GetLocationResponseDTO:UpdateLocationRequestDTO
    {
        [JsonIgnore]
        public virtual ICollection<GetProductResponseDTO> Products { get; set; } = null;
    }
}
