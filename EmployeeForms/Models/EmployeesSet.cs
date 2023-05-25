using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations.Schema;

namespace EmployeeForms.Models
{
    public class EmployeesSet
    {
        [Key]
        [DisplayName("Id")]
        public int Id { get; set; }

        //personal details

        [Required]
        [MaxLength(30)]
        [DisplayName("First Name")]
        [RegularExpression(@"^[A-Za-z\s]+$", ErrorMessage = "Only alphabets are allowed.")]
        public string FirstName { get; set; } 

        [Required]
        [MaxLength(30)]
        [DisplayName("Last Name")]
        [RegularExpression(@"^[A-Za-z\s]+$", ErrorMessage = "Only alphabets are allowed.")]

        public string LastName { get; set; }

        [Required]
        [DisplayName("Employee Code")]
        public string EmployeeCode { get; set; }

        [Required]
        [MaxLength(6)]
        [DisplayName("Gender")]
        public string Gender { get; set; }

        [Required]
        [MaxLength(6)]
        [DisplayName("Blood Group")]
        public string BloodGroup { get; set; }

        //[Required]
        //[DataType(DataType.Date)]
        //[DisplayName("Date of Birth")]
        //[DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        //public DateTime DateOfBirth { get; set; }

        //[Required]
        //[DisplayName("Date of Birth")]
        //[DataType(DataType.Date)]
        //public DateOnly DateOfBirth { get; set; }

        //bank details

        [Required(ErrorMessage = "Account Number is required")]
        [RegularExpression("^[0-9]{10}$", ErrorMessage = "Account Number must be a 10-digit number")]
        [DisplayName("Account Number")]
        [MaxLength(10)]

        public string AccountNo { get; set; }

        [Required]
        [MaxLength(30)]
        [DisplayName("IFSC Code")]
        [RegularExpression(@"^[A-Za-z0-9]+$", ErrorMessage = "No Spaces are allowed.")]
        public string IFSCCode { get; set; }

        [Required]
        [DisplayName("Branch Name")]
        [RegularExpression(@"^[A-Za-z\s]+$", ErrorMessage = "Only alphabets are allowed.")]


        public string Branch { get; set; }

        [Required]
        [DisplayName("Bank Name")]
        [RegularExpression(@"^[A-Za-z\s]+$", ErrorMessage = "Only alphabets are allowed.")]
        public string BankName { get; set; }

        [Required]
        [DisplayName("Type of Account")]
        public string AccountType { get; set; }

        //address details

        [Required]
        [MaxLength(60)]
        [DisplayName("Address Line-1")]
        [RegularExpression(@"^[A-Za-z0-9.'#/ -]+$", ErrorMessage = "Invalid characters detected, only (A-Z, a-z, 0-9  '  # /  - . these characters were accepted!")]
        public string AddresssLine1 { get; set; }

        [Required]
        [MaxLength(60)]
        [DisplayName("Address Line-2")]
        [RegularExpression(@"^[A-Za-z0-9.'#\/ -]+$", ErrorMessage = "Invalid characters detected.")]
        public string AddressLine2 { get; set; }

        [Required]
        [DisplayName("City")]
        [RegularExpression(@"^[A-Za-z\s]+$", ErrorMessage = "Only alphabets are allowed.")]
        public string City { get; set; }

        [Required]
        [DisplayName("State")]
        [RegularExpression(@"^[A-Za-z\s]+$", ErrorMessage = "Only alphabets are allowed.")]
        public string State { get; set; }

        [Required(ErrorMessage = "Pincode is required")]
        [RegularExpression("^[0-9]{6}$", ErrorMessage = "Pincode must be a 6-digit number")]
        [DisplayName("Pincode")]
        public string Pincode { get; set; }

        [Required]
        public int DepartmentId { get; set; }

        [ForeignKey("DepartmentId")]
        [ValidateNever]
        public Department Department { get; set; }
    }
}
