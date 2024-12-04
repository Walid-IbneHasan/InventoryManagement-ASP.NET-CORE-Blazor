using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTO.Request.Products
{
    public class AddCategoryRequestDTO
    {
        [Required]
        public string Name { get; set; }
    }
}
