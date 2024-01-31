using System;
using Telegram.Bot.Types;

namespace Library
{
    public class CreateOrJoinHandler : BaseHandler
    {
        public CreateOrJoinHandler(BaseHandler next) : base(next)
        {
            this.Keywords = new string[] { "Iniciar", "iniciar" };
        }

        protected override void InternalHandle(Message message, out string response)
        {
            if (message.Text.Equals("Iniciar"))
            {
                response = $"¡Bienvenido a la batalla naval de Los Conos! \n¿Deseas crear una partida nueva o unirte a una existente? \nIngresa 'C' para crear una nueva o 'U' para unirte a una existente:";
            }
            else
            {
                response = "Error en la entrada, escribe 'Iniciar' para jugar";
            }
        }
    }
}