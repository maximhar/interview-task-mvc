using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using RealEstateMarket.Models;
using System.Data;
namespace RealEstateMarket.Service.Controllers
{
    public class SearchController : ApiController
    {
        //get all residences
        public IEnumerable<Residence> Get()
        {
            using (var context = new RealEstateDb())
            {
                var residences = context.Residences.ToArray();
                return residences;
            }
        }
        //search for residences
        public IEnumerable<Residence> Get(string city, string country, decimal? maxPrice, ResidenceType? type)
        {
            using (var context = new RealEstateDb())
            {
                var residences = context.Residences.AsQueryable();
                if (city != null) residences = residences.Where(res => res.City.ToUpper() == city.ToUpper());
                if (country != null) residences = residences.Where(res => res.Country.ToUpper() == country.ToUpper());
                if (maxPrice != null) residences = residences.Where(res => res.Price <= maxPrice);
                if (type != null) residences = residences.Where(res => res.Type == type);
                return residences.ToArray();
            }
        }
        //get single residence
        public Residence Get(int id)
        {
            using (var context = new RealEstateDb())
            {
                var residence = context.Residences.Find(id);
                return residence;
            }
        }

        //new residence
        public HttpResponseMessage Post([FromBody]Residence value)
        {
            using (var context = new RealEstateDb())
            {
                if (value.Address != null && value.City != null &&
                    value.Country != null && value.Owner != null)
                {
                    context.Residences.Add(value);
                    context.SaveChanges();
                    return ControllerContext.Request.CreateResponse(HttpStatusCode.OK, value);
                }
                return ControllerContext.Request.CreateResponse(HttpStatusCode.BadRequest);
            }
        }
        //edit residence
        public HttpResponseMessage Put(int id, [FromBody]Residence value)
        {
            using (var context = new RealEstateDb())
            {
                var residence = context.Residences.Find(id);
                if (residence != null)
                {
                    residence.Address = value.Address;
                    residence.Area = value.Area;
                    residence.City = value.City;
                    residence.Country = value.Country;
                    residence.Owner = value.Owner;
                    residence.Price = value.Price;
                    residence.Type = value.Type;
                    context.SaveChanges();
                    return ControllerContext.Request.CreateResponse(HttpStatusCode.OK, residence);
                }
                return ControllerContext.Request.CreateResponse(HttpStatusCode.NotFound);
            }
        }
        //delete residence
        public void Delete(int id)
        {
            using (var context = new RealEstateDb())
            {
                try
                {
                    var dummy = new Residence() { Id = id };
                    context.Entry(dummy).State = EntityState.Deleted;
                    context.SaveChanges();
                }
                catch { }
            }
        }
    }
}
