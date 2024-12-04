using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTO.Request.Identity
{
    public class CreateUserRequestDTO:LoginUserRequestDTO
    {
        [Required]
        public string Name { get; set; }
        [Required]
        [Compare(nameof(Password))]
        public string ConfirmPassword { get; set; }
        [Required]
        public string Policy { get; set; }
    }
}
