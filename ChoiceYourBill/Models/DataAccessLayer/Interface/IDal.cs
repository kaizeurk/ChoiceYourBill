using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChoiceYourBill.Models.DataAccessLayer.Interface
{
    // Interface Data Access Layer
    public interface IDal : IDisposable
    {
        void CreateRestaurant(string name, string fone = "", string address = "");
        void EditRestaurant(int id, string name, string fone, string address);
        List<Restaurant> ObtainAllRestaurants();
        User ObtainUser(int id);
        User ObtainUser(string idStrg);
        int AddUser(string firstname, string lastname = "" , string pwd="");
        User Authentificate(string firstname, string pwd);
        bool AlredyVoted(int idPoll, string idStr2);
        int CreatePoll();
        void AddVoted(int idSondage, int idResto, int idUser);
        List<Results> ObtainResults(int idSondage);
        bool RestaurantExist(string restoName);
    }
}
