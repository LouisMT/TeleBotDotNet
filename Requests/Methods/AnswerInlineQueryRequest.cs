using System.Collections.Generic;
using System.Linq;
using TeleBotDotNet.Http;
using TeleBotDotNet.Json;
using TeleBotDotNet.Requests.Methods.Bases;
using TeleBotDotNet.Requests.Types.Bases;
using TeleBotDotNet.Requests.Types.Interfaces;

namespace TeleBotDotNet.Requests.Methods
{
    public class AnswerInlineQueryRequest : BaseMethodRequest
    {
        public string InlineQueryId { get; set; }
        public List<IInlineQueryResultRequest> Results { get; set; }
        public int CacheTime { get; set; }
        public bool IsPersonal { get; set; }
        public string NextOffset { get; set; }

        internal override string MethodName => "answerInlineQuery";

        internal override HttpData Parse()
        {
            var httpData = new HttpData
            {
                Parameters = new HttpParameterList
                {
                    { "inline_query_id", InlineQueryId },
                    { "cache_time", CacheTime },
                    { "is_personal", IsPersonal },
                    { "next_offset", NextOffset }
                }
            };

            var results = Results.Select(r => ((BaseInlineQueryResultRequest)r).Parse()).ToArray();
            httpData.Parameters.Add("results", JsonData.Serialize(results));

            return httpData;
        }
    }
}
