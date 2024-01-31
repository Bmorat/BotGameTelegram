using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Library;

// creamos una libreria global para poder acceder a la informacion de la partida desde cualquier clase en cualquier punto de la ejecucion.
// agregado por Expert. Cumple con SRP ya que se dedica a almacenar y organizar los datos de la partida en funcionamiento.
public static class GlobalLibrary
{
        public static List<Jugador> JugadoresEnEspera = new List<Jugador>(); 

        public static List<Jugador> JugadoresJugando = new List<Jugador>();  

        public static string ConfiguracionTablero; 

        public static List<Naves> NavesJ1 = new List<Naves>();
        public static List<Naves> NavesJ2 = new List<Naves>();

        public static List<long> Usuarios = new List<long>();

        public static List<List<string>> tableroAtaquesJ1;
        public static List<List<string>> tableroPropioJ1;
        public static List<List<string>> tableroAtaquesJ2;
        public static List<List<string>> tableroPropioJ2;

        public static List<string> ListaAtaques = new List<string>();

       ///<summary> Agrego 2 listas nuevas a nuestro programa para poder agregar los ataques de cada jugador por separado
       /// la idea de la nueva User History es que cuando el usuario nos pida las estadisticas podamos mostrarle 
       ///</summary> el total de ataque realizados por el J1 y por el J2
        /// <summary>
        /// Representa la Lista de Ataques del Jugador 1
        /// </summary>
        public static List<string> ListaAtaquesJ1 = new List<string>();

        /// <summary>
        /// Representa la Lista de Ataques del Jugador 2
        /// </summary>

        public static List<string> ListaAtaquesJ2 = new List<string>();


        /// Agregamos un metodo para poder Imprimir las estadisticas que nos pida el usuario dado que es una lista de strings, poder pasarla
        /// a una cadena string pero la vamos a agregar en BotPrinter por SRP
      

}



/* DEFENSA: Como jugador necesito poder ver un registro detallado de los 
movimientos previos en cualqueir momento de la partida incluyedo ataques de ambos jugadores*/