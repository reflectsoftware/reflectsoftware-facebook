using ReflectSoftware.Facebook.Messenger.Client;
using ReflectSoftware.Facebook.Messenger.Common.Models.Client;
using ReflectSoftware.Facebook.Messenger.WebAPI.Webhook;
using ReflectSoftware.Insight;
using System.Threading.Tasks;
using System.Web.Http;

namespace WebApplication1.Controllers
{
    public class ChatterController : ApiController
    {
        private readonly WebhookHandler _webHookHandler;
        private readonly ClientMessenger _clientMessenger;

        public ChatterController()
        {
            _webHookHandler = new WebhookHandler();
            _webHookHandler.VerificationToken = "chatter_1234";
            _clientMessenger = new ClientMessenger("EAAZAHQZAO1zZCIBAK3ZBvjdS7pvIh9ZBVdHUwlvzo95LWVSHjC76LOEEPStX1pt2UMMYWyZC32ZCiK0jjlb4TQkmSjqKVdBG1Td0NgxYdYrY9Y05lBpoI4FMZAAkJolZCemN90ldZCo3rPEGfOiDZBDwGoZC6iVZCRlTBb9NbpHZCsSrnZCTQZDZD");
        }
        
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
        private Task<IHttpActionResult> FacebookAsync()
        {
            return _webHookHandler.HandleAsync(Request, (callback) =>
            {
                RILogManager.Default.SendJSON("Facebook.Callback", callback);

                foreach (var entry in callback.Entry)
                {
                    foreach (var messaging in entry.Messaging)
                    {
                        if (messaging.Message != null && !messaging.Message.IsEcho)
                        {
                            /// This callback will occur when a message has been sent to your page.You may receive text messages or messages 
                            /// with attachments(image, audio, video, file or location).Callbacks contain a seq number which can be used 
                            /// to know the sequence of a message in a conversation. Messages are always sent in order.
                            /// You can subscribe to this callback by selecting the message field when setting up your webhook.

                            var userProfile = _clientMessenger.GetUserProfileAsync(messaging.Sender.Id).Result;
                            RILogManager.Default.SendJSON("userProfile", userProfile);

                            //var result = await _clientMessenger.SendMessageAsync(messaging.Sender.Id, new TextMessage
                            //{
                            //    Text = $"Hi, {userProfile.Firstname}. An agent will respond to your question shortly."
                            //});

                            // RILogManager.Default.SendJSON("Results", new[] { result });

                            // User Send Message
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