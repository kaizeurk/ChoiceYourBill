using ChoiceYourBill.Models;
using ChoiceYourBill.Models.DataAccessLayer;
using ChoiceYourBill.Models.DataAccessLayer.Interface;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChoiceYourBill.Tests.Models.DataAccessLayer
{

    [TestClass]
    public class DalTests
    {
        private IDal dal;
        [TestInitialize]
        public void InitTest()
        {
            DbbInit.initDbb();
            dal = new Dal();
        }

        [TestMethod]
        public void Create_ANew_Restaurant_With_ObtainAllRestaurants()
        {

                dal.CreateRestaurant("La bonne fourchette", "01 02 03 04 05","Metro Longueuil");
                List<Restaurant> restos = dal.ObtainAllRestaurants();

                Assert.IsNotNull(restos);
                Assert.AreEqual(1, restos.Count);
                Assert.AreEqual("La bonne fourchette", restos[0].Name);
                Assert.AreEqual("01 02 03 04 05", restos[0].Fone);
                Assert.AreEqual("Metro Longueuil", restos[0].Address);

        }

        [TestMethod]
        public void Edit_Restaurant_With_EditRestaurant()
        {

                dal.CreateRestaurant("La bonne fourchette", "01 02 03 04 05");
                List<Restaurant> restos = dal.ObtainAllRestaurants();
                int id = restos.First(r => r.Name == "La bonne fourchette").Id;

                dal.EditRestaurant(id, "La bonne cuillère", null,null);

                restos = dal.ObtainAllRestaurants();
                Assert.IsNotNull(restos);
                Assert.AreEqual(1, restos.Count);
                Assert.AreEqual("La bonne cuillère", restos[0].Name);
                Assert.IsNotNull(restos[0].Fone);
            
        }

        [TestMethod]
        public void RestaurantExiste_WithCreateRestauraunt_ReturnExist()
        {
            dal.CreateRestaurant("La bonne fourchette", "0102030405");

            bool existe = dal.RestaurantExist("La bonne fourchette");

            Assert.IsTrue(existe);
        }

        [TestMethod]
        public void RestaurantExist_WithRestaurauntInexistant_ReturnExist()
        {
            bool existe = dal.RestaurantExist("La bonne fourchette");

            Assert.IsFalse(existe);
        }

        [TestMethod]
        public void ObtainUser_UserInexistant_ReturnNull()
        {
            User user = dal.ObtainUser(1);
            Assert.IsNull(user);
        }

        [TestMethod]
        public void ObtainUser_IdNonNumerique_ReturnNull()
        {
            User user = dal.ObtainUser("abc");
            Assert.IsNull(user);
        }

        [TestMethod]
        public void AddUser_NouvelUserEtRecuperation_LUserEstBienRecupere()
        {
            dal.AddUser("Nouvel User","new1", "12345");

            User user = dal.ObtainUser(1);

            Assert.IsNotNull(user);
            Assert.AreEqual("Nouvel User", user.Firstname);

            user = dal.ObtainUser("1");

            Assert.IsNotNull(user);
            Assert.AreEqual("Nouvel User", user.Firstname);
        }

        [TestMethod]
        public void Authentificate_LoginMdpOk_AuthentificationOK()
        {
            dal.AddUser("Nouvel User", "New1", "12345");

            User user = dal.Authentificate("Nouvel User", "12345");

            Assert.IsNotNull(user);
            Assert.AreEqual("Nouvel User", user.Firstname);
        }

        [TestMethod]
        public void Authentificate_LoginOkMdpKo_AuthentificationKO()
        {
            dal.AddUser("Nouvel User", "New1", "12345");
            User user = dal.Authentificate("Nouvel User", "0");

            Assert.IsNull(user);
        }

        [TestMethod]
        public void Authentificate_LoginKoMdpOk_AuthentificationKO()
        {
            dal.AddUser("Nouvel User", "New1", "12345");
            User user = dal.Authentificate("Nouvel", "12345");

            Assert.IsNull(user);
        }

        [TestMethod]
        public void Authentificate_LoginMdpKo_AuthentificationKO()
        {
            User user = dal.Authentificate("Nouvel User", "12345");

            Assert.IsNull(user);
        }

        [TestMethod]
        public void AlredyVoted_AvecIdNonNumerique_RetourneFalse()
        {
            bool pasVote = dal.AlredyVoted(1, "abc");

            Assert.IsFalse(pasVote);
        }

        [TestMethod]
        public void AlredyVoted_UserNAPasVote_RetourneFalse()
        {
            int idSondage = dal.CreatePoll();
            int idUser = dal.AddUser("Nouvel User","New1", "12345");

            bool pasVote = dal.AlredyVoted(idSondage, idUser.ToString());

            Assert.IsFalse(pasVote);
        }

        [TestMethod]
        public void AlredyVoted_UserAVote_RetourneTrue()
        {
            int idSondage = dal.CreatePoll();
            int idUser = dal.AddUser("Nouvel User", "New1", "12345");
            dal.CreateRestaurant("La bonne fourchette", "0102030405");
            dal.AddVoted(idSondage, 1, idUser);

            bool aVote = dal.AlredyVoted(idSondage, idUser.ToString());

            Assert.IsTrue(aVote);
        }

        [TestMethod]
        public void ObtainResults_AvecQuelquesChoix_RetourneBienLesResults()
        {
            int idSondage = dal.CreatePoll();
            int idUser1 = dal.AddUser("User1", "New1", "12345");
            int idUser2 = dal.AddUser("User2", "New2", "12345");
            int idUser3 = dal.AddUser("User3", "New3", "12345");

            dal.CreateRestaurant("Resto pinière", "0102030405");
            dal.CreateRestaurant("Resto pinambour", "0102030405");
            dal.CreateRestaurant("Resto mate", "0102030405");
            dal.CreateRestaurant("Resto ride", "0102030405");

            dal.AddVoted(idSondage, 1, idUser1);
            dal.AddVoted(idSondage, 3, idUser1);
            dal.AddVoted(idSondage, 4, idUser1);
            dal.AddVoted(idSondage, 1, idUser2);
            dal.AddVoted(idSondage, 1, idUser3);
            dal.AddVoted(idSondage, 3, idUser3);

            List<Results> results = dal.ObtainResults(idSondage);

            Assert.AreEqual(3, results[0].VotesNbr);
            Assert.AreEqual("Resto pinière", results[0].Name);
            Assert.AreEqual("0102030405", results[0].Fone);
            Assert.AreEqual(2, results[1].VotesNbr);
            Assert.AreEqual("Resto mate", results[1].Name);
            Assert.AreEqual("0102030405", results[1].Fone);
            Assert.AreEqual(1, results[2].VotesNbr);
            Assert.AreEqual("Resto ride", results[2].Name);
            Assert.AreEqual("0102030405", results[2].Fone);
        }

        [TestMethod]
        public void ObtainResults_AvecDeuxSondages_RetourneBienLesBonsResults()
        {
            int idSondage1 = dal.CreatePoll();
            int idUser1 = dal.AddUser("User1", "New1", "12345");
            int idUser2 = dal.AddUser("User2", "New2", "12345");
            int idUser3 = dal.AddUser("User3", "New3", "12345");
            dal.CreateRestaurant("Resto pinière", "0102030405");
            dal.CreateRestaurant("Resto pinambour", "0102030405");
            dal.CreateRestaurant("Resto mate", "0102030405");
            dal.CreateRestaurant("Resto ride", "0102030405");
            dal.AddVoted(idSondage1, 1, idUser1);
            dal.AddVoted(idSondage1, 3, idUser1);
            dal.AddVoted(idSondage1, 4, idUser1);
            dal.AddVoted(idSondage1, 1, idUser2);
            dal.AddVoted(idSondage1, 1, idUser3);
            dal.AddVoted(idSondage1, 3, idUser3);

            int idSondage2 = dal.CreatePoll();
            dal.AddVoted(idSondage2, 2, idUser1);
            dal.AddVoted(idSondage2, 3, idUser1);
            dal.AddVoted(idSondage2, 1, idUser2);
            dal.AddVoted(idSondage2, 4, idUser3);
            dal.AddVoted(idSondage2, 3, idUser3);

            List<Results> results1 = dal.ObtainResults(idSondage1);
            List<Results> results2 = dal.ObtainResults(idSondage2);

            Assert.AreEqual(3, results1[0].VotesNbr);
            Assert.AreEqual("Resto pinière", results1[0].Name);
            Assert.AreEqual("0102030405", results1[0].Fone);
            Assert.AreEqual(2, results1[1].VotesNbr);
            Assert.AreEqual("Resto mate", results1[1].Name);
            Assert.AreEqual("0102030405", results1[1].Fone);
            Assert.AreEqual(1, results1[2].VotesNbr);
            Assert.AreEqual("Resto ride", results1[2].Name);
            Assert.AreEqual("0102030405", results1[2].Fone);

            Assert.AreEqual(1, results2[0].VotesNbr);
            Assert.AreEqual("Resto pinambour", results2[0].Name);
            Assert.AreEqual("0102030405", results2[0].Fone);
            Assert.AreEqual(2, results2[1].VotesNbr);
            Assert.AreEqual("Resto mate", results2[1].Name);
            Assert.AreEqual("0102030405", results2[1].Fone);
            Assert.AreEqual(1, results2[2].VotesNbr);
            Assert.AreEqual("Resto pinière", results2[2].Name);
            Assert.AreEqual("0102030405", results2[2].Fone);
        }


    }
}
