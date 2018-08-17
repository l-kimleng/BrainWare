using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Web.Models.Dtos
{
    public class OrderDto
    {
        public string Description { get; set; }
        public decimal OrderTotal { get; set; }

        public IEnumerable<OrderProductDto> OrderProducts { get; set; }

    }
}