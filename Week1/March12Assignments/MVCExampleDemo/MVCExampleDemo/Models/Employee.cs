namespace MVCExampleDemo.Models
{
    public class Employee
    {
        public int EmployeeID { set; get; }
        public string? EmpName { set; get; }

        public int Salary { set; get; }

        public string? ImageUrl { set; get; }

        // FK + reference
        public int  DeptID { get; set; }
        public Dept? Dept { get; set; }

    }
}
