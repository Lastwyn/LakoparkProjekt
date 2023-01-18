using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LakoparkProjekt
{
    public partial class Form1 : Form
    {
        HappyLiving kell = new HappyLiving(new List<Lakopark>());
        public Form1()
        {
            InitializeComponent();
        }

        private void valtas() {
            int picturesize = 40;
            for (int i = 0; i < kell.Lakoparkok[0].MaxhazSzam; i++)
            {
                for (int j = 0; j < kell.Lakoparkok[0].UtcakSzama; j++)
                {
                    PictureBox picturebox = new PictureBox();
                    picturebox.ImageLocation = "..//../Kepek/kereszt.jpg";
                    picturebox.SizeMode = PictureBoxSizeMode.StretchImage;
                    picturebox.SetBounds(j * picturesize, i * picturesize, picturesize, picturesize);
                    picturebox.Click += (o, ev) => {
                        PictureBox picture = (PictureBox)o;
                        picture.ImageLocation = "..//../Kepek/Haz1.jpg";

                    };
                    panel1.Controls.Add(picturebox);
                }
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            string lines = System.IO.File.ReadAllText(@"..//../lakoparkok.txt");
            string[] lines1 = Regex.Split(lines, Environment.NewLine + Environment.NewLine);

            for (int i = 0; i < lines1.Length-1; i++)
            {
                string[] cod = lines1[i].Split('\n');
                string[] asd = cod[1].Split(';');
                int[,] hazak = new int[Convert.ToInt32(asd[0]),Convert.ToInt32(asd[1])];
                for (int j = 2; j < cod.Length; j++)
                {
                    string[] szet = cod[j].Split(';');
                    hazak[Convert.ToInt32(szet[0]) - 1, Convert.ToInt32(szet[1]) - 1] = Convert.ToInt32(szet[2]);
                }
                kell.Lakoparkok.Add(new Lakopark(hazak, Convert.ToInt32(asd[0]), cod[0], Convert.ToInt32(asd[1])));
            }
        }
    }
}
