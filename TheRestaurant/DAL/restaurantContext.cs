using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using TheRestaurant.Models;

namespace TheRestaurant.DAL
{
    public class restaurantContext:DbContext
    {
        public restaurantContext():base("RestaurantContext")
        {

        }
        public DbSet<UserProfile> UserProfiles { get; set; }
        public DbSet<Restaurant> restaurants { get; set; }
        public DbSet<RestaurantReview> reviews { get; set; }
    }
}