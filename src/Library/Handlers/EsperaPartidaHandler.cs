using Telegram.Bot.Types;

namespace Library
{
    public class EsperaPartidaHandler : BaseHandler
    {
        private ControladorPartida controladorpartida = new ControladorPartida();

        public EsperaPartidaHandler(IHandler next) : base(next)
        {
            this.Keywords = new string[] { "Espera" };
        }

        protected override void InternalHandle(Message message, out string response)
        {
            controladorpartida.NuevaPartida(message);

            if (GlobalLibrary.JugadoresJugando.Count == 2)
            {
                if (GlobalLibrary.ConfiguracionTablero == "S")
                {
                    response = "Partida Encontrada! \nConfiguracion: Set standard (tablero 10x10 con 3 Naves; 2 de 3 de vida y 1 de 4 de vida) \nIngresa la posicion de tu primer nave con el formato: 'N1 XYXY' donde los primeros XY son la coordenada inicial de tu barco y los segundos XY son la coordenada final de tu barco: ";

                }
                else
                {
                    response = "Partida Encontrada! \nConfiguracion: Set mini (tablero 6x6 con 2 naves de 2 de 3 vida) \nIngresa la posicion de tu primer nave con el formato: 'N1 XYXY' donde los primeros XY son la coordenada inicial de tu barco y los segundos XY son la coordenada final de tu barco: ";
                }
            }
            else
            {
                response = "Esperando a otro jugador...";
            }
        }
    }
}