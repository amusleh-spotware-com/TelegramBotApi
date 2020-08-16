using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;
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
        [IgnoreDataMember]
        public string MethodName { get; protected set; }

        public string ToJson()
        {
            string json;

            using (var stream = new MemoryStream())
            {
                var jsonSerializer = new DataContractJsonSerializer(this.GetType());

                jsonSerializer.WriteObject(stream, this);

                stream.Position = 0;

                using (StreamReader streamReader = new StreamReader(stream))
                {
                    json = streamReader.ReadToEnd();
                }
            }

            return json;
        }
    }
}