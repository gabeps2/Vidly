using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vidly2.Models;
using Vidly2.ViewModels;
using System.Data.Entity;

namespace Vidly2.Controllers
{
    public class CustomersController : Controller
    {
        private ApplicationDbContext _context;

        public CustomersController()
        {
            _context = new ApplicationDbContext();
        }

        public ActionResult New()
        {
            var membershipTypes = _context.MembershipTypes.ToList();
            var viewModel = new NewCustomerViewModel { MembershipTypes = membershipTypes };

            return View(viewModel);
        }

        [HttpPost]
        public ActionResult Create(NewCustomerViewModel viewModel)
        {
            return View();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        // GET: Customers
        [Route("Customers")]
        public ActionResult Index()
        {
            var customers = _context.Customers.Include(c => c.MembershipType).ToList();
            return View(new CustomersViewModel(customers));
        }

        // GET: Customers/Details/5
        [Route("Customers/Details/{id}")]
        public ActionResult Details(int id)
        {
            var customersList = _context.Customers.Include(c => c.MembershipType).ToList();

            foreach (var customer in customersList)
            {
                if (customer.id == id)
                {
                    return View(customer);
                }
            }
            return View(new Customer() { id = -1 });
        }

    }
}
