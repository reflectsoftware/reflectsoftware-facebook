using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ReflectSoftware.Facebook.Messenger.Common.Models.Webhooks;

namespace ReflectSoftware.Facebook.Messenger.AspNetCore.Webhook
{
    public interface IWebhookHandler
    {
        string AppSecret { get; }
        string VerificationToken { get; }

        Task<IActionResult> HandleAsync(HttpContext context, Func<Callback, string, IActionResult> onRequest);
        Task<IActionResult> HandleAsync(HttpContext context, Func<Callback, string, Task<IActionResult>> onRequest);
    }
}