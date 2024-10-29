using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WarehouseManagementProject.Data;
using WarehouseManagementProject.Models;

namespace WarehouseManagementProject.Controllers
{
    [Authorize]
    public class OrderController : Controller
    {
        private readonly ApplicationDbContext applicationDbContext;

        public OrderController(ApplicationDbContext context)
        {
            applicationDbContext = context;
        }

        public IActionResult Index()
        {
            IEnumerable<Order> orders = applicationDbContext.Orders.ToList();
            return View(orders);
        }

        public IActionResult Create()
        {
            List<SelectListItem> listCustomers = new List<SelectListItem>();
            foreach (Customer c in applicationDbContext.Customers)
            {
                listCustomers.Add(new SelectListItem
                {
                    Text = c.CustomerName,
                    Value = c.CustomerID.ToString()
                });
            }
            List<SelectListItem> listStatus = new List<SelectListItem>
            {
                new SelectListItem { Text = "Pending", Value = "Pending" },
                new SelectListItem { Text = "Shipped", Value = "Shipped" },
                new SelectListItem { Text = "Delivered", Value = "Delivered" },
                new SelectListItem { Text = "Cancelled", Value = "Cancelled" },
                new SelectListItem { Text = "Completed", Value = "Completed" }
            };
            ViewBag.ListCustomers = listCustomers;
            ViewBag.ListStatus = listStatus;

            return View();
        }
        [HttpPost]
        public IActionResult Create(Order order)
        {
            if (ModelState.IsValid)
            {
                applicationDbContext.Orders.Add(order);
                applicationDbContext.SaveChanges();
                return RedirectToAction("Index", new RouteValueDictionary(
                    new { controller = "OrderDetails", action = "Index", orderId = order.OrderID}));
            }
            return View(order);
        }

        public IActionResult Edit(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }

            Order? orderFromDB = applicationDbContext.Orders
                .Include(e => e.Customer)
                .FirstOrDefault(e => e.OrderID == id);

            if (orderFromDB == null)
            {
                return NotFound();
            }
            List<SelectListItem> listCustomers = new List<SelectListItem>();
            foreach (Customer c in applicationDbContext.Customers)
            {
                listCustomers.Add(new SelectListItem
                {
                    Text = c.CustomerName,
                    Value = c.CustomerID.ToString()
                });
            }
            List<SelectListItem> listStatus = new List<SelectListItem>
            {
                new SelectListItem { Text = "Pending", Value = "Pending" },
                new SelectListItem { Text = "Shipped", Value = "Shipped" },
                new SelectListItem { Text = "Delivered", Value = "Delivered" },
                new SelectListItem { Text = "Cancelled", Value = "Cancelled" },
                new SelectListItem { Text = "Completed", Value = "Completed" }
            };
            ViewBag.ListCustomers = listCustomers;
            ViewBag.ListStatus = listStatus;

            return View(orderFromDB);
        }

        [HttpPost]
        public IActionResult Edit(Order obj)
        {
            if (ModelState.IsValid)
            {
                applicationDbContext.Orders.Update(obj);
                applicationDbContext.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            List<SelectListItem> listCustomers = new List<SelectListItem>();
            foreach (Customer c in applicationDbContext.Customers)
            {
                listCustomers.Add(new SelectListItem
                {
                    Text = c.CustomerName,
                    Value = c.CustomerID.ToString()
                });
            }
            List<SelectListItem> listStatus = new List<SelectListItem>
            {
                new SelectListItem { Text = "Pending", Value = "Pending" },
                new SelectListItem { Text = "Shipped", Value = "Shipped" },
                new SelectListItem { Text = "Delivered", Value = "Delivered" },
                new SelectListItem { Text = "Cancelled", Value = "Cancelled" },
                new SelectListItem { Text = "Completed", Value = "Completed" }
            };
            ViewBag.ListCustomers = listCustomers;
            ViewBag.ListStatus = listStatus;
            return View(obj.OrderID);
        }

        [HttpDelete]
        public IActionResult Delete(int? id)
        {

            Order? orderToBeDelete = applicationDbContext.Orders.FirstOrDefault(e => e.OrderID == id);

            if (orderToBeDelete == null)
            {
                return Json(new { success = false, message = "error while deleting" });
            }
            try
            {
                applicationDbContext.Orders.Remove(orderToBeDelete);
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
            IEnumerable<Order> orders = applicationDbContext.Orders.Include(e => e.Customer).ToList();
            return Json(new { data = orders });
        }
    }
}
