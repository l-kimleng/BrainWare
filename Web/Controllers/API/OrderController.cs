using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Web.Controllers
{
    using System.Web.Mvc;
    using Infrastructure;

    public class OrderController : ApiController
    {
        [HttpGet]
        public IEnumerable<Models.Old.Order> GetOrders(int id = 1)
        {
            var data = new OrderService();

            return data.GetOrdersForCompany(id);
        }
    }
}
