using ChoiceYourBill.TemplateHelpers.AbstractClass;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ChoiceYourBill.Controllers.AbstractClass
{
    abstract public class GenericController : Controller
    {
        private TemplateHelper templateHelper;

        protected TemplateHelper TemplateHelper { get => templateHelper; set => templateHelper = value; }


    }
}