using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApiAndAngularSimpleProgect.Models;

namespace WebApiAndAngularSimpleProgect.Controllers
{
    [ApiController]
    [Route("api/bikes")]
    public class BikeController : ControllerBase
    {
        private readonly RentBikeContext rentBikeDb;
        public BikeController(RentBikeContext rentBikeContext)
        {
            rentBikeDb = rentBikeContext;

            if (!rentBikeDb.BikeBases.Any())
            {
                rentBikeDb.BikeBases.Add(new BikeBase { Name = "Test Bike", TypeBike = "Custom", RentPrice = 12 });
                rentBikeDb.BikeBases.Add(new BikeBase { Name = "Test", TypeBike = "Custom", RentPrice = 5 });
                rentBikeDb.BikeBases.Add(new BikeBase { Name = "Bike", TypeBike = "Custom", RentPrice = 13 });

                rentBikeDb.SaveChanges();
            }
        }

        [HttpGet("available")]
        public IEnumerable<BikeBase> GetRentedBikes()
        {
            return rentBikeDb.BikeBases.Where(bike => bike.IsRented == false).ToList();
        }

        [HttpGet("rented")]
        public IEnumerable<BikeBase> GetAvailableBikes()
        {
            return rentBikeDb.BikeBases.Where(bike => bike.IsRented == true).ToList();
        }

        [HttpPost]
        public IActionResult Post(BikeBase bike)
        {

            if (ModelState.IsValid &&
                !string.IsNullOrEmpty(bike.Name) &&
                !string.IsNullOrEmpty(bike.TypeBike))
            {
                rentBikeDb.BikeBases.Add(bike);
                rentBikeDb.SaveChanges();
                return Ok(bike);
            }

            return BadRequest(ModelState);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            BikeBase bike = rentBikeDb.BikeBases.FirstOrDefault(x => x.Id == id);
            if (bike != null)
            {
                rentBikeDb.BikeBases.Remove(bike);
                rentBikeDb.SaveChanges();
            }
            return Ok(bike);
        }

        [HttpPut]
        public IActionResult Put(BikeBase bike)
        {
            if (ModelState.IsValid)
            {
                rentBikeDb.Update(bike);
                rentBikeDb.SaveChanges();
                return Ok(bike);
            }
            return BadRequest(ModelState);
        }
    }
}
