using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApiAndAngularSimpleProgect.Models
{
    public class RentBikeContext : DbContext
    {
        public DbSet<BikeBase> BikeBases { get; set; }

        public RentBikeContext(DbContextOptions<RentBikeContext> options)
            : base(options)
        {
            Database.EnsureCreated();
        }
    }
}
