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
        
        private int idResto;
        private string name;
        private string fone;
        private string address;

        public Restaurant()
        {
        }

        public Restaurant(Restaurant inRestaurant)
        {
            this.Id      = inRestaurant.Id;
            this.Name    = inRestaurant.Name;
            this.Fone    = inRestaurant.Fone;
            this.Address = inRestaurant.Address;
        }

        public int Id { get; set; }
        public int IdResto { get => idResto; set => idResto = value; }
        public string Name { get => name; set => name = value; }
        public string Fone { get => fone; set => fone = value; }
        public string Address { get => address; set => address = value; }

        public override bool Equals(object obj)
        {
            Restaurant rest = (Restaurant)obj;
            return ( (Name.CompareTo(rest.Name) & Fone.CompareTo(rest.Fone) & Address.CompareTo(rest.Address))==1?true:false);
        }

        public override int GetHashCode()
        {
            var hashCode = -94008202;
            hashCode = hashCode * -1521134295 + idResto.GetHashCode();
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(name);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(fone);
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