using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using Telegram.Bot.Types;

namespace Library;

public class InicioPartidaHandler : BaseHandler
{
        BotPrinter bot = new BotPrinter();
        ControladorNaves control = new ControladorNaves();

        public InicioPartidaHandler(BaseHandler next) : base(next)
        {
            this.Keywords = new string[] { "Jugar"};
        }

        protected override void InternalHandle(Message message, out string response)
        {
            if (message.Text.Equals("Jugar"))
            {
                control.ConfigPredeterminada();
                string tabla1 = bot.ImprimirTablero(GlobalLibrary.tableroPropioJ1);
                string tabla2 = bot.ImprimirTablero(GlobalLibrary.tableroAtaquesJ1);
                string tabla3 = bot.ImprimirTablero(GlobalLibrary.tableroPropioJ2);
                string tabla4 = bot.ImprimirTablero(GlobalLibrary.tableroAtaquesJ2);

                TelegramBot.SendTextMessageAsync($"Tablero de Naves J2\n\n{tabla3}Tablero de Naves J2\n\n{tabla4}\n",GlobalLibrary.JugadoresJugando[1].Id);
                response = $"Tablero de Naves J1\n\n{tabla1}\n\nTablero de Ataques J1\n\n{tabla2}\n\n Es el turno de atacar del J1 escriba Atacar y su cordenada XY";
            }
            else
            {
                response = "error, debe ingresar 'Jugar' para jogar manito";
            }
        }
    }
