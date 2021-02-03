using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace Ceramics.Models
{
    public enum MembershipStat
    {
        A, B, C, D, F
    }

    public class Order
    {
        public int OrderID { get; set; }
        public int ColorID { get; set; }
        public int CustomerID { get; set; }

        [DisplayFormat(NullDisplayText = "No membership status")]
        public MembershipStat? MembershipStat { get; set; }

        public Color Color { get; set; }
        public Customer Customer { get; set; }
    }
}