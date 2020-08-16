using TelegramBotApi.Types;
using System.Runtime.Serialization;

// ReSharper disable once CheckNamespace
namespace TelegramBotApi.Requests
{
    /// <summary>
    /// Receive incoming updates using long polling. An Array of <see cref="Update" /> objects is returned.
    /// </summary>
    [DataContract]
    public class DeleteWebhookRequest : RequestBase<bool>
    {
        /// <summary>
        /// Initializes a new GetUpdates request
        /// </summary>
        public DeleteWebhookRequest()
            : base("deleteWebhook")
        {
        }
    }
}