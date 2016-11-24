// ReflectSoftware.Facebook
// Copyright (c) 2016 ReflectSoftware Inc.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information. 

using Newtonsoft.Json;
using ReflectSoftware.Facebook.Messenger.Common.Models.Webhooks;
using ReflectSoftware.Facebook.Messenger.WebAPI.Webhook.ActionResults;
using ReflectSoftware.Facebook.Messenger.WebAPI.Webhook.Extensions;
using ReflectSoftware.Facebook.Messenger.WebAPI.Webhook.Helpers;
using System;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Results;

namespace ReflectSoftware.Facebook.Messenger.WebAPI.Webhook
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
        /// <param name="request">The request.</param>
        /// <param name="onRequest">The on request.</param>
        /// <returns></returns>
        public async Task<IHttpActionResult> HandleAsync(HttpRequestMessage request, Func<Callback, IHttpActionResult> onRequest)
        {
            var result = (IHttpActionResult)null;

            if (request.Method == HttpMethod.Post)
            {
                var data = WebHelper.ReadRequestDataAsString();
                var callback = JsonConvert.DeserializeObject<Callback>(data);

                result = onRequest(callback);
            }
            else if (request.Method == HttpMethod.Get)
            {
                if (request.Query("hub.mode") == "subscribe")
                {
                    result = await SubscribeAsycn(request);
                }
            }

            return result ?? new BadRequestResult(request);
        }

        /// <summary>
        /// Handles the asynchronous.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <param name="onRequest">The on request.</param>
        /// <returns></returns>
        public async Task<IHttpActionResult> HandleAsync(HttpRequestMessage request, Func<Callback, Task<IHttpActionResult>> onRequest)
        {
            var resultCallback = (Callback)null;

            var result = await HandleAsync(request, (callback) =>
            {
                resultCallback = callback;
                return new OkResult(request);
            });

            if(resultCallback != null)
            {
                result = await onRequest(resultCallback);
            }

            return result;
        }

        /// <summary>
        /// Subscribes the asycn.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <returns></returns>
        private Task<IHttpActionResult> SubscribeAsycn(HttpRequestMessage request)
        {
            var result = (IHttpActionResult)null;

            if (request.Query("hub.verify_token") == VerificationToken)
            {
                result = new PlainTextActionResult(request, request.Query("hub.challenge"));
            }

            return Task.FromResult(result);
        }
    }
}
