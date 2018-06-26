using ChoiceYourBill.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ChoiceYourBill.TemplateHelpers.AbstractClass
{
    public class MultiLevelCollectionsGroupHelper
    {
        protected string title;
        //private Dictionary<string, CollectionsGroupHelper> mapCollectionsGroupHelper;

        //public MultiLevelCollectionsGroupHelper()
        //{
        //    this.mapCollectionsGroupHelper = new Dictionary<string, CollectionsGroupHelper>();
        //}

        //public Dictionary<string, CollectionsGroupHelper> MapCollectionsGroupHelper { get => mapCollectionsGroupHelper; set => mapCollectionsGroupHelper = value; }


        //public void Add(List<Poll> inPolls)
        //{

        //    foreach (var poll in inPolls)
        //    {
        //        foreach (var vote in poll.Votes)
        //        {
        //            if (MapCollectionsGroupHelper.ContainsKey(poll.Name))
        //            {
        //                MapCollectionsGroupHelper[poll.Name].Add(vote.Restaurant.Name, vote);
        //            }
        //            else
        //            {
        //                MapCollectionsGroupHelper.Add(poll.Name, new CollectionsGroupHelper());
        //                MapCollectionsGroupHelper[poll.Name].Add(vote.Restaurant.Name, vote);
        //            }
        //            //PollCollectionsGroupHelpers.Add(vote.Restaurant.Name, vote);
        //        }
        //    }
        //public void Add(String name, var value)
        //{

        //    foreach (var poll in inPolls)
        //    {
        //        foreach (var vote in poll.Votes)
        //        {
        //            if (MapCollectionsGroupHelper.ContainsKey(name))
        //            {
        //                MapCollectionsGroupHelper[name].Add(name, vote.Restaurant.Name);
        //            }
        //            else
        //            {
        //                MapCollectionsGroupHelper.Add(name, new CollectionsGroupHelper());
        //                MapCollectionsGroupHelper[name].Add(name, value);
        //            }
        //            PollCollectionsGroupHelpers.Add(vote.Restaurant.Name, vote);
        //        }
        //    }

        //}
    }
}