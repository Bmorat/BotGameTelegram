using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Telegram.Bot;
using Telegram.Bot.Polling;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;


namespace Library
{
    /// <summary>
    /// Clase que imprime en la consola un tablero y naves.
    /// </summary>
    public class ConsolePrinter : IPrinter
    {
        /// <summary>
        /// Imprime el tablero en la consola.
        /// </summary>
        public void ImprimirTablero(List<List<string>> tablero)
        {
        // Definimos un método para imprimir el tablero en la consola.
        // El tablero se imprimirá con un formato de matriz.
            for (int i = 0; i < tablero.Count; i++)
            {
                for (int j = 0; j < tablero[i].Count; j++)
                {
                    Console.Write(tablero[i][j] + " ");
                }

                Console.WriteLine();
            }
        }

        /// <summary>
        /// Imprime mensajes en la consola.
        /// </summary>
        public void ImprimirMensaje(string mensaje)
        {
            Console.WriteLine(mensaje);
        }
    }
}