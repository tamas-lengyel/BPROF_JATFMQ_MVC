using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Models
{
    public class Renters
    {
        [Key]
        public string RenterId { get; set; }
        [StringLength(80)]
        public string Name { get; set; }
        [StringLength(20)]
        public string PostalCode { get; set; }
        [StringLength(30)]
        public string City { get; set; }
        [StringLength(50)]
        public string Address { get; set; }
        [StringLength(40)]
        public string Email { get; set; }
        [StringLength(20)]
        public string PhoneNumber { get; set; }
        [Range(1, 365)]
        public int RentedDays { get; set; }

        public string CarId { get; set; }
        [NotMapped]
        public virtual Cars Car { get; set; }
    }
}
