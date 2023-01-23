using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Web;
using System.Windows.Forms;

namespace LakoparkProjekt
{
    public partial class Form1 : Form
    {
        
        HappyLiving kell = new HappyLiving(new List<Lakopark>());
        string keput = @"..//../Kepek/";
        int oldalszama = 0;
        public Form1()
        {
            InitializeComponent();
        }
        private void kepekbetoltese(PictureBox pictureBox, int i, int j) {
            string haz = keput + @"Haz" + kell.Lakoparkok[oldalszama].Hazak[i, j] + ".jpg";
            if (File.Exists(haz))
            {
                pictureBox.ImageLocation = haz;
            }
            else { 
                pictureBox.ImageLocation = "..//../Kepek/kereszt.jpg";
            }
        }
        private void valtas(Lakopark lakopark) {
            panel1.Controls.Clear();
            kep.ImageLocation = keput + kell.Lakoparkok[oldalszama].Nev + ".jpg";
            int picturesize = 40;
            for (int i = 0; i < kell.Lakoparkok[oldalszama].MaxhazSzam; i++)
            {
                for (int j = 0; j < kell.Lakoparkok[oldalszama].UtcakSzama; j++)
                {
                    PictureBox picturebox = new PictureBox();
                    picturebox.ImageLocation = "..//../Kepek/kereszt.jpg";
                    picturebox.SizeMode = PictureBoxSizeMode.StretchImage;
                    picturebox.SetBounds(j * picturesize, i * picturesize, picturesize, picturesize);
                    picturebox.Name = $"{i};{j}";
                  //  MessageBox.Show(picturebox.Name);
                    kepekbetoltese(picturebox, i, j);
                    picturebox.Click += (o, ev) => {
                        PictureBox picture = (PictureBox)o;
                        int[] hazak = Array.ConvertAll(picture.Name.Split(';'), int.Parse);
                        int koordinata_i = hazak[0];
                        int koordinata_j = hazak[1];
                        if (kell.Lakoparkok[oldalszama].Hazak[koordinata_i, koordinata_j] + 1 > 3)
                        {
                            kell.Lakoparkok[oldalszama].Hazak[koordinata_i, koordinata_j] = 0;
                        }
                        else {
                            kell.Lakoparkok[oldalszama].Hazak[koordinata_i, koordinata_j] += 1;
                        }
                        kepekbetoltese(picturebox, koordinata_i, koordinata_j);

                    };
                    panel1.Controls.Add(picturebox);
                }
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            string lines = System.IO.File.ReadAllText(@"..//../lakoparkok.txt");
          //  MessageBox.Show(Regex.Escape(lines));
            string[] lines1 = Regex.Split(lines, Environment.NewLine + Environment.NewLine);

            for (int i = 0; i < lines1.Length-1; i++)
            {
                string[] cod = lines1[i].Split('\n');
                string[] asd = cod[1].Split(';');
               // MessageBox.Show(asd[0] + " " + asd[1]);
                int[,] hazak = new int[Convert.ToInt32(asd[0]),Convert.ToInt32(asd[1])];
              //  MessageBox.Show(hazak.GetLength(0) + " " + hazak.GetLength(1));
                for (int j = 2; j < cod.Length; j++)
                {
                    string[] szet = cod[j].Split(';');
                    hazak[Convert.ToInt32(szet[0]) - 1, Convert.ToInt32(szet[1]) - 1] = Convert.ToInt32(szet[2]);
                }
                kell.Lakoparkok.Add(new Lakopark(hazak, Convert.ToInt32(asd[0]), cod[0].Replace("\r", ""), Convert.ToInt32(asd[1])));
            }
            valtas(kell.Lakoparkok[oldalszama]);
            nyilak();
        }
        private void nyilak() 
        {
            if (oldalszama > 0)
            {
                bal.ImageLocation = keput + @"balnyil.jpg";
            }
            else {
                bal.ImageLocation = @"";
            }
            if (oldalszama < 2)
            {
                jobb.ImageLocation = keput + @"jobbnyil.jpg";
            }
            else
            {
                jobb.ImageLocation = @"";
            }
        }
        private void jobb_Click(object sender, EventArgs e)
        {
            if (oldalszama + 1 < 3)
            {
                oldalszama++;
            }                    
            valtas(kell.Lakoparkok[oldalszama]);
            nyilak();
               
        }
        private void bal_Click(object sender, EventArgs e)
        {
            if (oldalszama - 1 > -1)
            {
                oldalszama--;
            }
            valtas(kell.Lakoparkok[oldalszama]);
            nyilak();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string[] datum = Regex.Split(DateTime.Now.ToString(), ". ");
            File.Move(@"..//../lakoparkok.txt", $"..//../lakoparkok_{datum[0]}{datum[1]}{datum[2]}{datum[3].Replace(":", "")}.txt");
            string filesave = "";
            foreach (Lakopark lp in kell.Lakoparkok)
            {
                filesave += $"{lp.Nev}{Environment.NewLine}{lp.MaxhazSzam};{lp.UtcakSzama}{Environment.NewLine}";
                for (int x = 0; x < lp.Hazak.GetLength(0); x++)
                {
                    for (int y = 0; y < lp.Hazak.GetLength(1); y++)
                    {
                        filesave += (lp.Hazak[x, y] == 0) ? ("") : ($"{x + 1};{y + 1};{lp.Hazak[x, y]}{Environment.NewLine}");
                    }
                }
                filesave += Environment.NewLine;
            }
            File.WriteAllText(@"..//../lakoparkok.txt", filesave);

        }
    }
}
