using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Fitnessotomasyon
{
    public partial class AnaSayfa : Form
    {
        public AnaSayfa()
        {
            InitializeComponent();
        }

        private void bunifuThinButton25_Click(object sender, EventArgs e)
        {
            UyeEkle uyeekle= new UyeEkle();
            uyeekle.Show();
            this.Hide();

        }

        private void bunifuThinButton22_Click(object sender, EventArgs e)
        {
            GuncelleSil guncelle = new GuncelleSil();
            guncelle.Show();
            this.Hide();
        }

        private void bunifuThinButton24_Click(object sender, EventArgs e)
        {
            Odeme odeme= new Odeme();
            odeme.Show();
            this.Hide();

        }

        private void bunifuThinButton21_Click(object sender, EventArgs e)
        {
            UyeleriGoruntule uyelerigoruntule = new UyeleriGoruntule();
            uyelerigoruntule.Show();
            this.Hide();
        }
    }
}
