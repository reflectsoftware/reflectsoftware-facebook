// ReflectSoftware.Facebook
// Copyright (c) 2020 ReflectSoftware Inc.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information. 

using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using ReflectSoftware.Facebook.Messenger.Common.Enums;
using ReflectSoftware.Facebook.Messenger.Common.Extensions;
using ReflectSoftware.Facebook.Messenger.Common.Models;
using ReflectSoftware.Facebook.Messenger.Common.Models.Client;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ReflectSoftware.Facebook.Messenger.Client
{
    /// <summary>
    /// https://developers.facebook.com/docs/messenger-platform
    /// </summary>
    public class ClientMessenger : IClientMessenger
    {
        private readonly string _apiVersion;
        private readonly string _accessToken;

        #region Constructors      
        /// <summary>
        /// Initializes a new instance of the <see cref="ClientMessenger" /> class.
        /// </summary>
        /// <param name="accessToken">The facebook access_token.</param>
        /// <param name="version">The version.</param>
        public ClientMessenger(string accessToken, string version = "8.0")
        {
            _accessToken = accessToken;
            _apiVersion = version;
        }
        #endregion Constructors

        /// <summary>
        /// Posts the task asynchronous.
        /// </summary>
        /// <param name="path">The path.</param>
        /// <param name="parameters">The parameters.</param>
        /// <returns></returns>
        protected async Task<object> PostTaskAsync(string path, object parameters)
        {
            var content = (StringContent)null;

            if (parameters != null)
            {
                var body = JsonConvert.SerializeObject(parameters);
                content = new StringContent(body, Encoding.UTF8, "application/json");
            }

            using (var client = new HttpClient())
            {
                using (var response = await client.PostAsync($"https://graph.facebook.com/v{_apiVersion}/{path}?access_token={_accessToken}", content))
                {
                    var responseData = await response.Content.ReadAsStringAsync();
                    var responseObject = JObject.Parse(responseData);

                    return responseObject;
                }
            }
        }

        /// <summary>
        /// Deletes the task asynchronous.
        /// </summary>
        /// <param name="path">The path.</param>
        /// <param name="parameters">The parameters.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns></returns>
        protected async Task<object> DeleteTaskAsync(string path, object parameters, CancellationToken cancellationToken)
        {
            var content = (StringContent)null;

            if (parameters != null)
            {
                var body = JsonConvert.SerializeObject(parameters);
                content = new StringContent(body, Encoding.UTF8, "application/json");
            }

            using (var client = new HttpClient())
            {
                var request = new HttpRequestMessage(HttpMethod.Delete, $"https://graph.facebook.com/v{_apiVersion}/{path}?access_token={_accessToken}")
                {
                    Content = content
                };

                using (var response = await client.SendAsync(request, cancellationToken))
                {
                    var responseData = await response.Content.ReadAsStringAsync();
                    var responseObject = JObject.Parse(responseData);

                    return responseObject;
                }
            }
        }

        /// <summary>
        /// Gets the task asynchronous.
        /// </summary>
        /// <typeparam name="TResult">The type of the result.</typeparam>
        /// <param name="parameters">The parameters.</param>
        /// <returns></returns>
        protected async Task<TResult> GetTaskAsync<TResult>(object parameters)
        {
            using (var client = new HttpClient())
            {
                try
                {
                    var response = await client.GetStringAsync($"https://graph.facebook.com/{parameters}&access_token={_accessToken}");
                    if (string.IsNullOrWhiteSpace(response) == false)
                    {
                        var data = JsonConvert.DeserializeObject<TResult>(response);
                        return data;
                    }
                }
                catch (Exception)
                {
                }

                return default(TResult);
            }
        }

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
                            text
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
            catch (Exception ex)
            {
                HandleException(ex, result);
            }

            return result;
        }

        /// <summary>
        /// The Welcome Screen can display a Get Started button. When this button is tapped, we will trigger the postback received callback and deliver the person's 
        /// page-scoped ID (PSID). You can then present a personalized message to greet the user or present buttons to prompt him or her to take an action.
        /// There are certain conditions to seeing the Welcome Screen and the Get Started button:
        /// They are only rendered the first time the user interacts with a the Page on Messenger.
        /// Only admins/developers/testers of the app can see it when the app is in development mode.
        /// Your app must be subscribed to post-backs on your webhook.
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
                        call_to_actions = new[]
                        {
                            new { payload }
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
            catch (Exception ex)
            {
                HandleException(ex, result);
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
            catch (Exception ex)
            {
                HandleException(ex, result);
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
                if (result.Error == null)
                {
                    result.Message = returnValue.Value<string>("recipient_id");
                    result.Success = true;
                }
            }
            catch (Exception ex)
            {
                HandleException(ex, result);
            }

            return result;
        }

        /// <summary>
        /// Send messages to users.
        /// </summary>
        /// <param name="userId">User identification</param>
        /// <param name="message">Message object</param>
        /// <param name="notificationType">Push notification type: REGULAR, SILENT_PUSH, NO_PUSH</param>
        /// <param name="messageType">Type of the message: RESPONSE, UPDATE, MESSAGE_TAG</param>
        /// <param name="messageTag">The message tag.</param>
        /// <returns></returns>
        public async Task<MessageResult> SendMessageAsync(string userId, MessageSent message,
            NotificationType notificationType = NotificationType.Regular,
            MessageType? messageType = null,
            MessageTag? messageTag = null)
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
                    tag = messageTag?.GetJsonPropertyName(),
                    messaging_type = messageType?.GetJsonPropertyName(),
                    notification_type = notificationType.GetJsonPropertyName(),
                    message
                });

                result.Error = CreateResultError(returnValue);
                if (result.Error == null)
                {
                    result.RecipientId = returnValue.Value<string>("recipient_id");
                    result.MessageId = returnValue.Value<string>("message_id");
                    result.Success = true;
                }
            }
            catch (Exception ex)
            {
                HandleException(ex, result);
            }

            return result;
        }

        /// <summary>
        /// Gets the json rendered asynchronous.
        /// </summary>
        /// <param name="userId">The user identifier.</param>
        /// <param name="message">The message.</param>
        /// <param name="notificationType">Type of the notification.</param>
        /// <param name="messageType">Type of the message.</param>
        /// <param name="messageTag">The message tag.</param>
        /// <returns></returns>
        public Task<string> GetJSONRenderedAsync(string userId, MessageSent message,
            NotificationType notificationType = NotificationType.Regular,
            MessageType? messageType = null,
            MessageTag? messageTag = null)
        {
            var package = new
            {
                recipient = new
                {
                    id = userId
                },
                tag = messageTag?.GetJsonPropertyName(),
                messaging_type = messageType?.GetJsonPropertyName(),
                notification_type = notificationType.GetJsonPropertyName(),
                message
            };

            var result = JsonConvert.SerializeObject(package, Formatting.Indented);
            return Task.FromResult(result);
        }


        /// <summary>
        /// Sends the attachment asynchronous.
        /// </summary>
        /// <param name="userId">The user identifier.</param>
        /// <param name="stream">The stream.</param>
        /// <param name="filename">The filename.</param>
        /// <param name="mimeType">Type of the MIME.</param>
        /// <param name="type">The type.</param>
        /// <returns></returns>
        public async Task<MessageResult> SendFileAttachmentAsync(string userId, Stream stream, string filename, string mimeType, string type = "file")
        {
            var attachment = (Attachment)null;

            switch (type)
            {
                case "image":
                    attachment = new ImageAttachment();
                    break;

                case "video":
                    attachment = new VideoAttachment();
                    break;

                case "audio":
                    attachment = new AudioAttachment();
                    break;

                default:
                    attachment = new FileAttachment();
                    break;
            }

            (attachment as Attachment<MediaPayload>).Payload.IsReusable = true;

            var result = new MessageResult();
            try
            {
                using (var client = new HttpClient())
                {
                    client.Timeout = TimeSpan.FromMinutes(5);

                    using (var content = new MultipartFormDataContent())
                    {
                        var recipient = JsonConvert.SerializeObject(new Identity(userId));
                        var message = JsonConvert.SerializeObject(new AttachmentMessage(attachment));

                        content.Add(new StringContent(recipient), "recipient");
                        content.Add(new StringContent(message), "message");

                        var fileContent = new StreamContent(stream);
                        fileContent.Headers.ContentType = MediaTypeHeaderValue.Parse(mimeType);

                        content.Add(fileContent, "filedata", filename);

                        using (var response = await client.PostAsync($"https://graph.facebook.com/v{_apiVersion}/me/messages?access_token={_accessToken}", content))
                        {
                            if (response.StatusCode != HttpStatusCode.OK
                            && response.StatusCode != HttpStatusCode.BadRequest)
                            {
                                result.Success = false;
                                result.Error = new ResultError
                                {
                                    Code = -1,
                                    ErrorSubcode = (int)response.StatusCode,
                                    Message = response.ReasonPhrase ?? response.StatusCode.ToString(),
                                };
                            }
                            else
                            {
                                var returnValue = (JObject)JsonConvert.DeserializeObject(await response.Content.ReadAsStringAsync());
                                result.Error = CreateResultError(returnValue);
                                if (result.Error == null)
                                {
                                    result.RecipientId = returnValue.Value<string>("recipient_id");
                                    result.MessageId = returnValue.Value<string>("message_id");
                                    result.AttachmentId = returnValue.Value<string>("attachment_id");
                                    result.Success = true;
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                HandleException(ex, result);
            }

            return result;
        }

        /// <summary>
        /// The profile API can be used to query more information about the user, and personalize the experience further. 
        /// This API is only available after the user initiated the conversation by sending a message or by interacting with a Web Plug-in.
        /// </summary>
        /// <param name="userId">User identification</param>
        /// <returns></returns>
        public async Task<UserProfile> GetUserProfileAsync(string userId)
        {
            return await GetTaskAsync<UserProfile>($"{userId}?fields=first_name,last_name,profile_pic,locale,timezone,gender");
        }
        #endregion

        #region Methods Private
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
                result = new ResultError
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

        /// <summary>
        /// Handles the exception.
        /// </summary>
        /// <param name="ex">The ex.</param>
        /// <param name="result">The result.</param>
        private void HandleException(Exception ex, Result result)
        {
            if (ex is WebException)
            {
                HandleWebException(ex as WebException, result);
                return;
            }

            //if (ex is HttpException)
            //{
            //    var code = (ex as HttpException).GetHttpCode();
            //    HandleStatusCode((HttpStatusCode)code, result);
            //    return;
            //}

            if (ex is TaskCanceledException)
            {
                HandleStatusCode(HttpStatusCode.RequestTimeout, result);
                return;
            }

            if (ex is HttpRequestException)
            {
                if ((ex as HttpRequestException).InnerException is WebException)
                {
                    HandleWebException((ex as HttpRequestException).InnerException as WebException, result);
                    return;
                }
            }

            HandleStatusCode(HttpStatusCode.InternalServerError, result);
        }

        /// <summary>
        /// Handles the web exception.
        /// </summary>
        /// <param name="ex">The ex.</param>
        /// <param name="result">The result.</param>
        private void HandleWebException(WebException ex, Result result)
        {
            if (ex.Status == WebExceptionStatus.ProtocolError)
            {
                if (ex.Response is HttpWebResponse response)
                {
                    HandleStatusCode(response.StatusCode, result);
                    return;
                }
            }
            else if (ex.Status == WebExceptionStatus.NameResolutionFailure)
            {
                HandleStatusCode(HttpStatusCode.BadGateway, result);
                return;
            }

            HandleStatusCode(HttpStatusCode.InternalServerError, result);
        }

        /// <summary>
        /// Handles the status code.
        /// </summary>
        /// <param name="code">The code.</param>
        /// <param name="result">The result.</param>
        private void HandleStatusCode(HttpStatusCode code, Result result)
        {
            result.Error = new ResultError
            {
                Code = -1,
                ErrorSubcode = (int)code,
                Type = code.ToString(),
            };
        }
        #endregion
    }
}
