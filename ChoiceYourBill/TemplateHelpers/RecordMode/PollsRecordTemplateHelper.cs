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
        private CollectionsGroupHelper pollCollectionsGroupHelpers;

        public CollectionsGroupHelper PollCollectionsGroupHelpers
        {
            get => pollCollectionsGroupHelpers;
            private set => pollCollectionsGroupHelpers = value;
        }

        public PollsRecordTemplateHelper()
        {
            PollCollectionsGroupHelpers = new CollectionsGroupHelper();
            Records = ObtainAllRecords();
        }

        public override List<Model> ObtainAllRecords()
        {
            List<Poll> polls = Dbb.Polls.Include("Votes").ToList();
            Records = polls.Cast<Model>().ToList();
            provideCollectionsGroup(polls);
            return Records;
        }

        private void provideCollectionsGroup(List<Poll> polls)
        {
            foreach (var poll in polls)
            {
                foreach (var vote in poll.Votes)
                {
                    PollCollectionsGroupHelpers.Add(vote.Restaurant.Name, vote);
                }
            } 
        }

    }
}