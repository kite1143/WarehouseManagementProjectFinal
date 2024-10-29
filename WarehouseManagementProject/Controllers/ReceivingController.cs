using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WarehouseManagementProject.Data;
using WarehouseManagementProject.Models;

namespace WarehouseManagementProject.Controllers
{
    [Authorize]
    public class ReceivingController : Controller
    {


        private readonly ApplicationDbContext applicationDbContext;

        public ReceivingController(ApplicationDbContext context)
        {
            applicationDbContext = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Create()
        {
            List<SelectListItem> listSuppliers = new List<SelectListItem>();
            foreach (Supplier s in applicationDbContext.Suppliers)
            {
                listSuppliers.Add(new SelectListItem
                {
                    Text = s.SupplierName,
                    Value = s.SupplierID.ToString()
                });
            }
            List<SelectListItem> listWarehouses = new List<SelectListItem>();
            foreach (Warehouse w in applicationDbContext.Warehouses)
            {
                listWarehouses.Add(new SelectListItem
                {
                    Text = w.WarehouseName,
                    Value = w.WarehouseID.ToString()
                });
            }
            ViewBag.ListSuppliers = listSuppliers;
            ViewBag.ListWarehouses = listWarehouses;

            return View();
        }

        [HttpPost]
        public IActionResult Create(Receiving receiving)
        {
            if (ModelState.IsValid)
            {
                applicationDbContext.Receivings.Add(receiving);
                applicationDbContext.SaveChanges();
                return RedirectToAction("Index", new RouteValueDictionary(
                    new { controller = "ReceivingDetails", action = "Index", receivingId = receiving.ReceivingID }));
            }
            return View(receiving);
        }

        public IActionResult Edit(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }

            Receiving? receivingFromDb = applicationDbContext.Receivings.FirstOrDefault(e => e.ReceivingID == id);

            if (receivingFromDb == null)
            {
                return NotFound();
            }

            List<SelectListItem> listSuppliers = new List<SelectListItem>();
            foreach(Supplier s in applicationDbContext.Suppliers)
            {
                listSuppliers.Add(new SelectListItem
                {
                    Text = s.SupplierName,
                    Value = s.SupplierID.ToString()
                });
            }
            List<SelectListItem> listWarehouses = new List<SelectListItem>();
            foreach (Warehouse w in applicationDbContext.Warehouses)
            {
                listWarehouses.Add(new SelectListItem
                {
                    Text = w.WarehouseName,
                    Value = w.WarehouseID.ToString()
                });
            }
            ViewBag.ListSuppliers = listSuppliers;
            ViewBag.ListWarehouses = listWarehouses;

            return View(receivingFromDb);
        }

        [HttpPost]
        public IActionResult Edit(Receiving obj)
        {
            if (ModelState.IsValid)
            {
                applicationDbContext.Receivings.Update(obj);
                applicationDbContext.SaveChanges();
                return RedirectToAction(nameof(Index));
            }

            List<SelectListItem> listSuppliers = new List<SelectListItem>();
            foreach (Supplier s in applicationDbContext.Suppliers)
            {
                listSuppliers.Add(new SelectListItem
                {
                    Text = s.SupplierName,
                    Value = s.SupplierID.ToString()
                });
            }
            List<SelectListItem> listWarehouses = new List<SelectListItem>();
            foreach (Warehouse w in applicationDbContext.Warehouses)
            {
                listWarehouses.Add(new SelectListItem
                {
                    Text = w.WarehouseName,
                    Value = w.WarehouseID.ToString()
                });
            }
            ViewBag.ListSuppliers = listSuppliers;
            ViewBag.ListWarehouses = listWarehouses;
            return View(obj.ReceivingID);
        }

        [HttpDelete]
        public IActionResult Delete(int? id)
        {

            Receiving? receivingToBeDelete = applicationDbContext.Receivings.FirstOrDefault(e => e.ReceivingID == id);

            if (receivingToBeDelete == null)
            {
                return Json(new { success = false, message = "error while deleting" });
            }
            try
            {
                applicationDbContext.Receivings.Remove(receivingToBeDelete);
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
            IEnumerable<Receiving> receivings = applicationDbContext.Receivings
                .Include(e => e.Supplier)
                .Include(e => e.Warehouse)
                .ToList();
            return Json(new { data = receivings });
        }
    }
}
