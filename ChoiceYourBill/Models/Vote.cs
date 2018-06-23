using ChoiceYourBill.Models.AbstractClass;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ChoiceYourBill.Models
{
    public class Vote : Model
    {

        [Key]
        private int idVote;
        private User user;
        private Restaurant restaurant;

        public Vote()
        {
        }

        public Vote(int idVote, User user, Restaurant restaurant)
        {
            this.IdVote = idVote;
            this.User = user ?? throw new ArgumentNullException(nameof(user));
            this.Restaurant = restaurant ?? throw new ArgumentNullException(nameof(restaurant));
        }

        public int Id { get; set; }
        public int IdVote { get => idVote; set => idVote = value; }
        public virtual User User { get => user; set => user = value; }
        public virtual Restaurant Restaurant { get => restaurant; set => restaurant = value; }
    }
}