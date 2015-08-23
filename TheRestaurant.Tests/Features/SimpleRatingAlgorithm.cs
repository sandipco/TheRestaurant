using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TheRestaurant.Models;

namespace TheRestaurant.Tests.Features
{
    public class SimpleRatingAlgorithm:IRatingAlgorithm
    {
        public RatingResult Compute(IList<RestaurantReview> reviews)
        {
            var result = new RatingResult();
            result.Rating = (int)reviews.Average(a => a.Rating);
            return result;
        }
    }
}
