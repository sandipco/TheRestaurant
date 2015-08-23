using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace TheRestaurant.Models
{
    public class Restaurant
    {
        public int Id { get; set; }
        [Required]
        [Display(Name="Name of the Restaurant")]
        public string Name { get; set; }
        [Required]
        [Display(Name="Name of the City")]
        public string City { get; set; }
        [Display(Name="Name of the Country")]
        public string Country { get; set; }
        public virtual ICollection<RestaurantReview> Reviews { get; set; }
    }
}