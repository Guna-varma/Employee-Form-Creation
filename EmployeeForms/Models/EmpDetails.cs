using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeForms.Models
{
    public class EmpDetails
    {
        [Key]
        [DisplayName("Id")]
        public int Id { get; set; }

        [Required]
        [MaxLength(30)]
        [DisplayName("First Name")]
        public string FirstName { get; set; }

        [Required]
        [MaxLength(30)]
        [DisplayName("Last Name")]
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

    }
}
