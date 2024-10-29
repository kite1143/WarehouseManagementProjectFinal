using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WarehouseManagementProject.Data;
using WarehouseManagementProject.Models;
using WarehouseManagementProject.ViewModels;

namespace WarehouseManagementProject.Controllers
{
    [Authorize]
    public class ReceivingDetailsController : Controller
    {
        private readonly ApplicationDbContext applicationDbContext;

        public ReceivingDetailsController(ApplicationDbContext context)
        {
            applicationDbContext = context;
        }

        public IActionResult Index(int receivingId)
        {
            return View(receivingId);
        }

        public IActionResult Create(int receivingId)
        {
            List<SelectListItem> listProducts = new List<SelectListItem>();
            foreach(Product p in applicationDbContext.Product.ToList())
            {
                listProducts.Add(new SelectListItem
                {
                    Value = p.ProductID.ToString(),
                    Text = p.ProductName
                });
            }
            ViewBag.ListProducts = listProducts;
            ReceivingDetail rd = new ReceivingDetail();
            rd.ReceivingID = receivingId;
            return View(rd);
        }
        [HttpPost]
        public IActionResult Create(ReceivingDetail rd)
        {
            if (ModelState.IsValid)
            {
                applicationDbContext.ReceivingDetails.Add(rd);

                Inventory? inventory = applicationDbContext.Inventories
                    .FirstOrDefault(e => e.ProductID == rd.ProductID);
                inventory.QuantityAvailable = inventory.QuantityAvailable + rd.Quantity;
                applicationDbContext.Update(inventory);

                applicationDbContext.SaveChanges();
                return RedirectToAction("Index", new RouteValueDictionary(
                    new { controller = "ReceivingDetails", action = "Index", receivingId = rd.ReceivingID }));

            }
            List<SelectListItem> listProducts = new List<SelectListItem>();
            foreach (Product p in applicationDbContext.Product.ToList())
            {
                listProducts.Add(new SelectListItem
                {
                    Value = p.ProductID.ToString(),
                    Text = p.ProductName
                });
            }
            ViewBag.ListProducts = listProducts;
            return View(rd);
        }

        public IActionResult Edit(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }

            ReceivingDetail? rdFromDb = applicationDbContext.ReceivingDetails.FirstOrDefault(e => e.ReceivingDetailsID == id);

            if (rdFromDb == null)
            {
                return NotFound();
            }
            ReceivingDetailsVM rdVM = new ReceivingDetailsVM
            {
                rd = rdFromDb,
                oldRDQuantity = rdFromDb.Quantity
            };


            List<SelectListItem> listProducts = new List<SelectListItem>();
            foreach (Product p in applicationDbContext.Product.ToList())
            {
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
        public IActionResult Edit(ReceivingDetailsVM rdVM)
        {
            if (ModelState.IsValid)
            {
                applicationDbContext.ReceivingDetails.Update(rdVM.rd);

                Inventory? inventory = applicationDbContext.Inventories
                    .FirstOrDefault(e => e.ProductID == rdVM.rd.ProductID);
                inventory.QuantityAvailable = Math.Max((inventory.QuantityAvailable - rdVM.oldRDQuantity), 0);
                inventory.QuantityAvailable = inventory.QuantityAvailable + rdVM.rd.Quantity;
                applicationDbContext.Update(inventory);

                applicationDbContext.SaveChanges();
                return RedirectToAction("Index", new RouteValueDictionary(
                    new { controller = "ReceivingDetails", action = "Index", receivingId = rdVM.rd.ReceivingID }));
            }
            List<SelectListItem> listProducts = new List<SelectListItem>();
            foreach (Product p in applicationDbContext.Product.ToList())
            {
                listProducts.Add(new SelectListItem
                {
                    Value = p.ProductID.ToString(),
                    Text = p.ProductName
                });
            }
            ViewBag.ListProducts = listProducts;
            return View(rdVM.rd.ReceivingID);
        }

        [HttpDelete]
        public IActionResult Delete(int? id)
        {

            ReceivingDetail? rdToBeDelete = applicationDbContext.ReceivingDetails.FirstOrDefault(e => e.ReceivingDetailsID == id);

            if (rdToBeDelete == null)
            {
                return Json(new { success = false, message = "error while deleting" });
            }
            try
            {
                Inventory? inventory = applicationDbContext.Inventories
                    .FirstOrDefault(e => e.ProductID == rdToBeDelete.ProductID);
                inventory.QuantityAvailable = Math.Max((inventory.QuantityAvailable - rdToBeDelete.Quantity), 0);
                applicationDbContext.Update(inventory);

                applicationDbContext.ReceivingDetails.Remove(rdToBeDelete);
                applicationDbContext.SaveChanges();
            }
            catch (Exception e)
            {
                return Json(new { success = false, message = "Can't delete because this item is used as a foreign key in another table." });
            }
            return Json(new { success = true, message = "Delete Successful" });
        }



        public IActionResult GetAll(int receivingID)
        {
            IEnumerable<ReceivingDetail> receivingDetails = applicationDbContext.ReceivingDetails
                                                            .Include(e => e.Product)
                                                            .Where(e => e.ReceivingID==receivingID)
                                                            .ToList();
            return Json(new { data = receivingDetails });
        }
    }
}
