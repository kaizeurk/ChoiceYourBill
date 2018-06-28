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
        private List<Group> pollCollectionsGroupHelpers;

        private  IEnumerable<Poll> polls;

        public List<Group> PollCollectionsGroupHelpers
        {
            get => pollCollectionsGroupHelpers;
            private set => pollCollectionsGroupHelpers = value;
        }
        public IEnumerable<Poll> Polls { get => polls; private set => polls = value; }


        // Constructor
        public PollsRecordTemplateHelper()
        {
            PollCollectionsGroupHelpers = new List<Group>();
            ObtainAllRecords();
        }

        public override List<Model> ObtainAllRecords()
        {
            List<Poll> inPolls = Dbb.Polls.Include("Votes").ToList();
            Polls = inPolls.ToList().ToArray();
            Records = inPolls.Cast<Model>().ToList();
            ProvideCollectionsGroup(inPolls);
            return Records;
           
        }

        private void ProvideCollectionsGroup(List<Poll> inPolls)
        {
            List<Restaurant> restaurants = Dbb.Restaurants.ToList();
           // List<Group> pollListGroupHelper = new List<Group>();
            PollCollectionsGroupHelpers = new List<Group>();
            foreach (var poll in inPolls)
            {
                Group pollGroupHelper = new Group();
                pollGroupHelper.Title = poll.Name;
                pollGroupHelper.Id = poll.Id;
                foreach (var rest in restaurants)
                {

                    List<Vote> listeVote = (from vote in poll.Votes
                                            where vote.Restaurant.Name == rest.Name
                                            select vote ).ToList();

                    Group votreGroupHelper = new Group();
                    votreGroupHelper.Id = rest.Id;
                    votreGroupHelper.Title = rest.Name;
                    if (listeVote.Any())
                    {
                        votreGroupHelper.GroupList = listeVote;
                    }
                    if (pollGroupHelper.NextGroups == null)
                    {
                        pollGroupHelper.NextGroups = new List<Group>() { votreGroupHelper };
                    }
                    else
                    {
                        ((List<Group>)(pollGroupHelper.NextGroups)).Add(votreGroupHelper);
                    }

                    
                    //PollCollectionsGroupHelpers.Add(vote.Restaurant.Name, vote, poll.Name);
                    //PollCollectionsGroupHelpers[0].CollectionsGroupNextLevel.
                    

                }
                PollCollectionsGroupHelpers.Add(pollGroupHelper);
            } 
        }

        private Dictionary<string,Poll> t()
        {
            return null;
        }

    }
}