using System;
using Telegram.Bot.Types;

namespace Library
{
    /// <summary>
    /// Un "handler" del patrón Chain of Responsibility que implementa el comando "Hola", luego continua la cadena.
    /// </summary>
    public class HelloHandler : BaseHandler
    {
        public HelloHandler(BaseHandler next) : base(next)
        {
            this.Keywords = new string[] { "Hola", "hola" };
        }

        protected override void InternalHandle(Message message, out string response)
        {
            // registramos a todos los jugadores que saluden al bot.
            Jugador jugador = new Jugador (message.From.FirstName, message.Chat.Id);
            RegistroUsuarios Registro = new RegistroUsuarios(jugador);

            response = $"¡Hola! Para jugar a la batalla naval escribe 'Iniciar'";
        }
    }
}