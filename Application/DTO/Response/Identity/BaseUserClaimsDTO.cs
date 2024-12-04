using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTO.Response.Identity
{
    public class BaseUserClaimsDTO
    {
        public string UserId { get; set; }
        public string Name { get; set; }
        public string Role  { get; set; }
        public bool ManageUser { get; set; }
        public bool Read    { get; set; }
        public bool Update { get; set; }
        public bool Delete { get; set; }
        public bool Create { get; set; }
    }
}
