using System.ComponentModel.DataAnnotations;

namespace EmployeeManagementCRUD.Models
{
    public class User
    {
        [Required]
        public int Id { get; set; }
        public string Username { get; set; }
        public string Password {  get; set; }
    }
}

