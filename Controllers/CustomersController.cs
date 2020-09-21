using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vidly2.Models;
using Vidly2.ViewModels;

namespace Vidly2.Controllers
{
    public class CustomersController : Controller
    {
        public List<Customer> customersList = new List<Customer>
        {
            new Customer() { name="John Smith", id=1 },
            new Customer() {name="Mary Williams", id = 2},
        };


        // GET: Customers
        [Route("Customers")]
        public ActionResult Customers()
        {
            var viewModel = new CustomersViewModel()
            {
                customerList = this.customersList,
            };
            return View(viewModel);
        }

        // GET: Customers/Details/5
        [Route("Customers/Details/{id}")]
        public ActionResult Details(int id)
        {
            foreach (var customer in customersList)
            {
                if (customer.id == id)
                {
                    return View(customer);
                }
            }
            return View(new Customer() { id = -1 });
        }

        // GET: Customers/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Customers/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Customers/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Customers/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Customers/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Customers/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
