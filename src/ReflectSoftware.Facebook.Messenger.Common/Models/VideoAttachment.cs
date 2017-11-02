// ReflectSoftware.Facebook
// Copyright (c) 2017 ReflectSoftware Inc.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information. 

namespace ReflectSoftware.Facebook.Messenger.Common.Models
{
    /// <summary>
    /// You can send videos by uploading them or sharing a URL using the Send API.
    /// </summary>
    public class VideoAttachment : Attachment<MediaPayload>
    {
        public VideoAttachment()  : base("video")
        {
            Payload = new MediaPayload();
        }

        public VideoAttachment(string url) : this()
        {
            Payload = new MediaPayload(url);
        }
    }
}
