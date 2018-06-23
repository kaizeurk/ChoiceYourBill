using ChoiceYourBill.Models.AbstractClass;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ChoiceYourBill.Models
{
    public class Results : Model
    {
        public string Name { get; set; }
        public string Fone { get; set; }
        public int VotesNbr  { get; set; }
    }
}