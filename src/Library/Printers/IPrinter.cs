using System;
using System.Collections.Generic;

namespace Library
{
    // creamos una interfaz del printer para imprimir tanto en consola como en el bot de telegram.
    // gracias a esta implementacion de una interfaz podemos incluir el polimorfismo en nuestro codigo.
    public interface IPrinter
    {
    public void ImprimirTablero(List<List<string>> tablero);

    public void ImprimirMensaje(string mensaje);
    }
}