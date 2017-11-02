// ReflectSoftware.Facebook
// Copyright (c) 2017 ReflectSoftware Inc.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information. 

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using ReflectSoftware.Facebook.Messenger.AspNetCore.Webhook.Helpers;
using ReflectSoftware.Facebook.Messenger.Common.Models.Webhooks;
using System;
using System.Net;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace ReflectSoftware.Facebook.Messenger.AspNetCore.Webhook
{
    /// <summary>
    /// https://developers.facebook.com/docs/messenger-platform
    /// </summary>
    public class WebhookHandler
    {
        public string VerificationToken { get; private set; }
        public string AppSecret { get; private set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="WebhookHandler"/> class.
        /// </summary>
        /// <param name="verificationToken">The verification token.</param>
        public WebhookHandler(string verificationToken = null, string appSecret = null)
        {
            VerificationToken = verificationToken;
            AppSecret = appSecret;
        }

        /// <summary>
        /// Validates the signature asynchronous.
        /// </summary>
        /// <param name="headerSignature">The header signature.</param>
        /// <param name="body">The body.</param>
        /// <returns></returns>
        private Task<ContentResult> ValidateSignatureAsync(string headerSignature, string body)
        {
            var result = new ContentResult { StatusCode = (int)HttpStatusCode.Forbidden, Content = "plain/text" };
            if (string.IsNullOrEmpty(headerSignature))
            {
                result.ContentType = "Missing header.";
                return Task.FromResult(result);
            }
            
            var signatureParts = headerSignature.Split('=');
            if (signatureParts.Length != 2)
            {
                result.ContentType = "Invalid header.";
                return Task.FromResult(result);
            }

            var hasher = (HashAlgorithm)null;
            switch (signatureParts[0].ToLower())
            {
                case "sha1":
                    hasher = new HMACSHA1(Encoding.UTF8.GetBytes(AppSecret));
                    break;

                case "sha256":
                    hasher = new HMACSHA256(Encoding.UTF8.GetBytes(AppSecret));
                    break;

                case "sha512":
                    hasher = new HMACSHA512(Encoding.UTF8.GetBytes(AppSecret));
                    break;
            }

            if(hasher == null)
            {
                result.ContentType = "Unsupported Hash Algorithm.";
                return Task.FromResult(result);
            }

            using (hasher)
            {
                var byteSignature = hasher.ComputeHash(Encoding.UTF8.GetBytes(body));
                var signature = BitConverter.ToString(byteSignature).Replace("-", string.Empty).ToLower();

                if (signature == signatureParts[1].ToLower())
                {
                    result = null;
                }
            }

            return Task.FromResult(result);
        }

        /// <summary>
        /// Handles the asynchronous.
        /// </summary>
        /// <param name="context">The context.</param>
        /// <param name="onRequest">The on request.</param>
        /// <returns></returns>
        public async Task<IActionResult> HandleAsync(HttpContext context, Func<Callback, string, IActionResult> onRequest)
        {
            var result = (IActionResult)null;

            if (context.Request.Method == "POST")
            {
                var body = WebHelper.ReadRequestDataAsString(context);
                var callback = JsonConvert.DeserializeObject<Callback>(body);

                if(AppSecret != null)
                {
                    var headerSignature = context.Request.Headers["X-Hub-Signature"];
                    result = await ValidateSignatureAsync(headerSignature, body);
                }

                if (result == null)
                {
                    result = onRequest(callback, body);
                }

                return result;
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
        public async Task<IActionResult> HandleAsync(HttpContext context, Func<Callback, string, Task<IActionResult>> onRequest)
        {
            var resultData = (string)null;
            var resultCallback = (Callback)null;
            
            var result = await HandleAsync(context, (callback, data) =>
            {
                resultCallback = callback;
                resultData = data;

                return new OkResult();
            });

            if (resultCallback != null)
            {
                result = await onRequest(resultCallback, resultData);
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
