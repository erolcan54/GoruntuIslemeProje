using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoruntuIslemeProje
{
    public class NoktasalIslemler
    {
        int genislik, yukseklik,R=0,G=0,B=0;
        Color renk;
        Bitmap gelenResim;
        Bitmap gidenResim;

        public Bitmap Tersleme(Image resim)
        {
            gelenResim = new Bitmap(resim);
            this.genislik = gelenResim.Width;
            this.yukseklik = gelenResim.Height;
            gidenResim = new Bitmap(genislik, yukseklik);
            for (int i = 0; i < genislik; i++)
            {
                for (int j = 0; j < yukseklik; j++)
                {
                    renk = gelenResim.GetPixel(i, j);
                    R = 255 - renk.R;
                    G = 255 - renk.G;
                    B = 255 - renk.B;
                    gidenResim.SetPixel(i, j, Color.FromArgb(R, G, B));
                }
            }
            return gidenResim;
        }

        public Bitmap Esikleme(Image resim)
        {
            Color donusenRenk;
            gelenResim = new Bitmap(resim);
            this.genislik = gelenResim.Width;
            this.yukseklik = gelenResim.Height;
            gidenResim = new Bitmap(genislik, yukseklik);
            int i = 0, j = 0;
            for (int x = 0; x < genislik; x++)
            {
                j = 0;
                for (int y = 0; y < yukseklik; y++)
                {
                    renk = gelenResim.GetPixel(x, y);
                    if (renk.R >= 128)
                        this.R = 255;
                    else
                        this.R = 0;
                    if (renk.G >= 128)
                        this.G = 255;
                    else
                        this.G = 0;
                    if (renk.B >= 128)
                        this.B = 255;
                    else
                        this.B = 0;
                    donusenRenk = Color.FromArgb(R, G, B);
                    gidenResim.SetPixel(i, j, donusenRenk);
                    j++;
                }
                i++;
            }
            return gidenResim;
        }

        public Bitmap LogaritmikDonusum(Image resim)
        {
            gelenResim = new Bitmap(resim);
            this.genislik = gelenResim.Width;
            this.yukseklik = gelenResim.Height;
            gidenResim = new Bitmap(genislik, yukseklik);

            int c = 10;


            for (int i = 0; i < genislik; i++)
            {
                for (int j = 0; j < yukseklik; j++)
                {
                    R = Convert.ToInt32(c * Math.Log(1 + gelenResim.GetPixel(i, j).R));
                    G = Convert.ToInt32(c * Math.Log(1 + gelenResim.GetPixel(i, j).G));
                    B = Convert.ToInt32(c * Math.Log(1 + gelenResim.GetPixel(i, j).B));
                    if (R > 255) R = 255;
                    if (G > 255) G = 255;
                    if (B > 255) B = 255;
                    if (R < 0) R = 0;
                    if (G < 0) G = 0;
                    if (B < 0) B = 0;

                    gidenResim.SetPixel(i, j, Color.FromArgb(R, G, B));
                }
            }
            return gidenResim;
        }

        public Bitmap Gama(Image resim)
        {
            gelenResim = new Bitmap(resim);
            this.genislik = gelenResim.Width;
            this.yukseklik = gelenResim.Height;
            gidenResim = new Bitmap(genislik, yukseklik);
            int c = 1;
            double y = 1.5;
            for (int i = 0; i < genislik; i++)
            {
                for (int j = 0; j < yukseklik; j++)
                {
                    R = Convert.ToInt32(c * Math.Pow(gelenResim.GetPixel(i, j).R, y));
                    G = Convert.ToInt32(c * Math.Pow(gelenResim.GetPixel(i, j).G, y));
                    B = Convert.ToInt32(c * Math.Pow(gelenResim.GetPixel(i, j).B, y));
                    if (R > 255) R = 255;
                    if (G > 255) G = 255;
                    if (B > 255) B = 255;
                    if (R < 0) R = 0;
                    if (G < 0) G = 0;
                    if (B < 0) B = 0;

                    gidenResim.SetPixel(i, j, Color.FromArgb(R, G, B));
                }
            }
            return gidenResim;
        }

        public Bitmap Parlaklik(Image resim)
        {
            gelenResim = new Bitmap(resim);
            this.genislik = gelenResim.Width;
            this.yukseklik = gelenResim.Height;
            gidenResim = new Bitmap(genislik, yukseklik);
            int b = 50;
            for (int i = 0; i < genislik; i++)
            {
                for (int j = 0; j < yukseklik; j++)
                {
                    renk = gelenResim.GetPixel(i, j);
                    R = renk.R+b;
                    G = renk.G+b;
                    B = renk.B+b;
                    if (R > 255) R = 255;
                    if (G > 255) G = 255;
                    if (B > 255) B = 255;
                    if (R < 0) R = 0;
                    if (G < 0) G = 0;
                    if (B < 0) B = 0;

                    gidenResim.SetPixel(i, j, Color.FromArgb(R, G, B));
                }
            }
            return gidenResim;
        }
        
        public Bitmap Karsitlik(Image resim)
        {
            gelenResim = new Bitmap(resim);
            this.genislik = gelenResim.Width;
            this.yukseklik = gelenResim.Height;
            gidenResim = new Bitmap(genislik, yukseklik);
            double a = 0.5;
            for (int i = 0; i < genislik; i++)
            {
                for (int j = 0; j < yukseklik; j++)
                {
                    renk = gelenResim.GetPixel(i, j);
                    double R = renk.R *a;
                    double G = renk.G *a;
                    double B = renk.B *a;
                    if (R > 255) R = 255;
                    if (G > 255) G = 255;
                    if (B > 255) B = 255;
                    if (R < 0) R = 0;
                    if (G < 0) G = 0;
                    if (B < 0) B = 0;

                    gidenResim.SetPixel(i, j, Color.FromArgb((int)R, (int)G, (int)B));
                }
            }
            return gidenResim;
        }

        public Bitmap ParlaklikKarsitlik(Image resim)
        {
            gelenResim = new Bitmap(resim);
            this.genislik = gelenResim.Width;
            this.yukseklik = gelenResim.Height;
            gidenResim = new Bitmap(genislik, yukseklik);
            double a = 0.5;
            int b = 50;
            for (int i = 0; i < genislik; i++)
            {
                for (int j = 0; j < yukseklik; j++)
                {
                    renk = gelenResim.GetPixel(i, j);
                    double R = renk.R * a +b;
                    double G = renk.G * a+b;
                    double B = renk.B * a+b;
                    if (R > 255) R = 255;
                    if (G > 255) G = 255;
                    if (B > 255) B = 255;
                    if (R < 0) R = 0;
                    if (G < 0) G = 0;
                    if (B < 0) B = 0;

                    gidenResim.SetPixel(i, j, Color.FromArgb((int)R, (int)G, (int)B));
                }
            }
            return gidenResim;
        }

        public Bitmap Histogramsitleme(Image resim)
        {
            gelenResim = new Bitmap(resim);
            this.genislik = gelenResim.Width;
            this.yukseklik = gelenResim.Height;
            gidenResim = new Bitmap(genislik, yukseklik);
            Color input_clr;

            int[] histogram_r = new int[256];
            int[] histogram_g = new int[256];
            int[] histogram_b = new int[256];

            int[] cdf_r = histogram_r;
            int[] cdf_g = histogram_g;
            int[] cdf_b = histogram_b;

            uint pixels = (uint)this.yukseklik * (uint)this.genislik;
            decimal Const = 255 / (decimal)pixels;

            for (int i = 0; i < this.genislik; i++)
            {
                for (int j = 0; j < this.yukseklik; j++)
                {
                    input_clr = gelenResim.GetPixel(i, j);

                    histogram_r[(int)input_clr.R]++;
                    histogram_g[(int)input_clr.G]++;
                    histogram_b[(int)input_clr.B]++;
                }
            }

            for (int r = 1; r <= 255; r++)
            {
                cdf_r[r] = cdf_r[r] + cdf_r[r - 1];
                cdf_g[r] = cdf_g[r] + cdf_g[r - 1];
                cdf_b[r] = cdf_b[r] + cdf_b[r - 1];
            }

            for (int y = 0; y < this.yukseklik; y++)
            {
                for (int x = 0; x < this.genislik; x++)
                {
                    Color pixelColor = gelenResim.GetPixel(x, y);

                    R = Convert.ToInt32(cdf_r[pixelColor.R] * Const);
                    G = Convert.ToInt32(cdf_r[pixelColor.G] * Const);
                    B = Convert.ToInt32(cdf_r[pixelColor.B] * Const);

                    gidenResim.SetPixel(x, y, Color.FromArgb(R, G, B));
                }
            }

            return gidenResim;
        }
    }
}
