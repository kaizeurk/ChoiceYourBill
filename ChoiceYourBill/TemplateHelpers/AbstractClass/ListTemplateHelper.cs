using ChoiceYourBill.Models.AbstractClass;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace ChoiceYourBill.TemplateHelpers.AbstractClass
{
    [DataContract]
    abstract public class ListTemplateHelper : TemplateHelper
    {
        protected List<Model> records;

        [DataMember]
        public List<Model> Records { get => records; protected set => records = value; }

        abstract public List<Model> ObtainAllRecords();
    }
}