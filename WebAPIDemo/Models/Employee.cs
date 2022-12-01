using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebAPIDemo.Models
{
    [Table("emp")]
    public class Employee
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage ="Name is required")]
        public string? Name { get; set; }
        [Required(ErrorMessage = "Salary is required")]
        public decimal Salary { get; set; }
    }
}
