using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CodeFirstEFInAsp.netcoreDemo.Models
{
    public class Product
    {
        public int ProductID { get; set; }

        [Required]
        public string ProductName { set; get; }

        [Display(Name ="who buyed")]
        [ForeignKey("Customer")]
        public int CustomerID { set; get; }

       
        public Customer Customer { set; get; }
    }
}
