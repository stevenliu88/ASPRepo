 
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using System.Web.Mvc;
using WebApplication2.ViewModels;
using WebApplication2.Models;
 

namespace WebApplication1.Controllers
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
            return View();
        }
        public ActionResult New()
        {
            var membershipType = _context.MembershipTypes.ToList();
            var viewModel = new NewCustomerViewModel()
            {
                Customer = new Customer(),
                MembershipTypes = membershipType
            };
            return View("CustomerForm",viewModel);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Customer customer)
        {
            if (!ModelState.IsValid)
            {
                var viewModel = new NewCustomerViewModel
                {
                    Customer = customer,
                    MembershipTypes = _context.MembershipTypes.ToList()
                };
                return View("CustomerForm",viewModel);
            }
            if (customer.Id == 0)
            {
                _context.Customers.Add(customer);
            }
            else
            {
                var customerInDb = _context.Customers.Single(c => c.Id == customer.Id);
             
                customerInDb.Name = customer.Name;
                customerInDb.Birthday = customer.Birthday;
                customerInDb.MembershipTypeId = customer.MembershipTypeId;
                customerInDb.isSubscribedTonewsletter = customer.isSubscribedTonewsletter;

            }
            _context.SaveChanges();
            
            return RedirectToAction("Index", "Customers");
        }
        public ActionResult Details(int id)
        {
            var customer = _context.Customers.Include(c=>c.MembershipType).SingleOrDefault(c => c.Id == id);
            if (customer == null)
                return HttpNotFound();
            return View(customer);
        }
        public ActionResult Edit(int id)
        {
            var customer = _context.Customers.SingleOrDefault(c => c.Id == id);
            if (customer == null)
                return HttpNotFound();
            var viewModel = new NewCustomerViewModel
            {
                Customer = customer,
                MembershipTypes = _context.MembershipTypes.ToList()
                
            };
            return View("CustomerForm",viewModel);
        }
    }
}