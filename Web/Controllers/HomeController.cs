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
        public ActionResult Index()
        {
            return View();
        }

        
    }
}
