using Telegram.Bot.Args;

namespace TelegramBotAbstractions
{
    public class MessageData : IMessageData
    {
        public MessageEventArgs Data { get; set; }
    }
}
