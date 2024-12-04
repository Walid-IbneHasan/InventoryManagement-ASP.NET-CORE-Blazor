using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTO.Request.Orders
{
    public class UpdateClientOrderRequestDTO
    {
        public Guid OrderId { get; set; }
        public string OrderState { get; set; }
        public DateTime DeliveringDate { get; set; }=DateTime.Now;
    }
}
