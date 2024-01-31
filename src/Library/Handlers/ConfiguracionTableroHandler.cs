using System;
using Telegram.Bot.Types;
using System.Collections.Generic;

namespace Library
{
    public class ConfiguracionTableroHandler : BaseHandler
    {
        private Tablero TableroJuego = new Tablero();

        public ConfiguracionTableroHandler(IHandler next) : base(next)
        {
            this.Keywords = new string[] { "S", "M" };
        }

        protected override void InternalHandle(Message message, out string response)
        {

            if (message.Text.Equals("S"))
            {
                List<List<string>> tablerpj1 = this.TableroJuego.CrearTablero();
                List<List<string>> tableraj1 = this.TableroJuego.CrearTablero();
                List<List<string>> tablerpj2 = this.TableroJuego.CrearTablero();
                List<List<string>> tableraj2 = this.TableroJuego.CrearTablero();
         

                GlobalLibrary.tableroPropioJ1 = tablerpj1;
                GlobalLibrary.tableroPropioJ2 = tablerpj2;
                GlobalLibrary.tableroAtaquesJ1 = tableraj1;
                GlobalLibrary.tableroAtaquesJ2 = tableraj2;

                GlobalLibrary.ConfiguracionTablero = "S";

                response = "Tableros configurados correctamente en modo Standard. \nEscriba 'Espera' para esperar a otro jugador.";
            }
            else if (message.Text.Equals("M"))
            {
                List<List<string>> tablerpj1 = this.TableroJuego.CrearTablero(6,6);
                List<List<string>> tableraj1 = this.TableroJuego.CrearTablero(6,6);
                List<List<string>> tablerpj2 = this.TableroJuego.CrearTablero(6,6);
                List<List<string>> tableraj2 = this.TableroJuego.CrearTablero(6,6);
         

                GlobalLibrary.tableroPropioJ1 = tablerpj1;
                GlobalLibrary.tableroPropioJ2 = tablerpj2;
                GlobalLibrary.tableroAtaquesJ1 = tableraj1;
                GlobalLibrary.tableroAtaquesJ2 = tableraj2;
                
                response = "Tableros configurados correctamente en modo Mini \nEscriba 'Espera' para esperar a otro jugador. ";
            }
            else
            {
                response = "Entrada no valida, ingrese 'S' O 'M'";
            }
        }
    }
}