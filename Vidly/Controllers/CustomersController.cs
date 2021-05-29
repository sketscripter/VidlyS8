using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vidly.Models;
using Vidly.ViewModels;

namespace Vidly.Controllers
{
    public class CustomersController : Controller
    {
        private ApplicationDbContext _context;

        public CustomersController()
        {
            _context = new ApplicationDbContext();
        }

        public ActionResult Index()
        {
            var customers = _context.Customers.Include("MemberShipType").ToList();
            return View(customers);
        }

        public ActionResult Detail(int id)
        {
            var customer = _context.Customers.Include("MemberShipType").Where(c => c.Id == id).FirstOrDefault();
            if (customer == null)
            {
                return HttpNotFound();
            }
            else
            {
                return View(customer);
            }
        }

        [HttpGet]
        public ActionResult New()
        {
            var membershiptypes = _context.MemberShipTypes.ToList();
            var newCustomerViewModel = new customerViewModel()
            {
                MemberShipTypes = membershiptypes,
                Customer = new Customer()
            };
            return View(newCustomerViewModel);
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            var customerInDb = _context.Customers.Find(id);

            if(customerInDb == null)
            {
                return HttpNotFound();
            }

            var membershiptypes = _context.MemberShipTypes.ToList();

            var newCustomerViewModel = new customerViewModel()
            {
                MemberShipTypes = membershiptypes,
                Customer = customerInDb
            };

            return View(newCustomerViewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(Customer customer)
        {
            if (customer.Id == 0)
            {
                if(ModelState.IsValid == false)
                {
                    var membershiptypes = _context.MemberShipTypes.ToList();
                    var newCustomerViewModel = new customerViewModel()
                    {
                        MemberShipTypes = membershiptypes,
                        Customer = customer
                    };
                    return View("New",newCustomerViewModel);
                }
                _context.Customers.Add(customer);
            }
            else
            {
                if (ModelState.IsValid == false)
                {
                    var membershiptypes = _context.MemberShipTypes.ToList();
                    var newCustomerViewModel = new customerViewModel()
                    {
                        MemberShipTypes = membershiptypes,
                        Customer = customer
                    };
                    return View("Edit", newCustomerViewModel);
                }

                var CustomerInDb = _context.Customers.Find(customer.Id);

                CustomerInDb.Name = customer.Name;
                CustomerInDb.LastName = customer.LastName;
                CustomerInDb.IDN = customer.IDN;
                CustomerInDb.Email = customer.Email;
                CustomerInDb.Phone = customer.Phone;
                CustomerInDb.BirthDate = customer.BirthDate;
                CustomerInDb.MemberShipTypeId = customer.MemberShipTypeId;
                CustomerInDb.IsSubscribedToNewsLetter = customer.IsSubscribedToNewsLetter;
            }

            _context.SaveChanges();
            return RedirectToAction("Index");
        }

    }
            
}