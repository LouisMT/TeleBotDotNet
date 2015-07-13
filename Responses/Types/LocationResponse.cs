namespace TeleBotDotNet.Responses.Types
{
    public class LocationResponse
    {
        public float Longitude { get; set; }
        public float Latitude { get; set; }

        internal static LocationResponse Parse(dynamic data)
        {
            if (data == null || data.longitude == null || data.latitude == null)
            {
                return null;
            }

            return new LocationResponse
            {
                Longitude = data.longitude,
                Latitude = data.latitude
            };
        }
    }
}