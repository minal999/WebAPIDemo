using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebAPIDemo.Models
{
    [Table("student")]
    public class Student
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage="Name is required")]
        public string? Name { get; set; }
        [Required(ErrorMessage = "Subject 1 Marks are required")]
        public int Sub1 { get; set; }
        [Required(ErrorMessage = "Subject 2 Marks are required")]

        public int Sub2 { get; set; }
        [Required(ErrorMessage = "Subject 3 Marks are required")]

        public int Sub3 { get; set; }
        [Required(ErrorMessage = "Percentage are required")]
        public decimal Percentage { get; set; }
    }
}
