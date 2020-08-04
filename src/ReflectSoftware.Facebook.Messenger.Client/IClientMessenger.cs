// ReflectSoftware.Facebook
// Copyright (c) 2020 ReflectSoftware Inc.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information. 

using ReflectSoftware.Facebook.Messenger.Common.Enums;
using ReflectSoftware.Facebook.Messenger.Common.Models.Client;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace ReflectSoftware.Facebook.Messenger.Client
{
    public interface IClientMessenger
    {
        Task<string> GetJSONRenderedAsync(string userId, MessageSent message, NotificationType notificationType = NotificationType.Regular, MessageType? messageType = null, MessageTag? messageTag = null);
        Task<UserProfile> GetUserProfileAsync(string userId);
        Task<Result> SendActionAsync(string userId, SenderAction action);
        Task<MessageResult> SendFileAttachmentAsync(string userId, Stream stream, string filename, string mimeType, string type = "file");
        Task<MessageResult> SendMessageAsync(string userId, MessageSent message, NotificationType notificationType = NotificationType.Regular, MessageType? messageType = null, MessageTag? messageTag = null);
        Task<Result> SetGetStartedButtonAsync(string payload = null);
        Task<Result> SetGreetingTextAsync(string text = null);
        Task<Result> SetPersistentMenuAsync(List<MenuItem> menuItems = null);
    }
}