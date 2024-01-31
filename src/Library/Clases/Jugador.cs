using System;
using System.Collections.Generic;

namespace Library
{
    public class Jugador
    {
    // creo dos propiedades Nombre(string) y Id(int)
    // solo le adjudico el set a la propiedad Nombre porque la Id no se puede cambiar
    // con los principios de SRP, la clase jugador solo se encarga de crear un jugador con un nombre y una Id
        public string Nombre { get; set; }

        public long Id { get; set; }

        public Jugador(string nombre, long id)
        {
            this.Nombre = nombre;
            this.Id = id;
        }
    }
}