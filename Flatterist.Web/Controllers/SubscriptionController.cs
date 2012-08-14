using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Twilio.TwiML;
using Twilio.TwiML.Mvc;
using System.Net;
using System.IO;
using Twilio;
using Microsoft.WindowsAzure;
using Microsoft.WindowsAzure.StorageClient;
using System.Text.RegularExpressions;
using PhoneNumbers;

namespace Flatterist.Web.Controllers
{
    public class SubscriptionController : Controller
    {
        //
        // GET: /Subscription/

        public ActionResult Index(string From, string To, string Body)
        {
            TwilioRestClient twilio;
            SMSMessage text;

            PhoneNumberUtil phoneUtil = PhoneNumberUtil.GetInstance();
            string oldFrom = From;

            try
            {
                From = phoneUtil.Parse(Body, "US").NationalNumber.ToString();

                twilio = new TwilioRestClient("accountSid", "authToken");
                text = twilio.SendSmsMessage("+YOURTWILIONUMBER", oldFrom, "You're so thoughtful. Steve will call your friend soon!");
            }
            catch (NumberParseException e)
            {

            }

            string storageConnectionString = "DefaultEndpointsProtocol=https;AccountName=AccountName;AccountKey=ACCOUNTKEY";

            CloudStorageAccount storageAccount = CloudStorageAccount.Parse(storageConnectionString);
            CloudQueueClient queueClient = storageAccount.CreateCloudQueueClient();
            CloudQueue queue = queueClient.GetQueueReference("messages");
            queue.CreateIfNotExist();
            CloudQueueMessage message = new CloudQueueMessage(From);
            queue.AddMessage(message, new TimeSpan(1, 0, 0), new TimeSpan(0, 1, 0));

            twilio = new TwilioRestClient("accountSid", "authToken");
            text = twilio.SendSmsMessage("+YOURTWILIONUMBER", From, "Sorry you're not feeling well. You'll soon hear from Steve! If you want Steve to call a friend just send their number!");

            return View();

        }

    }
}
