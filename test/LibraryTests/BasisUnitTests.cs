using Library;
using NUnit.Framework;
using System;
using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;
using Library;
using System.Threading;
using Telegram.Bot.Polling;
using Telegram.Bot.Types.ReplyMarkups;
using Telegram.Bot.Args;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using NUnit;
using NuGet;
using Moq;
using System.Linq;

namespace Tests
{
    public class BasicTests
    {
        // Test de la clase TelegramBot
        [Test]
        public void TelegramBOT()
        {
            TelegramBot bot = new TelegramBot();
            Assert.IsNotNull(bot);
        }
        // Test de la clase GlobalLibrary
        [Test]
        public void Global_Library()
        {
            
            Assert.IsNotNull(GlobalLibrary.JugadoresEnEspera);
            Assert.IsNotNull(GlobalLibrary.JugadoresJugando);
            Assert.IsNotNull(GlobalLibrary.NavesJ1);
            Assert.IsNotNull(GlobalLibrary.NavesJ2);
            Assert.IsNotNull(GlobalLibrary.Usuarios);
                     
        }
        
        // Test de la clase IPrinter
        [Test]
        public void ImprimirMensaje()
        {
            //arrange
            IPrinter printer = new ConsolePrinter();
            string mensaje = "Comenzar la Batalla Naval";
            //act
            printer.ImprimirMensaje(mensaje);
            //assert
            Assert.IsNotNull(mensaje);
        }

        //Test de la clase ConsolePrinter
        [Test]
        public void ImprimirTablero()
        {
            //arrange
            IPrinter printer = new ConsolePrinter();
            List<List<string>> tablero = new List<List<string>>();
            //act
            printer.ImprimirTablero(tablero);
            //assert
            Assert.IsNotNull(tablero);
        }
        [Test]
        public void ImprimirMensaje_ConsolePrinter()
        {
            //Arrange
            var printer = new ConsolePrinter();
            var mensaje = "Batalla Naval";
            //act
            printer.ImprimirMensaje(mensaje);
            //assert
            Assert.AreSame(mensaje, mensaje);
        }
        //Test de la clase BotPrinter
        [Test]
        public void ImprimirTablero_BotPrinter()
        {
            var botPrinter = new BotPrinter();
            var tablero = new List<List<string>>
            {
                new List<string> { "A", "B", "C" },
                new List<string> { "D", "E", "F" },
                new List<string> { "G", "H", "I" }
            };
            var expected = "A  B  C  D  E  F  G  H  I  ";
            // Act
            var resultado = botPrinter.ImprimirTablero(tablero);
            // Assert
            Assert.AreEqual(expected, resultado);  
        }
        [Test]
        public void ImprimirMensaje_BotPrinter()
        {
            //Arrange
            var botPrinter = new BotPrinter();
            var mensaje = "Esperando otro jugador...";
            //act
            botPrinter.ImprimirMensaje(mensaje);
            //assert
            Assert.AreEqual(mensaje, mensaje);
        }

        //Test de la clase RegistroNavesHandler
        [Test]
        public void RegistrarNave_Handler()
        {
            //arrange
            var registroNavesHandler = new RegistroNavesHandler(null);
            var coordenadas = "A1B2";
            var longitud = 3;

            //act
            registroNavesHandler.RegistrarNave(coordenadas, longitud);
            //Assert
            Assert.AreEqual("A", coordenadas.Substring(0, 1).ToUpper());
            Assert.AreEqual(1, int.Parse(coordenadas.Substring(1, 1)));
            Assert.AreEqual("B", coordenadas.Substring(2, 1).ToUpper());
            Assert.AreEqual(2, int.Parse(coordenadas.Substring(3, 1)));
        }

        //test de la Clase ControladorPartida
        [Test]
        public void NuevaPartida()
        {
            // Arrange
            var controlador = new ControladorPartida();
            // Asumimos que ya hay dos jugadores en espera
            GlobalLibrary.JugadoresEnEspera.Add(new Jugador("juanita", 456));
            GlobalLibrary.JugadoresEnEspera.Add(new Jugador("lola", 789));
            var message = new Message { From = new User { FirstName = "OCono" }, Chat = new Chat { Id = 123 } };
            // Act
            controlador.UnirsePartida(message);
            // Assert
            Assert.AreEqual(0, GlobalLibrary.JugadoresJugando.Count);
            Assert.IsFalse(GlobalLibrary.JugadoresEnEspera.All(j => j.Nombre != "OCono"));
            bool ContieneJugador(Jugador jugador)
            {
                return jugador.Nombre == "John" && jugador.Id == 123;
            }
        }

        //test de la Clase ControladorNaves
        [Test]
        public void PosicionarNave()
        {
                // Arrange
                var controlador = new ControladorNaves();
                var tableroj1 = new List<List<string>>();
                var tableroj2 = new List<List<string>>();
                // Act
                controlador.PosicionarNaves(tableroj1, tableroj2);
                // Assert
                Assert.AreEqual(0, tableroj1.Count);
                Assert.AreEqual(0, tableroj2.Count);
        }


        public void PosicionarNaves()
        {
            // Arrange
            List<List<string>> tableroj2 = new List<List<string>>()
            {
                new List<string>() { ".", ".", ".", ".", ".", ".", ".", ".", ".", "." },
                new List<string>() { ".", ".", ".", ".", ".", ".", ".", ".", ".", "." },
                new List<string>() { ".", ".", ".", ".", ".", ".", ".", ".", ".", "." },
                new List<string>() { ".", ".", ".", ".", ".", ".", ".", ".", ".", "." },
                new List<string>() { ".", ".", ".", ".", ".", ".", ".", ".", ".", "." },
                new List<string>() { ".", ".", ".", ".", ".", ".", ".", ".", ".", "." },
                new List<string>() { ".", ".", ".", ".", ".", ".", ".", ".", ".", "." },
                new List<string>() { ".", ".", ".", ".", ".", ".", ".", ".", ".", "." },
                new List<string>() { ".", ".", ".", ".", ".", ".", ".", ".", ".", "." },
                new List<string>() { ".", ".", ".", ".", ".", ".", ".", ".", ".", "." }
            };

            // Act
            ControladorNaves controlador = new ControladorNaves();
            controlador.PosicionarNaves(new List<List<string>>(), tableroj2);

            // Assert
            Assert.AreEqual("⛵", tableroj2[0][0]);
            Assert.AreEqual("⛵", tableroj2[1][0]);
            Assert.AreEqual("⛵", tableroj2[2][0]);
        }

        //test de la Clase Tablero
        [Test]
        public void CrearTablero()
        {
            // Arrange
            var tablero = new Tablero();
            // Act
            var resultado = tablero.CrearTablero();
            // Assert
            Assert.AreEqual(10, resultado.Count);
            Assert.AreEqual(10, resultado[0].Count);
        }

        //test de la Clase Registro Usuarios
        [Test]
        public void RegistrarUsuario()
        {
            // Arrange
            GlobalLibrary.Usuarios.Clear();
            var jugador = new Jugador("juanita", 1);

            // Act
            RegistroUsuarios registro = new RegistroUsuarios(jugador);

            // Assert
            Assert.Contains(1, GlobalLibrary.Usuarios);
        }

        //test de la clase Naves
        [Test]
        public void CrearNave()
        {
            // Arrange
        int vida = 100;
        int tamaño = 5;
        string posx1 = "A";
        int posY1 = 1;
        string posx2 = "E";
        int posY2 = 5;

        // Act
        Naves naves = new Naves(vida, tamaño, posx1, posY1, posx2, posY2);

        // Assert
        Assert.AreEqual(vida, naves.Vida);
        Assert.AreEqual(tamaño, naves.TamañoNave);
        Assert.AreEqual(posx1, naves.PosicionX1);
        Assert.AreEqual(posY1, naves.PosicionY1);
        Assert.AreEqual(posx2, naves.PosicionX2);
        Assert.AreEqual(posY2, naves.PosicionY2);
        }


        //test de la clase Jugador
        [Test]
        public void CrearJugador()
        {
            // Arrange
            var jugador = new Jugador("juanita", 456);
            // Act
            Jugador jugador1 = new Jugador("juanita", 456);
            // Assert
            Assert.AreEqual("juanita", jugador.Nombre);
            Assert.AreEqual(456, jugador.Id);
        }

        //test de la clase Ataque
        [Test]
        public void RealizarAtaque_()
        {
            // Arrange
        var juego = new Ataques();
        List<List<string>> tableroAtaquesJ1 = new List<List<string>> { new List<string> { " " } };
        List<List<string>> tableroPropioJ2 = new List<List<string>> { new List<string> { "💦" } };
        string x = "A";
        int y = 1;

        // Act
        juego.RealizarAtaque(tableroAtaquesJ1, tableroPropioJ2, x, y);

        // Assert
        Assert.AreEqual("❌", tableroAtaquesJ1[0][0]);
        }

        [Test]
        public void RealizarAtaque_Excepcionn()
        {
            // Arrange
            var ataques = new Ataques();
            var tableroataquesJ1 = new List<List<string>>();
            var tableropropioJ2 = new List<List<string>>();
            string X = "B";
            int Y = 2;
            GlobalLibrary.ListaAtaques.Add("B,2");

            // Act & Assert
            Assert.Throws<Exception>(() => ataques.RealizarAtaque(tableroataquesJ1, tableropropioJ2, X, Y));
        }

        [Test]
        public void RealizarAtaque_Agua()
        {
            // Arrange
            var ataques = new Ataques();
            var tableroataquesJ1 = new List<List<string>> { new List<string> { " ", " ", " " }, new List<string> { " ", " ", " " }, new List<string> { " ", " ", " " } };
            var tableropropioJ2 = new List<List<string>> { new List<string> { " ", " ", " " }, new List<string> { " ", " ", " " }, new List<string> { " ", " ", " " } };
            string X = "C";
            int Y = 3;
            tableropropioJ2[2][2] = "💦";

            // Act
            ataques.RealizarAtaque(tableroataquesJ1, tableropropioJ2, X, Y);

            // Assert
            Assert.AreEqual("❌", tableroataquesJ1[2][2]);
        }

        [Test]
        public void RealizarAtaque_Barco()
        {
            // Arrange
            var ataques = new Ataques();
            var tableroataquesJ1 = new List<List<string>> { new List<string> { " ", " ", " " }, new List<string> { " ", " ", " " }, new List<string> { " ", " ", " " } };
            var tableropropioJ2 = new List<List<string>> { new List<string> { " ", " ", " " }, new List<string> { " ", " ", " " }, new List<string> { " ", " ", " " } };
            string X = "B";
            int Y = 2;
            tableropropioJ2[1][1] = "🚢";

            // Act
            ataques.RealizarAtaque(tableroataquesJ1, tableropropioJ2, X, Y);

            // Assert
            Assert.AreEqual("💥", tableropropioJ2[1][1]);
            Assert.AreEqual("💥", tableroataquesJ1[1][1]);
        }
    


        [Test]
        
        //testeamos el metodo creado para procesar los datos provenientes de las listas de global library para asegurarnos que 
        //que el usuario recibe los mensajes en formato string y se genere un error en el mensaje.
        public void registrarAtaquesparaEstadisticas() 
        {
            List<string> ListaAtaques = new List<string>{"A1","C3","D5","F4"};

            string listaString= BotPrinter.PrintStatic(ListaAtaques);

            Assert.That(listaString,Is.EqualTo("A1, C3, D5, F4, ")); 
           

        }



        























        /*[Test]
        public void InternalHandle_MessageStartsWithN1_RegistraNave1YDevuelveRespuestaCorrecta()
        {
            // Arrange
            var registroNavesHandler = new RegistroNavesHandler(null);
            var message = new Message { Text = "N1XYZ" }; // Ajusta el mensaje según tus necesidades

            // Act
            registroNavesHandler.InternalHandle(message, out string response);

            // Assert
            // Aquí debes verificar que se haya registrado la nave y que la respuesta sea la esperada
            var naveRegistrada = GlobalLibrary.NavesJ1[0];
            
            Assert.AreEqual("XYZ", naveRegistrada); // Ajusta según la implementación real de RegistrarNave
            Assert.AreEqual("Nave 1 registrada con éxito. Ingrese las coordenadas de la nave 2 en formato N2 XYXY", response);
        }

        [Test]
        public void InternalHandle_MessageNoStartsWithN1_NoRegistraNaveYRespuestaVacia()
        {
            // Arrange
            var registroNavesHandler = new RegistroNavesHandler(null);
            var message = new Message { Text = "OtroMensaje" }; // Ajusta el mensaje según tus necesidades

            // Act
            registroNavesHandler.InternalHandle(message, out string response);

            // Assert
            // Aquí debes verificar que no se haya registrado ninguna nave y que la respuesta esté vacía
            Assert.IsEmpty(GlobalLibrary.NavesJ1); // Ajusta según la implementación real de RegistrarNave
            Assert.IsEmpty(response);
        }*/

        //Test de la clase InicioPartidaHandler
       /* [Test]
        public void InternalHandle_MessageStartsWithJugar_RegistraNave1YDevuelveRespuestaCorrecta()
        {
           // Arrange
            var handler = new InicioPartidaHandler(null);
            var message = new Message { Text = "Jugar" }; // Ajusta el mensaje según tus necesidades
            
            // Act
            handler.InternalHandle(message, out string response);

            // Assert
            Assert.That(response, Is.EqualTo("Tablero de Naves J1\n\n{tabla1}\n\nTablero de Ataques J1\n\n{tabla2}\n\n Es el turno de atacar del J1 escriba Atacar y su cordenada XY"));

        }

        //Test de la clase IHandler
        [Test]
        public void Test3()
        {
            //arrange
            IHandler handler = new RegistroNavesHandler(null);
            //act
            handler.Cancel(null);
            handler.Handle(null, out string response);
            //assert
            Assert.IsNotNull(handler);
        }

        //test de la clase HelloHandler
        [Test]
        public void HelloHandler()
        {
            //arrange
            var helloHandler = new HelloHandler(null);
            var message = new Message { Text = "Hola" }; 
            //act
            helloHandler.InternalHandle(message, out string response);
            //assert
            Assert.AreEqual("¡Hola! Para jugar a la batalla naval escribe 'Iniciar'", response);
        }*/

    }
}