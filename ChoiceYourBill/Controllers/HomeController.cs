using ChoiceYourBill.Controllers.AbstractClass;
using ChoiceYourBill.TemplateHelpers.RecordMode;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ChoiceYourBill.Controllers
{
    public class HomeController : GenericController
    {
        public  ActionResult Index()
        {

            TemplateHelper = new HomeRecordTemplateHelper();
            ViewData["TemplateHelperJson"] = JObject.Parse(TemplateHelper.ToJson());
            ViewData["TemplateHelper"] = TemplateHelper;
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";
            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult AddRestaurant()
        {
            ViewBag.Message = "Add  Restaurant page.";

            return View();
        }
    }
}