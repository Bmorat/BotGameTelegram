﻿using System;
using System.Linq;
using Library;
using Telegram.Bot.Types;

public class RegistroNavesHandler : BaseHandler
{
    public void RegistrarNave(string coordenadas, int longitud)
    {
        string posXInicio = coordenadas.Substring(0, 1).ToUpper();
        int posYInicio = int.Parse(coordenadas.Substring(1, 1));

        string posXFinal = coordenadas.Substring(2, 1).ToUpper();
        int posYFinal = int.Parse(coordenadas.Substring(3, 1));

        GlobalLibrary.NavesJ1.Add(new Naves(longitud, longitud, posXInicio, posYInicio, posXFinal, posYFinal));
    }

    public RegistroNavesHandler(IHandler next) : base(next)
    {
        this.Keywords = new string[] { "N1" };
    }

    protected override void InternalHandle(Message message, out string response)
    {
        if (message.Text.StartsWith("N1"))
        {
            string mensaje = message.Text;
            string substr1 = mensaje.Substring(3);
            RegistrarNave(substr1, 3);

            response = "Nave 1 registrada con exito ingrese las cordenadas de la nave 2 formato N2 XYXY";
        }
        else
        {
            response = "";
        }
    }
}