# ReflectSoftware.Facebook

## Getting Started

To install the Reflectinsight Facebook Messenger, run the following command in the Package Manager Console:


### Usage - Webhook for AspNetCore 1.0.1

```powershell
Install-Package ReflectSoftware.Facebook.Messenger.AspNetCore.Webhook
```


```csharp
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ReflectSoftware.Facebook.Messenger.AspNetCore.Webhook;
using ReflectSoftware.Facebook.Messenger.Client;
using ReflectSoftware.Facebook.Messenger.Common.Models.Client;
using ReflectSoftware.Insight;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace WebApiSample.AspNetCore.Controllers
{
    // https://developers.facebook.com/docs/messenger-platform

    /// <summary>
    /// 
    /// </summary>
    /// <seealso cref="Microsoft.AspNetCore.Mvc.Controller" />
    [Route("api/[controller]")]
    public class ChatterController : Controller
    {
        private static readonly HashSet<string> _FirstTimeCaller;

        private readonly WebhookHandler _webHookHandler;
        private readonly ClientMessenger _clientMessenger;

        /// <summary>
        /// Initializes the <see cref="ChatterController"/> class.
        /// </summary>
        static ChatterController()
        {
            _FirstTimeCaller = new HashSet<string>();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ChatterController"/> class.
        /// </summary>
        public ChatterController()
        {
            _webHookHandler = new WebhookHandler();
            _webHookHandler.VerificationToken = "your_verification_code";
            _clientMessenger = new ClientMessenger("your_page_access_token");
        }

        /// <summary>
        /// Receives the asynchronous.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
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

            return result ?? BadRequest();
        }

        #region Facebook
        /// <summary>
        /// Facebook the asynchronous.
        /// </summary>
        /// <returns></returns>
        private async Task<IActionResult> FacebookAsync()
        {
            return await _webHookHandler.HandleAsync(HttpContext, async (callback) =>
            {
                RILogManager.Default.SendJSON("Facebook.Callback", callback);

                foreach (var entry in callback.Entry)
                {
                    foreach (var messaging in entry.Messaging)
                    {
                        if (messaging.Message != null && !messaging.Message.IsEcho)
                        {
                            /// User Send Message
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
                            /// User Call "Message Us" 
                        }
                        else if (messaging.Referral != null)
                        {
                            /// Referral
                        }
                        else if (messaging.AccountLinking != null)
                        {
                            /// Account Linking
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

### Usage - Webhook for WebAPI Full Framework .NET 4.6.1

```powershell
Install-Package ReflectSoftware.Facebook.Messenger.WebAPI.Webhook
```

```csharp
using ReflectSoftware.Facebook.Messenger.Client;
using ReflectSoftware.Facebook.Messenger.Common.Models.Client;
using ReflectSoftware.Facebook.Messenger.WebAPI.Webhook;
using ReflectSoftware.Insight;
using System.Threading.Tasks;
using System.Web.Http;

namespace WebApiSample.Controllers
{
    /// <summary>
    /// 
    /// </summary>
    /// <seealso cref="System.Web.Http.ApiController" />
    public class ChatterController : ApiController
    {
        private readonly WebhookHandler _webHookHandler;
        private readonly ClientMessenger _clientMessenger;

        /// <summary>
        /// Initializes a new instance of the <see cref="ChatterController"/> class.
        /// </summary>
        public ChatterController()
        {
            _webHookHandler = new WebhookHandler();
            _webHookHandler.VerificationToken = "your_verification_code";
            _clientMessenger = new ClientMessenger("your_page_access_token");
        }

        /// <summary>
        /// Receives the asynchronous.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        [AllowAnonymous]
        [HttpPost, HttpGet]
        [Route("api/chatter/receive/{id}")]
        public async Task<IHttpActionResult> ReceiveAsync(string id)
        {
            var result = (IHttpActionResult)null;

            switch (id)
            {
                case "fbmessager":
                    result = await FacebookAsync();
                    break;
            }

            return result ?? BadRequest();
        }


        #region Facebook
        /// <summary>
        /// Facebook the asynchronous.
        /// </summary>
        /// <returns></returns>
        private async Task<IHttpActionResult> FacebookAsync()
        {
            return await _webHookHandler.HandleAsync(Request, async (callback) =>
            {
                RILogManager.Default.SendJSON("Facebook.Callback", callback);

                foreach (var entry in callback.Entry)
                {
                    foreach (var messaging in entry.Messaging)
                    {
                        if (messaging.Message != null && !messaging.Message.IsEcho)
                        {
                            /// User Send Message
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
                             /// User Call "Message Us" 
                        }
                        else if (messaging.Referral != null)
                        {
                            /// Referral
                        }
                        else if (messaging.AccountLinking != null)
                        {
                            /// Account Linking
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
