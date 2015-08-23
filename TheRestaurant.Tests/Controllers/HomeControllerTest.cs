﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TheRestaurant;
using TheRestaurant.Controllers;
using TheRestaurant.Tests.Fakes;
using TheRestaurant.Models;

namespace TheRestaurant.Tests.Controllers
{
    [TestClass]
    public class HomeControllerTest
    {
        [TestMethod]
        public void Index()
        {
            // Arrange
            HomeController controller = new HomeController(new FakeRestaurantDb());
            controller.ControllerContext = new FakeControllerContext();
            
            // Act
            ViewResult result = controller.Index() as ViewResult;

            // Assert
            IEnumerable<Restaurant> model = result.Model as IEnumerable<Restaurant>;
            Assert.AreEqual(10, model.Count());

            
        }

        [TestMethod]
        public void About()
        {
            //// Arrange
            //HomeController controller = new HomeController();

            //// Act
            //ViewResult result = controller.About() as ViewResult;

            //// Assert
            //Assert.IsNotNull(result);
        }

        [TestMethod]
        public void Contact()
        {
            // Arrange
            //HomeController controller = new HomeController();

            //// Act
            //ViewResult result = controller.Contact() as ViewResult;

            //// Assert
            //Assert.IsNotNull(result);
        }
    }
}
