using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using Telegram.Bot.Types;

namespace Library;

public class AtacarJ1 : BaseHandler
    {
        Ataques ataques = new Ataques();
        BotPrinter bot  = new BotPrinter();

        public AtacarJ1(BaseHandler next) : base(next)
        {
            this.Keywords = new string[] { "Atacar" };
        }

        protected override void InternalHandle(Message message, out string response)
        {
            if (message.Text.StartsWith("Atacar"))
            {
                string mensaje = message.Text;
                string coordenada = mensaje.Substring(7);  // Obtener la parte de la cadena después de "Atacar "
                string x = coordenada[0].ToString();
                int y = Convert.ToInt32(coordenada.Substring(1));
                

                if (message.Chat.Id == GlobalLibrary.JugadoresJugando[0].Id)
                    {
                        ataques.RealizarAtaque(GlobalLibrary.tableroAtaquesJ1, GlobalLibrary.tableroPropioJ2, x, y);

                         /// <summary>
                         /// Agregamos en cada caso los ataques correspondientes a la nueva lista creada en GlobalLibrary
                         /// </summary>
                        GlobalLibrary.ListaAtaquesJ1.Add(coordenada);

                        string tabla3 = bot.ImprimirTablero(GlobalLibrary.tableroPropioJ2);
                        string tabla4 = bot.ImprimirTablero(GlobalLibrary.tableroAtaquesJ2);


                        if (GlobalLibrary.NavesJ2.All(nave => nave.Vida <= 0))
                        {
                            response = "El Jugador 1 ha ganado la partida";
                        }
                        else
                        {
                            // Aca agrego los ataques que realiza el jugador 2 ala lista de sus ataques.
                            message.Chat.Id = GlobalLibrary.JugadoresJugando[1].Id;
                             /// <summary>
                             /// Mismo caso pero con el otro jugador se añaden los ataques correspondientes para poderlos devolver mediante el bot
                             /// </summary>
                            GlobalLibrary.ListaAtaquesJ2.Add(coordenada);
                            response = $"El Jugador 1 ha atacado al Jugador 2 \n Turno del jugador 2 para atacar\n\nTablero de Naves J2\n\n{tabla3}Tablero de Naves J2\n\n{tabla4}";
                        }

                    }
                    else
                    {
                        ataques.RealizarAtaque(GlobalLibrary.tableroAtaquesJ2, GlobalLibrary.tableroPropioJ1, x, y);
                        
                        string tabla1 = bot.ImprimirTablero(GlobalLibrary.tableroPropioJ1);
                        string tabla2 = bot.ImprimirTablero(GlobalLibrary.tableroAtaquesJ1);
                        if(GlobalLibrary.NavesJ1.All(nave => nave.Vida <= 0))
                        {
                            response = "El Jugador 2 ha ganado la partida";
                        }
                        else
                        {
                            
                            message.Chat.Id = GlobalLibrary.JugadoresJugando[0].Id;
                            response = $"El Jugador 2 ha atacado al Jugador 1 \n Turno del jugador 1 para atacarTablero de Naves J1\n\n{tabla1}\n\nTablero de Ataques J1\n\n{tabla2}";
                        }
                    }
            }
            else
            {
                response = "error";
            }

        }
        
    }
