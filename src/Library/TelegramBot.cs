using System;
using System.Threading;
using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Polling;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;

namespace Library
{
    public class TelegramBot
    {
        private static TelegramBotClient bot;

        // encapsulamos los handlers
        private static IHandler firstHandler;

        internal object message;

        public static long ChatId { get; private set; }

        public static string Mensajebot { get; private set; }

        public static void Main()
        {
            bot = new TelegramBotClient("6503767401:AAHJDbuRQXWvsFZINsCk8ksfBUPdyHYmRbQ");

            firstHandler = new HelloHandler
            (new CreateOrJoinHandler
            (new GameModeHandler
            (new ConfiguracionTableroHandler
            (new EsperaPartidaHandler
            (new RegistroNavesHandler
            (new Nave2J1Handler
            (new Nave3J1Handler
            (new Nave1J2Handler
            (new Nave2J2Handler
            (new Nave3J2Handler
            (new InicioPartidaHandler
            (new AtacarJ1
            (new GetStaticsHandler(null)))))))))))))); // se Agrega al final el nuevo Handler GetStaticHandler para poder interactuar con el bot

            var cts = new CancellationTokenSource();

            bot.StartReceiving(
                HandleUpdateAsync,
                HandleErrorAsync,
                new ReceiverOptions
                {
                    AllowedUpdates = Array.Empty<UpdateType>()
                },
                cts.Token
            );

            Console.WriteLine($"Bot is up!");

            Console.ReadLine();

            cts.Cancel();
        }

        public static async Task HandleUpdateAsync(ITelegramBotClient botClient, Update update, CancellationToken cancellationToken)
        {
            try
            {
                if (update.Type == UpdateType.Message)
                {
                    await HandleMessageReceived(botClient, update.Message);

                }
            }
            catch (Exception e)
            {
                await HandleErrorAsync(botClient, e, cancellationToken);
            }
        }

        private static async Task HandleMessageReceived(ITelegramBotClient botClient, Message message)
        {
            Console.WriteLine($"Received a message from {message.From.FirstName} saying: {message.Text}");

            string response = String.Empty;
            firstHandler.Handle(message, out response);

            await botClient.SendTextMessageAsync(message.Chat.Id, response);
            ChatId = message.Chat.Id;
            Mensajebot = message.Text.ToString();
        }

        public static Task HandleErrorAsync(ITelegramBotClient botClient, Exception exception, CancellationToken cancellationToken)
        {
            Console.WriteLine(exception.Message);
            return Task.CompletedTask;
        }

        public static async Task SendTextMessageAsync(string mensaje)
        {
        // Envía el mensaje al bot de Telegram
        await bot.SendTextMessageAsync(ChatId, mensaje);
        }
    
        public static async Task SendTextMessageAsync(string mensaje, long chatid)
        {
        // Envía el mensaje al bot de Telegram
        await bot.SendTextMessageAsync(chatid, mensaje);
        }
    
    
    
    
    }
}