using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Web.Models;
using Web.Persistences;
using Web.Persistences.Repositories;

namespace Tests.Repositories
{
    [TestClass]
    public class OrderRepositoryTest
    {
        private BrainWareDbContext Context { get; set; }

        [TestInitialize]
        public void Setup()
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

        [TestMethod]
        public void OrderRepository_GetOrdersByCompanyId_MustReturn3Orders()
        {
            const int companyId = 1;

            var orders = OrderRepository.GetOrdersBy(companyId);

            Assert.IsTrue(orders.Count == 3);
        }
    }
}
