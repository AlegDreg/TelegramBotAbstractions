namespace TelegramBotAbstractions
{
    public interface IMessageData
    {
        Telegram.Bot.Args.MessageEventArgs Data { get; set; }
    }
}