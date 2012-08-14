using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Twilio;
using Microsoft.WindowsAzure;
using Microsoft.WindowsAzure.StorageClient;

namespace Flatterist.Web.Controllers
{
    public class SendMessagesController : Controller
    {
        //
        // GET: /SendMessages/

        public ActionResult Index()
        {
            bool messages = true;

            while (messages)
            {
                string storageConnectionString = "DefaultEndpointsProtocol=https;AccountName=AccountName;AccountKey=ACCOUNTKEY";

                CloudStorageAccount storageAccount = CloudStorageAccount.Parse(storageConnectionString);
                CloudQueueClient queueClient = storageAccount.CreateCloudQueueClient();
                CloudQueue queue = queueClient.GetQueueReference("messages");
                CloudQueueMessage retrievedMessage = queue.GetMessage();

                if (retrievedMessage == null)
                {
                    messages = false;
                }

                string phone = retrievedMessage.AsString;

                var twilio = new TwilioRestClient("accountSid", "authToken");
                var call = twilio.InitiateOutboundCall("+YOURTWILIONUMBER", phone, "http://YOURSITE.azurewebsites.net/LookupCompliment/");

                queue.DeleteMessage(retrievedMessage);

            }

            return View("Complete!");
        }

    }
}
