using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using TelegramBotApi.Requests.Abstractions;
using TelegramBotApi.Types;
using TelegramBotApi.Types.Enums;
using TelegramBotApi.Types.ReplyMarkups;

// ReSharper disable once CheckNamespace
namespace TelegramBotApi.Requests
{
    /// <summary>
    /// Send text messages
    /// </summary>
    [JsonObject(MemberSerialization.OptIn, NamingStrategyType = typeof(SnakeCaseNamingStrategy))]
    public class SendMessageRequest : RequestBase<Message>,
                                      INotifiableMessage,
                                      IReplyMessage,
                                      IFormattableMessage,
                                      IReplyMarkupMessage<IReplyMarkup>
    {
        /// <summary>
        /// Unique identifier for the target chat or username of the target channel
        /// </summary>
        [JsonProperty(Required = Required.Always)]
        public ChatId ChatId { get; }

        /// <summary>
        /// Text of the message to be sent
        /// </summary>
        [JsonProperty(Required = Required.Always)]
        public string Text { get; }

        /// <inheritdoc />
        [JsonProperty(DefaultValueHandling = DefaultValueHandling.Ignore)]
        public ParseMode ParseMode { get; set; }

        /// <summary>
        /// Disables link previews for links in this message
        /// </summary>
        [JsonProperty(DefaultValueHandling = DefaultValueHandling.Ignore)]
        public bool DisableWebPagePreview { get; set; }

        /// <inheritdoc />
        [JsonProperty(DefaultValueHandling = DefaultValueHandling.Ignore)]
        public bool DisableNotification { get; set; }

        /// <inheritdoc />
        [JsonProperty(DefaultValueHandling = DefaultValueHandling.Ignore)]
        public int ReplyToMessageId { get; set; }

        /// <inheritdoc />
        [JsonProperty(DefaultValueHandling = DefaultValueHandling.Ignore)]
        public IReplyMarkup ReplyMarkup { get; set; }

        /// <summary>
        /// Initializes a new request with chatId and text
        /// </summary>
        /// <param name="chatId">Unique identifier for the target chat or username of the target channel</param>
        /// <param name="text">Text of the message to be sent</param>
        public SendMessageRequest(ChatId chatId, string text)
            : base("sendMessage")
        {
            ChatId = chatId;
            Text = text;
        }
    }
}
