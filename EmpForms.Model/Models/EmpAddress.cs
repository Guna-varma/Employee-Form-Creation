using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmpForms.Model.Models
{
    public class EmpAddress
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(60)]
        [DisplayName("Address Line-1")]
        public string AddresssLine1 { get; set; }

        [Required]
        [MaxLength(60)]
        [DisplayName("Address Line-2")]
        public string AddressLine2 { get; set; }

        [Required]
        [DisplayName("City")]
        public string City { get; set; }

        [Required]
        [DisplayName("State")]
        public string State { get; set; }

        [Required]
        [DisplayName("Pincode")]
        [MaxLength(6)]
        public string Pincode { get; set; }
    }
}
