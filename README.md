# ReflectSoftware.Facebook

[![Build status](https://ci.appveyor.com/api/projects/status/0ftxpw3dne25ncra?svg=true)](https://ci.appveyor.com/project/reflectsoftware/reflectsoftware-facebook)
[![Stars](https://img.shields.io/github/stars/reflectsoftware/reflectsoftware-facebook.svg)](https://github.com/reflectsoftware/reflectsoftware-facebook/stargazers) 
[![NuGet Version](http://img.shields.io/nuget/v/Reflectsoftware.Facebook.Messenger.AspNetCore.Webhook.svg?style=flat)](https://www.nuget.org/packages/ReflectSoftware.Facebook.Messenger.AspNetCore.Webhook/)


## Getting Started

To install the ReflectSoftware Facebook Messenger, run the following command in the Package Manager Console:


**Package** - [ReflectSoftware.Facebook.Messenger.Common](https://www.nuget.org/packages/ReflectSoftware.Facebook.Messenger.Common/) | .NET Standard 4.6.1  
**Package** - [ReflectSoftware.Facebook.Messenger.Client](https://www.nuget.org/packages/ReflectSoftware.Facebook.Messenger.Client/) | .NET Standard 4.6.1  
**Package** - [ReflectSoftware.Facebook.Messenger.AspNetCore.Webhook](https://www.nuget.org/packages/ReflectSoftware.Facebook.Messenger.AspNetCore.Webhook/) | .NET Standard 4.6.1  



### Usage - Webhook for AspNetCore 2.0.0

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



Copyright &copy; 2017 ReflectSoftware Inc. - Provided under the [Apache License, Version 2.0](http://apache.org/licenses/LICENSE-2.0.html).

I like to give recognition to the following repos for their awesome work: 

* https://github.com/thiagoamarante/Deadlock.FBMessengerPlatform
