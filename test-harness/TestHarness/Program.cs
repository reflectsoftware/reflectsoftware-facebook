using ReflectSoftware.Facebook.Messenger.Client;
using System;
using System.IO;

namespace TestHarness
{
    class Program
    {
        static void Main(string[] args)
        {
            var client = new ClientMessenger("....");

            //using (var stream = File.OpenRead(@"C:\Data\FTP\Ross\hubster.io\Sample Attachments\File\pdf-sample.pdf"))
            //{
            //    var result = client.SendAttachmentAsync("2001954456545360", stream, "pdf-sample.pdf", "application/pdf", "file").Result;
            //}

            //using (var stream = File.OpenRead(@"C:\Data\FTP\Ross\hubster.io\Sample Attachments\Images\Cosmos.jpg"))
            //{
            //    var result = client.SendAttachmentAsync("2001954456545360", stream, "Cosmos.jpg", "image/jpeg", "image").Result;
            //}

            using (var stream = File.OpenRead(@"C:\Data\FTP\Ross\hubster.io\Sample Attachments\Audio\TheLamb.mp3"))
            {
                var result = client.SendAttachmentAsync("2001954456545360", stream, "TheLamb.mp3", "audio/mp3", "audio").Result;
            }
        }
    }
}
