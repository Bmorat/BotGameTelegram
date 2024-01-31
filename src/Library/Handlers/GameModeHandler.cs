using System;
using Telegram.Bot.Types;

namespace Library;

public class GameModeHandler : BaseHandler
{
    private ControladorPartida controladorpartida = new ControladorPartida();

    public GameModeHandler (IHandler next) : base (next)
    {
        this.Keywords = new string[] { "C", "U" };
    }

    protected override void InternalHandle(Message message, out string response)
    {
        if (message.Text.Equals ("C"))
        {
            response = "¿Desea jugar con el set standard (tablero 10x10 con 3 Naves; 2 de 3 de vida y 1 de 4 de vida) o la version mini (6x6 con 2 naves de 2 de 3 vida)? \nPara elegir la version standard ingrese 'S' y para la version mini ingrese 'M'";
        }
        else if (message.Text.Equals("U"))
        {
            controladorpartida.UnirsePartida(message);

            if (GlobalLibrary.JugadoresJugando.Count == 2)
            {
                if (GlobalLibrary.ConfiguracionTablero == "S")
                {
                    response = "Partida Encontrada! \nConfiguracion: Set standard (tablero 10x10 con 3 Naves; 2 de 3 de vida y 1 de 4 de vida) \nIngresa la posicion de tu primer nave con el formato: 'B1 XYXY' donde los primeros XY son la coordenada inicial de tu barco y los segundos XY son la coordenada final de tu barco: ";

                }
                else
                {
                    response = "Partida Encontrada! \nConfiguracion: Set mini (tablero 6x6 con 2 naves de 2 de 3 vida) \nIngresa la posicion de tu primer nave con el formato: 'B1 XYXY' donde los primeros XY son la coordenada inicial de tu barco y los segundos XY son la coordenada final de tu barco: ";
                }
            }
            else
            {
                response = "Esperando para unirte...";
            }
        }
        else
        {
            response = "El valor ingresado no es válido. Debes ingresar C o U.";
        }
    }
}