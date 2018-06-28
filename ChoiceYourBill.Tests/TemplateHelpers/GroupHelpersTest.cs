using ChoiceYourBill.Models;
using ChoiceYourBill.TemplateHelpers.AbstractClass;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChoiceYourBill.Tests.TemplateHelpers
{
    [TestClass]
    class GroupHelpersTest
    {

        [TestMethod]
        public void GroupHelpersTests() 
        {
            List<GroupHelper<Vote>> polls = new List<GroupHelper<Vote>>();
            // restaurants creat test
            Restaurant restaurant1 = new Restaurant
            {
                Id = 1,
                Name = "restaurant1",
                Fone = "1224775522",
                Address = "rue place de rien 1"
            };
            Restaurant restaurant2 = new Restaurant
            {
                Id = 2,
                Name = "restaurant2",
                Fone = "1224775522",
                Address = "rue place de rien 2"
            };
            Restaurant restaurant3 = new Restaurant
            {
                Id = 3,
                Name = "restaurant3",
                Fone = "1224775522",
                Address = "rue place de rien 3"
            };
            Restaurant restaurant4 = new Restaurant
            {
                Id = 4,
                Name = "restaurant4",
                Fone = "1224775522",
                Address = "rue place de rien 4"
            };
            Restaurant restaurant5 = new Restaurant
            {
                Id = 5,
                Name = "restaurant5",
                Fone = "1224775522",
                Address = "rue place de rien 5"
            };
            Restaurant restaurant6 = new Restaurant
            {
                Id = 6,
                Name = "restaurant6",
                Fone = "1224775522",
                Address = "rue place de rien 6"
            };
            Restaurant restaurant7 = new Restaurant
            {
                Id = 7,
                Name = "restaurant7",
                Fone = "1224775522",
                Address = "rue place de rien 7"
            };
            Restaurant restaurant8 = new Restaurant
            {
                Id = 8,
                Name = "restaurant8",
                Fone = "1224775522",
                Address = "rue place de rien 8"
            };

            //users create test
            User user1 = new User(1, "userLastname1","userFirstName1");
            User user2 = new User(2, "userLastname2","userFirstName2");
            User user3 = new User(3, "userLastname3","userFirstName3");
            User user4 = new User(4, "userLastname4","userFirstName4");
            User user5 = new User(5, "userLastname5","userFirstName5");
            User user6 = new User(6, "userLastname6","userFirstName6");


            Poll poll1 = new Poll
            {
                Id = 1,
                Name = "Session-2018-06-26"
            };
            Poll poll2 = new Poll
            {
                Id = 2,
                Name = "Session-2018-06-27"
            };
            Poll poll3 = new Poll
            {
                Id = 3,
                Name = "Session-2018-06-28"
            };

            Vote vote1 = new Vote
            {
                 Id = 1,
                 Name = "vote1",
                 Restaurant = restaurant1,
                 User = user1
            };

            Vote vote2 = new Vote
            {
                 Id = 2,
                 Name = "vote2",
                 Restaurant = restaurant1,
                 User = user2
            };

            Vote vote3 = new Vote
            {
                 Id = 3,
                 Name = "vote3",
                 Restaurant = restaurant1,
                 User = user3
            };

            Vote vote4 = new Vote
            {
                 Id = 4,
                 Name = "vote4",
                 Restaurant = restaurant2,
                 User = user4
            };

            Vote vote5 = new Vote
            {
                 Id = 5,
                 Name = "vote5",
                 Restaurant = restaurant3,
                 User = user5
            };

            Vote vote6 = new Vote
            {
                 Id = 6,
                 Name = "vote6",
                 Restaurant = restaurant3,
                 User = user6
            };

            poll1.Votes.Add(vote1);
            poll1.Votes.Add(vote2);
            poll1.Votes.Add(vote3);
            poll1.Votes.Add(vote4);
            poll1.Votes.Add(vote5);
            poll1.Votes.Add(vote6);

            poll2.Votes.Add(vote4);
            poll2.Votes.Add(vote5);
            poll2.Votes.Add(vote6);


            polls.Add(new GroupHelper<Vote>(poll1.Name,poll1.Votes));
            polls.Add(new GroupHelper<Vote>(poll2.Name,poll2.Votes));
           
            Assert.IsNotNull(polls);
            Assert.IsNotNull(polls[0].GroupList);
            Assert.Equals(6, polls[0].GroupList.Count());
        }
    }
}
