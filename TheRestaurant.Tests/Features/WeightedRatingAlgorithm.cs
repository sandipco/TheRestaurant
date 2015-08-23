using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TheRestaurant.Models;

namespace TheRestaurant.Tests.Features
{
    public class WeightedRatingAlgorithm:IRatingAlgorithm
    {
        public RatingResult Compute(IList<RestaurantReview> reviews)
        {
            var revs = reviews.ToArray();
            var result = new RatingResult();
            var counter = 0;
            var total = 0;
            for (int i = 0; i < revs.Count(); i++)
            {
                if (i < revs.Count() / 2)
                {
                    counter += 2;
                    total += revs[i].Rating * 2;
                }
                else
                {
                    counter += 1;
                    total += revs[i].Rating;
                }
            }
            result.Rating = total / counter;
            return result;
        }
    }
}
