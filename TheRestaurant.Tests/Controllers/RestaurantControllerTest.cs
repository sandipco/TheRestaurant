using TheRestaurant.Controllers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting.Web;
using TheRestaurant.DAL;
using System.Web.Mvc;
using TheRestaurant.Models;
using TheRestaurant.Tests.Fakes;
using System.Collections.Generic;

namespace TheRestaurant.Tests
{
    [TestClass()]
    public class RestaurantControllerTest
    {
        [TestMethod]
        public void AddValidRestaurant()
        {
            // Arrange
            var db = new FakeRestaurantDb();
            RestaurantController controller = new RestaurantController(db);
           // Act
            //ViewResult result = controller.Create() as ViewResult;

            ViewResult result = controller.Create(new Restaurant()) as ViewResult;
          //  IEnumerable<Restaurant> model= result.Model as IEnumerable<Restaurant>;

            // Assert
            Assert.IsNull(result);
        }
        [TestMethod]
        public void AddInvalidRestaurant()
        {
            // Arrange
            var db = new FakeRestaurantDb();
            RestaurantController controller = new RestaurantController(db);
            // Act
            //ViewResult result = controller.Create() as ViewResult;
            controller.ModelState.AddModelError("", "Invalid Object");
            
             ViewResult result= controller.Create(new Restaurant()) as ViewResult;
             IEnumerable<Restaurant> model = result.Model as IEnumerable<Restaurant>;

            // Assert
             Assert.IsNotNull(result);
        }
    }
}
