using System.ComponentModel.DataAnnotations;

namespace WarehouseManagementProject.Models
{
    public class Warehouse
    {
        [Key]
        public int WarehouseID { get; set; }

        [Required, MaxLength(100)]
        public string WarehouseName { get; set; }

        [MaxLength(255)]
        public string Location { get; set; }

    }
}
