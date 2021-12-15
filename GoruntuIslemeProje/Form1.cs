using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using IronPython.Hosting;

namespace GoruntuIslemeProje
{
    public partial class Form1 : Form
    {
        Image orjinalResim;

        ArrayList pikselSayilari = new ArrayList();
        ArrayList pikseller = new ArrayList();
        int[] numberP = new int[256];

        TemelIslemler temelIslemler = new TemelIslemler();
        NoktasalIslemler noktasalIslemler = new NoktasalIslemler();
        UzamsalIslemler uzamsalIslemler = new UzamsalIslemler();
        FiltreIslemler filtreIslemler = new FiltreIslemler();
        public Form1()
        {
            InitializeComponent();

            //TemelIslemler = TemelIslemlerPy.Fonksiyon();

            //var sonuc = TemelIslemler.topla(15, 20);
            //label1.Text = sonuc.ToString();


            if (pcborjinalResim.Image == null)
            {
                groupBox2.Visible = false;
                groupBox3.Visible = false;
                grpkirpma.Visible = false;
                grpoteleme.Visible = false;
                grpdondurme.Visible = false;
                grpislenen.Visible = false;
                grpnoktaislemler.Visible = false;
                grpPlcIslemler.Visible = false;
                grpUzamsalIslemler.Visible = false;
                grpUzamsalIslenenResim.Visible = false;
                grpfiltreislenenresim.Visible = false;
                grpfiltreler.Visible = false;

            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            pictureBox1.Image = temelIslemler.SiyahtanBeyazaFraktal();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            pictureBox1.Image = temelIslemler.BeyazDaire();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            pictureBox1.Image = temelIslemler.ReferansliYeni();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            OpenFileDialog od = new OpenFileDialog();
            od.InitialDirectory = @"\";
            od.Filter = "resimler|*.*";
            od.Multiselect = false;
            od.FilterIndex = 2;
            if (od.ShowDialog() == DialogResult.OK)
            {
                orjinalResim = Image.FromFile(od.FileName);
                pcbor.Image = orjinalResim;
                grpnoktaislemler.Visible = true;
            }
        }

        private void btnNoktaIslemYap_Click(object sender, EventArgs e)
        {
            if (!rdbesikleme.Checked && !rdbgamma.Checked && !rdbhistogramesitleme.Checked &&  !rdblogdonusum.Checked && !rdbparcalilineer.Checked && !rdbtersleme.Checked)
            {
                MessageBox.Show("İşlem seçmediniz.");
                return;
            }
            if (rdbtersleme.Checked)
            {
                grpislenen.Visible = true;
                Bitmap resim = noktasalIslemler.Tersleme(pcbor.Image);
                pcbis.Image = resim;
                pcbis.Visible = true;
            }
            else if (rdbesikleme.Checked)
            {
                grpislenen.Visible = true;
                Bitmap resim = noktasalIslemler.Esikleme(pcbor.Image);
                pcbis.Image = resim;
                pcbis.Visible = true;
            }
            else if(rdblogdonusum.Checked)
            {
                grpislenen.Visible = true;
                Bitmap resim = noktasalIslemler.LogaritmikDonusum(pcbor.Image);
                pcbis.Image = resim;
                pcbis.Visible = true;
            }
            else if(rdbgamma.Checked)
            {
                grpislenen.Visible = true;
                Bitmap resim = noktasalIslemler.Gama(pcbor.Image);
                pcbis.Image = resim;
                pcbis.Visible = true;
            }

            else if(rdbparlaklik.Checked)
            {
                grpislenen.Visible = true;
                Bitmap resim = noktasalIslemler.Parlaklik(pcbor.Image);
                pcbis.Image = resim;
                pcbis.Visible = true;
            }
            else if(rdbkarsitlik.Checked)
            {
                grpislenen.Visible = true;
                Bitmap resim = noktasalIslemler.Karsitlik(pcbor.Image);
                pcbis.Image = resim;
                pcbis.Visible = true;
            }
            else if(rdbparlaklilkarsitlik.Checked)
            {
                grpislenen.Visible = true;
                Bitmap resim = noktasalIslemler.ParlaklikKarsitlik(pcbor.Image);
                pcbis.Image = resim;
                pcbis.Visible = true;
            }
            else if(rdbhistogramesitleme.Checked)
            {
                grpislenen.Visible = true;
                Bitmap resim = noktasalIslemler.Histogramsitleme(pcbor.Image);
                pcbis.Image = resim;
                pcbis.Visible = true;
            }
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton2.Checked)
            {
                grpkirpma.Visible = true;
                grpoteleme.Visible = false;
                grpdondurme.Visible = false;
            }
            else
            {
                grpkirpma.Visible = false;
            }
        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton3.Checked)
            {
                grpoteleme.Visible = true;
                grpkirpma.Visible = false;
                grpdondurme.Visible = false;
            }
            else
            {
                grpkirpma.Visible = false;
            }
        }

        private void radioButton6_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton6.Checked)
            {
                grpoteleme.Visible = false;
                grpkirpma.Visible = false;
                grpdondurme.Visible = true;
            }
            else
            {
                grpdondurme.Visible = false;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (!radioButton1.Checked && !radioButton2.Checked && !radioButton3.Checked && !radioButton4.Checked && !radioButton5.Checked && !radioButton6.Checked)
            {
                MessageBox.Show("İşlem seçmediniz.");
                return;
            }

            if (radioButton1.Checked)
            {
                groupBox2.Visible = true;
                Bitmap aynalanmisResim = temelIslemler.Aynalama(orjinalResim);
                pcbislenenResim.Image = aynalanmisResim;
            }
            else if (radioButton2.Checked)
            {
                if (!String.IsNullOrEmpty(txtKirpmaX.Text) || !String.IsNullOrEmpty(txtKirpmaY.Text))
                {
                    groupBox2.Visible = true;
                    int x = Convert.ToInt32(txtKirpmaX.Text);
                    int y = Convert.ToInt32(txtKirpmaY.Text);
                    Bitmap kirpilanResim = temelIslemler.Kirpma(orjinalResim, x, y);
                    pcbislenenResim.Image = kirpilanResim;
                }
                else
                {
                    MessageBox.Show("Kırpma işlemi başlangıç piksellerini yazınız.", "UYARI");
                }
            }
            else if (radioButton3.Checked)
            {
                if (!String.IsNullOrEmpty(txtOtelemeX.Text) || !String.IsNullOrEmpty(txtOtelemeY.Text))
                {
                    groupBox2.Visible = true;
                    int x = Convert.ToInt32(txtOtelemeX.Text);
                    int y = Convert.ToInt32(txtOtelemeY.Text);
                    Bitmap otelenenResim = temelIslemler.Oteleme(orjinalResim, x, y);
                    pcbislenenResim.Image = otelenenResim;
                }
                else
                {
                    MessageBox.Show("Öteleme işlemi başlangıç piksellerini yazınız.", "UYARI");
                }
            }
            else if (radioButton4.Checked)
            {
                pcbislenenResim.SizeMode = PictureBoxSizeMode.AutoSize;
                groupBox2.Visible = true;
                Bitmap yakinResim = temelIslemler.Yakinlastir(orjinalResim);
                pcbislenenResim.Image = yakinResim;
            }
            else if (radioButton5.Checked)
            {
                pcbislenenResim.SizeMode = PictureBoxSizeMode.AutoSize;
                groupBox2.Visible = true;
                Bitmap uzakResim = temelIslemler.Uzaklastir(orjinalResim);
                pcbislenenResim.Image = uzakResim;
                pcbislenenResim.SizeMode = PictureBoxSizeMode.StretchImage;
            }
            else if(radioButton6.Checked)
            {
                if (!String.IsNullOrEmpty(txtdondurmeAci.Text))
                {
                    pcbislenenResim.SizeMode = PictureBoxSizeMode.AutoSize;
                    groupBox2.Visible = true;
                    Bitmap donenResim = temelIslemler.Dondur(orjinalResim, Convert.ToInt32(txtdondurmeAci.Text));
                    pcbislenenResim.Image = donenResim;
                    pcbislenenResim.SizeMode = PictureBoxSizeMode.StretchImage;
                }
                else
                {
                    MessageBox.Show("Döndürme işlemi için Açı değerini giriniz.", "UYARI");
                }
            }
        }

        private void btnResimYukle_Click(object sender, EventArgs e)
        {
            OpenFileDialog od = new OpenFileDialog();
            od.InitialDirectory = @"\";
            od.Filter = "resimler|*.*";
            od.Multiselect = false;
            od.FilterIndex = 2;
            if (od.ShowDialog() == DialogResult.OK)
            {
                orjinalResim = Image.FromFile(od.FileName);
                pcborjinalResim.Image = orjinalResim;
                groupBox3.Visible = true;
            }
        }

        private void rdbparcalilineer_CheckedChanged(object sender, EventArgs e)
        {
            if (rdbparcalilineer.Checked)
            {
                grpPlcIslemler.Visible = true;
            }
            else
            {
                grpPlcIslemler.Visible = false;
                rdbparlaklik.Checked = false;
                rdbparlaklilkarsitlik.Checked = false;
                rdbkarsitlik.Checked = false;
            }
        }

        private void btnUzamsalResimYukle_Click(object sender, EventArgs e)
        {
            OpenFileDialog od = new OpenFileDialog();
            od.InitialDirectory = @"\";
            od.Filter = "resimler|*.*";
            od.Multiselect = false;
            od.FilterIndex = 2;
            if (od.ShowDialog() == DialogResult.OK)
            {
                orjinalResim = Image.FromFile(od.FileName);
                pctUzamsalorjinal.Image = orjinalResim;
                grpUzamsalIslemler.Visible = true;
            }
        }

        private void btnUzamsalIslemler_Click(object sender, EventArgs e)
        {
            if (!gaussGurultu.Checked && !rayleighGurultu.Checked && !exponentialGurultu.Checked &&
                !uniformGurultu.Checked && !saltandpepperGurultu.Checked)
            {
                MessageBox.Show("İşlem seçmediniz.");
                return;
            }

            if (gaussGurultu.Checked)
            {
                grpUzamsalIslenenResim.Visible = true;
                Bitmap resim = uzamsalIslemler.GaussGurultu((Bitmap)pctUzamsalorjinal.Image);
                pctUzamsalIslenen.Image = resim;
                pctUzamsalIslenen.Visible = true;
            }
            else if (rayleighGurultu.Checked)
            {
                grpUzamsalIslenenResim.Visible = true;
                Bitmap resim = uzamsalIslemler.RayleighGurultu((Bitmap)pctUzamsalorjinal.Image);
                pctUzamsalIslenen.Image = resim;
                pctUzamsalIslenen.Visible = true;
            }
            else if (exponentialGurultu.Checked)
            {
                grpUzamsalIslenenResim.Visible = true;
                Bitmap resim = uzamsalIslemler.ExponentialGurultu((Bitmap)pctUzamsalorjinal.Image);
                pctUzamsalIslenen.Image = resim;
                pctUzamsalIslenen.Visible = true;
            }
            else if (uniformGurultu.Checked)
            {
                grpUzamsalIslenenResim.Visible = true;
                Bitmap resim = uzamsalIslemler.UniformGurultu((Bitmap)pctUzamsalorjinal.Image);
                pctUzamsalIslenen.Image = resim;
                pctUzamsalIslenen.Visible = true;
            }
            else if (saltandpepperGurultu.Checked)
            {
                grpUzamsalIslenenResim.Visible = true;
                Bitmap resim = uzamsalIslemler.SaltAndPepperGurultu((Bitmap)pctUzamsalorjinal.Image);
                pctUzamsalIslenen.Image = resim;
                pctUzamsalIslenen.Visible = true;
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            OpenFileDialog od = new OpenFileDialog();
            od.InitialDirectory = @"\";
            od.Filter = "resimler|*.*";
            od.Multiselect = false;
            od.FilterIndex = 2;
            if (od.ShowDialog() == DialogResult.OK)
            {
                orjinalResim = Image.FromFile(od.FileName);
                pctfiltreorjinal.Image = orjinalResim;
                grpfiltreler.Visible = true;
            }
        }

        private void btnfiltreislemler_Click(object sender, EventArgs e)
        {
            if (!rdbaritmatikortalama.Checked&&!rdbgeometrikortalama.Checked&&!rdbharmonik.Checked&&!rdbkontraharmonik.Checked&&!rdbmedyan.Checked&&!rdbMaxMin.Checked&&!rdbmidpoint.Checked&&!rdbalfainceayar.Checked)
            {
                MessageBox.Show("İşlem seçmediniz.");
                return;
            }

            if (rdbaritmatikortalama.Checked)
            {
                grpfiltreislenenresim.Visible = true;
                Bitmap resim = filtreIslemler.AritmetikOrtalamaFiltre((Bitmap)pctfiltreorjinal.Image);
                pctfiltreislenen.Image = resim;
                pctfiltreislenen.Visible = true;
            }
            else if (rdbgeometrikortalama.Checked)
            {
                grpfiltreislenenresim.Visible = true;
                Bitmap resim = filtreIslemler.GeometrikOrtalamaFiltre((Bitmap)pctfiltreorjinal.Image);
                pctfiltreislenen.Image = resim;
                pctfiltreislenen.Visible = true;
            }
            else if (rdbharmonik.Checked)
            {
                grpfiltreislenenresim.Visible = true;
                Bitmap resim = filtreIslemler.HarmonikOrtalamaFiltre((Bitmap)pctfiltreorjinal.Image);
                pctfiltreislenen.Image = resim;
                pctfiltreislenen.Visible = true;
            }
            else if (rdbkontraharmonik.Checked)
            {
                grpfiltreislenenresim.Visible = true;
                Bitmap resim = filtreIslemler.KontraHarmonikFiltre((Bitmap)pctfiltreorjinal.Image,0.5);
                pctfiltreislenen.Image = resim;
                pctfiltreislenen.Visible = true;
            }
            else if (rdbmedyan.Checked)
            {
                grpfiltreislenenresim.Visible = true;
                Bitmap resim = filtreIslemler.MedyanFiltre((Bitmap)pctfiltreorjinal.Image);
                pctfiltreislenen.Image = resim;
                pctfiltreislenen.Visible = true;
            }
            else if (rdbMaxMin.Checked)
            {
                grpfiltreislenenresim.Visible = true;
                Bitmap resim = filtreIslemler.MaxMinFiltre((Bitmap)pctfiltreorjinal.Image);
                pctfiltreislenen.Image = resim;
                pctfiltreislenen.Visible = true;
            }
            else if (rdbmidpoint.Checked)
            {
                grpfiltreislenenresim.Visible = true;
                Bitmap resim = filtreIslemler.MidPointFiltre((Bitmap)pctfiltreorjinal.Image);
                pctfiltreislenen.Image = resim;
                pctfiltreislenen.Visible = true;
            }
            else if (rdbalfainceayar.Checked)
            {
                grpfiltreislenenresim.Visible = true;
                Bitmap resim = filtreIslemler.AlfaInceAyarliOrtalamaFiltre((Bitmap)pctfiltreorjinal.Image,2);
                pctfiltreislenen.Image = resim;
                pctfiltreislenen.Visible = true;
            }
        }
    }
}
