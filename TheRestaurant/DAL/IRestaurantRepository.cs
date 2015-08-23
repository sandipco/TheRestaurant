using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TheRestaurant.Models;
using TheRestaurant.ViewModels;

namespace TheRestaurant.DAL
{
    public interface IRestaurantRepository
    {
        IQueryable<Restaurant> GetRestaurants();
        IQueryable<Restaurant> GetRestaurantById(int restaurantId);
        IQueryable<Restaurant> GetRestaurantsIncludingReviews();
        IQueryable<RestaurantReview> GetReviewsByRestaurant(int restaurantId);
        IQueryable<RestaurantReview> GetReview(int id);
        int GetRestaurantsCount();

        bool Save();
        bool AddRestaurant(Restaurant restaurant);
        bool RemoveRestaurant(Restaurant restaurant);
        bool EditRestaurant(Restaurant restaurant);
        bool AddReview(RestaurantReview review);
        bool EditReview(RestaurantReview review);
        bool EditReview(VMRestaurantReview review);
        
    }
}
