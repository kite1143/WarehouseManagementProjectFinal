using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace WarehouseManagementProject.Models
{
    public class Inventory
    {
        [Key]
        public int InventoryID { get; set; }
        public int ProductID { get; set; }
        [ForeignKey("ProductID")]
        public Product Product { get; set; }

        [Required]
        public int QuantityAvailable { get; set; }
    }
}
