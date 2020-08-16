using System;
using System.Runtime.Serialization;
using TelegramBotApi.Converters;

namespace TelegramBotApi.Types
{
    /// <summary>
    /// This object represents a message.
    /// </summary>
    [DataContract]
    public class Message
    {
        /// <summary>
        /// Unique message identifier
        /// </summary>
        [DataMember(Name = "message_id")]
        public int MessageId { get; set; }

        /// <summary>
        /// Sender
        /// </summary>
        [DataMember(Name = "from")]
        public User From { get; set; }

        /// <summary>
        /// Date the message was sent
        /// </summary>
        [DataMember(Name = "date")]
        public long DateUnixSeconds
        {
            get { return UnixDateTimeConverter.ToUnixTimeSeconds(Date); }
            set { Date = UnixDateTimeConverter.FromUnixTimeSeconds(value); }
        }

        public DateTimeOffset Date { get; set; }

        /// <summary>
        /// Conversation the message belongs to
        /// </summary>
        [DataMember(Name = "chat")]
        public Chat Chat { get; set; }

        /// <summary>
        /// Optional. For text messages, the actual UTF-8 text of the message
        /// </summary>
        [DataMember(Name = "text")]
        public string Text { get; set; }
    }
}