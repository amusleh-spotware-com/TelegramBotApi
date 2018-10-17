using Newtonsoft.Json;
using TelegramBotApi.Requests.Abstractions;

namespace TelegramBotApi.Requests
{
    /// <summary>
    /// Represents a API request
    /// </summary>
    /// <typeparam name="TResponse">Type of result expected in result</typeparam>
    public abstract class RequestBase<TResponse> : IRequest<TResponse>
    {
        /// <summary>
        /// Initializes an instance of request
        /// </summary>
        /// <param name="methodName">Bot API method</param>
        protected RequestBase(string methodName)
        {
            MethodName = methodName;
        }

        /// <inheritdoc />
        public string MethodName { get; protected set; }

        public string ToJson()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
}
