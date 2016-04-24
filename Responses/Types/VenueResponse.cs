using TeleBotDotNet.Json;

namespace TeleBotDotNet.Responses.Types
{
    public class VenueResponse
    {
        public LocationResponse Location { get; private set; }
        public string Title { get; private set; }
        public string Address { get; private set; }
        public string FoursquareId { get; private set; }

        internal static VenueResponse Parse(JsonData data)
        {
            if (data == null || !data.Has("location") || !data.Has("title") || !data.Has("address"))
            {
                return null;
            }

            return new VenueResponse
            {
                Location = LocationResponse.Parse(data.GetJson("location")),
                Title = data.Get<string>("title"),
                Address = data.Get<string>("address"),
                FoursquareId = data.Get<string>("foursquare_id")
            };
        }
    }
}
