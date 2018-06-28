using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ChoiceYourBill.TemplateHelpers.AbstractClass
{
    public class Group
    {
        private int id;
        private string title;
        private IEnumerable<Object> groupList;
        private IEnumerable<Group> nextGroups;

        public Group()
        {

        }

        public IEnumerable<Group> NextGroups { get => nextGroups; set => nextGroups = value; }
        public int Id { get => id; set => id = value; }
        public string Title { get => title; set => title = value; }
        public IEnumerable<object> GroupList { get => groupList; set => groupList = value; }
    }
}