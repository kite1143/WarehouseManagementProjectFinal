using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using WarehouseManagementProject.Models;
using WarehouseManagementProject.Utilities;

namespace WarehouseManagementProject.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Product { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Supplier> Suppliers { get; set; }
        public DbSet<Warehouse> Warehouses { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderDetail> OrderDetails { get; set; }
        public DbSet<Receiving> Receivings { get; set; }
        public DbSet<ReceivingDetail> ReceivingDetails { get; set; }
        public DbSet<Inventory> Inventories { get; set; }
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Customer>().HasData(
                new Customer { CustomerID = 1, CustomerName = "Alice Johnson", ContactInfo = "alice.johnson@email.com", Address = "123 Main St, City A", PhoneNumber = "123-456-7890" },
                new Customer { CustomerID = 2, CustomerName = "Bob Smith", ContactInfo = "bob.smith@email.com", Address = "456 Elm St, City B", PhoneNumber = "234-567-8901" },
                new Customer { CustomerID = 3, CustomerName = "Carol White", ContactInfo = "carol.white@email.com", Address = "789 Maple Ave, City C", PhoneNumber = "345-678-9012" },
                new Customer { CustomerID = 4, CustomerName = "David Brown", ContactInfo = "david.brown@email.com", Address = "101 Pine Rd, City D", PhoneNumber = "456-789-0123" },
                new Customer { CustomerID = 5, CustomerName = "Eva Green", ContactInfo = "eva.green@email.com", Address = "202 Oak Blvd, City E", PhoneNumber = "567-890-1234" }
            );
            modelBuilder.Entity<Warehouse>().HasData(
                new Warehouse { WarehouseID = 1, WarehouseName = "Central Warehouse", Location = "Downtown City A" },
                new Warehouse { WarehouseID = 2, WarehouseName = "Northside Warehouse", Location = "Uptown City B" },
                new Warehouse { WarehouseID = 3, WarehouseName = "East End Warehouse", Location = "East District City C" },
                new Warehouse { WarehouseID = 4, WarehouseName = "Westside Warehouse", Location = "Westside City D" },
                new Warehouse { WarehouseID = 5, WarehouseName = "Southpoint Warehouse", Location = "Southside City E" }
            );
            modelBuilder.Entity<Supplier>().HasData(
                new Supplier { SupplierID = 1, SupplierName = "Alpha Supplies", ContactInfo = "contact@alphasupplies.com", Address = "101 Alpha Ave, City A", PhoneNumber = "123-456-7890" },
                new Supplier { SupplierID = 2, SupplierName = "Beta Industries", ContactInfo = "info@betaindustries.com", Address = "202 Beta Blvd, City B", PhoneNumber = "234-567-8901" },
                new Supplier { SupplierID = 3, SupplierName = "Gamma Goods", ContactInfo = "support@gammagoods.com", Address = "303 Gamma St, City C", PhoneNumber = "345-678-9012" },
                new Supplier { SupplierID = 4, SupplierName = "Delta Wholesale", ContactInfo = "sales@deltawholesale.com", Address = "404 Delta Rd, City D", PhoneNumber = "456-789-0123" },
                new Supplier { SupplierID = 5, SupplierName = "Epsilon Enterprises", ContactInfo = "inquiry@epsilon.com", Address = "505 Epsilon Ln, City E", PhoneNumber = "567-890-1234" }
            );
            modelBuilder.Entity<Category>().HasData(
                new Category { CategoryID = 1, CategoryName = "Electronics" },
                new Category { CategoryID = 2, CategoryName = "Household Items" },
                new Category { CategoryID = 3, CategoryName = "Office Supplies" },
                new Category { CategoryID = 4, CategoryName = "Outdoor Gear" },
                new Category { CategoryID = 5, CategoryName = "Sports Equipment" }
            );
            modelBuilder.Entity<Product>().HasData(
               new Product { ProductID = 1, ProductName = "Laptop", CategoryID = 1, UnitPrice = 999.99, Description = "High-performance laptop"},
               new Product { ProductID = 2, ProductName = "Vacuum Cleaner", CategoryID = 2, UnitPrice = 150.00, Description = "Bagless vacuum cleaner"},
               new Product { ProductID = 3, ProductName = "Office Chair", CategoryID = 3, UnitPrice = 120.50, Description = "Ergonomic office chair"},
               new Product { ProductID = 4, ProductName = "Tent", CategoryID = 4, UnitPrice = 200.75, Description = "Two-person tent"},
               new Product { ProductID = 5, ProductName = "Soccer Ball", CategoryID = 5, UnitPrice = 30.00, Description = "Standard size soccer ball"},
               new Product { ProductID = 6, ProductName = "Smartphone", CategoryID = 1, UnitPrice = 699.99, Description = "Latest model smartphone"},
               new Product { ProductID = 7, ProductName = "Blender", CategoryID = 2, UnitPrice = 49.99, Description = "High-speed blender"},
               new Product { ProductID = 8, ProductName = "Desk Lamp", CategoryID = 3, UnitPrice = 25.75, Description = "LED desk lamp"},
               new Product { ProductID = 9, ProductName = "Backpack", CategoryID = 4, UnitPrice = 45.50, Description = "Water-resistant backpack"},
               new Product { ProductID = 10, ProductName = "Basketball", CategoryID = 5, UnitPrice = 25.00, Description = "Professional basketball"}
            );
            modelBuilder.Entity<Inventory>().HasData(
                new Inventory { InventoryID = 1, ProductID = 1, QuantityAvailable = 100 },
                new Inventory { InventoryID = 2, ProductID = 2, QuantityAvailable = 50 },
                new Inventory { InventoryID = 3, ProductID = 3, QuantityAvailable = 75 },
                new Inventory { InventoryID = 4, ProductID = 4, QuantityAvailable = 120 },
                new Inventory { InventoryID = 5, ProductID = 5, QuantityAvailable = 30 },
                new Inventory { InventoryID = 6, ProductID = 6, QuantityAvailable = 60 },
                new Inventory { InventoryID = 7, ProductID = 7, QuantityAvailable = 40 },
                new Inventory { InventoryID = 8, ProductID = 8, QuantityAvailable = 90 },
                new Inventory { InventoryID = 9, ProductID = 9, QuantityAvailable = 55 },
                new Inventory { InventoryID = 10, ProductID = 10, QuantityAvailable = 25 }
            );
            modelBuilder.Entity<Order>().HasData(
                new Order { OrderID = 1, OrderDate = new DateTime(2023, 9, 1), TotalAmount = 2025.73, Status = "Completed", CustomerID = 1 },
                new Order { OrderID = 2, OrderDate = new DateTime(2023, 9, 5), TotalAmount = 5361.45, Status = "Pending", CustomerID = 2 },
                new Order { OrderID = 3, OrderDate = new DateTime(2023, 9, 10), TotalAmount = 525.75, Status = "Completed", CustomerID = 3 },
                new Order { OrderID = 4, OrderDate = new DateTime(2023, 9, 15), TotalAmount = 1119.99, Status = "Shipped", CustomerID = 4 },
                new Order { OrderID = 5, OrderDate = new DateTime(2023, 9, 20), TotalAmount = 370.45, Status = "Cancelled", CustomerID = 5 }
            );

            modelBuilder.Entity<OrderDetail>().HasData(
                new OrderDetail { OrderDetailsID = 1, OrderID = 1, ProductID = 1, Quantity = 2},
                new OrderDetail { OrderDetailsID = 2, OrderID = 2, ProductID = 2, Quantity = 1 },
                new OrderDetail { OrderDetailsID = 3, OrderID = 2, ProductID = 1, Quantity = 3  },
                new OrderDetail { OrderDetailsID = 4, OrderID = 2, ProductID = 3, Quantity = 1  },
                new OrderDetail { OrderDetailsID = 5, OrderID = 2, ProductID = 2, Quantity = 2 },
                new OrderDetail { OrderDetailsID = 6, OrderID = 3, ProductID = 4, Quantity = 1 },
                new OrderDetail { OrderDetailsID = 7, OrderID = 4, ProductID = 5, Quantity = 4 },
                new OrderDetail { OrderDetailsID = 8, OrderID = 2, ProductID = 6, Quantity = 2 },
                new OrderDetail { OrderDetailsID = 9, OrderID = 5, ProductID = 3, Quantity = 1 },
                new OrderDetail { OrderDetailsID = 10, OrderID = 5, ProductID = 7, Quantity = 5 },
                new OrderDetail { OrderDetailsID = 11, OrderID = 1, ProductID = 8, Quantity = 1 },
                new OrderDetail { OrderDetailsID = 12, OrderID = 2, ProductID = 9, Quantity = 2 },
                new OrderDetail { OrderDetailsID = 13, OrderID = 3, ProductID = 10, Quantity = 13 },
                new OrderDetail { OrderDetailsID = 14, OrderID = 4, ProductID = 1, Quantity = 1 },
                new OrderDetail { OrderDetailsID = 15, OrderID = 2, ProductID = 2, Quantity = 2 }
            );

            modelBuilder.Entity<Receiving>().HasData(
                new Receiving { ReceivingID = 1, ReceivingDate = new DateTime(2023, 9, 2), SupplierID = 1, WarehouseID = 1 },
                new Receiving { ReceivingID = 2, ReceivingDate = new DateTime(2023, 9, 6), SupplierID = 2, WarehouseID = 2 },
                new Receiving { ReceivingID = 3, ReceivingDate = new DateTime(2023, 9, 11), SupplierID = 3, WarehouseID = 1 },
                new Receiving { ReceivingID = 4, ReceivingDate = new DateTime(2023, 9, 16), SupplierID = 4, WarehouseID = 3 },
                new Receiving { ReceivingID = 5, ReceivingDate = new DateTime(2023, 9, 21), SupplierID = 5, WarehouseID = 2 }
            );

            modelBuilder.Entity<ReceivingDetail>().HasData(
                new ReceivingDetail { ReceivingDetailsID = 1, ReceivingID = 1, ProductID = 1, Quantity = 50 },
                new ReceivingDetail { ReceivingDetailsID = 2, ReceivingID = 1, ProductID = 2, Quantity = 30 },
                new ReceivingDetail { ReceivingDetailsID = 3, ReceivingID = 2, ProductID = 3, Quantity = 40 },
                new ReceivingDetail { ReceivingDetailsID = 4, ReceivingID = 2, ProductID = 4, Quantity = 60 },
                new ReceivingDetail { ReceivingDetailsID = 5, ReceivingID = 3, ProductID = 5, Quantity = 20 },
                new ReceivingDetail { ReceivingDetailsID = 6, ReceivingID = 3, ProductID = 6, Quantity = 25 },
                new ReceivingDetail { ReceivingDetailsID = 7, ReceivingID = 4, ProductID = 7, Quantity = 15 },
                new ReceivingDetail { ReceivingDetailsID = 8, ReceivingID = 4, ProductID = 8, Quantity = 35 },
                new ReceivingDetail { ReceivingDetailsID = 9, ReceivingID = 5, ProductID = 9, Quantity = 50 },
                new ReceivingDetail { ReceivingDetailsID = 10, ReceivingID = 5, ProductID = 10, Quantity = 20 },
                new ReceivingDetail { ReceivingDetailsID = 11, ReceivingID = 1, ProductID = 3, Quantity = 45 },
                new ReceivingDetail { ReceivingDetailsID = 12, ReceivingID = 2, ProductID = 4, Quantity = 55 },
                new ReceivingDetail { ReceivingDetailsID = 13, ReceivingID = 3, ProductID = 5, Quantity = 10 },
                new ReceivingDetail { ReceivingDetailsID = 14, ReceivingID = 4, ProductID = 6, Quantity = 30 },
                new ReceivingDetail { ReceivingDetailsID = 15, ReceivingID = 5, ProductID = 7, Quantity = 60 }
            );
        }
    }
}
