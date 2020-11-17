using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Models
{
    public class Cars
    {
        [Key]
        public string CarId { get; set; }
        [StringLength(20)]
        public string Make { get; set; }
        [StringLength(30)]
        public string Model { get; set; }
        [Range(1900, 2020)]
        public int ModelYear { get; set; }
        [StringLength(20)]
        public string BodyType { get; set; }
        [Range(0, 30)]
        public double CombFuelEco { get; set; }
        public bool Available { get; set; }
        [Range(0, 500000)]
        public int PricePerDay { get; set; }

        public string SalonId { get; set; }
        [NotMapped]
        public virtual Salons Salon { get; set; }
    }
}
