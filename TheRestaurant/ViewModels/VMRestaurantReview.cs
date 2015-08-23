using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TheRestaurant.ViewModels
{
    public class VMRestaurantReview
    {
        public int Id { get; set; }
        public int Rating { get; set; }
        public string Body { get; set; }
        //public string ReviewerName { get; set; }
        public virtual int RestaurantId { get; set; }
    }
}