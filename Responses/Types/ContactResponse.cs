namespace TeleBotDotNet.Responses.Types
{
    public class ContactResponse
    {
        public string PhoneNumber { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int UserId { get; set; }

        internal static ContactResponse Parse(Json data)
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