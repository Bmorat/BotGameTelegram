using System;
using System.Linq;
using Library;
using Telegram.Bot.Types;

namespace Library;

public class Nave2J2Handler : BaseHandler
{
    private void RegistrarNave(string coordenadas, int longitud)
    {

        string posXInicio = coordenadas.Substring(0, 1).ToUpper();
        int posYInicio = int.Parse(coordenadas.Substring(1, 1));

        string posXFinal = coordenadas.Substring(2, 1).ToUpper();
        int posYFinal = int.Parse(coordenadas.Substring(3, 1));

        GlobalLibrary.NavesJ2.Add(new Naves(longitud, longitud, posXInicio, posYInicio, posXFinal, posYFinal));
    }

    public Nave2J2Handler(IHandler next) : base(next)
    {
        this.Keywords = new string[] { "B2" };
    }

    protected override void InternalHandle(Message message, out string response)
    {
        
        if (message.Text.StartsWith("B2"))
        {
            string mensaje = message.Text;
            string substr1 = mensaje.Substring(3);
            RegistrarNave(substr1,3);

            if (GlobalLibrary.ConfiguracionTablero == "S")
            {
                response = "Nave 2 registrada con exito ingrese las cordenadas de la nave 3 J2 formato B2 XYXY de 4 casillas";
            }
            else
            {
                response = "Nave 2 registrada con exito escriba 'Jugar' para comenzar";
            }
        }
        else
        {
            response = "Respete el formato BN XYXY manito";
        }
    }
    
}


