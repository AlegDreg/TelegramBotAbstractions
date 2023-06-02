namespace TelegramBotAbstractions
{
    public interface ICommand
    {
        List<string> Associations { get; }
        void Execute(IMessageData e, IClient client);
    }
}