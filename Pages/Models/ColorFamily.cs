using Ceramics.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace Ceramics.Models
{
    public class ColorFamily
    {


        public int ID { get; set; }
        public int ColorFamID { get; set; }

        [Required]
        [Display(Name = "Color Family")]
        [StringLength(50)]
        public string ColorFam { get; set; }

        [Required]
        [Column("ColorName")]
        [Display(Name = "Color Name")]
        [StringLength(50)]
        public string ColorName { get; set; }


        [Required]
        public int ColorID { get; set; }

        public int? ChemID { get; set; }
        // public int? InstructorID { get; set; }

        public Chemistry ChemAdmin { get; set; }
        //public Instructor Administrator { get; set; }



        public ICollection<Color> Colors { get; set; }

    }
}
