using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TheRestaurant.Models;
using TheRestaurant.DAL;

namespace TheRestaurant.Tests.Fakes
{
    public class FakeRestaurantDb:IRestaurantRepository
    {
        List<Restaurant> _restaurants;
        public FakeRestaurantDb()
        {
            var restaurants = new List<Restaurant>
            {
                new Restaurant{Name="The Oasis Cafe", City="Kathmandu", Country="Nepal", Reviews=new List<RestaurantReview>
                {
                    new RestaurantReview{ Body="Conjusted", ReviewerName="Allen", Rating=3},
                    new RestaurantReview {Body="Good Parking", ReviewerName="Bill", Rating=4},
                    new RestaurantReview {Body="Worst Momo",ReviewerName="Sabina", Rating=1}
                }},
                new Restaurant{Name="Delicacies", City="Delhi",Country="India", Reviews=
                    new List<RestaurantReview>
                    {
                        new RestaurantReview{Body="Good Ambience", Rating=4, ReviewerName="Mahesh"},
                        new RestaurantReview{Body="Awesome Food", Rating=5,ReviewerName="Piyush"}
                    }
                },
                new Restaurant{Name="Filipino", City="Sydney", Country="Australia"},
                new Restaurant{Name="The Oriental", City="Beijing", Country="China"},
                new Restaurant {Name="58 Main St",City="Brockport",Country="USA"},
                new Restaurant {Name="Abundance Cooperative Market",City="Rochester",Country="USA"},
                new Restaurant {Name="Abyssina",City="Rochester",Country="USA"},
                new Restaurant {Name="Aces",City="Honeoye",Country="USA"},
                new Restaurant {Name="Acropolis",City="Rochester",Country="USA"},
                new Restaurant {Name="Admiral Woolsey's",City="Oswego",Country="USA"},
                new Restaurant {Name="Agatina's Restaurant",City="Rochester",Country="USA"},
                new Restaurant {Name="Aja Noodle Company",City="Rochester",Country="USA"},
                new Restaurant {Name="Akropolis",City="Canandaigua",Country="USA"},
                new Restaurant {Name="Aladdins Natural Eatery",City="Pittsford",Country="USA"},
                new Restaurant {Name="Aladdin's Natural Eatery",City="Rochester",Country="USA"},
                new Restaurant {Name="Alexander Street Pub",City="NA",Country="USA"},
                new Restaurant {Name="Allen's Cobblestone Deli",City="Victor",Country="USA"},
                new Restaurant {Name="Allens Hill Farm",City="Bloomfield",Country="USA"},
                new Restaurant {Name="Al's Diner",City="Clyde",Country="USA"},
                new Restaurant {Name="American Hotel",City="Lima",Country="USA"},
                new Restaurant {Name="Amiels The Original Submarine",City="NA",Country="USA"},
                new Restaurant {Name="Argento's Kitchen",City="Albion",Country="USA"},
                new Restaurant {Name="Zorba's (RIP 01)",City="Geneva",Country="USA"}
     };
        }
        public IQueryable<Restaurant> GetRestaurants()
        {
           
            IQueryable<Restaurant> rests = _restaurants.AsQueryable();
            return rests;
        }

        public IQueryable<Restaurant> GetRestaurantById(int restaurantId)
        {
            throw new NotImplementedException();
        }

        public IQueryable<Restaurant> GetRestaurantsIncludingReviews()
        {
            throw new NotImplementedException();
        }

        public IQueryable<RestaurantReview> GetReviewsByRestaurant(int restaurantId)
        {
            throw new NotImplementedException();
        }

        public IQueryable<RestaurantReview> GetReview(int id)
        {
            throw new NotImplementedException();
        }

        public bool Save()
        {
            return true;
        }

        public bool AddRestaurant(Restaurant restaurant)
        {
            return true;
        }

        public bool RemoveRestaurant(Restaurant restaurant)
        {
            throw new NotImplementedException();
        }

        public bool EditRestaurant(Restaurant restaurant)
        {
            throw new NotImplementedException();
        }

        public bool AddReview(RestaurantReview review)
        {
            throw new NotImplementedException();
        }

        public bool EditReview(RestaurantReview review)
        {
            throw new NotImplementedException();
        }

        public bool EditReview(ViewModels.VMRestaurantReview review)
        {
            throw new NotImplementedException();
        }


        public int GetRestaurantsCount()
        {
            throw new NotImplementedException();
        }
    }
}
