using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using ChoiceYourBill.Models;
using ChoiceYourBill.Models.AbstractClass;
using ChoiceYourBill.TemplateHelpers.AbstractClass;
using ChoiceYourBill.TemplateHelpers.CreateMode;

namespace ChoiceYourBill.TrxObject.CreateMode
{
    public class RestaurantCreateTrxObject : CreateTrxObject
    {
        public RestaurantCreateTrxObject(Model record) : base(record)
        {
            this.TemplateHelper = new RestaurantCreateTemplateHelper(record);
        }
        public RestaurantCreateTrxObject(CreateTemplateHelper templateHelper): base(templateHelper)
        {
        }
        public override Task<int> SaveRecord()
        {
            return ((RestaurantCreateTemplateHelper)TemplateHelper).SaveRecordAsync();
        }

        protected override CreateTemplateHelper ValidateTemplateHelper(CreateTemplateHelper templateHelper)
        {
            return TemplateHelper;
        }
    }
}