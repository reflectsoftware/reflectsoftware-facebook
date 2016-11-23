using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Http;

namespace ReflectSoftware.Facebook.Messenger.WebAPI.Webhook.ActionResults
{
    /// <summary>
    /// 
    /// </summary>
    /// <seealso cref="System.Web.Http.IHttpActionResult" />
    public class PlainTextActionResult : IHttpActionResult
    {
        private readonly string _value;
        private readonly HttpRequestMessage _request;

        /// <summary>
        /// Initializes a new instance of the <see cref="PlainTextActionResult" /> class.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <param name="value">The value.</param>
        public PlainTextActionResult(HttpRequestMessage request, string value)
        {
            _value = value;
            _request = request;
        }

        /// <summary>
        /// Creates an <see cref="T:System.Net.Http.HttpResponseMessage" /> asynchronously.
        /// </summary>
        /// <param name="cancellationToken">The token to monitor for cancellation requests.</param>
        /// <returns>
        /// A task that, when completed, contains the <see cref="T:System.Net.Http.HttpResponseMessage" />.
        /// </returns>
        public Task<HttpResponseMessage> ExecuteAsync(CancellationToken cancellationToken)
        {
            var response = new HttpResponseMessage(HttpStatusCode.OK)
            {
                Content = new StringContent(_value, Encoding.UTF8, "text/plain"),
                RequestMessage = _request                
            };

            return Task.FromResult(response);
        }
    }
}
