using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TheRestaurant.Models;

namespace TheRestaurant.Tests.Features
{
    public interface IRatingAlgorithm
    {
        RatingResult Compute(IList<RestaurantReview> reviews);
    }
}
