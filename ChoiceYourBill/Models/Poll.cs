using ChoiceYourBill.Models.AbstractClass;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ChoiceYourBill.Models
{
    public class Poll : Model
    {
        const int IS_ACTIVE     = 1;
        const int IS_NOT_ACTIVE = 0;
        public Poll()
        {
            Votes = new List<Vote>();
        }

        public int Id { get; set; }
        public bool ActiveFlag { get; set; }
        //[DatabaseGenerated(DatabaseGenerationOption.Computed)]
        public DateTime Date { get; set; }
        public virtual List<Vote> Votes { get; set; }
    }
}