using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WarehouseManagementProject.Data;
using WarehouseManagementProject.Models;

namespace WarehouseManagementProject.Controllers
{
    [Authorize]
    public class WarehouseController : Controller
    {
        private readonly ApplicationDbContext applicationDbContext;

        public WarehouseController(ApplicationDbContext context)
        {
            applicationDbContext = context;
        }

        public IActionResult Index()
        {
            IEnumerable<Warehouse> warehouses = applicationDbContext.Warehouses.ToList();
            return View(warehouses);
        }

        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Warehouse warehouse)
        {
            if (ModelState.IsValid)
            {
                applicationDbContext.Warehouses.Add(warehouse);
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

            Warehouse? warehouseFromDb = applicationDbContext.Warehouses.FirstOrDefault(e => e.WarehouseID == id);

            if (warehouseFromDb == null)
            {
                return NotFound();
            }

            return View(warehouseFromDb);
        }

        [HttpPost]
        public IActionResult Edit(Warehouse obj)
        {
            if (ModelState.IsValid)
            {
                applicationDbContext.Warehouses.Update(obj);
                applicationDbContext.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View();
        }

        [HttpDelete]
        public IActionResult Delete(int? id)
        {

            Warehouse? warehouseToBeDelete = applicationDbContext.Warehouses.FirstOrDefault(e => e.WarehouseID == id);

            if (warehouseToBeDelete == null)
            {
                return Json(new { success = false, message = "error while deleting" });
            }
            try
            {
                applicationDbContext.Warehouses.Remove(warehouseToBeDelete);
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
            IEnumerable<Warehouse> warehouses = applicationDbContext.Warehouses.ToList();
            return Json(new { data = warehouses });
        }
    }
}
