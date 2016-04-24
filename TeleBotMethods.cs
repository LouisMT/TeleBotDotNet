using TeleBotDotNet.Json;
using TeleBotDotNet.Requests.Methods;
using TeleBotDotNet.Responses.Methods;
using TeleBotDotNet.Responses.Types;

namespace TeleBotDotNet
{
    public partial class TeleBot
    {
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

        public SendVenueResponse SendVenue(SendVenueRequest sendVenueRequest)
        {
            Log.Info(nameof(SendVenue));
            return SendVenueResponse.Parse(ExecuteAction(sendVenueRequest));
        }

        public SendContactResponse SendContact(SendContactRequest sendContactRequest)
        {
            Log.Info(nameof(SendContact));
            return SendContactResponse.Parse(ExecuteAction(sendContactRequest));
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

        public KickChatMemberResponse KickChatMember(KickChatMemberRequest kickChatMemberRequest)
        {
            Log.Info(nameof(KickChatMember));
            return KickChatMemberResponse.Parse(ExecuteAction(kickChatMemberRequest));
        }

        public UnbanChatMemberResponse UnbanChatMember(UnbanChatMemberRequest unbanChatMemberRequest)
        {
            Log.Info(nameof(UnbanChatMember));
            return UnbanChatMemberResponse.Parse(ExecuteAction(unbanChatMemberRequest));
        }

        public AnswerInlineQueryResponse AnswerInlineQuery(AnswerInlineQueryRequest answerInlineQueryRequest)
        {
            Log.Info(nameof(AnswerInlineQuery));
            return AnswerInlineQueryResponse.Parse(ExecuteAction(answerInlineQueryRequest));
        }
    }
}
