using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;
using TelegramBotApi.Exceptions;
using TelegramBotApi.Requests;
using TelegramBotApi.Requests.Abstractions;
using TelegramBotApi.Types;
using TelegramBotApi.Types.Enums;

namespace TelegramBotApi
{
    /// <summary>
    /// A client to use the Telegram Bot API
    /// </summary>
    public class TelegramBotClient
    {
        private const string BaseUrl = "https://api.telegram.org/bot";
        private const string BaseFileUrl = "https://api.telegram.org/file/bot";

        private readonly string _baseRequestUrl, _token;

        public TelegramBotClient(string token)
        {
            _token = token;
            _baseRequestUrl = string.Format("{0}{1}/", BaseUrl, _token);
        }

        #region Helpers

        public TResponse MakeRequest<TResponse>(IRequest<TResponse> request)
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

            var apiResponse =
                JsonConvert.DeserializeObject<ApiResponse<TResponse>>(responseJson)
                ?? new ApiResponse<TResponse> // ToDo is required? unit test
                {
                    Ok = false,
                    Description = "No response received"
                };

            if (!apiResponse.Ok)
                throw new ApiRequestException(apiResponse.Description, apiResponse.ErrorCode);

            return apiResponse.Result;
        }

        #endregion Helpers

        #region Getting updates

        public Update[] GetUpdates(int offset = 0, int limit = 0, int timeout = 0, IEnumerable<UpdateType> allowedUpdates = null)
        {
            return MakeRequest(new GetUpdatesRequest
            {
                Offset = offset,
                Limit = limit,
                Timeout = timeout,
                AllowedUpdates = allowedUpdates
            });
        }

        #endregion Getting updates

        #region Available methods

        public Message SendTextMessage(ChatId chatId, string text)
        {
            return MakeRequest(new SendMessageRequest(chatId, text));
        }

        public Message SendTextMessage(long chatId, string text)
        {
            return SendTextMessage(new ChatId(chatId), text);
        }

        #endregion Available methods
    }
}