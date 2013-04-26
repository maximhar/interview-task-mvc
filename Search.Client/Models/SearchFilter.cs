using RealEstateMarket.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RealEstateMarket.Models
{
    public class SearchFilter
    {
        public string City { get; set; }
        public string Country { get; set; }
        public int MaxPrice { get; set; }
        public ResidenceType Type { get; set; }
    }
}