using Telegram.Bot.Types;

namespace Library
{
    public interface IHandler
    {
        IHandler Next { get; set; }

        void Cancel(Message message);

        IHandler Handle(Message message, out string response);
    }
}