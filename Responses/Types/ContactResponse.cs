namespace TeleBotDotNet.Responses.Types
{
    public class ContactResponse
    {
        public string PhoneNumber { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string UserId { get; set; }

        internal static ContactResponse Parse(dynamic data)
        {
            if (data == null || data.phone_number == null || data.first_name == null)
            {
                return null;
            }

            return new ContactResponse
            {
                PhoneNumber = data.phone_number,
                FirstName = data.first_name,
                LastName = data.last_name,
                UserId = data.user_id
            };
        }
    }
}