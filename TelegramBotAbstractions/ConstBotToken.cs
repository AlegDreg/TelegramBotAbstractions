namespace TelegramBotAbstractions
{
    public class ConstBotToken : IBotToken
    {
        private const string Token = "";

        public string GetToken()
        {
            return Token;
        }
    }
}