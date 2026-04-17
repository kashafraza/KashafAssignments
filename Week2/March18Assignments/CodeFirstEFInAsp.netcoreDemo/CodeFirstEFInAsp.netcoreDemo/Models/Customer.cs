using System.ComponentModel.DataAnnotations;

namespace CodeFirstEFInAsp.netcoreDemo.Models
{
    public class Customer
    {
        public int CustomerID { set; get; }

        [Required]
        public string CustomerName { set; get; }

        public ICollection<Product> Products { set; get; }
    }
}
