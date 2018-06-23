using ChoiceYourBill.Models.DataAccessLayer;
using ChoiceYourBill.Models.DataAccessLayer.Interface;
using ChoiceYourBill.TemplateHelpers.AbstractClass;
using ChoiceYourBill.TemplateHelpers.RecordMode;
using ChoiceYourBill.Tests.Models.DataAccessLayer;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChoiceYourBill.Tests.TemplateHelpers
{
    [TestClass]
    public class HomeRecordTemplateHelperTest
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

            ListTemplateHelper templateHelper = new HomeRecordTemplateHelper();
            // Assert
            Assert.IsNotNull(templateHelper);
            Assert.IsNotNull(templateHelper.Records);
            Assert.Equals(5,templateHelper.Records.Count());
        }


    }
}
