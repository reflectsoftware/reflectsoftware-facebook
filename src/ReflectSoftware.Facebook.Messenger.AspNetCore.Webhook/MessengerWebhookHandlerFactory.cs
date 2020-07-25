namespace ReflectSoftware.Facebook.Messenger.AspNetCore.Webhook
{
    /// <summary>
    /// 
    /// </summary>
    /// <seealso cref="ReflectSoftware.Facebook.Messenger.AspNetCore.Webhook.IMessengerWebhookHandlerFactory" />
    public class MessengerWebhookHandlerFactory : IMessengerWebhookHandlerFactory
    {
        /// <summary>
        /// Creates the handler.
        /// </summary>
        /// <param name="verificationToken">The verification token.</param>
        /// <param name="appSecret">The application secret.</param>
        /// <param name="ignoreSignature">if set to <c>true</c> [ignore signature].</param>
        /// <returns></returns>
        public IMessengerWebhookHandler CreateHandler(string verificationToken = null, string appSecret = null, bool ignoreSignature = false)
        {
            return new MessengerWebhookHandler(verificationToken, appSecret, ignoreSignature);
        }
    }
}
