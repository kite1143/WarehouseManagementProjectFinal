using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System.Diagnostics;
using System.Xml;
using WarehouseManagementProject.Data;
using WarehouseManagementProject.Models;
using WarehouseManagementProject.ViewModels;

namespace WarehouseManagementProject.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        private readonly ApplicationDbContext adb;

        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger, ApplicationDbContext context)
        {
            adb = context;
            _logger = logger;
        }

        public IActionResult Index()
        {
            var totalInventoryQuantity = adb.Inventories.Sum(od => od.QuantityAvailable);
            var totalOrderQuantity = adb.OrderDetails.Sum(od => od.Quantity);
            var totalReceivingQuantity = adb.ReceivingDetails.Sum(rd => rd.Quantity);
            var cancelledOrderQuantity = (from order in adb.Orders
                 join orderDetail in adb.OrderDetails on order.OrderID equals orderDetail.OrderID
                 where order.Status == "Cancelled"
                 select orderDetail.Quantity).Sum();

            DashboardVM dbVM = new DashboardVM
            {
                inventoryQuantity = totalInventoryQuantity,
                ordersQuantity = totalOrderQuantity,
                orderCancelledQuantity = cancelledOrderQuantity,
                receivingQuantity = totalReceivingQuantity
            };

            return View(dbVM);
        }

        public IActionResult GetOrderQuantityByCategory()
        {
            var totalOrderQuantityByCategory =
                from order in adb.Orders
                join orderDetail in adb.OrderDetails on order.OrderID equals orderDetail.OrderID
                join product in adb.Product on orderDetail.ProductID equals product.ProductID
                join category in adb.Categories on product.CategoryID equals category.CategoryID
                group orderDetail by category.CategoryName into categoryGroup
                select new
                {
                    CategoryName = categoryGroup.Key,
                    TotalQuantity = categoryGroup.Sum(od => od.Quantity)
                } into result
                orderby result.CategoryName
                select result;


            return Json(new { data = totalOrderQuantityByCategory });
        }

        public IActionResult GetReceivingQuantityByCategory()
        {
            var totalReceivingQuantityByCategory =
                from receiving in adb.Receivings
                join receivingDetail in adb.ReceivingDetails on receiving.ReceivingID equals receivingDetail.ReceivingID
                join product in adb.Product on receivingDetail.ProductID equals product.ProductID
                join category in adb.Categories on product.CategoryID equals category.CategoryID
                group receivingDetail by category.CategoryName into categoryGroup
                select new
                {
                    CategoryName = categoryGroup.Key,
                    TotalQuantity = categoryGroup.Sum(rd => rd.Quantity)
                } into result
                orderby result.CategoryName
                select result;

            return Json(new { data = totalReceivingQuantityByCategory });
        }

        public IActionResult GetNumberOfOrderByStatus()
        {
            var numberOfOrdersByStatus =
                from order in adb.Orders
                group order by order.Status into statusGroup
                select new
                {
                    Status = statusGroup.Key,
                    NumberOfOrders = statusGroup.Count()
                } into result
                orderby result.Status
                select result;
            return Json(new { data = numberOfOrdersByStatus });
        }

        public IActionResult GetInventoryQuantityByCategory()
        {
            var totalInventoryQuantityByCategory =
                from inventory in adb.Inventories
                join product in adb.Product on inventory.ProductID equals product.ProductID
                join category in adb.Categories on product.CategoryID equals category.CategoryID
                group inventory by category.CategoryName into categoryGroup
                select new
                {
                    CategoryName = categoryGroup.Key,
                    TotalQuantity = categoryGroup.Sum(inv => inv.QuantityAvailable)
                } into result
                orderby result.CategoryName
                select result;
            return Json(new { data = totalInventoryQuantityByCategory });
        }

        public IActionResult GetLastestOrders()
        {
            var latestOrders = adb.Orders
                .Include(e => e.Customer)
                .OrderByDescending(order => order.OrderDate)
                .Take(10)
                .ToList();
            return Json(new { data = latestOrders });
        }

        public IActionResult GetLastestReceivings()
        {
            var latestReceivings = adb.Receivings
                .Include(e => e.Supplier)
                .Include(e => e.Warehouse)
                .OrderByDescending(receiving => receiving.ReceivingDate)
                .Take(10)
                .ToList();
            return Json(new { data = latestReceivings });
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
