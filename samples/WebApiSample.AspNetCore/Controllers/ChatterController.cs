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
            _webHookHandler.VerificationToken = "chatter_1234";
            _clientMessenger = new ClientMessenger("AEAZAHQZAO1zZCIBACZATWyOOPaRWDgFJqgapptnTZCFCLbaHUbJk4w7OJgArLLs43PvztQ3f6KUlySIjZAhPHx9jlP5QILvnhUgFudZAMATGmhmxTzDCkBtZBppwTFNSRJRZC87UV8sUUYWktVVNhL4Tbop9BBPIuL7qfey5gfm0gKwZDZD");            
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
