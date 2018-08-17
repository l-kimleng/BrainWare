using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Web.Models;

namespace Web.Persistences.Repositories
{
    public interface IOrderRepository
    {
        IList<Order> GetOrdersBy(int companyId);
    }
}
