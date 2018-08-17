using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Web.Persistences;
using Web.Persistences.Repositories;

namespace Web.Controllers
{
    using Infrastructure;

    public class HomeController : Controller
    {
        private BrainWareDbContext Context { get; set; }

        public HomeController()
        {
            Context = BrainWareDbContext.Create();
        }

        public ActionResult Index()
        {
            var orders = OrderRepository.GetOrdersBy(1);
            return View();
        }


        protected override void Dispose(bool disposing)
        {
            Context.Dispose();
            base.Dispose(disposing);
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

        
    }
}
