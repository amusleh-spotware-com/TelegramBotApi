using System.IO;
using System.Net;
using System.Runtime.Serialization.Json;
using System.Text;
using TelegramBotApi.Requests;
using TelegramBotApi.Requests.Abstractions;
using TelegramBotApi.Types;

namespace TelegramBotApi
{
    /// <summary>
    /// A client to use the Telegram Bot API
    /// </summary>
    public class TelegramBotClient
    {
        private const string BaseUrl = "https://api.telegram.org/bot";

        private readonly string _baseRequestUrl, _token;

        public TelegramBotClient(string token)
        {
            ServicePointManager.Expect100Continue = true;
            ServicePointManager.SecurityProtocol = (SecurityProtocolType)768 | (SecurityProtocolType)3072;

            _token = token;
            _baseRequestUrl = string.Format("{0}{1}/", BaseUrl, _token);
        }

        #region Helpers

        public ApiResponse<TResponse> MakeRequest<TResponse>(IRequest<TResponse> request)
        {
            string url = _baseRequestUrl + request.MethodName;

            byte[] payload = Encoding.UTF8.GetBytes(request.ToJson());

            WebRequest webRequest = WebRequest.Create(url);

            webRequest.Method = "POST";
            webRequest.ContentLength = payload.Length;
            webRequest.ContentType = "application/json";

            using (Stream requestStream = webRequest.GetRequestStream())
            {
                requestStream.Write(payload, 0, payload.Length);
            }

            WebResponse webResponse = webRequest.GetResponse();

            Stream responseStream = webResponse.GetResponseStream();

            byte[] responseByte = new byte[webResponse.ContentLength];

            responseStream.Read(responseByte, 0, responseByte.Length);

            string responseJson = Encoding.UTF8.GetString(responseByte);

            var apiResponse = Deserialize<ApiResponse<TResponse>>(responseJson)
                ?? new ApiResponse<TResponse> // ToDo is required? unit test
                {
                    Ok = false,
                    Description = "No response received"
                };

            return apiResponse;
        }

        private T Deserialize<T>(string json) where T : new()
        {
            using (var stream = new MemoryStream(Encoding.Unicode.GetBytes(json)))
            {
                DataContractJsonSerializer deserializer = new DataContractJsonSerializer(typeof(T));

                var result = deserializer.ReadObject(stream);

                return (T)result;
            }
        }

        #endregion Helpers

        #region Getting updates

        public ApiResponse<Update[]> GetUpdates()
        {
            return MakeRequest(new GetUpdatesRequest());
        }

        #endregion Getting updates

        #region Available methods

        public ApiResponse<Message> SendTextMessage(long chatId, string text)
        {
            return MakeRequest(new SendMessageRequest(chatId, text));
        }

        public ApiResponse<bool> DeleteWebhook()
        {
            return MakeRequest(new DeleteWebhookRequest());
        }

        #endregion Available methods
    }
}