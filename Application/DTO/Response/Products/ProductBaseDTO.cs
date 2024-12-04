using NetcodeHub.Packages.Extensions.Attributes.RequiredGuid;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTO.Response.Products
{
    public class ProductBaseDTO
    {
        [Required]
        public string Name { get; set; }
        [Required]
        [Display(Name = "Serial Number")]
        public string SerialNumber { get; set; }
        [NetcodeHubRequiredGuid(ErrorMessage ="Product Location is Required")]
        [RegularExpression(@"^[{(]?[0-9a-fA-F]{8}[-]?(?:[0-9a-fA-F]{4}[-]?){3}[0-9a-fA-F]{12}[)}]?$", ErrorMessage = "Invalid Product Location")]
        public Guid LocationId { get; set; }
        [NetcodeHubRequiredGuid(ErrorMessage = "Product Category is Required")]
        [RegularExpression(@"^[{(]?[0-9a-fA-F]{8}[-]?(?:[0-9a-fA-F]{4}[-]?){3}[0-9a-fA-F]{12}[)}]?$", ErrorMessage = "Invalid Product Category")]
        public Guid CategoryId { get; set; }
        [Required]
        [DataType(DataType.Currency)]
        public decimal Price { get; set; }
        [Required]
        [Range(1,int.MaxValue)]
        public int Quantity { get; set; }
        [Required]
        [MinLength(10)]
        [MaxLength(5000)]
        public string Description { get; set; }
        [Required]
        [Display(Name = "Product Image")]
        public string Base64Image { get; set; }

    }
}
