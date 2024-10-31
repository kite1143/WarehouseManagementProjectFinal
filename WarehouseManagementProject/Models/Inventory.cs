using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace WarehouseManagementProject.Models
{
    public class Inventory
    {
        [Key]
        public int InventoryID { get; set; }
        public int ProductID { get; set; }
        [ForeignKey("ProductID")]
        [DeleteBehavior(DeleteBehavior.Restrict)]
        public Product Product { get; set; }

        [Required]
        public int QuantityAvailable { get; set; }
    }
}
