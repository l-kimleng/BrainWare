using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using Web.Models;
using Web.Models.Dtos;
using Web.Persistences;
using Web.Persistences.Repositories;

namespace Web.Controllers.API
{
    public class OrdersController : ApiController
    {
        private BrainWareDbContext Context { get; }

        public OrdersController()
        {
            Context = BrainWareDbContext.Create();
        }

        private IOrderRepository _orderRepository;
        public IOrderRepository OrderRepository
        {
            get
            {
                if (_orderRepository == null)
                {
                    return _orderRepository = new OrderRepository(Context);
                }
                return _orderRepository;
            }
        }

        [System.Web.Mvc.HttpGet]
        public IHttpActionResult GetOrders(int id = 1)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var orders = OrderRepository.GetOrdersBy(id);

            if (orders.Count == 0)
                return NotFound();

            return Ok(MapDto(orders));
        }

        // This can replace by auto mapper
        private IEnumerable<OrderDto> MapDto(IEnumerable<Order> orders)
        {
            return orders.Select(x => new OrderDto
            {
                Description = x.Description,
                OrderTotal = x.OrderTotal,
                OrderProducts = x.OrderProducts.Select(y => new OrderProductDto
                {
                    Price = y.Product.Price ?? 0.0m,
                    Quantity = y.Quantity,
                    ProductName = y.Product.Name
                }).ToArray()

            }).ToArray();
        }

        protected override void Dispose(bool disposing)
        {
            Context.Dispose();
            base.Dispose(disposing);
        }
    }
}
