// ReflectSoftware.Facebook
// Copyright (c) 2016 ReflectSoftware Inc.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information. 

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using ReflectSoftware.Facebook.Messenger.AspNetCore.Webhook.Helpers;
using ReflectSoftware.Facebook.Messenger.Common.Models.Webhooks;
using System;
using System.Net;
using System.Threading.Tasks;

namespace ReflectSoftware.Facebook.Messenger.AspNetCore.Webhook
{
    /// <summary>
    /// https://developers.facebook.com/docs/messenger-platform
    /// </summary>
    public class WebhookHandler
    {
        public string VerificationToken { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="WebhookHandler"/> class.
        /// </summary>
        /// <param name="verificationToken">The verification token.</param>
        public WebhookHandler(string verificationToken = null)
        {
            VerificationToken = verificationToken;
        }

        /// <summary>
        /// Handles the asynchronous.
        /// </summary>
        /// <param name="context">The context.</param>
        /// <param name="onRequest">The on request.</param>
        /// <returns></returns>
        public async Task<IActionResult> HandleAsync(HttpContext context, Func<Callback, IActionResult> onRequest)
        {
            var result = (IActionResult)null;

            if (context.Request.Method == "POST")
            {
                var data = WebHelper.ReadRequestDataAsString(context);
                var callback = JsonConvert.DeserializeObject<Callback>(data);

                result = onRequest(callback);
            }
            else if (context.Request.Method == "GET")
            {
                if (context.Request.Query["hub.mode"] == "subscribe")
                {
                    result = await SubscribeAsycn(context);
                }
            }

            return result ?? new BadRequestResult();
        }


        /// <summary>
        /// Handles the asynchronous.
        /// </summary>
        /// <param name="context">The context.</param>
        /// <param name="onRequest">The on request.</param>
        /// <returns></returns>
        public async Task<IActionResult> HandleAsync(HttpContext context, Func<Callback, Task<IActionResult>> onRequest)
        {
            var resultCallback = (Callback)null;

            var result = await HandleAsync(context, (callback) =>
            {
                resultCallback = callback;
                return new OkResult();
            });

            if (resultCallback != null)
            {
                result = await onRequest(resultCallback);
            }

            return result;
        }

        /// <summary>
        /// Subscribes the async.
        /// </summary>
        /// <param name="context">The context.</param>
        /// <returns></returns>
        private Task<IActionResult> SubscribeAsycn(HttpContext context)
        {
            var result = (IActionResult)null;

            if (context.Request.Query["hub.verify_token"] == VerificationToken)
            {
                result = new ContentResult
                {
                    ContentType = "text/plain",
                    Content = context.Request.Query["hub.challenge"],
                    StatusCode = (int)HttpStatusCode.OK,
                };
            }

            return Task.FromResult(result);
        }
    }
}
