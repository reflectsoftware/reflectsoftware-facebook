// ReflectSoftware.Facebook
// Copyright (c) 2016 ReflectSoftware Inc.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information. 

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Internal;
using System.Text;

namespace ReflectSoftware.Facebook.Messenger.AspNetCore.Webhook.Helpers
{
    /// <summary>
    /// 
    /// </summary>
    public static class WebHelper
    {
        /// <summary>
        /// Read the Content from the request as into a Byte array if any.
        /// </summary>
        /// <param name="context">The context.</param>
        /// <returns>
        /// Returns the request Content as a Byte array if any, otherwise null if not found or not applicable.
        /// </returns>

        public static byte[] ReadRequestDataAsByteArray(HttpContext context)
        {
            var request = context.Request;
            if ((request.ContentLength ?? 0) == 0)
            {
                return null;
            }

            request.EnableRewind();

            request.Body.Position = 0L;
            try
            {
                var data = new byte[(int)request.ContentLength];
                request.Body.Read(data, 0, (int)request.ContentLength);
                return data;
            }
            finally
            {
                request.Body.Position = 0L;
            }            
        }

        /// <summary>
        /// Read the Content from the request as into a string, if any.
        /// </summary>
        /// <param name="context">The context.</param>
        /// <returns>
        /// Returns the request Content as a string, if any, otherwise null if not found or not applicable.
        /// </returns>
        public static string ReadRequestDataAsString(HttpContext context)
        {
            var bData = ReadRequestDataAsByteArray(context);
            return bData == null ? null : Encoding.UTF8.GetString(bData);
        }
    }
}
