namespace MVCExampleDemo.Models
{
    public class Dept
    {
        public int DeptID { set; get; }
        public string DeptName { set; get; }

        // Master-side collection
        public List<Employee> Employees { get; set; } = new List<Employee>();

    }
}
