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

            return View("CustomerForm",viewModel);
        }

        [HttpPost]
        public ActionResult Create(Customer customer)
        {
            _context.Customers.Add(customer);
            _context.SaveChanges();

            return RedirectToAction("Index", "Customers");
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

        public ActionResult Edit(int id)
        {
            var customer = _context.Customers.SingleOrDefault(c => c.id == id);

            if (customer == null)
                return HttpNotFound();

            var viewModel = new CustomerFormViewModel
            {
                Customer = customer,
                MembershipTypes = _context.MembershipTypes.ToList()
            };

            return View("CustomerForm", viewModel);

        }

    }
}
