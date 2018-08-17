using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using Web.Models;

namespace Web.Persistences.Repositories
{
    public class OrderRepository : IOrderRepository
    {
        private readonly BrainWareDbContext _context;

        public OrderRepository(BrainWareDbContext context)
        {
            _context = context;
        }

        public IList<Order> GetOrdersBy(int companyId)
        {
            var queryable = _context.Orders
                .Include(x => x.OrderProducts)
                .Include(x => x.Company)
                .Include("OrderProducts.Product")
                .Where(x => x.CompanyId == companyId);

            var orders = queryable.ToList();

            foreach (var order in orders)
            {
                order.OrderTotal = order.OrderProducts
                    .Where(x => x.OrderId == order.Id)
                    .Sum(x => (x.Price ?? 0.0m) * x.Quantity);
            }

            return orders;
        }
    }
}