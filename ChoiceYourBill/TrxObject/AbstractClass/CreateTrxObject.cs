using ChoiceYourBill.Models.AbstractClass;
using ChoiceYourBill.TemplateHelpers.AbstractClass;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace ChoiceYourBill.TrxObject.CreateMode
{
   abstract public class CreateTrxObject
   {
        protected CreateTemplateHelper templateHelper;

        public CreateTrxObject(Model record)
        {
        }
        public CreateTrxObject(CreateTemplateHelper templateHelper)
        {
            this.TemplateHelper = templateHelper;
        }

        protected CreateTemplateHelper TemplateHelper { get => templateHelper; set => templateHelper = this.ValidateTemplateHelper(value); }

        protected abstract CreateTemplateHelper ValidateTemplateHelper(CreateTemplateHelper templateHelper);

        public abstract Task<int> SaveRecord();
    }
}