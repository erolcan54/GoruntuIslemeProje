using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoruntuIslemeProje
{
    public class TemelIslemler
    {
        public Bitmap Aynalama(Image resim)
        {
            Bitmap simg = new Bitmap(resim);
            int genislik = simg.Width;
            int yukseklik = simg.Height;
            Bitmap mimg = new Bitmap(genislik * 2, yukseklik);
            for (int y = 0; y < yukseklik; y++)
                for (int solx = 0, sagx = genislik * 2 - 1; solx < genislik; solx++, sagx--)
                {
                    Color p = simg.GetPixel(solx, y);
                    mimg.SetPixel(solx, y, p);
                    mimg.SetPixel(sagx, y, p);
                }

            return mimg;
        }

        public Bitmap Kirpma(Image resim, int x, int y)
        {

            Rectangle rectDestination = new Rectangle(x, y, resim.Width, resim.Height);
            Bitmap bmp = new Bitmap(rectDestination.Width, rectDestination.Height);
            Graphics gr = Graphics.FromImage(bmp);
            gr.CompositingQuality = CompositingQuality.Default;
            gr.SmoothingMode = SmoothingMode.Default;
            gr.InterpolationMode = InterpolationMode.Bicubic;
            gr.PixelOffsetMode = PixelOffsetMode.Default;
            gr.DrawImage(resim, new Rectangle(0, 0, bmp.Width, bmp.Height), rectDestination, GraphicsUnit.Pixel);
            return bmp;
        }

        public Bitmap Oteleme(Image resim, int x, int y)
        {
            int R = 0, G = 0, B = 0;
            Bitmap mimg = new Bitmap(resim);
            for (int i = 0; i < resim.Width; i++)
            {
                for (int j = 0; j < resim.Height; j++)
                {
                    if (i < x || j < y)
                    { mimg.SetPixel(i, j, Color.Black); }
                    else
                    {
                        R = mimg.GetPixel(i - x + 1, j - y + 1).R;
                        G = mimg.GetPixel(i - x + 1, j - y + 1).G;
                        B = mimg.GetPixel(i - x + 1, j - y + 1).B;
                        mimg.SetPixel(i - x + 1, j - y + 1, Color.FromArgb(R, G, B));
                    }
                }
            }

            return mimg;
        }

        public Bitmap Yakinlastir(Image resim)
        {
            int R = 0, G = 0, B = 0;

            Bitmap img = new Bitmap(resim);
            int genislik = resim.Width;
            int yukseklik = resim.Height;
            Bitmap mimg = new Bitmap(genislik * 2, yukseklik * 2);

            int i = 0, j = 0;
            int a1, b1, c1, d1, a2, b2, c2, d2, a3, b3, c3, d3;

            for (int x = 0; x < genislik * 2; x++)
            {
                for (int y = 0; y < yukseklik * 2; y++)
                {
                    try
                    {
                        if ((x + 2) <= genislik && (y + 2) <= yukseklik)
                        {
                            a1 = img.GetPixel(x, y).R / 4;
                            b1 = img.GetPixel(x, y + 1).R / 4;
                            c1 = img.GetPixel(x + 1, y).R / 4;
                            d1 = img.GetPixel(x + 1, y + 1).R / 4;

                            R = Convert.ToInt32(a1 + b1 + c1 + d1);

                            a2 = img.GetPixel(x, y).G / 4;
                            b2 = img.GetPixel(x, y + 1).G / 4;
                            c2 = img.GetPixel(x + 1, y).G / 4;
                            d2 = img.GetPixel(x + 1, y + 1).G / 4;

                            G = Convert.ToInt32(a2 + b2 + c2 + d2);

                            a3 = img.GetPixel(x, y).B / 4;
                            b3 = img.GetPixel(x, y + 1).B / 4;
                            c3 = img.GetPixel(x + 1, y).B / 4;
                            d3 = img.GetPixel(x + 1, y + 1).B / 4;

                            B = Convert.ToInt32(a3 + b3 + c3 + d3);

                            mimg.SetPixel(i, j, Color.FromArgb(R, G, B));
                            mimg.SetPixel(i, j + 1, Color.FromArgb(R, G, B));
                            mimg.SetPixel(i + 1, j, Color.FromArgb(R, G, B));
                            mimg.SetPixel(i + 1, j + 1, Color.FromArgb(R, G, B));
                        }
                    }
                    catch { }
                    j += 2;
                }
                j = 0;
                i += 2;
            }

            return mimg;
        }

        public Bitmap Uzaklastir(Image resim)
        {
            int R = 0, G = 0, B = 0;

            Bitmap img = new Bitmap(resim);
            int genislik = resim.Width;
            int yukseklik = resim.Height;
            Bitmap mimg = new Bitmap(genislik / 2, yukseklik / 2);

            int i = 0, j = 0;

            for (int x = 0; x < genislik; x = x + 2)
            {
                for (int y = 0; y < yukseklik; y = y + 2)
                {
                    R = img.GetPixel(x, y).R;
                    G = img.GetPixel(x, y).G;
                    B = img.GetPixel(x, y).B;
                    mimg.SetPixel(i, j, Color.FromArgb(R, G, B));

                    j++;
                }
                j = 0;
                i++;
            }

            return mimg;
        }

        public Bitmap Dondur(Image resim, int aci)
        {
            Color okunanRenk;
            Bitmap img = new Bitmap(resim);
            int genislik = img.Width;
            int yukseklik = img.Height;


            Bitmap mimg = new Bitmap(genislik, yukseklik);
            double radyanAci = aci * 2 * Math.PI / 360;

            int x0 = genislik / 2;
            int y0 = yukseklik / 2;
            double x2 = 0, y2 = 0;
            for (int x1 = 0; x1 < genislik; x1++)
            {
                for (int y1 = 0; y1 < yukseklik; y1++)
                {
                    okunanRenk = img.GetPixel(x1, y1);

                    x2 = Math.Cos(radyanAci) * (x1 - x0) - Math.Sin(radyanAci) * (y1 - y0) + x0;
                    y2 = Math.Sin(radyanAci) * (x1 - x0) + Math.Cos(radyanAci) * (y1 - y0) + y0;

                    if (x2 > 0 && x2 < genislik && y2 > 0 && y2 < yukseklik)
                        mimg.SetPixel((int)x2, (int)y2, okunanRenk);
                }
            }

            return mimg;
        }

        public Bitmap SiyahtanBeyazaFraktal()
        {
            Color renk = Color.Black;
            Bitmap resim = new Bitmap(256, 256);
            for (int i = 0; i < 256; i++)
            {
                for (int j = 0; j < 256; j++)
                {
                    resim.SetPixel(i, j, renk);
                }
            }

            for (int i = 0; i < 256; i++)
            {
                for (int j = 0; j < 256; j++)
                {
                    resim.SetPixel(i, j, Color.FromArgb(i, i, i));
                }
            }

            return resim;
        }

        public Bitmap BeyazDaire()
        {
            Color renk = Color.Black;
            Bitmap resim = new Bitmap(256, 256);
            double dist = 0, a = 0, b = 0;
            for (int i = 0; i < 256; i++)
            {
                for (int j = 0; j < 256; j++)
                {
                    resim.SetPixel(i, j, renk);
                }
            }

            for (int i = 0; i < 256; i++)
            {
                for (int j = 0; j < 256; j++)
                {
                    a = Math.Pow(Convert.ToDouble(i - 128), Convert.ToDouble(2));
                    b = Math.Pow(Convert.ToDouble(j - 128), Convert.ToDouble(2));
                    dist = Math.Pow(Convert.ToDouble(a + b), Convert.ToDouble(0.5));
                    if (dist < 80)
                        resim.SetPixel(i, j, Color.FromArgb(255, 255, 255));
                    else
                        resim.SetPixel(i, j, Color.FromArgb(0, 0, 0));
                }
            }

            return resim;
        }

        public Bitmap ReferansliYeni()
        {
            int R = 0, G = 0, B = 0;
            int R1 = 0, G1 = 0, B1 = 0;
            int R2 = 0, G2 = 0, B2 = 0;
            Bitmap resim1 = SiyahtanBeyazaFraktal();
            Bitmap resim2 = BeyazDaire();
            Bitmap yeni = new Bitmap(256, 256);
            for (int i = 0; i < 256; i++)
            {
                for (int j = 0; j < 256; j++)
                {
                    R1 = resim1.GetPixel(i, j).R;
                    G1 = resim1.GetPixel(i, j).G;
                    B1 = resim1.GetPixel(i,j).B;

                    R2 = resim2.GetPixel(i, j).R;
                    G2 = resim2.GetPixel(i, j).G;
                    B2 = resim2.GetPixel(i, j).B;

                    R = (R1 * R2) / 255;
                    G = (G1 * G2) / 255;
                    B = (B1 * B2) / 255;
                    yeni.SetPixel(i, j, Color.FromArgb(R, G, B));
                }
            }
            return yeni;

        }
    }
}
