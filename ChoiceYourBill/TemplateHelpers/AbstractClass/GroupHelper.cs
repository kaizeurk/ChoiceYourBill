using System;
using System.Collections.Generic;
using System.Linq;
using ChoiceYourBill.Models.AbstractClass;

namespace ChoiceYourBill.TemplateHelpers.AbstractClass
{
    public struct GroupHelper <T> where T : Model
    {

        const int OUT_OF_RANGE = -1;
        private string title;

        private List<GroupHelper<T>> GroupsLevel;


        public List<T> GroupList { get; set; }
        public string Title { get => title; set => title = value; }
        public List<GroupHelper<T>> GroupsLevel1 { get => GroupsLevel; set => GroupsLevel = value; }

        public GroupHelper(string inTitle,List<T> inGroup)
        {
           title = inTitle;
           GroupsLevel = new List<GroupHelper<T>>();
           GroupList = new List<T>();
           if (inGroup.Any())
           {
                Collect(inTitle, inGroup);  
           }
        }

        private void Collect(string inTitle, List<T> inGroup)
        {
            foreach (var iteModel in inGroup)
            {
               if(String.Equals((iteModel.Name).ToLower(), inTitle.ToLower()))
               {
                    GroupList.Add(iteModel);       
               } 
            } 
        }

        public void Add( T inModel)
        {
           GroupList.Add(inModel); 
        }

        public void AddToLowerLevel(GroupHelper<T> group)
        {
            int indexGroupsContains = GroupLevelHelperContains(group);
            if(OUT_OF_RANGE == indexGroupsContains )
            {
                GroupsLevel[indexGroupsContains].Collect(group.Title,group.GroupList);
            }
        }

        private int GroupLevelHelperContains(GroupHelper<T> group)
        {
           int cpt = 0;
           foreach (var item in GroupsLevel)
           {
              if(String.Equals(item.Title,group.Title))
              {
                    return cpt;
              }
                cpt++;
           }
            return OUT_OF_RANGE;
        }
    }
}