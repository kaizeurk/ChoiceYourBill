using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using ChoiceYourBill.Models;

namespace ChoiceYourBill.Models.DataAccessLayer
{
    public class Dal : Interface.IDal
    {
        private DbbContext dbb;

        public Dal()
        {
            this.Dbb = new DbbContext();
        }

        public DbbContext Dbb { get => dbb; set => dbb = value; }

        public int AddUser(string firstname, string lastname = "", string inPwd = null)
        {
            string pwd = EncodeMD5(inPwd);
            User User = new User { Firstname = firstname, Lastname = lastname, Pwd = pwd  };
            dbb.Users.Add(User);
           // dbb.{"Users"}.Add(User);
            dbb.SaveChanges();
            return User.Id;
        }

        public void AddVoted(int idpoll, int idRestaurant, int idUser)
        {
            Vote vote = new Vote
            {
                Restaurant = dbb.Restaurants.First(r => r.Id == idRestaurant),
                User = dbb.Users.First(u => u.Id == idUser)
            };
            Poll poll = dbb.Polls.First(s => s.Id == idpoll);
            if (poll.Votes == null)
                poll.Votes = new List<Vote>();
            poll.Votes.Add(vote);
            dbb.SaveChanges();
        }

        public bool AlredyVoted(int idPoll, string idStr)
        {
            int id;
            if (int.TryParse(idStr, out id))
            {
                Poll poll = dbb.Polls.First(s => s.Id == idPoll);
                if (poll.Votes == null)
                    return false;
                return poll.Votes.Any(v => v.User != null && v.User.Id == id);
            }
            return false;
        }

        public User Authentificate(string firstname, string inPwd)
        {
            string pwd = EncodeMD5(inPwd);
            return dbb.Users.FirstOrDefault(u => u.Firstname == firstname && u.Pwd == pwd);
        }

        public int CreatePoll()
        {
            Poll poll = new Poll { Date = DateTime.Now };
            dbb.Polls.Add(poll);
            dbb.SaveChanges();
            return poll.Id;
        }

        public void CreateRestaurant(string name, string fone = "", string address = "")
        {
            Dbb.Restaurants.Add(new Restaurant { Name = name, Fone = fone, Address = address });
            Dbb.SaveChanges();
        }

        public void Dispose()
        {
            Dbb.Dispose();
        }

        public void EditRestaurant(int id, string name, string fone, string address)
        {
            Restaurant RestaurantFound = dbb.Restaurants.FirstOrDefault(Restaurant => Restaurant.Id == id);
            Restaurant restaurantToEdit = new Restaurant(RestaurantFound);
            if (RestaurantFound != null)
            {
                if (String.IsNullOrWhiteSpace(name)==false)
                {
                    RestaurantFound.Name = name;
                }

                if (String.IsNullOrWhiteSpace(fone) == false)
                {
                    RestaurantFound.Fone = fone;
                }

                if (String.IsNullOrWhiteSpace(address) == false)
                {
                    RestaurantFound.Address = address;
                }

                if (restaurantToEdit.Equals(RestaurantFound) == false)
                {
                    dbb.SaveChanges();
                }
            }
        }

        public List<Restaurant> ObtainAllRestaurants()
        {
            return Dbb.Restaurants.ToList();
        }

        public List<Results> ObtainResults(int idpoll)
        {
            List<Restaurant> restaurants = ObtainAllRestaurants();
            List<Results> results = new List<Results>();
            Poll sondage = dbb.Polls.First(s => s.Id == idpoll);
            foreach (IGrouping<int, Vote> grouping in sondage.Votes.GroupBy(v => v.Restaurant.Id))
            {
                int idRestaurant = grouping.Key;
                Restaurant Restaurant = restaurants.First(r => r.Id == idRestaurant);
                int votesNbr = grouping.Count();
                results.Add(new Results { Name = Restaurant.Name, Fone = Restaurant.Fone, VotesNbr = votesNbr });
            }
            return results;
        }

        public User ObtainUser(int id)
        {
            return dbb.Users.FirstOrDefault(u => u.Id == id);
        }

        public User ObtainUser(string idStrg)
        {
            int id;
            if (int.TryParse(idStrg, out id))
                return ObtainUser(id);
            return null;
        }

        public bool RestaurantExist(string RestaurantName)
        {
            return dbb.Restaurants.Any(Restaurant => string.Compare(Restaurant.Name, RestaurantName, StringComparison.CurrentCultureIgnoreCase) == 0);
        }

        private string EncodeMD5(string pwd)
        {
            string pwdl = "ChoixRestaurant" + pwd + "ASP.NET MVC";
            return BitConverter.ToString(new MD5CryptoServiceProvider().ComputeHash(ASCIIEncoding.Default.GetBytes(pwdl)));
        }
    }
}