using System;
using System.Collections.Generic;

namespace Library
{
    public class RegistroUsuarios
    {
        // cada instancia de la clase RegistroUsuarios es un registro de un nuevo usuario.
        public RegistroUsuarios (Jugador usuario)
        {
            if (!GlobalLibrary.Usuarios.Contains(usuario.Id))
            {
                GlobalLibrary.Usuarios.Add(usuario.Id);
                Console.WriteLine("Usuario registrado con exito.");
            }
            else
            {
                Console.WriteLine("El usuario ya ha sido registrado previamente.");
            }
        }
    }
}