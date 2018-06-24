using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ChoiceYourBill.Models.AbstractClass;

namespace ChoiceYourBill.TemplateHelpers.AbstractClass
{
    public class CollectionsGroupHelper
    {
       private Dictionary<string, GroupHelper> map;

        public CollectionsGroupHelper()
        {
            this.Map  = new Dictionary<string, GroupHelper>();
        }
   
        public CollectionsGroupHelper(Dictionary<string, GroupHelper> map)
        {
            this.Map = map;
        }

        public Dictionary<string, GroupHelper> Map { get; }

        public void Add(String name, Model value)
        {
            if(Map.ContainsKey(name))
            {
                Map[name].Add(name,value);
            }
            else
            {
                Map.Add(name, new GroupHelper (name,new List<Model>()));
                Map[name].Add(name,value);
            }
        }

        public bool delete(String name, Model value)
        {
            if(Map.ContainsKey(name))
            {
                Map[name].@group.Remove(value);
                return true;
            }

            return false;
        }

        public bool delete(String name, GroupHelper value)
        {
            if(Map.ContainsKey(name))
            {
                Map.Remove(name);
                return true;
            }

            return false;
        }

        private void AddOnGroups(GroupHelper groupHelper)
        {
            
        }
    }
}