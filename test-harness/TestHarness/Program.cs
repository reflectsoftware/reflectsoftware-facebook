using ReflectSoftware.Facebook.Messenger.Client;
using ReflectSoftware.Facebook.Messenger.Common.Models.Client;
using System;
using System.IO;
using System.Threading.Tasks;

namespace TestHarness
{
    class Program
    {
        private static async Task RunAync()
        {
            var client = new ClientMessenger("EAAeZCcIjFqGABAAw7i1ljNQySeT2ZB3HZAd5jvlr0mrFiMkJ4NZCobpiJ3lCZBK0JQrjXnUVOPShUAXHEwCZClBIiiqixsx5gH2y8FGZBgTurdKbM1Mtm0iscsI9x9KRaxR55v3M6anAIRZC6ZCbQZCx3bumkC8ZBxt3wynee80xkbviwZDZD");

            // var result = await client.SendMessageAsync("2001954456545360", new TextMessage("Hi there Ross - 3!"));
            // var result1 = await client.SendActionAsync("2001954456545360", ReflectSoftware.Facebook.Messenger.Common.Enums.SenderAction.TypingOn);
            // var result2 = await client.SendActionAsync("2001954456545360", ReflectSoftware.Facebook.Messenger.Common.Enums.SenderAction.TypingOff);

            //var result1 = await client.SetGreetingTextAsync("Welcome to Hubster");
            //var result2 = await client.SetGreetingTextAsync();

            var result = await client.GetUserProfileAsync("2001954456545360");
        }

        static void Main(string[] args)
        {
            RunAync().GetAwaiter().GetResult();


            //using (var stream = File.OpenRead(@"C:\Data\FTP\Ross\hubster.io\Sample Attachments\File\pdf-sample.pdf"))
            //{
            //    var result = client.SendAttachmentAsync("2001954456545360", stream, "pdf-sample.pdf", "application/pdf", "file").Result;
            //}

            //using (var stream = File.OpenRead(@"C:\Data\FTP\Ross\hubster.io\Sample Attachments\Images\Cosmos.jpg"))
            //{
            //    var result = client.SendAttachmentAsync("2001954456545360", stream, "Cosmos.jpg", "image/jpeg", "image").Result;
            //}

            //using (var stream = File.OpenRead(@"C:\Data\FTP\Ross\hubster.io\Sample Attachments\Audio\TheLamb.mp3"))
            //{
            //    var result = client.SendAttachmentAsync("2001954456545360", stream, "TheLamb.mp3", "audio/mp3", "audio").Result;
            //}
        }
    }
}
