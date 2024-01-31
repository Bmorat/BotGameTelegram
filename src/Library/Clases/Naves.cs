using System.ComponentModel.DataAnnotations;
using Library;

namespace Library
{
    public class Naves
    {
        public int Vida { get; set; }

        public int TamañoNave { get; set; }

        public string PosicionX1 { get; set; }

        public int PosicionY1 { get; set; }

        public string PosicionX2 { get; set; }

        public int PosicionY2 { get; set; }

        public Naves(int Vida, int Tamaño, string Posx1, int PosY1, string Posx2, int Posy2)
        {
            this.Vida = Vida;
            this.TamañoNave = Tamaño;
            this.PosicionX1 = Posx1;
            this.PosicionY1 = PosY1;
            this.PosicionX2 = Posx2;
            this.PosicionY2 = Posy2;
        }
    }
}