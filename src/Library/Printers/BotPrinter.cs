using System;
using System.Collections.Generic;
using System.Text;

namespace Library;

public class BotPrinter 
{

    public string ImprimirTablero (List<List<string>> tablero)
    {
        var tableros = new StringBuilder();
        // Definimos un método para imprimir el tablero .
        // El tablero se imprimirá con un formato de matriz.
        for (int i = 0; i < tablero.Count; i++)
        {
            for (int j = 0; j < tablero[i].Count; j++)
            {
                tableros.Append(tablero[i][j] + "  ");
                if ((j + 1) % 10 == 0)
                {
                    // Agregar un salto de línea después de cada conjunto de 10 elementos
                    tableros.Append("\n");
                }
            }


        }
        string tabla = tableros.ToString();
        return tabla;

    }

    public void ImprimirMensaje(string mensaje)
    {
    // Envía el mensaje al bot de Telegram
        TelegramBot.SendTextMessageAsync(mensaje);
    }

    /// <summary>
    /// por SRP agregamos el nuevo metodo de impresiones que vayan a ser para el bot en la clase bot printer
    /// </summary>
    /// <summary>
    /// en este caso para procesar datos desde la lista de ataques de cada jugador
    /// </summary>
      public static string PrintStatic (List<string> statics)
        {
        var estadistica = new StringBuilder();

        for (int i = 0; i < statics.Count; i++)
        {

                estadistica.Append(statics[i] + ", ");
                if ((i + 1) % 10 == 0)
                {
                    // Agregar un salto de línea después de cada conjunto de 10 elementos
                    estadistica.Append("\n");
                }

        }
        string stats = estadistica.ToString();
        return stats;

    }
}
