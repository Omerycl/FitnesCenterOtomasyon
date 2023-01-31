using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Fitnessotomasyon
{
    public partial class UyeEkle : Form
    {
        public UyeEkle()
        {
            InitializeComponent();
        }
        SqlConnection baglanti = new SqlConnection(@"Data Source=.\SQLEXPRESS;Initial Catalog=fitnessdb;Integrated Security=True");

        private void UyeEkle_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            if(AdSoyadTb.Text==""||TelefonTb.Text==""||OdemeTb.Text==""||YasTb.Text=="")
            {
                MessageBox.Show("Eksik Bilgi");
            }
            else
            {
                try
                {
                    baglanti.Open();
                    string query = "insert into UyeTbl values('" + AdSoyadTb.Text + "','" + TelefonTb.Text + "','" + CinsiyetCb.SelectedItem.ToString() + "','" + YasTb.Text + "','" + OdemeTb.Text + "','" + ZamanCb.SelectedItem.ToString() + "')";
                    SqlCommand komut = new SqlCommand(query,baglanti);
                    komut.ExecuteNonQuery();
                    MessageBox.Show("Üye Başarıyla Eklendi");
                    baglanti.Close();
                    AdSoyadTb.Text = "";
                    TelefonTb.Text = "";
                    OdemeTb.Text = "";
                    YasTb.Text = "";
                    CinsiyetCb.Text = "";
                    ZamanCb.Text = "";

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            AdSoyadTb.Text = "";
            TelefonTb.Text = "";
            OdemeTb.Text = "";
            YasTb.Text = "";
            CinsiyetCb.Text = "";
            ZamanCb.Text = "";
          
                
        }

        private void label3_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            AnaSayfa anasayfa= new AnaSayfa();
            anasayfa.Show();
            this.Hide();
        }
    }
}
