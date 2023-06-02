using TelegramBotAbstractions;

namespace Example.Commands
{
    internal class Hello : ICommand
    {
        public List<string> Associations => new List<string>() { "/start", "/hello" };

        public void Execute(IMessageData e, IClient client)
        {
            client.Client.SendTextMessageAsync(e.Data.Message.Chat.Id, "Hello!");
        }
    }
}
