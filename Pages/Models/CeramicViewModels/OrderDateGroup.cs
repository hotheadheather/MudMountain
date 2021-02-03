using System;
using System.ComponentModel.DataAnnotations;

namespace Ceramics.Pages.Models.CeramicViewModels
{
    public class OrderDateGroup
    {
      
            [DataType(DataType.Date)]
            public DateTime? OrderDate { get; set; }

            public int CustomerCount { get; set; }
        
    }
}
