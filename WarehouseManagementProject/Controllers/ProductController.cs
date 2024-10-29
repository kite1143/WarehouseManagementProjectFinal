using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WarehouseManagementProject.Data;
using WarehouseManagementProject.Models;

namespace WarehouseManagementProject.Controllers
{
    [Authorize]
    public class ProductController : Controller
    {
        private readonly ApplicationDbContext applicationDbContext;

        public ProductController(ApplicationDbContext context)
        {
            applicationDbContext = context;
        }

        public IActionResult Index()
        {
            IEnumerable<Product> products = applicationDbContext.Product.ToList();
            return View(products);
        }

        public IActionResult Create()
        {
            List<SelectListItem> listCategories = new List<SelectListItem>();
            foreach(Category c in applicationDbContext.Categories)
            {
                listCategories.Add(new SelectListItem
                {
                    Value = c.CategoryID.ToString(),
                    Text = c.CategoryName
                });
            }
            ViewBag.ListCategories = listCategories;
            return View();
        }
        [HttpPost]
        public IActionResult Create(Product product)
        {
            if (ModelState.IsValid)
            {
                applicationDbContext.Product.Add(product);
                applicationDbContext.SaveChanges();
                Inventory inventory = new Inventory
                {
                    ProductID = product.ProductID,
                    QuantityAvailable = 0
                };
                applicationDbContext.Inventories.Add(inventory);
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

            Product? productFromDb = applicationDbContext.Product.FirstOrDefault(e => e.ProductID == id);

            if (productFromDb == null)
            {
                return NotFound();
            }
            List<SelectListItem> listCategories = new List<SelectListItem>();
            foreach (Category c in applicationDbContext.Categories)
            {
                listCategories.Add(new SelectListItem
                {
                    Value = c.CategoryID.ToString(),
                    Text = c.CategoryName
                });

            }
            ViewBag.ListCategories = listCategories;
            return View(productFromDb);
        }

        [HttpPost]
        public IActionResult Edit(Product obj)
        {
            if (ModelState.IsValid)
            {
                applicationDbContext.Product.Update(obj);
                applicationDbContext.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View();
        }

        [HttpDelete]
        public IActionResult Delete(int? id)
        {

            Product? productToBeDelete = applicationDbContext.Product.FirstOrDefault(e => e.ProductID == id);

            if (productToBeDelete == null)
            {
                return Json(new { success = false, message = "error while deleting" });
            }
            try
            {
                Inventory inventoryToBeDelete = applicationDbContext.Inventories.FirstOrDefault(e => e.ProductID == id);
                applicationDbContext.Inventories.Remove(inventoryToBeDelete);
                applicationDbContext.Product.Remove(productToBeDelete);
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
            IEnumerable<Product> products = applicationDbContext.Product.Include(e => e.Category);
            return Json(new { data = products });
        }
    }
}
