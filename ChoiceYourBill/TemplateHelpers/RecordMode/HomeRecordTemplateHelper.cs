using ChoiceYourBill.Models;
using ChoiceYourBill.Models.AbstractClass;
using ChoiceYourBill.TemplateHelpers.AbstractClass;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace ChoiceYourBill.TemplateHelpers.RecordMode
{
    [DataContract]
    public class HomeRecordTemplateHelper : ListTemplateHelper
    {

        public  HomeRecordTemplateHelper()
        {
            Records = ObtainAllRecords();
        }

        public override List<Model> ObtainAllRecords()
        {
            List<Restaurant> rest = Dbb.Restaurants.ToList();
            Records = rest.Cast<Model>().ToList();
            return Records;
        }

    }
}