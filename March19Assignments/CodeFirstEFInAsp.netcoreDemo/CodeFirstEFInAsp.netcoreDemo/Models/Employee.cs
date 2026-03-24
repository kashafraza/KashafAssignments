using System.ComponentModel.DataAnnotations;

namespace CodeFirstEFInAsp.netcoreDemo.Models
{
    public class Employee
    {
        public int Id { set; get; }

        [Required(ErrorMessage ="please enter your first name ")]
        public string FirstName { set; get; }

        [Required(ErrorMessage = "please enter your last name ")]
        public string LastName { set; get; }

        [Required(ErrorMessage = "please enter your email  ")]
        [EmailAddress(ErrorMessage ="enter valid email")]
        public string Email { set; get; }

        [Required(ErrorMessage="enter your age ")]
        [Range(0,100,ErrorMessage ="please enter age between 1 to 100 only ")]
        public int Age { set; get; }

    }
}
