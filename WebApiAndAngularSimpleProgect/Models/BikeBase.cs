using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebApiAndAngularSimpleProgect.Models
{
    public class BikeBase
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public bool IsRented { get; set; }
        public double RentPrice { get; set; }
        public string TypeBike { get; set; }
    }
}
