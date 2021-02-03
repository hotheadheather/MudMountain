using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Ceramics.Models
{
    public class Chemistry
    {
        
        public int ID { get; set; }

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




        //  public ICollection<CourseAssignment> CourseAssignments { get; set; }
        //  public OfficeAssignment OfficeAssignment { get; set; }
    }
}

