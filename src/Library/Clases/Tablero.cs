using System;
using System.Collections.Generic;
using Telegram.Bot.Types.Enums;

namespace Library
{
    public class Tablero
    {
        public int AnchoTablero { get; set; } = 10;

        public int LargoTablero { get; set; } = 10;

        public List<List<string>> CrearTablero() // crea el tablero predeterminado
        {
            // Definimos un método para crear el tablero basándonos en el largo y ancho del mismo.
            // El tablero estará representado por una lista de listas de celdas que contienen una "O" en cada espacio.
            List<List<string>> tablero = new List<List<string>>();
            for (int i = 0; i < this.AnchoTablero; i++)
            {
                List<string> fila = new List<string>();
                for (int j = 0; j < this.LargoTablero; j++)
                {
                    fila.Add("💦");
                }

                tablero.Add(fila);
            }

            return tablero;
        }

        public List<List<string>> CrearTablero(int Ancho, int Largo) // aplica el polimorfismo para crear un tablero de tamaño personalizado
        {
            // Definimos un método para crear el tablero basándonos en el largo y ancho del mismo.
            // El tablero estará representado por una lista de listas de celdas que contienen un "O" en cada espacio.
            List<List<string>> tablero = new List<List<string>>();
            for (int i = 0; i < Ancho; i++)
            {
                List<string> fila = new List<string>();
                for (int j = 0; j <Largo; j++)
                {
                    fila.Add("O");
                }

                tablero.Add(fila);
            }

            return tablero;
        }
    }
}
