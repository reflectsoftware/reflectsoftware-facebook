// ReflectSoftware.Facebook
// Copyright (c) 2016 ReflectSoftware Inc.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information. 

using System.Text;
using System.Web;

namespace ReflectSoftware.Facebook.Messenger.WebAPI.Webhook.Helpers
{
    /// <summary>
    /// A utility class for web related one-offs.
    /// </summary>
    public static class WebHelper
    {
        /// <summary>
        /// Read the Content from the request as into a Byte array if any.
        /// </summary>
        /// <returns>Returns the request Content as a Byte array if any, otherwise null if not found or not applicable.</returns>

        public static byte[] ReadRequestDataAsByteArray()
        {
            if (HttpContext.Current == null || HttpContext.Current.Request.ContentLength == 0)
            {
                return null;
            }

            HttpRequest request = HttpContext.Current.Request;

            request.InputStream.Position = 0;
            try
            {
                return request.BinaryRead(request.ContentLength);
            }
            finally
            {
                request.InputStream.Position = 0;
            }
        }

        /// <summary>
        /// Read the Content from the request as into a string, if any.
        /// </summary>
        /// <returns>Returns the request Content as a string, if any, otherwise null if not found or not applicable.</returns>
        public static string ReadRequestDataAsString()
        {
            byte[] bData = ReadRequestDataAsByteArray();
            return bData == null ? null : Encoding.UTF8.GetString(bData);
        }
    }
}
