using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TelegramBotApi.Tests
{
    [TestClass()]
    public class TelegramBotClientTests
    {
        public const string BotToken = "";

        [TestMethod()]
        public void GetUpdatesTest()
        {
            var client = new TelegramBotClient(BotToken);

            client.DeleteWebhook();

            var result = client.GetUpdates();

            Assert.IsTrue(result.Ok);
        }

        [TestMethod()]
        public void DeleteWebhookTest()
        {
            var client = new TelegramBotClient(BotToken);

            var result = client.DeleteWebhook();

            Assert.IsTrue(result.Ok);
        }

        [TestMethod()]
        public void SendTextMessageTest()
        {
            var client = new TelegramBotClient(BotToken);

            var result = client.SendTextMessage("827464027", "Hello World!");

            Assert.IsTrue(result.Ok);
        }
    }
}