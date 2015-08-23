using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TheRestaurant.Models;
using TheRestaurant.DAL;

namespace TheRestaurant.Controllers
{
    public class RestaurantController : Controller
    {
        
        private IRestaurantRepository _repo;

        //
        // GET: /Restaurant/
        public RestaurantController(IRestaurantRepository repo)
        {
            _repo = repo;
        }

        public ActionResult Index()
        {
            var results = _repo.GetRestaurants().OrderBy(x => x.Name);
            return View(results);
        }

        //
        // GET: /Restaurant/Details/5

        public ActionResult Details(int id = 0)
        {
            
            //var restaurant = _repo.GetRestaurantById(id).OrderBy(x => x.Name);
            var restaurant = _repo.GetRestaurantsIncludingReviews().OrderBy(x => x.Name);
            if (restaurant.Count() == 0)
            {
                return View("NotFound");
            }
            return View(restaurant.FirstOrDefault());
        }

        //
        // GET: /Restaurant/Create
        [Authorize(Roles = "admin")]
        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Restaurant/Create

        [HttpPost]
        [Authorize(Roles="admin")]
        public ActionResult Create(Restaurant restaurant)
        {
            if (ModelState.IsValid)
            {
                _repo.AddRestaurant(restaurant);
                return RedirectToAction("Index");
            }

            return View(restaurant);
        }

        //
        // GET: /Restaurant/Edit/5

        public ActionResult Edit(int id = 0)
        {
            var restaurant = _repo.GetRestaurantById(id);
            
            if (restaurant == null)
            {
                return HttpNotFound();
            }
            return View(restaurant.SingleOrDefault());
        }

        //
        // POST: /Restaurant/Edit/5

        [HttpPost]
        public ActionResult Edit(Restaurant restaurant)
        {
            if (ModelState.IsValid)
            {
                _repo.EditRestaurant(restaurant);
                return RedirectToAction("Index");
            }
            return View(restaurant);
        }

        //
        // GET: /Restaurant/Delete/5

        public ActionResult Delete(int id = 0)
        {
            var restaurant = _repo.GetRestaurantById(id);
            if (restaurant == null)
            {
                return HttpNotFound();
            }
            return View(restaurant);
        }

        //
        // POST: /Restaurant/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {

            var restaurant = _repo.GetRestaurantById(id);
            _repo.RemoveRestaurant(restaurant.FirstOrDefault());
            return RedirectToAction("Index");
        }

        
    }
}