// ReflectSoftware.Facebook
// Copyright (c) 2018 ReflectSoftware Inc.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information. 

namespace ReflectSoftware.Facebook.Messenger.Common.Models
{
    /// <summary>
    /// You can send images by uploading them or sharing a URL using the Send API. Supported formats are jpg, png and gif.
    /// </summary>
    public class ImageAttachment : Attachment<MediaPayload>
    {
        public ImageAttachment() : base("image")
        {
            Payload = new MediaPayload();
        }

        public ImageAttachment(string url) : this()
        {
            Payload = new MediaPayload(url);
        }
    }
}
