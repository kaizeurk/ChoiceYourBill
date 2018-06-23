using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ChoiceYourBill.TemplateHelpers.AbstractClass
{
    public class GroupHelper
    {
       private Dictionary<string, List<Object>> map;

        public GroupHelper()
        {
            this.Map  = new Dictionary<string, List<Object>>();
        }
   
        public GroupHelper(Dictionary<string, List<Object>> map)
        {
            this.Map = map;
        }

        public Dictionary<string, List<Object>> Map { get; }

        public void Add(String name, Object value)
        {
            if(Map.ContainsKey(name))
            {
                Map[name].Add(value);
            }
            else
            {
                Map.Add(name, new List <Object> ());
                Map[name].Add(value);
            }
            
        }
    }
}