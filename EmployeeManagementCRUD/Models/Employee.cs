namespace EmployeeManagementCRUD.Models
{
    public class Employee
    {
        public int Id { get; set; }
        public string? EmployeeNumber { get; set;  }
        public string? Name { get; set; }
        public string? Email { get; set; }   
        public string? Phone { get; set; }
        public string?  Position { get; set; }
        public decimal? Salary { get; set; }

    }
}

