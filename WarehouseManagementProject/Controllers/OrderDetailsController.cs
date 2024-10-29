using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using WarehouseManagementProject.Data;
using WarehouseManagementProject.Models;
using WarehouseManagementProject.ViewModels;

namespace WarehouseManagementProject.Controllers
{
    [Authorize]
    public class OrderDetailsController : Controller
    {
        private readonly ApplicationDbContext applicationDbContext;

        public OrderDetailsController(ApplicationDbContext context)
        {
            applicationDbContext = context;
        }

        public IActionResult Index(int orderId)
        {
            UpdateOrder(orderId);
            return View(orderId);
        }
        public bool QuantityIsZero(Product p)
        {
            Inventory? inventory = applicationDbContext.Inventories.FirstOrDefault(e => e.ProductID == p.ProductID);
            return (inventory.QuantityAvailable == 0);
        }
        public double CalculateOrderTotalAmount(int orderId)
        {
            IEnumerable<OrderDetail> orderDetails = applicationDbContext.OrderDetails
                .Include(e => e.Product)
                .Where(e => e.OrderID == orderId).ToList();
            if (orderDetails == null)
            {
                return 0;
            }
            double totalAmount = 0;
            foreach(OrderDetail od in orderDetails)
            {
                totalAmount += od.Product.UnitPrice * od.Quantity;
            }
            return Math.Round(totalAmount, 4);
        }

        public void UpdateOrder(int orderId)
        {
            Order? order = applicationDbContext.Orders.FirstOrDefault(e => e.OrderID == orderId);
            order.TotalAmount = CalculateOrderTotalAmount(order.OrderID);
            applicationDbContext.Update(order);
            applicationDbContext.SaveChanges();
        }

        public IActionResult Create(int orderId)
        {
            List<SelectListItem> listProducts = new List<SelectListItem>();
            foreach (Product p in applicationDbContext.Product.ToList())
            {
                if (QuantityIsZero(p))
                {
                    continue;
                }
                listProducts.Add(new SelectListItem
                {
                    Value = p.ProductID.ToString(),
                    Text = p.ProductName
                });
            }
            ViewBag.ListProducts = listProducts;
            OrderDetail od = new OrderDetail();
            od.OrderID = orderId;
            return View(od);
        }


        [HttpPost]
        public IActionResult Create(OrderDetail od)
        {
            Inventory? inventory = applicationDbContext.Inventories
                .FirstOrDefault(e => e.ProductID == od.ProductID);

            if(inventory.QuantityAvailable < od.Quantity)
            {
                ModelState.AddModelError("Quantity", "The quantity must less than: " + inventory.QuantityAvailable);
            }


            if (ModelState.IsValid)
            {
                applicationDbContext.OrderDetails.Add(od);
                inventory.QuantityAvailable = inventory.QuantityAvailable - od.Quantity;
                applicationDbContext.Update(inventory);
                applicationDbContext.SaveChanges();

                return RedirectToAction("Index", new RouteValueDictionary(
                    new { controller = "OrderDetails", action = "Index", orderId = od.OrderID }));
            }
            List<SelectListItem> listProducts = new List<SelectListItem>();
            foreach (Product p in applicationDbContext.Product.ToList())
            {
                if (QuantityIsZero(p))
                {
                    continue;
                }
                listProducts.Add(new SelectListItem
                {
                    Value = p.ProductID.ToString(),
                    Text = p.ProductName
                });
            }
            ViewBag.ListProducts = listProducts;
            return View(od);
        }

        

        public IActionResult Edit(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }

            OrderDetail? odFromDb = applicationDbContext.OrderDetails.FirstOrDefault(e => e.OrderDetailsID == id);

            if (odFromDb == null)
            {
                return NotFound();
            }
            OrderDetailsVM rdVM = new OrderDetailsVM
            {
                od = odFromDb,
                oldQuantity = odFromDb.Quantity
            };

            List<SelectListItem> listProducts = new List<SelectListItem>();
            foreach (Product p in applicationDbContext.Product.ToList())
            {
                if (QuantityIsZero(p))
                {
                    continue;
                }
                listProducts.Add(new SelectListItem
                {
                    Value = p.ProductID.ToString(),
                    Text = p.ProductName
                });
            }
            ViewBag.ListProducts = listProducts;

            return View(rdVM);
        }

        [HttpPost]
        public IActionResult Edit(OrderDetailsVM odVM)
        {
            Inventory? inventory = applicationDbContext.Inventories
                    .FirstOrDefault(e => e.ProductID == odVM.od.ProductID);

            if ((inventory.QuantityAvailable + odVM.oldQuantity) < odVM.od.Quantity)
            {
                ModelState.AddModelError("od.Quantity", "The quantity must less than: " + (inventory.QuantityAvailable + odVM.oldQuantity));
            }

            if (ModelState.IsValid)
            {
                applicationDbContext.OrderDetails.Update(odVM.od);
                inventory.QuantityAvailable = inventory.QuantityAvailable + odVM.oldQuantity;
                inventory.QuantityAvailable = inventory.QuantityAvailable - odVM.od.Quantity;
                applicationDbContext.Update(inventory);

                applicationDbContext.SaveChanges();
                return RedirectToAction("Index", new RouteValueDictionary(
                    new { controller = "OrderDetails", action = "Index", orderId = odVM.od.OrderID }));
            }

            List<SelectListItem> listProducts = new List<SelectListItem>();
            foreach (Product p in applicationDbContext.Product.ToList())
            {
                if (QuantityIsZero(p))
                {
                    continue;
                }
                listProducts.Add(new SelectListItem
                {
                    Value = p.ProductID.ToString(),
                    Text = p.ProductName
                });
            }
            ViewBag.ListProducts = listProducts;
            return View(odVM);
        }

        [HttpDelete]
        public IActionResult Delete(int? id)
        {

            OrderDetail? odToBeDelete = applicationDbContext.OrderDetails.FirstOrDefault(e => e.OrderDetailsID == id);
            int orderId = odToBeDelete.OrderID;
            if (odToBeDelete == null)
            {
                return Json(new { success = false, message = "error while deleting" });
            }
            try
            {
                Inventory? inventory = applicationDbContext.Inventories
                    .FirstOrDefault(e => e.ProductID == odToBeDelete.ProductID);
                inventory.QuantityAvailable = (inventory.QuantityAvailable + odToBeDelete.Quantity);
                applicationDbContext.Update(inventory);
                applicationDbContext.OrderDetails.Remove(odToBeDelete);
                applicationDbContext.SaveChanges();
            }
            catch (Exception e)
            {
                return Json(new { success = false, message = "Can't delete because this item is used as a foreign key in another table." });
            }
            UpdateOrder(orderId);
            return Json(new { success = true, message = "Delete Successful" });
        }

        [HttpGet]
        public IActionResult GetAll(int orderID)
        {
            IEnumerable<OrderDetail> orderDetails = applicationDbContext.OrderDetails
                .Include(e => e.Product)
                .Where(e => e.OrderID==orderID).ToList();
            return Json(new { data = orderDetails });
        }
    }
}
