using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace RazorDrop.Models
{
    public class Customer
    {
        [Key]
        public Guid CustomerId { get; set; }

        [Required]
        [MaxLength(128)]
        public string CustomerName { get; set; }

        [Required]
        public string CountryId { get; set; }
        public Country Country { get; set; }

        public string RegionId { get; set; }
        public Region Region { get; set; }
    }
}
