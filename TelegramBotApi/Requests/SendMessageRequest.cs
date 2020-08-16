using System.Runtime.Serialization;
using TelegramBotApi.Types;

// ReSharper disable once CheckNamespace
namespace TelegramBotApi.Requests
{
    /// <summary>
    /// Send text messages
    /// </summary>
    [DataContract]
    public class SendMessageRequest : RequestBase<Message>
    {
        /// <summary>
        /// Unique identifier for the target chat or username of the target channel
        /// </summary>
        [DataMember(Name = "chat_id")]
        public long ChatId { get; set; }

        /// <summary>
        /// Text of the message to be sent
        /// </summary>
        [DataMember(Name = "text")]
        public string Text { get; set; }

        /// <summary>
        /// Initializes a new request with chatId and text
        /// </summary>
        /// <param name="chatId">Unique identifier for the target chat or username of the target channel</param>
        /// <param name="text">Text of the message to be sent</param>
        public SendMessageRequest(long chatId, string text)
            : base("sendMessage")
        {
            ChatId = chatId;
            Text = text;
        }
    }
}