using TeleBotDotNet.Http;
using TeleBotDotNet.Requests.Types.Bases;

namespace TeleBotDotNet.Requests.Types
{
    public class ActionRequest : BaseTypeRequest
    {
        public ChatAction Action { get; set; }

        internal override void Parse(HttpData httpData, string key)
        {
            string action = null;

            switch (Action)
            {
                case ChatAction.Typing:
                    action = "typing";
                    break;

                case ChatAction.UploadPhoto:
                    action = "upload_photo";
                    break;

                case ChatAction.RecordVideo:
                    action = "record_video";
                    break;

                case ChatAction.UploadVideo:
                    action = "upload_video";
                    break;

                case ChatAction.RecordAudio:
                    action = "record_audio";
                    break;

                case ChatAction.UploadAudio:
                    action = "upload_audio";
                    break;

                case ChatAction.UploadDocument:
                    action = "upload_document";
                    break;

                case ChatAction.FindLocation:
                    action = "find_location";
                    break;
            }

            httpData.Parameters.Add(key, action);
        }
    }
}