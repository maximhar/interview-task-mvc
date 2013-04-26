
using RealEstateMarket.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web;
using System.Web.Mvc;

namespace RealEstateMarket.Client.Controllers
{
    public class HomeController : Controller
    {
        private HttpClient client = new HttpClient();

        public HomeController()
        {
            client.BaseAddress = new Uri("http://localhost:7080/");
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }

        public ActionResult Index()
        {
            return View();
        }

        public PartialViewResult NewBar()
        {
            return PartialView("~/Views/Home/New.cshtml");
        }

        public PartialViewResult EditBar(int id)
        {
            var residence = LoadResidence("/api/search/" + id);
            return PartialView("~/Views/Home/Edit.cshtml", residence);
        }

        public PartialViewResult SearchBar()
        {
            return PartialView("~/Views/Home/Search.cshtml");
        }

        public PartialViewResult Search(SearchFilter filter)
        {
            return PartialView("~/Views/Shared/Results.cshtml");
        }

        private Residence LoadResidence(string query)
        {
            var response = client.GetAsync(query).Result;
            var residence = response.Content.ReadAsAsync<Residence>().Result;
            return residence;
        }
    }
}
