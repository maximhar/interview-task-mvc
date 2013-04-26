using RealEstateMarket.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace RealEstateMarket.Models
{
    public class RealEstateDb:DbContext
    {
        public RealEstateDb() : base("DefaultConnection") { }
        public DbSet<Residence> Residences { get; set; }
    }
}