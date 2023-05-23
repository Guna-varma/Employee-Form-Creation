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
    public class EmpBankDetails
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(30)]
        [DisplayName("Account Number")]
        public string AccountNo { get; set; }

        [Required]
        [MaxLength(30)]
        [DisplayName("IFSC Code")]
        public string IFSCCode { get; set; }

        [Required]
        [DisplayName("Branch Name")]
        public string Branch { get; set; }

    }
}
