namespace TheRestaurant.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using TheRestaurant.Models;
    using System.Collections.Generic;
    using WebMatrix.WebData;
    using System.Web.Security;

    internal sealed class Configuration : DbMigrationsConfiguration<TheRestaurant.DAL.restaurantContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(TheRestaurant.DAL.restaurantContext context)
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
new Restaurant {Name="Argento's Kitchen",City="Elba",Country="USA"},
new Restaurant {Name="Ariana Kebob House",City="Rochester",Country="USA"},
new Restaurant {Name="Arigato Japanese Steak House",City="Rochester",Country="USA"},
new Restaurant {Name="Arlington Restaurant",City="Hilton",Country="USA"},
new Restaurant {Name="Arnolds",City="Weedsport",Country="USA"},
new Restaurant {Name="Arya Tea",City="Pittsford",Country="USA"},
new Restaurant {Name="Asia Market",City="Rochester",Country="USA"},
new Restaurant {Name="Asian Garden Thai & Chinese Cuisine",City="Rochester",Country="USA"},
new Restaurant {Name="Astoria FR",City="Phelps",Country="USA"},
new Restaurant {Name="Athena Restaurant",City="Rochester",Country="USA"},
new Restaurant {Name="Athenia",City="Palmyra",Country="USA"},
new Restaurant {Name="Auberge de Soleil",City="NA",Country="USA"},
new Restaurant {Name="Aunt Denise's Donut Den",City="Lima",Country="USA"},
new Restaurant {Name="Anchor Inn",City="NA",Country="USA"},
new Restaurant {Name="Anchor Inn",City="NA",Country="USA"},
new Restaurant {Name="Anchor Inn",City="NA",Country="USA"},
new Restaurant {Name="Andy's Candies",City="Rochester",Country="USA"},
new Restaurant {Name="Andy's Mt Read Diner",City="Rochester",Country="USA"},
new Restaurant {Name="Angelo & Maxie's Pub & Eatery",City="Rochester",Country="USA"},
new Restaurant {Name="Angel's",City="PennYan",Country="USA"},
new Restaurant {Name="Ann's Pancakes",City="Elmira",Country="USA"},
new Restaurant {Name="Anthony's Birch Beer",City="NA",Country="USA"},
new Restaurant {Name="Antonetta's",City="Rochester",Country="USA"},
new Restaurant {Name="Apollo",City="Henrietta",Country="USA"},
new Restaurant {Name="Apple Tree Inn",City="Brockport",Country="USA"},
new Restaurant {Name="Aunt Judy's",City="Rochester",Country="USA"},
new Restaurant {Name="Aurora Inn",City="Aurora",Country="USA"},
new Restaurant {Name="Avon Cafe (RIP 97)",City="East Avon",Country="USA"},
new Restaurant {Name="Avon Inn",City="Avon",Country="USA"},
new Restaurant {Name="Zebb's Deluxe Grill & Bar",City="NA",Country="USA"},
new Restaurant {Name="Zorba's (RIP 01)",City="Geneva",Country="USA"}
     };
            restaurants.ForEach(s => context.restaurants.AddOrUpdate(p => p.Name, s));
            context.SaveChanges();
            var reviews = new List<RestaurantReview>
            {
               new RestaurantReview { RestaurantId= context.restaurants.Single(a=>a.Name=="Filipino").Id, Body="I didn't like the smell", Rating=2, ReviewerName="Boxy"},
               new RestaurantReview {RestaurantId=context.restaurants.Single(a=>a.Name=="Filipino").Id, Body="Tidy", Rating=4, ReviewerName="I-m-no-one"},
               
            };
            reviews.ForEach(s => context.reviews.AddOrUpdate(s));
            context.SaveChanges();
            SeedMembership();
        }

        private void SeedMembership()
        {
            WebSecurity.InitializeDatabaseConnection("RestaurantContext",
                "UserProfile", "UserId", "UserName", autoCreateTables: true);
            var roles = (SimpleRoleProvider)Roles.Provider;
            var membership = (SimpleMembershipProvider)Membership.Provider;

            if (!roles.RoleExists("admin"))
            {
                roles.CreateRole("admin");
            }
            if (!roles.RoleExists("users"))
            {
                roles.CreateRole("users");
            }
            if (membership.GetUser("archana",false)==null)
            {
                membership.CreateUserAndAccount("archana", "umbrella");
            }
            if (!roles.GetRolesForUser("archana").Contains("users"))
            {
                
                roles.AddUsersToRoles(new[] { "archana" }, new[] { "users" });
            }
        }
    }
}
