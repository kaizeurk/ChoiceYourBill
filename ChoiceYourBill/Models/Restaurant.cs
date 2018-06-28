using ChoiceYourBill.Models.AbstractClass;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ChoiceYourBill.Models
{
    public class Restaurant : Model
    {
        private string address;

        public Restaurant():base()
        {
            Address = "";
        }

        public Restaurant(Restaurant inRestaurant)
        {
            this.Id      = inRestaurant.Id;
            this.Name    = inRestaurant.Name;
            this.Fone    = inRestaurant.Fone;
            this.Address = inRestaurant.Address;
        }

        public int Id { get; set; }
        public int IdResto { get; set; }
        public string Fone { get; set; }
        public string Address { get => address; set => address = value; }

        public override bool Equals(object obj)
        {
            Restaurant rest = (Restaurant)obj;
            return ( (Name.CompareTo(rest.Name) & Fone.CompareTo(rest.Fone) & Address.CompareTo(rest.Address))==1?true:false);
        }

        public override int GetHashCode()
        {
            var hashCode = -94008202;
            hashCode = hashCode * -1521134295 + IdResto.GetHashCode();
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Name);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Fone);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(address);
            hashCode = hashCode * -1521134295 + Id.GetHashCode();
            hashCode = hashCode * -1521134295 + IdResto.GetHashCode();
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Name);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Fone);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Address);
            return hashCode;
        }
    }
}