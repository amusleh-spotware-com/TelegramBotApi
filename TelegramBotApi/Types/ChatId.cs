using Newtonsoft.Json;
using TelegramBotApi.Converters;

namespace TelegramBotApi.Types
{
    /// <summary>
    /// Represents a ChatId
    /// </summary>
    [JsonConverter(typeof(ChatIdConverter))]
    public class ChatId
    {
        /// <summary>
        /// Unique identifier for the chat
        /// </summary>
        public readonly long Identifier;

        /// <summary>
        /// Username of the channel (in the format @channelusername)
        /// </summary>
        public readonly string Username;

        /// <summary>
        /// Create a <see cref="ChatId"/> using an identifier
        /// </summary>
        /// <param name="identifier">The Identifier</param>
        public ChatId(long identifier)
        {
            Identifier = identifier;
        }

        /// <summary>
        /// Create a <see cref="ChatId"/> using an identifier
        /// </summary>
        /// <param name="chatId">The Identifier</param>
        public ChatId(int chatId)
        {
            Identifier = chatId;
        }

        /// <summary>
        /// Create a <see cref="ChatId"/> using an user name
        /// </summary>
        /// <param name="username">The user name</param>
        public ChatId(string username)
        {
            if (username.Length > 1 && username.Substring(0, 1) == "@")
            {
                Username = username;
            }
            else if (int.TryParse(username, out int chatId))
            {
                Identifier = chatId;
            }
            else if (long.TryParse(username, out long identifier))
            {
                Identifier = identifier;
            }
        }
    }
}
