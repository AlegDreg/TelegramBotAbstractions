using Telegram.Bot;

namespace TelegramBotAbstractions
{
    public class Bot : TelegramBotClient, IClient
    {
        public delegate void Message(IMessageData e, ICommand command);
        public event Message OnNewMessage;
        private List<ICommand> _commands;
        private Func<string, bool> _checkMessage;
        public TelegramBotClient Client => this;

        public Bot(IBotToken botToken, List<ICommand> commands, Func<string, bool> checkMessage) : base(botToken.GetToken())
        {
            _checkMessage = checkMessage;
            _commands = commands;
            base.OnMessage += Client_OnMessage;
            base.StartReceiving();
        }

        private void Client_OnMessage(object? sender, Telegram.Bot.Args.MessageEventArgs e)
        {
            if (_checkMessage(e.Message.Text))
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
