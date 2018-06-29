using ChoiceYourBill.Models.AbstractClass;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ChoiceYourBill.TemplateHelpers.AbstractClass
{
    abstract public class EditTemplateHelper : RecordTemplateHelper
    {
        public EditTemplateHelper(Model inRecord) :base( inRecord)
        {

        }

        abstract public bool Validate();

        abstract public bool UpdateRecord();


    }
}