using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Models
{
    public class Salons
    {
        [Key]
        public string SalonId { get; set; }
        [StringLength(30)]
        public string City { get; set; }
        [StringLength(50)]
        public string Address { get; set; }
        [StringLength(20)]
        public string PostalCode { get; set; }

        public virtual ICollection<Cars> Car { get; set; }
    }
}
