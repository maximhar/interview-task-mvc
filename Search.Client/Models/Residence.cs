using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealEstateMarket.Models
{
    public enum ResidenceType
    {
        House, Apartment
    }

    public class Residence
    {
        public int Id { get; set; }
        public ResidenceType Type { get; set; }
        public virtual float Area { get; set; }
        public string Country { get; set; }
        public string City { get; set; }
        public decimal Price { get; set; }
        public string Owner { get; set; }
        public string Address { get; set; }
    }
}
