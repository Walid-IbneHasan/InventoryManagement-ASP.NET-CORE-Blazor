using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Extensions
{
    public static class OrderState
    {
        public const string Cancelled = "Cancelled";
        public const string Processing = "Processing";
        public const string Delivered = "Delivered";
        public const string Delivering = "Delivering";
    }
}
