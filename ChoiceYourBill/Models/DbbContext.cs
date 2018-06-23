using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace ChoiceYourBill.Models
{
    public class DbbContext : DbContext
    {
        public DbSet<Poll> Polls { get; set; }
        public DbSet<Restaurant> Restaurants { get; set; }
        public DbSet<User> Users { get; set; }

        public System.Data.Entity.DbSet<ChoiceYourBill.Models.Vote> Votes { get; set; }
    }
}