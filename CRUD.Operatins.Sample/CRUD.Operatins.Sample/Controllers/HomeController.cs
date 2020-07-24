using CRUD.Operatins.Sample.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CRUD.Operatins.Sample.Controllers
{
    public class HomeController : Controller
    {
        //GET : HOME
        public ActionResult Index()
        {
            CustomersEntities1 entities = new CustomersEntities1();
            List<Customer> customers = entities.Customers.ToList();
            if (customers.Count == 0)
            {
                customers.Add(new Customer());
            }

            return View(customers);
             
        }
    }
}
