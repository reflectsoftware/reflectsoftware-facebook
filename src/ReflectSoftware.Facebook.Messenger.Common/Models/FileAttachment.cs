// ReflectSoftware.Facebook
// Copyright (c) 2020 ReflectSoftware Inc.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information. 

namespace ReflectSoftware.Facebook.Messenger.Common.Models
{
    /// <summary>
    /// You can send files by uploading them or sharing a URL using the Send API.
    /// </summary>
    public class FileAttachment : Attachment<MediaPayload>
    {
        public FileAttachment() : base("file")
        {
            Payload = new MediaPayload();
        }

        public FileAttachment(string url) : this()
        {
            Payload = new MediaPayload(url);
        }
    }
}
