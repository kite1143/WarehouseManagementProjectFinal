using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WarehouseManagementProject.Data;
using WarehouseManagementProject.Models;

namespace WarehouseManagementProject.Controllers
{
    [Authorize]
    public class InventoryController : Controller
    {
        private readonly ApplicationDbContext applicationDbContext;

        public InventoryController(ApplicationDbContext context)
        {
            applicationDbContext = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Category category)
        {
            if (ModelState.IsValid)
            {
                applicationDbContext.Categories.Add(category);
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

            Category? categoryFromDb = applicationDbContext.Categories.FirstOrDefault(e => e.CategoryID == id);

            if (categoryFromDb == null)
            {
                return NotFound();
            }

            return View(categoryFromDb);
        }

        [HttpPost]
        public IActionResult Edit(Category obj)
        {
            if (ModelState.IsValid)
            {
                applicationDbContext.Categories.Update(obj);
                applicationDbContext.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View();
        }

        [HttpDelete]
        public IActionResult Delete(int? id)
        {

            Category? categoryToBeDelete = applicationDbContext.Categories.FirstOrDefault(e => e.CategoryID == id);

            if (categoryToBeDelete == null)
            {
                return Json(new { success = false, message = "error while deleting" });
            }
            try
            {
                applicationDbContext.Categories.Remove(categoryToBeDelete);
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
            IEnumerable<Inventory> inventories = applicationDbContext.Inventories.Include(e => e.Product).ToList();
            return Json(new { data = inventories });
        }
    }
}
