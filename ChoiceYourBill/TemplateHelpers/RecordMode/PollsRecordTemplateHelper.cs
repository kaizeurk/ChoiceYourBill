using ChoiceYourBill.Models;
using ChoiceYourBill.Models.AbstractClass;
using ChoiceYourBill.TemplateHelpers.AbstractClass;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace ChoiceYourBill.TemplateHelpers.RecordMode
{
    [DataContract]
    public class PollsRecordTemplateHelper : ListTemplateHelper
    {

        public PollsRecordTemplateHelper()
        {
            Records = ObtainAllRecords();
        }

        public override List<Model> ObtainAllRecords()
        {
            List<Poll> poll = Dbb.Polls.Include("Votes").ToList();
            Records = poll.Cast<Model>().ToList();
            return Records;
        }

    }
}