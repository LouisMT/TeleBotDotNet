using TeleBotDotNet.Http;
using TeleBotDotNet.Requests.Types.Bases;

namespace TeleBotDotNet.Requests.Types
{
    public class ActionRequest : BaseTypeRequest
    {
        public Action Action { get; set; }

        internal override void Parse(HttpData httpData, string key)
        {
            string action = null;

            switch (Action)
            {
                case Action.Typing:
                    action = "typing";
                    break;

                case Action.UploadPhoto:
                    action = "upload_photo";
                    break;

                case Action.RecordVideo:
                    action = "record_video";
                    break;

                case Action.UploadVideo:
                    action = "upload_video";
                    break;

                case Action.RecordAudio:
                    action = "record_audio";
                    break;

                case Action.UploadAudio:
                    action = "upload_audio";
                    break;

                case Action.UploadDocument:
                    action = "upload_document";
                    break;

                case Action.FindLocation:
                    action = "find_location";
                    break;
            }

            httpData.Parameters.Add(key, action);
        }
    }
}