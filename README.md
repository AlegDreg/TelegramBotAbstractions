# TelegramBotAbstractions
## Simple abstractions for a telegram bot

Example
```c#
    private static Bot bot;
    public static void Main(string[] args)
    {
        bot = new Bot(new ConstBotToken(), new List<ICommand>
        {
            new Hello()
        },
        (message) =>
        {
            return message.Length > 0;
        });

        bot.OnNewMessage += Bot_OnNewMessage;
    }

    private static void Bot_OnNewMessage(IMessageData e, ICommand command)
    {
        command.Execute(e, bot);
    }
```
