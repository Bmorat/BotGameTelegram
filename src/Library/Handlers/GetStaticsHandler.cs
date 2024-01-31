using System;
using Telegram.Bot.Types;

namespace Library
{   
        /// <summary>
        /// Implementacion de un nuevo handler para interactuar con el bot
        /// </summary>
        public class GetStaticsHandler : BaseHandler
        {
       

        public GetStaticsHandler(BaseHandler next) : base(next)
            {
                this.Keywords = new string[] { "/Estadisticas"};
            }

            protected override void InternalHandle(Message message, out string response)
            {
                if (message.Text.Equals("/Estadisticas"))
                {
                    if (GlobalLibrary.ListaAtaquesJ1 != null && GlobalLibrary.ListaAtaquesJ2 != null)
                    {
                        /// <summary>
                        /// se implementa el metodo de la clase bot printer para mostrarle al usuario mediante el handler las estadisticas de ataque
                        /// checkeando primero que las listas contengan algun ataque
                        /// </summary>
                        /// <returns></returns>
                        string ataquesj1 = BotPrinter.PrintStatic(GlobalLibrary.ListaAtaquesJ1);
                        string ataquesj2 = BotPrinter.PrintStatic(GlobalLibrary.ListaAtaquesJ2);

                        response = $"Aqui tienes las estadisticas de ataques de la Partida\nEl Jugador 1 ha realizado los siguientes ataques:\n{ataquesj1}\nEl Jugador 2 ha realizado los siguientes ataques{ataquesj2}\npara continuar con el juego continua Atacando con el comando Atacar XY";
                    }
                    else
                    {
                        response = "Error al registrar estadisticas, alguno de los jugadores aun no ha atacado";
                    }
                }

                else
                {
                    response = String.Empty;
                }
            }
        }
}
