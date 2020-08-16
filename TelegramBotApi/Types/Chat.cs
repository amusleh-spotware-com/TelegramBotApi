using System.Runtime.Serialization;

namespace TelegramBotApi.Types
{
    /// <summary>
    /// This object represents a chat.
    /// </summary>
    [DataContract]
    public class Chat
    {
        /// <summary>
        /// Unique identifier for this chat, not exceeding 1e13 by absolute value
        /// </summary>
        [DataMember(Name = "id")]
        public long Id { get; set; }

        /// <summary>
        /// Optional. Username, for private chats and channels if available
        /// </summary>
        [DataMember(Name = "username")]
        public string Username { get; set; }

        /// <summary>
        /// Optional. First name of the other party in a private chat
        /// </summary>
        [DataMember(Name = "first_name")]
        public string FirstName { get; set; }

        /// <summary>
        /// Optional. Last name of the other party in a private chat
        /// </summary>
        [DataMember(Name = "last_name")]
        public string LastName { get; set; }

        [DataMember(Name = "title")]
        public string Title { get; set; }
    }
}