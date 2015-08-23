using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TheRestaurant.Models;
using System.Web.Mvc;
using TheRestaurant.ViewModels;
using AutoMapper;

namespace TheRestaurant.DAL
{
    public class RestaurantRepository: IRestaurantRepository
    {
        restaurantContext _ctx;
        string err;
        public RestaurantRepository(restaurantContext ctx)
        {
            _ctx = ctx;
        }
        public IQueryable<Models.Restaurant> GetRestaurants()
        {
            return _ctx.restaurants;
        }
        public IQueryable<Models.Restaurant> GetRestaurantById(int restaurantId)
        {
            return _ctx.restaurants.Where(a => a.Id == restaurantId);
        }
        public IQueryable<Models.Restaurant> GetRestaurantsIncludingReviews()
        {
            return _ctx.restaurants.Include("Reviews");
        }

        public IQueryable<Models.RestaurantReview> GetReviewsByRestaurant(int restaurantId)
        {
            return _ctx.reviews.Where(a => a.RestaurantId == restaurantId);
        }

        public int GetRestaurantsCount()
        {
            return _ctx.restaurants.Count();
        }
        public bool Save()
        {
            try
            {
               return _ctx.SaveChanges()>0;
            }
            catch(System.Exception ex)
            {
                err = ex.ToString();
                return false;
            }
        }

        public bool AddRestaurant(Models.Restaurant restaurant)
        {
            try
            {
                _ctx.restaurants.Add(restaurant);
                return(this.Save());
                
            }
            catch
            {
                return false;
            }
        }

        public bool RemoveRestaurant(Models.Restaurant restaurant)
        {
            try
            {
                _ctx.restaurants.Remove(restaurant);
                _ctx.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }
        public bool EditRestaurant(Restaurant restaurant)
        {
            try
            {
                _ctx.Entry(restaurant).State = System.Data.EntityState.Modified;

                return (this.Save());
            }
            catch
            {
                return false;
            }
        }
        public IQueryable<RestaurantReview> GetReview(int id)
        {
            return _ctx.reviews.Where(x => x.Id == id);
        }
        public bool AddReview(Models.RestaurantReview review)
        {
            try
            {
                _ctx.reviews.Add(review);
                return(this.Save());
            }
            catch
            {
                return false;
            }
        }
        public bool EditReview(VMRestaurantReview review)
        {
            
            Mapper.CreateMap<VMRestaurantReview, RestaurantReview>();
            
            RestaurantReview rev = Mapper.Map<RestaurantReview>(review);

            

            var result = this.GetReview(rev.Id).Select(a => a.ReviewerName).FirstOrDefault().ToString();
            rev.ReviewerName = result.ToString();
            

            _ctx.Entry(rev).State = System.Data.EntityState.Modified;
            return (this.Save());
        }
        public bool EditReview([Bind(Exclude="ReviewerName")]RestaurantReview review)
        {
            _ctx.Entry(review).State = System.Data.EntityState.Modified;
            return (this.Save());
        }
    }
}