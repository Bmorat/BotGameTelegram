using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Microsoft.VisualBasic;
using System.Diagnostics;
using Telegram.Bot.Types;

namespace Library;

public class ControladorPartida // Por SRP esta clase solo se encarga de dar inicio a la partida por 2 diferentes metodos (que hacen lo mismo pero se implementan diferente).
{
    public void NuevaPartida(Message message)
    {
        Jugador jugador = new Jugador (message.From.FirstName, message.Chat.Id);
        if (!GlobalLibrary.JugadoresEnEspera.Contains(jugador));
        {
            GlobalLibrary.JugadoresEnEspera.Add(jugador);
        }

        if (GlobalLibrary.JugadoresEnEspera.Count < 2)
        {
            GlobalLibrary.JugadoresJugando.Add(jugador);
        }
    }

    public void UnirsePartida(Message message)
    {
        Jugador jugador = new Jugador (message.From.FirstName, message.Chat.Id);
        if (!GlobalLibrary.JugadoresEnEspera.Contains(jugador));
        {
            GlobalLibrary.JugadoresEnEspera.Add(jugador);
        }

        if (GlobalLibrary.JugadoresEnEspera.Count < 3)
        {
            GlobalLibrary.JugadoresJugando.Add(jugador);
        }
    }
}