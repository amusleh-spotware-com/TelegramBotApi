using System.Runtime.Serialization;

namespace TelegramBotApi.Types
{
    /// <summary>
    /// This object represents an incoming update.
    /// </summary>
    /// <remarks>
    /// Only one of the optional parameters can be present in any given update.
    /// </remarks>
    [DataContract]
    public class Update
    {
        /// <summary>
        /// The update's unique identifier. Update identifiers start from a certain positive number and increase sequentially.
        /// This ID becomes especially handy if you're using Webhooks, since it allows you to ignore repeated updates or to
        /// restore the correct update sequence, should they get out of order.
        /// </summary>
        [DataMember(Name = "update_id")]
        public long Id { get; set; }

        /// <summary>
        /// Optional. New incoming message of any kind — text, photo, sticker, etc.
        /// </summary>
        [DataMember(Name = "message")]
        public Message Message { get; set; }

        [DataMember(Name = "channel_post")]
        public Message ChannelPost { get; set; }
    }
}