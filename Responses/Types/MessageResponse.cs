using System;
using System.Collections.Generic;
using TeleBotDotNet.Json;

namespace TeleBotDotNet.Responses.Types
{
    public class MessageResponse
    {
        public MessageResponse()
        {
            Photo = new List<PhotoSizeResponse>();
            NewChatPhoto = new List<PhotoSizeResponse>();
        }

        public int MessageId { get; private set; }
        public UserResponse From { get; private set; }
        public DateTime? Date { get; private set; }
        public ChatResponse Chat { get; private set; }
        public UserResponse ForwardFrom { get; private set; }
        public DateTime? ForwardDate { get; private set; }
        public MessageResponse ReplyToMessage { get; private set; }
        public string Text { get; private set; }
        public AudioResponse Audio { get; private set; }
        public DocumentResponse Document { get; private set; }
        public List<PhotoSizeResponse> Photo { get; }
        public StickerResponse Sticker { get; private set; }
        public VideoResponse Video { get; private set; }
        public VoiceResponse Voice { get; private set; }
        public string Caption { get; private set; }
        public ContactResponse Contact { get; private set; }
        public LocationResponse Location { get; private set; }
        public UserResponse NewChatParticipant { get; private set; }
        public UserResponse LeftChatParticipant { get; private set; }
        public string NewChatTitle { get; private set; }
        public List<PhotoSizeResponse> NewChatPhoto { get; }
        public bool? DeleteChatPhoto { get; private set; }
        public bool? GroupChatCreated { get; private set; }

        internal static MessageResponse Parse(JsonData data)
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
                Chat = ChatResponse.Parse(data.GetJson("chat")),
                ForwardFrom = UserResponse.Parse(data.GetJson("forward_from")),
                ForwardDate = data.GetDateTime("forward_date"),
                ReplyToMessage = Parse(data.GetJson("reply_to_message")),
                Text = data.Get<string>("text"),
                Audio = AudioResponse.Parse(data.GetJson("audio")),
                Document = DocumentResponse.Parse(data.GetJson("document")),
                Sticker = StickerResponse.Parse(data.GetJson("sticker")),
                Video = VideoResponse.Parse(data.GetJson("video")),
                Voice = VoiceResponse.Parse(data.GetJson("voice")),
                Caption = data.Get<string>("caption"),
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

        public override string ToString()
        {
            return $"Message id: {MessageId} Text: {Text}";
        }
    }
}