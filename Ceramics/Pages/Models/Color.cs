using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Ceramics.Pages.Models;

namespace Ceramics.Models
{
    public class Color
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Display(Name = "Number")]
        public int ColorID { get; set; }



        [StringLength(50, MinimumLength = 3)]
        public string ColorName { get; set; }



        [DataType(DataType.Currency)]
        public double Price { get; set; }


          public int ColorFamID { get; set; }
          public string ColorFamName { get; set; }

        //public ColorFamily ColorFamily { get; set; }

       

     


   

     
       // public ICollection<ColorAssignment> ColorAssignments { get; set; }


        public ICollection<Order> Orders { get; set; }
    }
}