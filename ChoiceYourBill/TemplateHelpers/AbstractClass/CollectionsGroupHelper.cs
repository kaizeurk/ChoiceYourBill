using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ChoiceYourBill.Models.AbstractClass;

namespace ChoiceYourBill.TemplateHelpers.AbstractClass
{
    public class CollectionsGroupHelper <T> where T : Model
    {
        const int OUT_OF_RANGE = -1;

        public CollectionsGroupHelper()
        {
            this.GroupHelpers  = new List<GroupHelper<T>>();
        }
   
        public CollectionsGroupHelper(string inTitle, List<GroupHelper<T>> map)
        {
            this.GroupHelpers = map;
            Title = inTitle;
        }

        public List<GroupHelper<T>> GroupHelpers { get; set; }
        protected string Title { get; set; }

        public void Add(string name, T value)
        {
            int indexContains = ContainsTitle(name);
            if (indexContains == OUT_OF_RANGE)
            {
                GroupHelpers[indexContains].Add(value);
            }
            else
            {
                GroupHelper<T> groupHelper = new GroupHelper<T>(name,new List<T> { value});

                GroupHelpers.Add(groupHelper);
            }
        }

        private int ContainsTitle(string inTitle)
        {
            int cpt = 0;
            foreach(var elem in GroupHelpers)
            {
                if(String.Equals(elem.Title,inTitle))
                {
                    return cpt;
                }
                cpt++;
            }
            return OUT_OF_RANGE;
        }

        public bool delete(String name, T value)
        {
            

            return false;
        }

        public bool delete(String name, GroupHelper<T> value)
        {
            
            return false;
        }

        private void AddOnGroups(GroupHelper<T> groupHelper)
        {
            
        }
    }
}