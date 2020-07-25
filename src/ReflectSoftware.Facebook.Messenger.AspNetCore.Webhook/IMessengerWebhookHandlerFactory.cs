namespace ReflectSoftware.Facebook.Messenger.AspNetCore.Webhook
{
    public interface IMessengerWebhookHandlerFactory
    {
        IMessengerWebhookHandler CreateHandler(string verificationToken = null, string appSecret = null, bool ignoreSignature = false);
    }
}
