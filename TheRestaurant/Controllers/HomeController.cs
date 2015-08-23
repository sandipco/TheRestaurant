using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TheRestaurant.DAL;
using TheRestaurant.Models;
using PagedList;

namespace TheRestaurant.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        private IRestaurantRepository _repo;
        public HomeController(IRestaurantRepository repo)
        {
            _repo = repo;
        }

        public JsonResult AutoComplete(string term)
        {
            term = term.ToUpper();
            var results = _repo.GetRestaurants().
                Where(a => a.Name.ToUpper().StartsWith(term)).
                Select(r => new { label = r.Name });
            return Json(results, JsonRequestBehavior.AllowGet);
        }

        [OutputCache(Duration=60)]
        public ActionResult Index(string searchTerm="",int page=1)
        {
            searchTerm = searchTerm.ToUpper();
            IPagedList<Restaurant> restaurants;
            if (String.IsNullOrEmpty(searchTerm))
                restaurants = _repo.GetRestaurants()
                    .OrderBy(a => a.Name)
                    .ToPagedList(page, 10);
            else
                restaurants = _repo.GetRestaurants()
                    .Where(a => a.Name.ToUpper().Contains(searchTerm))
                    .ToPagedList(page, 10);
            
            int id = restaurants.Count();
            if (Request.IsAjaxRequest())
                return PartialView("_Restaurants",restaurants);
            else
                return View(restaurants);
        }


        public ActionResult About()
        {
            ViewBag.Message = "Your app description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}
