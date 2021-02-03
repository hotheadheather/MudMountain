using Ceramics.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ceramics.Pages.Models.CeramicViewModels
{
    public class ChemistryIndexData
    {
       
            public IEnumerable<ChemistryIndexData> Chemistry { get; set; }
            public IEnumerable<Color> Color { get; set; }
            public IEnumerable<Order> Order { get; set; }
        
    }
}
