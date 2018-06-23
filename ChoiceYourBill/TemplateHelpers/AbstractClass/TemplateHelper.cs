using ChoiceYourBill.Models;
using ChoiceYourBill.Models.AbstractClass;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Web;
using System.Web.Script.Serialization;
using Newtonsoft.Json;

namespace ChoiceYourBill.TemplateHelpers.AbstractClass
{
    [System.Runtime.Serialization.DataContract]
    abstract public class TemplateHelper
    {
        private DbbContext dbb;

        protected TemplateHelper()
        {
            Dbb = new DbbContext();
        }

        protected DbbContext Dbb { get => dbb; set => dbb = value; }
        public string ToJson()
        {
            TemplateHelper bsObj = this;
            string js = JsonConvert.SerializeObject(bsObj);
            // DataContractJsonSerializer js = new DataContractJsonSerializer(typeof(TemplateHelper));
            //MemoryStream msObj = new MemoryStream();
            //js.WriteObject(msObj, bsObj);
            //msObj.Position = 0;
            // StreamReader sr = new StreamReader(msObj);

            // "{\"Description\":\"Share Knowledge\",\"Name\":\"C-sharpcorner\"}"  
            //string json = sr.ReadToEnd();

            //sr.Close();
            //msObj.Close();
            //JsonConverter.Serialize;
            //string json = new JavaScriptSerializer().Serialize(bsObj);

            //return json;


            //Create a stream to serialize the object to.  
            //MemoryStream ms = new MemoryStream();

            // Serializer the User object to the stream.  
            //DataContractJsonSerializer ser = new DataContractJsonSerializer(typeof(TemplateHelper));
            //ser.WriteObject(ms, bsObj);
            //byte[] json = ms.ToArray();
            //ms.Close();
            //return Encoding.UTF8.GetString(json, 0, json.Length);
            return js;
        }
    }
}