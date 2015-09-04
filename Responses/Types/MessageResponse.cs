using System;
using System.Collections.Generic;

namespace TeleBotDotNet.Responses.Types
{
    public class MessageResponse
    {
        public MessageResponse()
        {
            Photo = new List<PhotoSizeResponse>();
            NewChatPhoto = new List<PhotoSizeResponse>();
        }

        /// <summary>
        ///     Unique message identifier
        /// </summary>
        public int MessageId { get; set; }

        /// <summary>
        ///     Sender
        /// </summary>
        public UserResponse From { get; set; }

        /// <summary>
        ///     Date the message was sent
        /// </summary>
        public DateTime? Date { get; set; }

        /// <summary>
        ///     Conversation the message belongs to
        /// </summary>
        public UserResponse UserChat { get; set; }

        /// <summary>
        ///     Conversation the message belongs to
        /// </summary>
        public GroupChatResponse GroupChat { get; set; }

        /// <summary>
        ///     Optional. For forwarded messages, sender of the original message
        /// </summary>
        public UserResponse ForwardFrom { get; set; }

        /// <summary>
        ///     Optional. For forwarded messages, date the original message was sent
        /// </summary>
        public DateTime? ForwardDate { get; set; }

        /// <summary>
        ///     Optional. For replies, the original message. Note that the Message object in this field will not contain further
        ///     reply_to_message fields even if it itself is a reply.
        /// </summary>
        public MessageResponse ReplyToMessage { get; set; }

        /// <summary>
        ///     Optional. For text messages, the actual UTF-8 text of the message
        /// </summary>
        public string Text { get; set; }

        /// <summary>
        ///     Optional. Message is an audio file, information about the file
        /// </summary>
        public AudioResponse Audio { get; set; }

        /// <summary>
        ///     Optional. Message is a general file, information about the file
        /// </summary>
        public DocumentResponse Document { get; set; }

        /// <summary>
        ///     Optional. Message is a photo, available sizes of the photo
        /// </summary>
        public List<PhotoSizeResponse> Photo { get; set; }

        /// <summary>
        ///     Optional. Message is a sticker, information about the sticker
        /// </summary>
        public StickerResponse Sticker { get; set; }

        /// <summary>
        ///     Optional. Message is a video, information about the video
        /// </summary>
        public VideoResponse Video { get; set; }

        /// <summary>
        ///     Optional. Message is a shared contact, information about the contact
        /// </summary>
        public ContactResponse Contact { get; set; }

        /// <summary>
        ///     Optional. Message is a shared location, information about the location
        /// </summary>
        public LocationResponse Location { get; set; }

        /// <summary>
        ///     Optional. A new member was added to the group, information about them (this member may be bot itself)
        /// </summary>
        public UserResponse NewChatParticipant { get; set; }

        /// <summary>
        ///     Optional. A member was removed from the group, information about them (this member may be bot itself)
        /// </summary>
        public UserResponse LeftChatParticipant { get; set; }

        /// <summary>
        ///     Optional. A group title was changed to this value
        /// </summary>
        public string NewChatTitle { get; set; }

        /// <summary>
        ///     Optional. A group photo was change to this value
        /// </summary>
        public List<PhotoSizeResponse> NewChatPhoto { get; set; }

        /// <summary>
        ///     Optional. Informs that the group photo was deleted
        /// </summary>
        public bool? DeleteChatPhoto { get; set; }

        /// <summary>
        ///     Optional. Informs that the group has been created
        /// </summary>
        public bool? GroupChatCreated { get; set; }

        internal static MessageResponse Parse(Json data)
        {
            if (data == null || !data.Has("message_id") || !data.Has("from") || !data.Has("date") || !data.Has("chat"))
            {
                return null;
            }

            var messageResponse = new MessageResponse
            {
                MessageId = data.Get<int>("message_id"),
                From = UserResponse.Parse(data.GetJson("from")),
                Date = data.GetDateTime("date"),
                UserChat = UserResponse.Parse(data.GetJson("chat")),
                GroupChat = GroupChatResponse.Parse(data.GetJson("chat")),
                ForwardFrom = UserResponse.Parse(data.GetJson("forward_from")),
                ForwardDate = data.GetDateTime("forward_date"),
                ReplyToMessage = MessageResponse.Parse(data.GetJson("reply_to_message")),
                Text = data.Get<string>("text"),
                Audio = AudioResponse.Parse(data.GetJson("audio")),
                Document = DocumentResponse.Parse(data.GetJson("document")),
                Sticker = StickerResponse.Parse(data.GetJson("sticker")),
                Video = VideoResponse.Parse(data.GetJson("video")),
                Contact = ContactResponse.Parse(data.GetJson("contact")),
                Location = LocationResponse.Parse(data.GetJson("location")),
                NewChatParticipant = UserResponse.Parse(data.GetJson("new_chat_participant")),
                LeftChatParticipant = UserResponse.Parse(data.GetJson("left_chat_participant")),
                NewChatTitle = data.Get<string>("new_chat_title"),
                DeleteChatPhoto = data.Get<bool?>("delete_chat_photo"),
                GroupChatCreated = data.Get<bool?>("group_chat_created")
            };

            if (data.Has("photo"))
            {
                foreach (var photo in data.GetJsonList("photo"))
                {
                    messageResponse.Photo.Add(PhotoSizeResponse.Parse(photo));
                }
            }
            if (data.Has("new_chat_photo"))
            {
                foreach (var photo in data.GetJsonList("new_chat_photo"))
                {
                    messageResponse.NewChatPhoto.Add(PhotoSizeResponse.Parse(photo));
                }
            }

            return messageResponse;
        }
    }
}