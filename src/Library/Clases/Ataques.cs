using System;
using System.Collections.Generic;

namespace Library
{
    public class Ataques
    {


        public void RealizarAtaque(List<List<string>> tableroataquesJ1, List<List<string>> tableropropioJ2, string X, int Y)
        {
            string coordenadas = $"{X},{Y}";
            // comprobamos que el ataque no sea uno hecho previamente ya
            if (!GlobalLibrary.ListaAtaques.Contains(coordenadas))
            {
                GlobalLibrary.ListaAtaques.Add($"{X},{Y}");

                int columna = char.ToUpper(X[0]) - 'A';

                if (tableropropioJ2[Y-1][columna] == "💦")
                {
                    tableroataquesJ1[Y-1][columna] = "❌"; // marco como agua en el tablero de ataques del atacante.

                }
                else
                {
                    // marcamos el ataque de tocado en ambos tableros de los jugadores.
                    tableropropioJ2[Y-1][columna] = "💥";
                    tableroataquesJ1[Y-1][columna] = "💥";
                }
            
            }
            
            else
            {
                throw new Exception("Ese ataque ya fue realizado previamente");
            }
        }
    }
}