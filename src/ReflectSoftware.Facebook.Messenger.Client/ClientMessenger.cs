// ReflectSoftware.Facebook
// Copyright (c) 2017 ReflectSoftware Inc.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information. 

using Facebook;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using ReflectSoftware.Facebook.Messenger.Common.Enums;
using ReflectSoftware.Facebook.Messenger.Common.Extensions;
using ReflectSoftware.Facebook.Messenger.Common.Interfaces;
using ReflectSoftware.Facebook.Messenger.Common.Models;
using ReflectSoftware.Facebook.Messenger.Common.Models.Client;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading;
using System.Threading.Tasks;

namespace ReflectSoftware.Facebook.Messenger.Client
{
    /// <summary>
    /// https://developers.facebook.com/docs/messenger-platform
    /// </summary>
    public class ClientMessenger : FacebookClient
    {
        private readonly string _apiVersion;
        private readonly JsonSerializerSettings _jsonSerializerSettings;

        #region Constructors      
        /// <summary>
        /// Initializes a new instance of the <see cref="ClientMessenger"/> class.
        /// </summary>
        /// <param name="accessToken">The facebook access_token.</param>
        public ClientMessenger(string accessToken, string version = "2.8") : base(accessToken)
        {
            _apiVersion = version;

            SetJsonSerializers();
            _jsonSerializerSettings = new JsonSerializerSettings();
        }
        #endregion Constructors

        #region Methods
        /// <summary>
        /// You can set a greeting for new conversations. This can be used to communicate your bot's functionality. 
        /// If the greeting text is not set, the page description will be shown in the welcome screen. You can personalize the text with the person's name.
        /// </summary>
        /// <param name="text">
        /// Must be UTF-8 and has a 160 character limit
        /// You can personalize the greeting text using the person's name. You can use the following template strings: {{user_first_name}}, {{user_last_name}}, {{user_full_name}}
        /// </param>
        /// <returns></returns>
        public async Task<Result> SetGreetingTextAsync(string text = null)
        {
            var result = new Result();
            try
            {
                var returnValue = (JObject)null;
                if (!string.IsNullOrWhiteSpace(text))
                {
                    returnValue = (JObject)await PostTaskAsync("me/thread_settings", new
                    {
                        setting_type = "greeting",
                        greeting = new
                        {
                            text = text
                        }
                    });
                }
                else
                {
                    returnValue = (JObject)await DeleteTaskAsync("me/thread_settings", new
                    {
                        setting_type = "greeting"
                    }, new CancellationToken());
                }

                result.Error = CreateResultError(returnValue);
                if (result.Error == null)
                {
                    result.Message = returnValue.Value<string>("result");
                    result.Success = result.Message.Contains("Successfully");
                }
            }
            catch (WebExceptionWrapper ex)
            {
                result.Message = ex.Message;
                result.Error = new ResultError
                {
                    Type = "Bad connection",
                    Code = -1000,
                };
            }
            catch (Exception ex)
            {
                result.Message = ex.Message;
            }

            return result;
        }

        /// <summary>
        /// The Welcome Screen can display a Get Started button. When this button is tapped, we will trigger the postback received callback and deliver the person's 
        /// page-scoped ID (PSID). You can then present a personalized message to greet the user or present buttons to prompt him or her to take an action.
        /// There are certain conditions to seeing the Welcome Screen and the Get Started button:
        /// They are only rendered the first time the user interacts with a the Page on Messenger.
        /// Only admins/developers/testers of the app can see it when the app is in development mode.
        /// Your app must be subscribed to postbacks on your webhook.
        /// </summary>
        /// <param name="payload">This data will be sent back to you via webhook.</param>
        /// <returns>
        /// A user tapping the Get Started button triggers the postback received callback.
        /// </returns>
        public async Task<Result> SetGetStartedButtonAsync(string payload = null)
        {
            var result = new Result();
            try
            {
                var returnValue = (JObject)null;
                if (!string.IsNullOrWhiteSpace(payload))
                {
                    returnValue = (JObject)await PostTaskAsync("me/thread_settings", new
                    {
                        setting_type = "call_to_actions",
                        thread_state = "new_thread",
                        call_to_actions = new []
                        {
                            new { payload = payload }
                        }
                    });
                }
                else
                {
                    returnValue = (JObject)await DeleteTaskAsync("me/thread_settings", new
                    {
                        setting_type = "call_to_actions",
                        thread_state = "new_thread"
                    }, new CancellationToken());
                }

                result.Error = CreateResultError(returnValue);
                if (result.Error == null)
                {
                    result.Message = returnValue.Value<string>("result");
                    result.Success = result.Message.Contains("Successfully");
                }
            }
            catch (WebExceptionWrapper ex)
            {
                result.Message = ex.Message;
                result.Error = new ResultError
                {
                    Type = "Bad connection",
                    Code = -1000,
                };
            }
            catch (Exception ex)
            {
                result.Message = ex.Message;
            }

            return result;
        }

        /// <summary>
        /// The Persistent Menu is a menu that is always available to the user. This menu should contain top-level actions that users can 
        /// enact at any point. Having a persistent menu easily communicates the basic capabilities of your bot for first-time and returning users.
        /// The menu can be invoked by a user, by tapping on the 3-caret icon on the left of the composer. Menus are loaded from cache but updates 
        /// are fetched each time they're loaded. If you update the menu, trigger the fetch by loading it and then load it again to see your changes.
        /// </summary>
        /// <param name="menuItems">call_to_actions is limited to 5</param>
        /// <returns></returns>
        public async Task<Result> SetPersistentMenuAsync(List<MenuItem> menuItems = null)
        {
            var result = new Result();
            try
            {
                var returnValue = (JObject)null;
                if (menuItems != null)
                {
                    returnValue = (JObject)await PostTaskAsync("me/thread_settings", new
                    {
                        setting_type = "call_to_actions",
                        thread_state = "existing_thread",
                        call_to_actions = menuItems
                    });
                }
                else
                {
                    returnValue = (JObject)await DeleteTaskAsync("me/thread_settings", new
                    {
                        setting_type = "call_to_actions",
                        thread_state = "existing_thread"
                    }, new CancellationToken());
                }

                result.Error = CreateResultError(returnValue);
                if (result.Error == null)
                {
                    result.Message = returnValue.Value<string>("result");
                    result.Success = result.Message.Contains("Successfully");
                }
            }
            catch (WebExceptionWrapper ex)
            {
                result.Message = ex.Message;
                result.Error = new ResultError
                {
                    Type = "Bad connection",
                    Code = -1000,
                };
            }
            catch (Exception ex)
            {
                result.Message = ex.Message;
            }

            return result;
        }

        /// <summary>
        /// Set typing indicators or send read receipts using the Send API, to let users know you are processing their request.
        /// Typing indicators are automatically turned off after 20 seconds
        /// </summary>
        /// <param name="userId">User identification</param>
        /// <param name="action"></param>
        /// <returns></returns>
        public async Task<Result> SendActionAsync(string userId, SenderAction action)
        {
            var result = new Result();
            try
            {
                var returnValue = (JObject)await PostTaskAsync("me/messages", new
                {
                    recipient = new
                    {
                        id = userId
                    },

                    sender_action = action.GetJsonPropertyName()
                });

                result.Error = CreateResultError(returnValue);
                if(result.Error == null)
                {
                    result.Message = returnValue.Value<string>("recipient_id");
                    result.Success = true;
                }   
            }
            catch (WebExceptionWrapper ex)
            {
                result.Message = ex.Message;
                result.Error = new ResultError
                {
                    Type = "Bad connection",
                    Code = -1000,
                };
            }
            catch (Exception ex)
            {
                result.Message = ex.Message;
            }

            return result;
        }

        /// <summary>
        /// Subscribe an app to get updates for a page. You can do this in the Webhooks section under the Messenger Tab.
        /// </summary>
        /// <returns></returns>
        public async Task<Result> SubscribedAppsAsync()
        {
            var result = new Result();
            try
            {
                var returnValue = (JObject)await PostTaskAsync("me/subscribed_apps", null);

                result.Error = CreateResultError(returnValue);
                result.Success = result.Error == null;
            }
            catch (WebExceptionWrapper ex)
            {
                result.Message = ex.Message;
                result.Error = new ResultError
                {
                    Type = "Bad connection",
                    Code = -1000,
                };
            }
            catch (Exception ex)
            {
                result.Message = ex.Message;
            }

            return result;
        }

        /// <summary>
        /// Send messages to users.
        /// </summary>
        /// <param name="userId">User identification</param>
        /// <param name="message">Message object</param>
        /// <param name="notificationType">Push notification type: REGULAR, SILENT_PUSH, NO_PUSH</param>
        /// <returns></returns>
        public async Task<MessageResult> SendMessageAsync(string userId, MessageSent message, NotificationType notificationType = NotificationType.Regular)
        {
            var result = new MessageResult();
            try
            {
                var returnValue = (JObject)await PostTaskAsync("me/messages", new
                {
                    recipient = new
                    {
                        id = userId
                    },
                    notification_type = notificationType.GetJsonPropertyName(),
                    message = message
                });

                result.Error = CreateResultError(returnValue);
                if (result.Error == null)
                {
                    result.RecipientId = returnValue.Value<string>("recipient_id");
                    result.MessageId = returnValue.Value<string>("message_id");
                    result.Success = true;
                }
            }
            catch (WebExceptionWrapper ex)
            {
                result.Message = ex.Message;
                result.Error = new ResultError
                {
                    Type = "Bad connection",
                    Code = -1000,
                };
            }
            catch (Exception ex)
            {
                result.Message = ex.Message;
            }

            return result;
        }

        /// <summary>
        /// Sends the attachment asynchronous.
        /// </summary>
        /// <param name="userId">The user identifier.</param>
        /// <param name="stream">The stream.</param>
        /// <param name="filename">The filename.</param>
        /// <param name="type">The type.</param>
        /// <returns></returns>
        public async Task<MessageResult> SendAttachmentAsync(string userId, Stream stream, string filename, string type = "file")
        {            
            var fileType = string.Empty;
            var contenFilename = $"@/tmp/{filename}";
            var attachment = (new FileAttachment() as IAttachment);

            switch (type)
            {
                case "image":
                    var ext = Path.GetExtension(filename).Replace(".", string.Empty);
                    if(ext.ToLower() == "jpg")
                    {
                        ext = "jpeg";
                    }

                    fileType = $"image/{ext}";
                    contenFilename = $"{contenFilename};type={fileType}";
                    attachment = new ImageAttachment();
                    break;

                case "video":
                    fileType = "video/mp4";
                    contenFilename = $"{contenFilename};type={fileType}";
                    attachment = new VideoAttachment();
                    break;

                case "audio":
                    fileType = "audio/mp3";
                    contenFilename = $"{contenFilename};type={fileType}";
                    attachment = new AudioAttachment();
                    break;
            }

            var result = new MessageResult();
            try
            {
                using (var client = new HttpClient())
                {
                    using (var content = new MultipartFormDataContent())
                    {
                        var recipient = JsonConvert.SerializeObject(new Identity(userId));
                        var message = JsonConvert.SerializeObject(new AttachmentMessage(attachment));

                        content.Add(new StringContent(recipient), "recipient");
                        content.Add(new StringContent(message), "message");

                        var imageContent = new StreamContent(stream);
                        if (!string.IsNullOrWhiteSpace(fileType))
                        {
                            imageContent.Headers.ContentType = MediaTypeHeaderValue.Parse(fileType);
                        }

                        content.Add(imageContent, "filedata", contenFilename);

                        using (var response = await client.PostAsync($"{"https"}://graph.facebook.com/v{_apiVersion}/me/messages?access_token={AccessToken}", content))
                        {
                            var returnValue = (JObject)JsonConvert.DeserializeObject(await response.Content.ReadAsStringAsync());
                            
                            result.Error = CreateResultError(returnValue);
                            if (result.Error == null)
                            {
                                result.RecipientId = returnValue.Value<string>("recipient_id");
                                result.MessageId = returnValue.Value<string>("message_id");
                                result.Success = true;
                            }
                        }
                    }
                }
            }
            catch (WebExceptionWrapper ex)
            {
                result.Message = ex.Message;
                result.Error = new ResultError
                {
                    Type = "Bad connection",
                    Code = -1000,
                };
            }
            catch (Exception ex)
            {
                result.Message = ex.Message;
            }

            return result;
        }

        /// <summary>
        /// The profile API can be used to query more information about the user, and personalize the experience further. 
        /// This API is only available after the user initiated the conversation by sending a message or by interacting with a Web Plugin.
        /// </summary>
        /// <param name="userId">User identification</param>
        /// <returns></returns>
        public async Task<UserProfile> GetUserProfileAsync(string userId)
        {
            return await GetTaskAsync<UserProfile>($"{userId}?fields=first_name,last_name,profile_pic,locale,timezone,gender,is_payment_enabled");
        }
        #endregion

        #region Methods Private
        /// <summary>
        /// Sets the json serializer.
        /// </summary>
        private void SetJsonSerializers()
        {
            SetJsonSerializers((obj) =>
            {
                var value = JsonConvert.SerializeObject(obj, _jsonSerializerSettings);
                return value;
            }, 
            (value, type) =>
            {
                return type == null? JsonConvert.DeserializeObject(value, _jsonSerializerSettings) : JsonConvert.DeserializeObject(value, type, _jsonSerializerSettings);
            });
        }

        /// <summary>
        /// Creates the result error.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <returns></returns>
        private ResultError CreateResultError(JObject value)
        {
            var result = (ResultError)null;
            if (value.Property("error") != null)
            {
                var error = (JObject)value.Property("error").Value;
                result = new ResultError()
                {
                    Message = error.Value<string>("message"),
                    Code = error.Value<int>("code"),
                    ErrorSubcode = error.Value<int>("error_subcode"),
                    FBTraceId = error.Value<string>("fbtrace_id"),
                    Type = error.Value<string>("type")
                };
            }
            return result;
        }
        #endregion
    }
}
