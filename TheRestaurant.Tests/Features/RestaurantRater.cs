﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TheRestaurant.Models;

namespace TheRestaurant.Tests.Features
{
    class RestaurantRater
    {
        private Restaurant _restaurant;

        public RestaurantRater(Restaurant restaurant)
        {
            // TODO: Complete member initialization
            this._restaurant = restaurant ;
        }

        public RatingResult ComputeResult(IRatingAlgorithm algorithm, int numberOfReviewsToUse)
        {
            var filteredReviews = _restaurant.Reviews.Take(numberOfReviewsToUse);
            return algorithm.Compute(filteredReviews.ToList());
        }

       
       
    }
}
