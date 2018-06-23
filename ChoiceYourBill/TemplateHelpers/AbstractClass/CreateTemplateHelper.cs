using ChoiceYourBill.Models.AbstractClass;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ChoiceYourBill.TemplateHelpers.AbstractClass
{
    abstract public class CreateTemplateHelper : TemplateHelper
    {
        protected Model record;

        public CreateTemplateHelper(Model inRecord)
        {
            this.Record = Validate(inRecord);
        }

        public Model Record { get => record; set => record = this.Validate(value); }

        public abstract Model Validate(Model record);

    }
}