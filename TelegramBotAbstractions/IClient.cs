using Telegram.Bot;

namespace TelegramBotAbstractions
{
    public interface IClient
    {
        TelegramBotClient Client { get; }
    }
}