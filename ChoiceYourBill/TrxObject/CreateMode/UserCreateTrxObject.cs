using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using ChoiceYourBill.TemplateHelpers.AbstractClass;

namespace ChoiceYourBill.TrxObject.CreateMode
{
    public class UserCreateTrxObject : CreateTrxObject
    {
        public UserCreateTrxObject(CreateTemplateHelper templateHelper): base(templateHelper)
        {
        }
        public override Task<int> SaveRecord()
        {
           return null;
        }

        protected override CreateTemplateHelper ValidateTemplateHelper(CreateTemplateHelper templateHelper)
        {
            return TemplateHelper;
        }
    }
}