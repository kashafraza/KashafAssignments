using System.ComponentModel.DataAnnotations;

namespace MVCExampleDemo.Models
{
    public class Dog
    {
       [Required(ErrorMessage="ID is required")]
       public int ID { set; get; }

        [Required(ErrorMessage = "Name  is required"),MaxLength(222)]
        public string? Name { set; get; }

        [Required(ErrorMessage = "Name  is required"),
            Range(0,20,ErrorMessage ="Age should be between 0 to 20 only ")]
        public int Age { set; get; }
    }
}
