using ChoiceYourBill.Models;
using ChoiceYourBill.Models.AbstractClass;
using ChoiceYourBill.TemplateHelpers.AbstractClass;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace ChoiceYourBill.TemplateHelpers.EditMode
{
    [DataContract]
    public class PollsEditTemplateHelper : EditTemplateHelper
    {
        public PollsEditTemplateHelper(Model inRecord) : base(inRecord)
        {

        }


    }
}