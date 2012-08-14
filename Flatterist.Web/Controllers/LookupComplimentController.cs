using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Net;
using System.IO;
using Twilio.TwiML;
using Twilio.TwiML.Mvc;

namespace Flatterist.Web.Controllers
{
    public class LookupComplimentController : TwilioController
    {
        //
        // GET: /LookupCompliment/

        public ActionResult Index()
        {
            WebRequest request = WebRequest.Create("http://www.flatterist.com/compliments.json");

            request.Method = "GET";
            request.ContentType = "application/json; charset=utf-8";

            string jsonData = string.Empty;

            using (Stream s = request.GetResponse().GetResponseStream())
            {
                using (StreamReader sr = new StreamReader(s))
                {
                    jsonData = sr.ReadToEnd();
                }
            }

            var json = (IDictionary<string, object>)SimpleJson.DeserializeObject(jsonData);
            var results = (List<object>)json["compliments"];

            int randomNumber = new Random().Next(results.Count);

            dynamic fileNameStuff = results[randomNumber];
            dynamic fileName = fileNameStuff[0];

            TwilioResponse tr = new TwilioResponse();

            tr.Play("http://www.flatterist.com/" + fileName + ".mp3");

            return TwiML(tr);
        }
    }
}
