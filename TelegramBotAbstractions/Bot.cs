using Telegram.Bot;

namespace TelegramBotAbstractions
{
    public class Bot : TelegramBotClient, IClient
    {
        public delegate void Message(IMessageData e, ICommand command);
        public event Message OnNewMessage;
        private List<ICommand> _commands;

        public TelegramBotClient Client => this;

        public Bot(IBotToken botToken, List<ICommand> commands) : base(botToken.GetToken())
        {
            _commands = commands;
            base.OnMessage += Client_OnMessage;
            base.StartReceiving();
        }

        private void Client_OnMessage(object? sender, Telegram.Bot.Args.MessageEventArgs e)
        {
            if (e.Message.Text.Length > 0)
            {
                var s = _commands.Where(x =>
                x.Associations.Contains(e.Message.Text.Split(' ')[0]))
                    .FirstOrDefault();
                if (s != null)
                    OnNewMessage?.Invoke(new MessageData { Data = e }, s);
            }
        }
    }
}
