using ChoiceYourBill.Models.AbstractClass;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;

namespace ChoiceYourBill.Models
{
    public class User : Model
    {

        private string lastname;
        private string firstname;
        private string pwd;

        public User()
        {
        }

        public User(int id, string lastname, string firstname)
        {
            this.Id = id;
            this.Lastname = lastname ?? throw new ArgumentNullException(nameof(lastname));
            this.Firstname = firstname ?? throw new ArgumentNullException(nameof(firstname));
        }

        public int Id { get => id; set => id = value; }

        [Required, MaxLength(80)]
        public string Lastname { get => lastname; set => lastname = value; }
        public string Firstname { get => firstname; set => firstname = value; }
        public string Pwd { get => pwd; set => pwd = value; }

        public override bool Equals(object obj)
        {
            return base.Equals(obj);
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public override string ToString()
        {
            return base.ToString();
        }
    }
}