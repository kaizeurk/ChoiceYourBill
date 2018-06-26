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

        private  IEnumerable<Poll> polls;

        public CollectionsGroupHelper PollCollectionsGroupHelpers
        {
            get => pollCollectionsGroupHelpers;
            private set => pollCollectionsGroupHelpers = value;
        }
        public IEnumerable<Poll> Polls { get => polls; private set => polls = value; }

        public PollsRecordTemplateHelper()
        {
            PollCollectionsGroupHelpers = new CollectionsGroupHelper();
            ObtainAllRecords();
        }

        public override List<Model> ObtainAllRecords()
        {
            List<Poll> inPolls = Dbb.Polls.Include("Votes").ToList();
            Polls = inPolls.ToList().ToArray();
            Records = inPolls.Cast<Model>().ToList();
            provideCollectionsGroup(inPolls);
            return Records;
           
        }

        private void provideCollectionsGroup(List<Poll> inPolls)
        {
            foreach (var poll in inPolls)
            {
                foreach (var vote in poll.Votes)
                {
                    PollCollectionsGroupHelpers.Add(vote.Restaurant.Name, vote);
                }
            } 
        }

    }
}