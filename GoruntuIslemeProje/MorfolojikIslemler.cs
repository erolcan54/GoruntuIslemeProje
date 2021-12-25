using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace GoruntuIslemeProje
{
    public class MorfolojikIslemler
    {
        NoktasalIslemler noktasalIslemler = new NoktasalIslemler();
        int genislik, yukseklik, R = 0, G = 0, B = 0;
        Color renk;
        Bitmap gelenResim, gidenResim, genislemisResim;

        public Bitmap Erosion(Image resim)
        {
            Color donusenRenk;
            gelenResim = new Bitmap(resim);
            this.genislik = gelenResim.Width;
            this.yukseklik = gelenResim.Height;
            gidenResim = new Bitmap(genislik, yukseklik);
            Bitmap SiyahBeyazResim = noktasalIslemler.Esikleme(resim);
            gidenResim = SiyahBeyazResim;

            return gidenResim;
        }
        
    }
}