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

        public override bool Equals(object obj)
        {
            if (obj is Salons)
            {
                Salons salon = obj as Salons;
                return this.SalonId == salon.SalonId &&
                this.City == salon.City &&
                this.Address == salon.Address &&
                this.PostalCode == salon.PostalCode &&
                this.Car == salon.Car;
            }
            return false;
        }

        public override int GetHashCode()
        {
            return 0;
        }
    }
}
