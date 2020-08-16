using Microsoft.VisualStudio.TestTools.UnitTesting;
using TelegramBotApi;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TelegramBotApi.Tests
{
    [TestClass()]
    public class TelegramBotClientTests
    {
        public const string BotToken = "940039667:AAFSTL9K33bigcPtxLhHCWAn_KAzQyRbOM4";

        [TestMethod()]
        public void GetUpdatesTest()
        {
            var client = new TelegramBotClient(BotToken);

            var result = client.GetUpdates();

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