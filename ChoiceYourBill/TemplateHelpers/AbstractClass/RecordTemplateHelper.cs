using ChoiceYourBill.Models.AbstractClass;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Json;
using System.Web;

namespace ChoiceYourBill.TemplateHelpers.AbstractClass
{
    abstract public class RecordTemplateHelper  : TemplateHelper
    {
        private Model record;

        protected RecordTemplateHelper(Model inRecord=null)
        {
            this.Record = inRecord;
        }

        protected Model Record { get => record; set => record = value; }

    }
}