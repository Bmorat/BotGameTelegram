using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Library
{
    public class ControladorNaves
    {
        public void PosicionarNaves (List<List<string>> tableroj1, List<List<string>> tableroj2)
        {
            for (int i = 0; i < GlobalLibrary.NavesJ1.Count; i++)
            {
                int x1 = GlobalLibrary.NavesJ1[i].PosicionX1[0] - 'A';
                int y1 = GlobalLibrary.NavesJ1[i].PosicionY1 - 1;
                int x2 = GlobalLibrary.NavesJ1[i].PosicionX2[0] - 'A';
                int y2 = GlobalLibrary.NavesJ1[i].PosicionY2 - 1;

                // Coloca el número de la nave en las coordenadas iniciales y finales
                tableroj1[y1][x1] = "⛵";
                tableroj1[y2][x2] = "⛵";

                // Marca las celdas intermedias con el número de la nave
                if (y1 == y2)
                {
                    for (int x = x1 + 1; x < x2; x++)
                    {
                    tableroj1[y1][x] = "⛵";
                    }
                }
                else if (x1 == x2)
                {
                    for (int y = y1 + 1; y < y2; y++)
                    {
                    tableroj1[y][x1] = "⛵";
                    }
                }
            }

            for (int i = 0; i < GlobalLibrary.NavesJ2.Count; i++)
            {
                int x1 = GlobalLibrary.NavesJ2[i].PosicionX1[0] - 'A';
                int y1 = GlobalLibrary.NavesJ2[i].PosicionY1 - 1;
                int x2 = GlobalLibrary.NavesJ2[i].PosicionX2[0] - 'A';
                int y2 = GlobalLibrary.NavesJ2[i].PosicionY2 - 1;

                // Coloca el número de la nave en las coordenadas iniciales y finales
                tableroj2[y1][x1] = "⛵";
                tableroj2[y2][x2] = "⛵";

                // Marca las celdas intermedias con el número de la nave
                if (y1 == y2)
                {
                    for (int x = x1 + 1; x < x2; x++)
                    {
                    tableroj2[y1][x] = "⛵";
                    }
                }
                else if (x1 == x2)
                {
                    for (int y = y1 + 1; y < y2; y++)
                    {
                    tableroj2[y][x1] = "⛵";
                    }
                }
            }
        }

        public void ConfigPredeterminada()
        {
            PosicionarNaves(GlobalLibrary.tableroPropioJ1, GlobalLibrary.tableroPropioJ2);
        }
    }
}
