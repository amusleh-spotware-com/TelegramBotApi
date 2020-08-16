using System;

namespace TelegramBotApi.Converters
{
    public static class UnixDateTimeConverter
    {
        private static readonly DateTimeOffset unixEpochTime = new DateTimeOffset(1970, 1, 1, 0, 0, 0, default);

        public static DateTimeOffset FromUnixTimeSeconds(long seconds)
        {
            return unixEpochTime.AddSeconds(seconds);
        }

        public static long ToUnixTimeSeconds(DateTimeOffset time)
        {
            return (long)(time - unixEpochTime).TotalSeconds;
        }
    }
}