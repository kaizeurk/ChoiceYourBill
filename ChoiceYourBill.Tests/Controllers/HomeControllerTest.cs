using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ChoiceYourBill.Tests.Models.DataAccessLayer;
using ChoiceYourBill.Controllers;
using ChoiceYourBill.Models;
using ChoiceYourBill.Models.DataAccessLayer;
using ChoiceYourBill.Models.DataAccessLayer.Interface;

namespace ChoiceYourBill.Tests.Controllers
{
    [TestClass]
    public class HomeControllerTest
    {
        private IDal dal;
        [TestInitialize]
        public void InitTest()
        {
            DbbInit.initDbb();
            dal = new Dal();
        }

        [TestMethod]
        public void Index()
        {
            dal.CreateRestaurant("La bonne fourchette", "01 02 03 04 05", "Metro Longueuil");
            dal.CreateRestaurant("La bonne fourchette1", "01 02 03 04 05", "Metro Longueuil");
            dal.CreateRestaurant("La bonne fourchette2", "01 02 03 04 05", "Metro Longueuil");
            dal.CreateRestaurant("La bonne fourchette3", "01 02 03 04 05", "Metro Longueuil");
            dal.CreateRestaurant("La bonne fourchette4", "01 02 03 04 05", "Metro Longueuil");
            // Arrange
            HomeController controller = new HomeController();

            // Act
            ViewResult result = controller.Index() as ViewResult;

            // Assert
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void About()
        {
            // Arrange
            HomeController controller = new HomeController();

            // Act
            ViewResult result = controller.About() as ViewResult;

            // Assert
            Assert.AreEqual("Your application description page.", result.ViewBag.Message);
        }

        [TestMethod]
        public void Contact()
        {
            // Arrange
            HomeController controller = new HomeController();

            // Act
            ViewResult result = controller.Contact() as ViewResult;

            // Assert
            Assert.IsNotNull(result);
        }
    }
}
