using ChoiceYourBill.Models;
using ChoiceYourBill.Models.AbstractClass;
using ChoiceYourBill.TemplateHelpers.AbstractClass;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace ChoiceYourBill.TemplateHelpers.EditMode
{
    [DataContract]
    public class PollsEditTemplateHelper : EditTemplateHelper
    {
        public PollsEditTemplateHelper(Poll inRecord) : base(inRecord)
        {

        }

        public override bool UpdateRecord()
        {
            Poll poll = (Poll)Record;

            if (Validate())
            {

                Dbb.Polls.Add(poll);
                Dbb.SaveChanges();
                return true;
            }
            return false;
        }

        public override bool Validate()
        {
            Poll poll = (Poll)Record;
            if (poll.Id == 0 || poll.Id == null)
            {
                throw new NotImplementedException();

            }

            if(poll.Votes == null)
            {
                throw new NotImplementedException();

            }

            return true;
        }
    }
}