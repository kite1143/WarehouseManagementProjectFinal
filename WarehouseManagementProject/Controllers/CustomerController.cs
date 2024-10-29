using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WarehouseManagementProject.Data;
using WarehouseManagementProject.Models;

namespace WarehouseManagementProject.Controllers
{
    [Authorize]
    public class CustomerController : Controller
    {
        private readonly ApplicationDbContext applicationDbContext;

        public CustomerController(ApplicationDbContext context)
        {
            applicationDbContext = context;
        }

        public IActionResult Index()
        {
            IEnumerable<Customer> customers = applicationDbContext.Customers.ToList();
            return View(customers);
        }

        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Customer customer)
        {
            if (ModelState.IsValid)
            {
                applicationDbContext.Customers.Add(customer);
                applicationDbContext.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View();
        }

        public IActionResult Edit(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }

            Customer? customerFromDB = applicationDbContext.Customers.FirstOrDefault(e => e.CustomerID == id);

            if (customerFromDB == null)
            {
                return NotFound();
            }

            return View(customerFromDB);
        }

        [HttpPost]
        public IActionResult Edit(Customer obj)
        {
            if (ModelState.IsValid)
            {
                applicationDbContext.Customers.Update(obj);
                applicationDbContext.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View();
        }

        [HttpDelete]
        public IActionResult Delete(int? id)
        {

            Customer? customerToBeDelete = applicationDbContext.Customers.FirstOrDefault(e => e.CustomerID == id);

            if (customerToBeDelete == null)
            {
                return Json(new { success = false, message = "error while deleting" });
            }
            try
            {
                applicationDbContext.Customers.Remove(customerToBeDelete);
                applicationDbContext.SaveChanges();
            }
            catch (Exception e)
            {
                return Json(new { success = false, message = "Can't delete because this item is used as a foreign key in another table." });
            }
            return Json(new { success = true, message = "Delete Successful" });
        }

        public IActionResult GetAll()
        {
            IEnumerable<Customer> customers = applicationDbContext.Customers.ToList();
            return Json(new { data = customers });
        }
    }
}
