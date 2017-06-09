using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
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


      

        public ActionResult New()
        {

            //var membershipTypes = _context.MembershipTypes.ToList();
            //var viewModel = new CustomerFormViewModel
            //{
            //    //For the new form if the Customer is not intialized the form will throw error.
            //    Customer = new Customer(),
            //    MembershipTypes = membershipTypes
            //};

            //return View("CustomerForm", viewModel);
            return View();


        }

        [HttpPost]
        public ActionResult Save(Customer customer)
        {


            if (!ModelState.IsValid)
            {
                var viewModel = new CustomerFormViewModel
                {
                    Customer = customer,
                    MembershipTypes = _context.MembershipTypes.ToList()
                };

                return View("CustomerForm", viewModel);
            }

            if (customer.Id == 0)
                _context.Customers.Add(customer);
            else
            {
                var customerInDb = _context.Customers.Single(c => c.Id == customer.Id);
                customerInDb.Name = customer.Name;
                customerInDb.BirthDate = customer.BirthDate;
                customerInDb.MembershipTypeId = customer.MembershipTypeId;
                customerInDb.IsSubscribedToNewsLetter = customer.IsSubscribedToNewsLetter;


            }

            _context.SaveChanges();

            return RedirectToAction("Index", "Customers");
        }

        public ActionResult Edit(int id)
        {
            var customer = _context.Customers.SingleOrDefault(c => c.Id == id);

            if (customer == null)
                return HttpNotFound();

            var viewModel = new CustomerFormViewModel
                {
                    Customer = customer,
                    MembershipTypes = _context.MembershipTypes.ToList()

                }
                ;

            return View("CustomerForm", viewModel);
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        // GET: Customers
        public ViewResult Index()
        {
            //var movies = _context.Movies.Include(m => m.Genre).ToList();
            if (User.IsInRole("CanManageMovies"))
            {
                return View("List");
            }
            else
            {
                return View("ReadOnlyList");
            }

        }


    }
}