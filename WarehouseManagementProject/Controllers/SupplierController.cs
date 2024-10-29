﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WarehouseManagementProject.Data;
using WarehouseManagementProject.Models;

namespace WarehouseManagementProject.Controllers
{
    [Authorize]
    public class SupplierController : Controller
    {
        private readonly ApplicationDbContext applicationDbContext;

        public SupplierController(ApplicationDbContext context)
        {
            applicationDbContext = context;
        }

        public IActionResult Index()
        {
            IEnumerable<Supplier> suppliers = applicationDbContext.Suppliers.ToList();
            return View(suppliers);
        }

        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Supplier supplier)
        {
            if (ModelState.IsValid)
            {
                applicationDbContext.Suppliers.Add(supplier);
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

            Supplier? supplierFromDb = applicationDbContext.Suppliers.FirstOrDefault(e => e.SupplierID == id);

            if (supplierFromDb == null)
            {
                return NotFound();
            }

            return View(supplierFromDb);
        }

        [HttpPost]
        public IActionResult Edit(Supplier obj)
        {
            if (ModelState.IsValid)
            {
                applicationDbContext.Suppliers.Update(obj);
                applicationDbContext.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View();
        }

        [HttpDelete]
        public IActionResult Delete(int? id)
        {

            Supplier? supplierFromDb = applicationDbContext.Suppliers.FirstOrDefault(e => e.SupplierID == id);

            if (supplierFromDb == null)
            {
                return Json(new { success = false, message = "error while deleting" });
            }
            try
            {
                applicationDbContext.Suppliers.Remove(supplierFromDb);
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
            IEnumerable<Supplier> suppliers = applicationDbContext.Suppliers.ToList();
            return Json(new { data = suppliers });
        }

    }
}