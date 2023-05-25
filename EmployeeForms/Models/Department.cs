using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace EmployeeForms.Models
{
    public class Department
    {
        [Key]
        [DisplayName("Id")]
        public int Id { get; set; }

        [Required]
        [MaxLength(30)]
        [RegularExpression(@"^[A-Za-z0-9\s]+$", ErrorMessage = "Invalid characters detected, only (A-Z, a-z, 0-9 these characters were accepted!")]
        [DisplayName("Department Code")]
        public string DeptCode { get; set; }

        [Required]
        [MaxLength(30)]
        [RegularExpression(@"^[A-Za-z\s]+$", ErrorMessage = "Only alphabets are allowed.")]
        [DisplayName("Department Name")]
        public string DeptName { get; set; }

        [Required]
        [MaxLength(30)]
        [DisplayName("Department Location")]
        [RegularExpression(@"^[A-Za-z\s]+$", ErrorMessage = "Only alphabets are allowed.")]
        public string DeptLocation { get; set; }

    }
}
