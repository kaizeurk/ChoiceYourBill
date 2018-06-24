using System;
using System.Collections.Generic;
using System.Linq;
using ChoiceYourBill.Models.AbstractClass;

namespace ChoiceYourBill.TemplateHelpers.AbstractClass
{
    public struct GroupHelper
    {
        public string title;
        public List<Model> group;

        public GroupHelper(string inTitle,List<Model> inGroup)
        {
           @group = new List<Model>();
           title = inTitle;
           if (inGroup.Any())
           {
              collect(inTitle, inGroup);  
           }
        }

        private void collect(string inTitle, List<Model> inGroup)
        {
            foreach (var iteModel in inGroup)
            {
               if(String.Equals((iteModel.Name).ToLower(), inTitle.ToLower()))
               {
                 @group.Add(iteModel);       
               } 
            } 
        }

        public void Add(string inTitle, Model inModel)
        {
            if (String.Equals(inTitle,title))
            {
               @group.Add(inModel); 
            }
        }
    }
}