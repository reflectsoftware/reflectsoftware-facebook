# ReflectSoftware.Facebook

## Getting Started

To install the Reflectinsight Facebook Messenger, run the following command in the Package Manager Console:

```powershell
Install-Package ReflectSoftware.Facebook.Messenger.AspNetCore.Webhook
```


### Usage (Webhook)

```csharp
using Chatter.Facebook.Messenger.AspNetCore.Webhook;
using Chatter.Facebook.Messenger.Client;
using Chatter.Facebook.Messenger.Common.Models.Client;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ReflectSoftware.Insight;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace WebApplication.Controllers
{
    // https://developers.facebook.com/docs/messenger-platform

    [Route("api/[controller]")]
    public class FacebookController : Controller
    {        
        private readonly WebhookHandler _webHookHandler;
        private readonly ClientMessenger _clientMessenger;

        public FacebookController()
        {
            _webHookHandler = new WebhookHandler();
            _webHookHandler.VerificationToken = "chatter_1234";
            _clientMessenger = new ClientMessenger("PageToken...");            
        }

        [AllowAnonymous]
        [HttpPost, HttpGet]
        [Route("receive/{id}")]
        public async Task<IActionResult> ReceiveAsync(string id)
        {
            var result = (IActionResult)null;

            switch (id)
            {
                case "fbmessager":
                    result = await FacebookAsync();
                    break;
            }

            return result ?? Forbid();
        }

        #region Facebook
        private async Task<IActionResult> FacebookAsync()
        {
            return await _webHookHandler.HandleAsync(HttpContext, async (callback) =>
            {
                RILogManager.Default.SendJSON("Facebook.Callback", callback);

                foreach (var entry in callback.Entry)
                {
                    foreach (var messaging in entry.Messaging)
                    {
                        // User Send Message

                        if (messaging.Message != null && !messaging.Message.IsEcho)
                        {
                            /// This callback will occur when a message has been sent to your page.You may receive text messages or messages 
                            /// with attachments(image, audio, video, file or location).Callbacks contain a seq number which can be used 
                            /// to know the sequence of a message in a conversation. Messages are always sent in order.
                            /// You can subscribe to this callback by selecting the message field when setting up your webhook.

                            var userProfile = await _clientMessenger.GetUserProfileAsync(messaging.Sender.Id);
                            RILogManager.Default.SendJSON("userProfile", userProfile);                           
                                                        
                            var result = await _clientMessenger.SendMessageAsync(messaging.Sender.Id, new TextMessage
                            {
                                Text = $"Hi, {userProfile.Firstname}. An agent will respond to your question shortly."
                            });

                            RILogManager.Default.SendJSON("Results", new[] { result });                            
                        }
                        else if (messaging.Postback != null)
                        {                         
                        }
                        else if (messaging.Delivery != null)
                        {
                            /// This callback will occur when a message a page has sent has been delivered.
                            /// You can subscribe to this callback by selecting the message_deliveries field when setting up your webhook.
                        }
                        else if (messaging.Read != null)
                        {
                            /// This callback will occur when a message a page has sent has been read by the user.
                            /// You can subscribe to this callback by selecting the message_reads field when setting up your webhook.
                        }
                        else if (messaging.Optin != null)
                        {
                            //User Call "Message Us" 
                        }
                        else if (messaging.Referral != null)
                        {
                            // Referral
                        }
                        else if (messaging.AccountLinking != null)
                        {
                            // Account Linking
                        }
                    }
                }

                return Ok();
            });
        }
              
        #endregion Facebook
    }
}
```

Copyright &copy; 2016 ReflectSoftware Inc. - Provided under the [Apache License, Version 2.0](http://apache.org/licenses/LICENSE-2.0.html).
