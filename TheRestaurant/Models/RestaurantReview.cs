using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace TheRestaurant.Models
{
    public class RestaurantReview
    {
        public int Id { get; set; }
        [Range(1,5)]
        [Required(ErrorMessage="Rating field cannot be left blank")]
        public int Rating { get; set; }
        [Required]
        [StringLength(1024)]
        [Display(Name="Your Message")]
        public string Body { get; set; }
        [DisplayFormat(NullDisplayText="anonymous")]
        public string ReviewerName { get; set; }
        public virtual int RestaurantId { get; set; }
    }
}