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
        //private CollectionsGroupHelper<Object> collectionsGroupNextLevel;

        public CollectionsGroupHelper()
        {
            this.GroupHelpers  = new List<GroupHelper<T>>();
        }
   
        public CollectionsGroupHelper(string inTitle, List<GroupHelper<T>> map, CollectionsGroupHelper<T> inCollectionsGroupNextLevel=null)
        {
            this.GroupHelpers = map;
            Title = inTitle;
            if(inCollectionsGroupNextLevel != null)
            {
              // CollectionsGroupNextLevel = new CollectionsGroupHelper<T>();
            }
        }

        public List<GroupHelper<T>> GroupHelpers { get; set; }
        protected string Title { get; set; }

        public void Add(string name, T value, string inCollectionName = null)
        {
            int indexContains = ContainsTitle(inCollectionName);
            if (indexContains > OUT_OF_RANGE)
            {
                GroupHelpers[indexContains].Add(value);
            }
            else
            {
                GroupHelper<T> groupHelper = new GroupHelper<T>(name,new List<T> { value});
                Title = inCollectionName;
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