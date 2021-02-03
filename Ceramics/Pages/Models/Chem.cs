using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Ceramics.Pages.Models;
using Ceramics.Models;

namespace Ceramics.Models
{
    public class Chem
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Display(Name = "Chemistry ID")]
        public int ChemID { get; set; }

        [Required]
        [Display(Name = "Chemical Composition")]
        [StringLength(255)]
        public string ChemComp { get; set; }

        [Required]
        [Display(Name = "Chemical Abbreviation")]
        [StringLength(50)]
        public string ChemAbbrev { get; set; }

        [Required]
        public int ColorID { get; set; }

        [Required]
        [Range(0, 4)]
        public int WarehouseLocationID { get; set; }


    



        /* 
         [Required]
         [Display(Name = "Color Family")]
         [StringLength(50)]
         public string ColorFam { get; set; }

         [Required]
         [Column("ColorName")]
         [Display(Name = "Color Name")]
         [StringLength(50)]
         public string ColorName { get; set; }
        */




       //   public ICollection<ColorAssignment> ColorAssignments { get; set; }
       // public ICollection<CourseAssignment> CourseAssignments { get; set; }

        public WarehouseLocation WarehouseLocation { get; set; }
        // public OfficeAssignment OfficeAssignment { get; set; }


      
     
    }
}

