using TelegramBotApi.Types.Enums;

namespace TelegramBotApi.Requests.Abstractions
{
    /// <summary>
    /// Represents a message with formatted text
    /// </summary>
    public interface IFormattableMessage
    {
        /// <summary>
        /// Change, if you want Telegram apps to show bold, italic, fixed-width text or inline URLs in your bot's message
        /// </summary>
        ParseMode ParseMode { get; set; }
    }
}
