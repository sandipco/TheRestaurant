using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TheRestaurant.DAL;
using TheRestaurant.Models;
using TheRestaurant.ViewModels;
using AutoMapper;

namespace TheRestaurant.Controllers
{
    public class ReviewsController : Controller
    {
        private IRestaurantRepository _repo;
        public ReviewsController(IRestaurantRepository repo)
        {
            _repo = repo;
        }
        //
        // GET: /Reviews/
        //following line means that if you find an parameter named id in the parameter list/querystring consider that as a restaurantid
        public ActionResult Index([Bind(Prefix="id")] int restaurantId)
        {
            var restaurant=_repo.GetRestaurantById(restaurantId).SingleOrDefault();
            return View(restaurant);
        }


        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(RestaurantReview rv)
        {
            if (ModelState.IsValid)
            {
                _repo.AddReview(rv);
                return RedirectToAction("Index", new { id = rv.RestaurantId });
            }
            return View();
        }

        public ActionResult Edit(int id)
        {
            var review = _repo.GetReview(id).FirstOrDefault();
            
            
            Mapper.CreateMap<RestaurantReview, VMRestaurantReview>();
            VMRestaurantReview rv = Mapper.Map<VMRestaurantReview>(review);

            
            return View(rv);
        }

        [HttpPost]
        
        public ActionResult Edit(VMRestaurantReview review)
        {
            
            if (ModelState.IsValid)
            {
                if (_repo.EditReview(review))
                {
                    return RedirectToAction("Index", new { id = review.RestaurantId });
                }
                else
                    return View(review);
            }
            else
                return View(review);
        }
    }
}
