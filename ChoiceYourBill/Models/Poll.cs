﻿using ChoiceYourBill.Models.AbstractClass;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ChoiceYourBill.Models
{
    public class Poll : Model
    {
        public Poll()
        {
            Votes = new List<Vote>();
        }

        public int Id { get; set; }
        public DateTime Date { get; set; }
        public virtual List<Vote> Votes { get; set; }
    }
}