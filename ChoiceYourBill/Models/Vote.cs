using ChoiceYourBill.Models.AbstractClass;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ChoiceYourBill.Models
{
    public class Vote : Model
    {

        [Key]
        private User user;
        private Restaurant restaurant;

        public Vote()
        {
        }

        public Vote(User user, Restaurant restaurant)
        {
            this.User       = user ?? throw new ArgumentNullException(nameof(user));
            this.Restaurant = restaurant ?? throw new ArgumentNullException(nameof(restaurant));
        }

        public int Id { get; set; }

        public int PollId { get; set; }

        public int RestaurantId { get; set; }

        public int UserId { get; set; }

        public virtual User User { get => user; set => user = value; }

        public virtual Restaurant Restaurant { get => restaurant; set => restaurant = value; }
    }
}