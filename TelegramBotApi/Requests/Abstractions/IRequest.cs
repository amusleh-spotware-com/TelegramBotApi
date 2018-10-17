// ReSharper disable once UnusedTypeParameter
namespace TelegramBotApi.Requests.Abstractions
{
    /// <summary>
    /// Represents a request to Bot API
    /// </summary>
    /// <typeparam name="TResponse">Type of result expected in result</typeparam>
    public interface IRequest<TResponse>
    {
        /// <summary>
        /// API method name
        /// </summary>
        string MethodName { get; }

        /// <summary>
        /// Request in JSON
        /// </summary>
        string ToJson();
    }
}
