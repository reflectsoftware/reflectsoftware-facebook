using ReflectSoftware.Facebook.Messenger.Client;
using ReflectSoftware.Facebook.Messenger.Common.Enums;
using ReflectSoftware.Facebook.Messenger.Common.Models;
using ReflectSoftware.Facebook.Messenger.Common.Models.Client;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace TestHarness
{
    partial class Program
    {
        private static async Task SendSimpleMessageAync(ClientMessenger client, string userId)
        {
            var result1 = await client.SendMessageAsync(userId, new TextMessage("Hi there Ross - 4!"));
            
            // typing on/off
            var result2 = await client.SendActionAsync(userId, SenderAction.TypingOn);
            await Task.Delay(10000);
            var result3 = await client.SendActionAsync(userId, SenderAction.TypingOff);
           
            var userProfile = await client.GetUserProfileAsync(userId);

            // set greeting - on first attaching
            var result10 = await client.SetGreetingTextAsync("Welcome to Hubster");
            
            // clear greeting
            var result11 = await client.SetGreetingTextAsync();

        }

        private static async Task SendAttachmentsMessageAync(ClientMessenger client, string userId)
        {
            using (var stream = File.OpenRead(@"C:\Data\FTP\Ross\hubster.io\work\Sample Attachments\File\pdf-sample.pdf"))
            {
                var result = await client.SendFileAttachmentAsync(userId, stream, "pdf-sample.pdf", "application/pdf", "file");
            }

            using (var stream = File.OpenRead(@"C:\Data\FTP\Ross\hubster.io\work\Sample Attachments\Images\Cosmos.jpg"))
            {
                var result = await client.SendFileAttachmentAsync(userId, stream, "Cosmos.jpg", "image/jpeg", "image");
            }

            using (var stream = File.OpenRead(@"C:\Data\FTP\Ross\hubster.io\work\Sample Attachments\Audio\2647611198313044978-a2002011001_e02.mp3"))
            {
                var result = await client.SendFileAttachmentAsync(userId, stream, "NiceMusic.mp3", "audio/mp3", "audio");
            }

            using (var stream = File.OpenRead(@"C:\Data\FTP\Ross\hubster.io\work\Sample Attachments\video\TextInMotion-Sample-576p.mp4"))
            {
                var result = await client.SendFileAttachmentAsync(userId, stream, "My Video.mp3", "video/mp4", "video");
            }
        }


        private static async Task SendQuickRepliesAsync(ClientMessenger client, string userId)
        {
            var buttonsMessage = new TextMessage 
            { 
                Text = "Pick a size:", 
                QuickReplies = new List<QuickReply> 
                { 
                    new TextQuickReply("Small", "small selected"),
                    new TextQuickReply("Medium", "medium selected"),
                    new TextQuickReply("Large", "large selected"),
                    new TextQuickReply("One", "One selected"),
                    new TextQuickReply("Two", "Two selected"),
                    new TextQuickReply("Three", "Three selected"),
                    new TextQuickReply("Four", "Four selected"),
                    new TextQuickReply("Five", "Five selected"),
                    new TextQuickReply("Six", "Six selected"),
                }
            };

            // var package = await client.GetJSONRenderedAsync(userId, buttonsMessage, messageType: MessageType.Response);            
            var result1 = await client.SendMessageAsync(userId, buttonsMessage);

            var buttonImagesMessage = new TextMessage
            {
                Text = "Pick a color:",
                QuickReplies = new List<QuickReply>
                {
                    new TextQuickReply("Red", "red selected", "https://hubsterdevcdn.blob.core.windows.net/pub/demo/playground/red.png" ),
                    new TextQuickReply("Green", "green selected", "https://hubsterdevcdn.blob.core.windows.net/pub/demo/playground/green.png" ),
                    new TextQuickReply("Yellow", "yellow selected", "https://hubsterdevcdn.blob.core.windows.net/pub/demo/playground/yellow.png" ),
                }
            };

            // var package = await client.GetJSONRenderedAsync(userId, buttonImagesMessage, messageType: MessageType.Response);
            var result2 = await client.SendMessageAsync(userId, buttonImagesMessage);

            // request for phone number
            var phoneMessage = new TextMessage { Text = "Please send us your phone number?", QuickReplies = new List<QuickReply> { new PhoneNumberQuickReply() } };
            var result10 = await client.SendMessageAsync(userId, phoneMessage);

            // request for email
            var emailMessage = new TextMessage { Text = "Please send us your email address.", QuickReplies = new List<QuickReply> { new EmailQuickReply() } };
            var result11 = await client.SendMessageAsync(userId, emailMessage);

            // has been deprecated 
            var locationMessage = new TextMessage { Text = "Please send us your location?", QuickReplies = new List<QuickReply> { new LocationQuickReply() } };
            var result12 = await client.SendMessageAsync(userId, locationMessage);

        }

        private static async Task SendButtonTemplateAsync(ClientMessenger client, string userId)
        {            
            // *NOTE: You're only allowed 3 buttons at a time
            var list = new List<Button> 
            {
                //new UrlButton()
                //{
                //    Title = "My Url",
                //    Url = "http://google.com"
                //},
                new PostbackButton()
                {
                    Title = "Button 1",
                    Payload = "Button 1 selected"
                },
                new PostbackButton()
                {
                    Title = "Button 2",
                    Payload = "Button 2 selected"
                },
                new PostbackButton()
                {
                    Title = "Button 3",
                    Payload = "Button 3 selected"
                },
                //new CallMeButton()
                //{
                //    Title = "Call me please",
                //    PhoneNumber = "416419001"
                //},
                //new LogInButton()
                //{
                //    Url = "http://google.com"
                //},
                //new LogOutButton()
                //{
                //}
            };

            var text = "Hey there welcome to Hubster! How can we help you today?";
            var message = new AttachmentMessage { Attachment = new ButtonTemplateAttachment(text, list) };
            var package = await client.GetJSONRenderedAsync(userId, message);
            var result = await client.SendMessageAsync(userId, message);
        }

        private static async Task SendGenericTemplateAsync(ClientMessenger client, string userId)
        {
            var genericTemplate = new GenericTemplateAttachment(new List<GenericElement>
            {
                new GenericElement
                {
                    ImageUrl = "https://hubsterdevcdn.blob.core.windows.net/pub/demo/webchat/cars/list_car_dragon.png",
                    //ItemUrl = "google.com?action=123",
                    Title = "Green Dragon",
                    Subtitle = "$2.99\nPage *Scoped* User ID (PSID) of the message recipient. The user needs to have interacted with any of the Messenger platform.",                    
                    //DefaultAction = new DefaultAction
                    //{
                    //    // Title = "Default Action Title",
                    //    Type = "web_url",
                    //    Url = "google.com?item=123",
                    //    WebviewHeightRatio = "COMPACT",
                    //}

                },
                //new GenericElement
                //{
                //    ImageUrl = "https://hubsterdevcdn.blob.core.windows.net/pub/demo/webchat/cars/list_car_red_baron.png",
                //    Title = "My Title",
                //    Subtitle = "This is my subtitle and it's very long.\nNext line."
                //}
            }); ;

            var message = new AttachmentMessage { Attachment = genericTemplate };
            var package = await client.GetJSONRenderedAsync(userId, message);
            var result = await client.SendMessageAsync(userId, message);
        }

        private static async Task SendCardAsync(ClientMessenger client, string userId)
        {
            var genericTemplate = new GenericTemplateAttachment(new List<GenericElement>
            {
                new GenericElement
                {
                    ImageUrl = "https://hubsterdevcdn.blob.core.windows.net/pub/demo/webchat/retail/contacts/maxim_shaw2.png",                    
                    Title = "Some Card Title",
                    Subtitle = "$2.99\nSome card details that can be at most 80 characters.",                    
                    Buttons = new List<Button>
                    {
                        new UrlButton
                        {
                            Title = "My Url",
                            Url = "http://google.com"
                        },
                        new PostbackButton
                        {
                            Title = "My postback",
                            Payload = "My postback selected"
                        },
                        // ignore 
                        new CallMeButton
                        {
                            Title = "Call me please",
                            PhoneNumber = "416419001"
                        },
                    }
                },
            }); 

            var message = new AttachmentMessage { Attachment = genericTemplate };
            var package = await client.GetJSONRenderedAsync(userId, message);
            var result = await client.SendMessageAsync(userId, message);
        }

        private static async Task SendContactAsync(ClientMessenger client, string userId)
        {
            var genericTemplate = new GenericTemplateAttachment(new List<GenericElement>
            {
                new GenericElement
                {
                    ImageUrl = "https://vignette.wikia.nocookie.net/jamesbond/images/7/78/Eva_Green.jpg/revision/latest/scale-to-width-down/1000?cb=20111001142753",
                    Title = "Eva Green",
                    Subtitle = "Mighty Health\n108 Kirkbride Crescent, Maple, ON\njames@mightyhealth.com\n17148736202",
                    Buttons = new List<Button>
                    {
                        new CallMeButton
                        {
                            Title = "Call",
                            PhoneNumber = "17148736202"
                        },
                    }
                },
            });

            var message = new AttachmentMessage { Attachment = genericTemplate };
            var package = await client.GetJSONRenderedAsync(userId, message);
            var result = await client.SendMessageAsync(userId, message);
        }

        private static async Task SendLocationAsync(ClientMessenger client, string userId)
        {
            var genericTemplate = new GenericTemplateAttachment(new List<GenericElement>
            {
                new GenericElement
                {
                    ImageUrl = "https://hubsterdevcdn.blob.core.windows.net/engine/00000000-0000-0000-0000-000000000001/maps/2607085880410200450-map.png",
                    ItemUrl = "https://www.google.com/maps/place/108+Kirkbride+Crescent,+Vaughan,+ON+L6A+2J6",
                    Title = "Location",
                    Subtitle = "108 Kirkbride Crescent, Maple, ON, Canada, L6A2J6",
                },
            });

            var message = new AttachmentMessage { Attachment = genericTemplate };
            var package = await client.GetJSONRenderedAsync(userId, message);
            var result = await client.SendMessageAsync(userId, message);
        }

        private static async Task SendCarouselAsync(ClientMessenger client, string userId)
        {
            var genericTemplate = new GenericTemplateAttachment(new List<GenericElement>
            {
                new GenericElement
                {
                    ImageUrl = "https://hubsterdevcdn.blob.core.windows.net/pub/demo/webchat/cars/list_car_victorious.png",
                    Title = "Victorious",
                    Subtitle = "Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry\'s standard dummy text ever since the 1500s.",
                    Buttons = new List<Button>
                    {
                        // NOTE: consider adding padding to Title. Must be 16 minimal
                        new PostbackButton
                        {
                            Title = Pad("Victorious", 16),
                            Payload = "Victorious"
                        },
                        // NOTE: consider adding padding to Title. Must be 16 minimal
                        new UrlButton
                        {
                            Title = Pad("Info", 16),
                            Url = "https://hubster.io?car=victorious"
                        },
                    }
                },
                new GenericElement
                {
                    ImageUrl = "https://hubsterdevcdn.blob.core.windows.net/pub/demo/webchat/cars/list_car_dragon.png",
                    Title = "Green Dragon",
                    Subtitle = "Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry\'s standard dummy text ever since the 1500s.",
                    Buttons = new List<Button>
                    {
                        new PostbackButton
                        {
                            Title = Pad("Green Dragon", 16),
                            Payload = "Green Dragon"
                        },
                        new UrlButton
                        {
                            Title = Pad("Info", 16),
                            Url = "https://hubster.io?car=green-dragon"
                        },
                    }
                },
                new GenericElement
                {
                    ImageUrl = "https://hubsterdevcdn.blob.core.windows.net/pub/demo/webchat/cars/list_car_panther.png",
                    Title = "Panther",
                    Subtitle = "Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry\'s standard dummy text ever since the 1500s.",
                    Buttons = new List<Button>
                    {
                        new PostbackButton
                        {
                            Title = Pad("Panther", 16),
                            Payload = "Panther"
                        },
                        new UrlButton
                        {
                            Title = Pad("Info", 16),
                            Url = "https://hubster.io?car=panther"
                        },
                    }
                },
                new GenericElement
                {
                    ImageUrl = "https://hubsterdevcdn.blob.core.windows.net/pub/demo/webchat/cars/list_car_red_baron.png",
                    Title = "Red Baron",
                    Subtitle = "Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry\'s standard dummy text ever since the 1500s.",
                    Buttons = new List<Button>
                    {
                        new PostbackButton
                        {
                            Title = Pad("Red Baron", 16),
                            Payload = "Red Baron"
                        },
                        new UrlButton
                        {
                            Title = Pad("Info", 16),
                            Url = "https://hubster.io?car=red-baron"
                        },
                    }
                },
            });

            var message = new AttachmentMessage { Attachment = genericTemplate};
            var package = await client.GetJSONRenderedAsync(userId, message);
            var result = await client.SendMessageAsync(userId, message);
        }


        private static async Task SendMediaUrlAsync(ClientMessenger client, string userId)
        {
            var vedio = new VideoAttachment("https://hubsterdevcdn.blob.core.windows.net/engine/00000000-0000-0000-0000-000000000001/media/8338156741751296193-textinmotion_sample_576p.mp4");
            var message = new AttachmentMessage { Attachment = vedio };
            var package = await client.GetJSONRenderedAsync(userId, message);
            var result = await client.SendMessageAsync(userId, message);
        }

        private static async Task SendFacebookMediaAsync(ClientMessenger client, string userId)
        {
            var mediaTemplate = new MedidaTemplateAttachment(new List<MediaElement>
            {
                new ImageElement
                {
                    Url = "need a facebook url"
                }
            });

            var message = new AttachmentMessage { Attachment = mediaTemplate };
            var package = await client.GetJSONRenderedAsync(userId, message);
            var result = await client.SendMessageAsync(userId, message);
        }


        private static string Pad(string text, int maxlength)
        {
            var padding = 16 - text.Length;
            if (padding > 0)
            {
                var left = padding / 2;
                var right = (padding / 2) + (padding % 2);

                text = text.PadLeft(text.Length + left, ' ');
                text = text.PadRight(text.Length + right, ' ');
            }

            return text;
        }


        private static async Task RunAync()
        {
            var val = "2046345502130235";
            var client = new ClientMessenger("EAAeZCcIjFqGABADu97rZA8ddjEetYM6MJ2Lj6dRrkZCudUEBY31MeCKcQYIe8ZCufeR2O1UMjoK0ttkN89AZCU20yx0PBZACYLJxKEahYM6uK8P8V8h3DUQa4TTnckWZA3NLvsIKFtVN6ZB4c1MzSPeChZCZCXAZBn26zdiNzDbKI0ZCGgZDZD");

            // await SendSimpleMessageAync(client, "2001954456545360");
            // await SendAttachmentsMessageAync(client, "2001954456545360");
            await SendQuickRepliesAsync(client, "2001954456545360");
            // await SendButtonTemplateAsync(client, "2001954456545360");
            // await SendGenericTemplateAsync(client, "2001954456545360");
            // await SendCardAsync(client, "2001954456545360");
            // await SendContactAsync(client, "2001954456545360");
            // await SendLocationAsync(client, "2001954456545360");
            // await SendCarouselAsync(client, "2001954456545360");
            // await SendMediaUrlAsync(client, "2001954456545360");
            // await SendFacebookMediaAsync(client, "2001954456545360");

            // Generic template 
            //      - done - Carousel
            //      - done - List: 
            // Button template 
            //      - done - message with buttons - use this hubster: regular buttons, quick replies and links

            // done - send files - images, audio, video, etc. using attachment - use by URL rather than upload
            
            // Media template
            //      video
            //      audio - doesn't work 
        }

        static void Main(string[] args)
        {
            RunAync().GetAwaiter().GetResult();
        }
    }
}
