using Ceramics.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Ceramics.Pages.Models
{
    public class WarehouseLocation
    {
        [Key]
        public int ID { get; set; }
        public int ChemID { get; set; }

       
        [StringLength(50)]
        [Display(Name = "Warehouse Location")]
        public string Location { get; set; }


        [Range(0, 4)]
        public int WarehouseLocationID { get; set; }

        // public Chemistry Chemistry { get; set; }
    }
}
