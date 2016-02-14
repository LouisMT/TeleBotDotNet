using System;
using System.Globalization;
using System.IO;
using System.Net;
using System.Text;
using TeleBotDotNet.Json;
using TeleBotDotNet.Log;
using TeleBotDotNet.Requests.Methods;
using TeleBotDotNet.Requests.Methods.Bases;
using TeleBotDotNet.Responses.Methods;
using TeleBotDotNet.Responses.Types;

namespace TeleBotDotNet
{
    /// <summary>
    /// API implementation of January 20, 2016.
    /// For documentation, please see https://core.telegram.org/bots/api.
    /// </summary>
    public class TeleBot
    {
        private LogEngine _log;

        public TeleBot(string apiToken, bool enableLog = false)
        {
            ApiToken = apiToken;
            Log.Enabled = enableLog;
        }

        public LogEngine Log => _log ?? (_log = new LogEngine());

        internal static string ApiUrl => "https://api.telegram.org";

        internal string ApiToken { get; }

        private dynamic ExecuteAction(BaseMethodRequest request)
        {
            const string httpNewLine = "\r\n";
            var webRequest = WebRequest.Create($"{ApiUrl}/bot{ApiToken}/{request.MethodName}");

            // If the request is a GetUpdatesRequest, the timeout property can be set for long polling.
            // Set the timeout property of the WebRequest to the same time, so the WebRequest won't
            // timeout before the API does. This way other requests will still timeout on time.
            var updatesRequest = request as GetUpdatesRequest;
            if (updatesRequest?.Timeout != null)
            {
                const int milliSecondsInSecond = 1000;
                webRequest.Timeout += updatesRequest.Timeout.Value * milliSecondsInSecond;
            }

            webRequest.Method = "POST";
            var boundary = "---------------------------" + DateTime.Now.Ticks.ToString("x", NumberFormatInfo.InvariantInfo);
            webRequest.ContentType = "multipart/form-data; boundary=" + boundary;
            boundary = "--" + boundary;

            using (var requestStream = webRequest.GetRequestStream())
            {
                var options = request.Parse();

                // Write the values
                foreach (var parameter in options.Parameters)
                {
                    var buffer = Encoding.ASCII.GetBytes(boundary + httpNewLine);
                    requestStream.Write(buffer, 0, buffer.Length);
                    buffer = Encoding.ASCII.GetBytes($"Content-Disposition: form-data; name=\"{parameter.Key}\"{httpNewLine}{httpNewLine}");
                    requestStream.Write(buffer, 0, buffer.Length);
                    buffer = Encoding.UTF8.GetBytes(parameter.Value + httpNewLine);
                    requestStream.Write(buffer, 0, buffer.Length);
                }

                // Write the files
                foreach (var file in options.Files)
                {
                    var buffer = Encoding.ASCII.GetBytes(boundary + httpNewLine);
                    requestStream.Write(buffer, 0, buffer.Length);
                    buffer = Encoding.UTF8.GetBytes($"Content-Disposition: form-data; name=\"{file.Key}\"; filename=\"{file.FileName}\"{httpNewLine}");
                    requestStream.Write(buffer, 0, buffer.Length);
                    buffer = Encoding.ASCII.GetBytes($"Content-Type: {file.ContentType}{httpNewLine}{httpNewLine}");
                    requestStream.Write(buffer, 0, buffer.Length);
                    new MemoryStream(file.File).CopyTo(requestStream);
                    buffer = Encoding.ASCII.GetBytes(httpNewLine);
                    requestStream.Write(buffer, 0, buffer.Length);
                }

                var boundaryBuffer = Encoding.ASCII.GetBytes(boundary + "--");
                requestStream.Write(boundaryBuffer, 0, boundaryBuffer.Length);
            }

            try
            {
                return DecodeWebResponse(webRequest.GetResponse());
            }
            catch (WebException e)
            {
                return DecodeWebResponse(e.Response);
            }
        }

        private static JsonData DecodeWebResponse(WebResponse webResponse)
        {
            using (webResponse)
            using (var responseStream = webResponse.GetResponseStream())
            using (var stream = new MemoryStream())
            {
                responseStream?.CopyTo(stream);
                var responseString = Encoding.UTF8.GetString(stream.ToArray());
                return JsonData.Deserialize(responseString);
            }
        }

        public GetMeResponse GetMe(GetMeRequest getMeRequest)
        {
            Log.Info(nameof(GetMe));
            return GetMeResponse.Parse(ExecuteAction(getMeRequest));
        }

        public SendMessageResponse SendMessage(SendMessageRequest sendMessageRequest)
        {
            Log.Info(nameof(SendMessage));
            return SendMessageResponse.Parse(ExecuteAction(sendMessageRequest));
        }

        public ForwardMessageResponse ForwardMessage(ForwardMessageRequest forwardMessageRequest)
        {
            Log.Info(nameof(ForwardMessage));
            return ForwardMessageResponse.Parse(ExecuteAction(forwardMessageRequest));
        }

        public SendPhotoResponse SendPhoto(SendPhotoRequest sendPhotoRequest)
        {
            Log.Info(nameof(SendPhoto));
            return SendPhotoResponse.Parse(ExecuteAction(sendPhotoRequest));
        }

        public SendAudioResponse SendAudio(SendAudioRequest sendAudioRequest)
        {
            Log.Info(nameof(SendAudio));
            return SendAudioResponse.Parse(ExecuteAction(sendAudioRequest));
        }

        public SendDocumentResponse SendDocument(SendDocumentRequest sendDocumentRequest)
        {
            Log.Info(nameof(SendDocument));
            return SendDocumentResponse.Parse(ExecuteAction(sendDocumentRequest));
        }

        public SendStickerResponse SendSticker(SendStickerRequest sendStickerRequest)
        {
            Log.Info(nameof(SendSticker));
            return SendStickerResponse.Parse(ExecuteAction(sendStickerRequest));
        }

        public SendVideoResponse SendVideo(SendVideoRequest sendVideoRequest)
        {
            Log.Info(nameof(SendVideo));
            return SendVideoResponse.Parse(ExecuteAction(sendVideoRequest));
        }

        public SendLocationResponse SendLocation(SendLocationRequest sendLocationRequest)
        {
            Log.Info(nameof(SendLocation));
            return SendLocationResponse.Parse(ExecuteAction(sendLocationRequest));
        }

        public SendChatActionResponse SendChatAction(SendChatActionRequest sendChatActionRequest)
        {
            Log.Info(nameof(SendChatAction));
            return SendChatActionResponse.Parse(ExecuteAction(sendChatActionRequest));
        }

        public GetUserProfilePhotosResponse GetUserProfilePhotos(GetUserProfilePhotosRequest getUserProfilePhotosRequest)
        {
            Log.Info(nameof(GetUserProfilePhotos));
            return GetUserProfilePhotosResponse.Parse(ExecuteAction(getUserProfilePhotosRequest));
        }

        public GetUpdatesResponse GetUpdates(GetUpdatesRequest getUpdatesRequest)
        {
            Log.Info(nameof(GetUpdates));
            return GetUpdatesResponse.Parse(ExecuteAction(getUpdatesRequest));
        }

        public SetWebhookResponse SetWebhook(SetWebhookRequest setWebhookRequest)
        {
            Log.Info(nameof(SetWebhook));
            return SetWebhookResponse.Parse(ExecuteAction(setWebhookRequest));
        }

        public UpdateResponse ConvertWebhookResponse(string json)
        {
            Log.Info(nameof(ConvertWebhookResponse));
            return UpdateResponse.Parse(JsonData.Deserialize(json));
        }

        public GetFileResponse GetFile(GetFileRequest getFileRequest)
        {
            Log.Info(nameof(GetFile));
            return GetFileResponse.Parse(ExecuteAction(getFileRequest));
        }

        public AnswerInlineQueryResponse AnswerInlineQuery(AnswerInlineQueryRequest answerInlineQueryRequest)
        {
            Log.Info(nameof(AnswerInlineQuery));
            return AnswerInlineQueryResponse.Parse(ExecuteAction(answerInlineQueryRequest));
        }
    }
}
