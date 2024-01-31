using System;
using System.Linq;
using Library;
using Telegram.Bot.Types;

namespace Library;

public class Nave3J1Handler : BaseHandler
{
    private void RegistrarNave(string coordenadas, int longitud)
    {
    
        string posXInicio = coordenadas.Substring(0, 1).ToUpper();
        int posYInicio = int.Parse(coordenadas.Substring(1, 1));

        string posXFinal = coordenadas.Substring(2, 1).ToUpper();
        int posYFinal = int.Parse(coordenadas.Substring(3, 1));

        GlobalLibrary.NavesJ1.Add(new Naves(longitud, longitud, posXInicio, posYInicio, posXFinal, posYFinal));
    }



    public Nave3J1Handler(IHandler next) : base(next)
    {
        this.Keywords = new string[] { "N3" };
    }

    protected override void InternalHandle(Message message, out string response)
    {
        
        if (message.Text.StartsWith("N3"))
        {
            string mensaje = message.Text;
            string substr1 = mensaje.Substring(3);
            RegistrarNave(substr1, 4);

            if (GlobalLibrary.NavesJ2.Count > 0)
            {
                response = "Nave 3 registrada con exito escriba 'Jugar' para comenzar";
            }
            else
            {
                if (GlobalLibrary.ConfiguracionTablero == "S")
                {
                    TelegramBot.SendTextMessageAsync("Partida Encontrada! \nConfiguracion: Set standard (tablero 10x10 con 3 Naves; 2 de 3 de vida y 1 de 4 de vida) \nIngresa la posicion de tu primer nave con el formato: 'N3 XYXY' donde los primeros XY son la coordenada inicial de tu barco y los segundos XY son la coordenada final de tu barco:", GlobalLibrary.JugadoresJugando[1].Id);
                    response = string.Empty;
                }
                else
                {
                    TelegramBot.SendTextMessageAsync("Partida Encontrada! \nConfiguracion: Configuracion: Set mini (tablero 6x6 con 2 naves de 2 de 3 vida) \nIngresa la posicion de tu primer nave con el formato: 'B1 XYXY' donde los primeros XY son la coordenada inicial de tu barco y los segundos XY son la coordenada final de tu barco:", GlobalLibrary.JugadoresJugando[1].Id);
                    response = string.Empty;
                }
            }

        }
        else
        {
            response="";
        }
    }
    
}


