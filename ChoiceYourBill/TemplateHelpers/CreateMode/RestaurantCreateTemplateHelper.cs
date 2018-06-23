using ChoiceYourBill.Models;
using ChoiceYourBill.Models.AbstractClass;
using ChoiceYourBill.TemplateHelpers.AbstractClass;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.Threading.Tasks;
using System.Net;
using System.Web.Mvc;

namespace ChoiceYourBill.TemplateHelpers.CreateMode
{
    public class RestaurantCreateTemplateHelper : CreateTemplateHelper
    {
        public RestaurantCreateTemplateHelper(Model inRecord): base(inRecord)
        {

        }

        public override Model Validate(Model record) 
        {
           if(String.IsNullOrWhiteSpace(((Restaurant)record).Name)==false)
           {
             new System.ArgumentException("Name of restaurant cannot be null", "record");
           }
           return record;
        }
        [HttpPost]
        public async Task<int> SaveRecordAsync()
        {
            Dbb.Restaurants.Add((Restaurant)Record);
            return await Dbb.SaveChangesAsync();
            
        }
    }
}