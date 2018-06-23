using ChoiceYourBill.Models.AbstractClass;
using ChoiceYourBill.TemplateHelpers.AbstractClass;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ChoiceYourBill.TemplateHelpers.CreateMode
{
    public class UserCreateTemplateHelper : CreateTemplateHelper
    {
        public UserCreateTemplateHelper(Model inRecord): base(inRecord)
        {

        }

        public override Model Validate(Model record) 
        {
           
           return record;
        }

        public int SaveRecord()
        {
            return 0;
        }
    }
}