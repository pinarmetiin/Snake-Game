using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace yilan
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        yilan yilanimiz = new yilan();
        yon yonumuz;
        PictureBox[] pb_yilanparcalari;
        bool yem_varmi = false;
        Random rast = new Random();
        PictureBox pb_yem;
        private void Form1_Load(object sender, EventArgs e)
        {
            yonumuz = new yon(0, 0);
            pb_yilanparcalari = new PictureBox[0];
            for(int i=0 ; i<3 ;i++)
            {
                Array.Resize(ref pb_yilanparcalari, pb_yilanparcalari.Length + 1);

                pb_yilanparcalari[i] = pb_ekle();
            }
            timer1.Start();
        }
        private PictureBox pb_ekle()
        {
            
            PictureBox pb = new PictureBox();
            pb.Size = new Size(10, 10);
            pb.BackColor = Color.White;
            pb.Location = yilanimiz.GetPos(pb_yilanparcalari.Length-1);
            panel1.Controls.Add(pb);
               return pb;
        }
        private void pb_guncelle()
        {
            for(int i=0;i<pb_yilanparcalari.Length;i++)
            {
                pb_yilanparcalari[i].Location = yilanimiz.GetPos(i);
            }
        }
        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode==Keys.Up||e.KeyCode==Keys.W)
            {
                if (yonumuz._y != 10)
                {
                    yonumuz = new yon(0, -10);
                }
            }
            else if (e.KeyCode == Keys.Down || e.KeyCode == Keys.S)
            {
                if (yonumuz._y != -10)
                {
                    yonumuz = new yon(0, 10);
                }
            }
            else if (e.KeyCode == Keys.Left || e.KeyCode == Keys.A)
            {
                if (yonumuz._x != 10)
                {
                    yonumuz = new yon(-10, 0);
                }
            }
            else if (e.KeyCode == Keys.Right || e.KeyCode == Keys.D)
            {
                if (yonumuz._x != -10)
                {
                    yonumuz = new yon(10, 0);
                }
            }

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            yilanimiz.ilerle(yonumuz);
            pb_guncelle();
            yem_olustur();
            yem_yedimi();
        }
        public void yem_olustur()
        {
            if (!yem_varmi)
            {
                PictureBox pb = new PictureBox();
                pb.BackColor = Color.Red;
                pb.Size = new Size(10, 10);
                pb.Location = new Point(rast.Next(panel1.Width / 10) * 10, rast.Next(panel1.Height / 10) * 10);
                pb_yem = pb;
                yem_varmi = true;
                panel1.Controls.Add(pb);
            }
        }
        public void yem_yedimi()
        {
            if(yilanimiz.GetPos(0)==pb_yem.Location)
            {
                yilanimiz.buyu();
                Array.Resize(ref pb_yilanparcalari, pb_yilanparcalari.Length + 1);
                pb_yilanparcalari[pb_yilanparcalari.Length - 1] = pb_ekle();
                yem_varmi = false;
                panel1.Controls.Remove(pb_yem);
            }
        }

    }
}
