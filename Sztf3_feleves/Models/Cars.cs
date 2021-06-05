using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using System.Text.Json.Serialization;

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
        [JsonIgnore]
        public virtual Salons Salon { get; set; }

        public string RenterId { get; set; }
        [NotMapped]
        [JsonIgnore]
        public virtual Renters Renter { get; set; }

        public override bool Equals(object obj)
        {
            if (obj is Cars)
            {
                Cars car = obj as Cars;
                return this.CarId == car.CarId &&
                this.Make == car.Make &&
                this.Model == car.Model &&
                this.ModelYear == car.ModelYear &&
                this.BodyType == car.BodyType &&
                this.CombFuelEco == car.CombFuelEco &&
                this.Available == car.Available &&
                this.PricePerDay == car.PricePerDay &&
                this.SalonId == car.SalonId &&
                this.Salon == car.Salon &&
                this.RenterId == car.RenterId &&
                this.Renter == car.Renter;
            }
            return false;
        }

        public override int GetHashCode()
        {
            return 0;
        }
    }
}
