using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BOTVaticano
{
    public class ImgCarta
    {
        Carta carta;

        public ImgCarta(Carta newCarta)
        {
            this.carta = newCarta;
        }

        public Image GraphCarta()
        {
            string caminho = null;
            if (this.carta.Naipe == 'C')
            {
                caminho = "Cartas/Copas1.png";
            }
            if (this.carta.Naipe == 'O')
            {
                caminho = "Cartas/Ouros1.png";
            }
            if (this.carta.Naipe == 'S')
            {
                caminho = "Cartas/Estrela1.png";
            }
            if (this.carta.Naipe == 'E')
            {
                caminho = "Cartas/Espadas1.png";
            }
            if (this.carta.Naipe == 'L')
            {
                caminho = "Cartas/Lua1.png";
            }
            if (this.carta.Naipe == 'P')
            {
                caminho = "Cartas/Paus1.png";
            }
            if (this.carta.Naipe == 'T')
            {
                caminho = "Cartas/Triangulo1.png";
            }

            return Image.FromFile(caminho);
        }
    }
}
