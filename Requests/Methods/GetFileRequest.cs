using TeleBotDotNet.Http;
using TeleBotDotNet.Requests.Methods.Bases;

namespace TeleBotDotNet.Requests.Methods
{
    public class GetFileRequest : BaseMethodRequest
    {
        public string FileId { get; set; }

        internal override string MethodName => "getFile";

        internal override HttpData Parse()
        {
            return new HttpData
            {
                Parameters = new HttpParameterList
                {
                    { "file_id", FileId }
                }
            };
        }
    }
}
