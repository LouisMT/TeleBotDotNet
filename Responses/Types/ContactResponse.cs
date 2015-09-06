using TeleBotDotNet.Json;

namespace TeleBotDotNet.Responses.Types
{
    public class ContactResponse
    {
        public string PhoneNumber { get; private set; }
        public string FirstName { get; private set; }
        public string LastName { get; private set; }
        public int UserId { get; private set; }

        internal static ContactResponse Parse(JsonData data)
        {
            if (data == null || !data.Has("phone_number") || !data.Has("first_name"))
            {
                return null;
            }

            return new ContactResponse
            {
                PhoneNumber = data.Get<string>("phone_number"),
                FirstName = data.Get<string>("first_name"),
                LastName = data.Get<string>("last_name"),
                UserId = data.Get<int>("user_id")
            };
        }
    }
}