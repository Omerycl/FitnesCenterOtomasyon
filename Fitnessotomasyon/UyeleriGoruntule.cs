using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static Guna.UI2.Native.WinApi;


namespace Fitnessotomasyon
{
    public partial class UyeleriGoruntule : Form
    {
        public UyeleriGoruntule()
        {
            InitializeComponent();
        }
        SqlConnection baglanti = new SqlConnection(@"Data Source=.\SQLEXPRESS;Initial Catalog=fitnessdb;Integrated Security=True");
        private void uyeler()
        {
            baglanti.Open();
            string query = "select *from UyeTbl";
            SqlDataAdapter sda= new SqlDataAdapter(query, baglanti);
            SqlCommandBuilder builder= new SqlCommandBuilder();
            var DataSet =new DataSet();
            sda.Fill(DataSet);
            UyeDGV.DataSource= DataSet.Tables[0];
            baglanti.Close();

        }

        private void label2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void UyeleriGoruntule_Load(object sender, EventArgs e)
        {
            uyeler();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Login log= new Login();
            log.Show();
            this.Hide();


        }
        private void AdFiltrele()
        {
            baglanti.Open();
            string query = "select *from UyeTbl where UAdSoyad='" + AraUyeTb.Text + "'";
            SqlDataAdapter sda = new SqlDataAdapter(query, baglanti);
            SqlCommandBuilder builder = new SqlCommandBuilder();
            var DataSet = new DataSet();
            sda.Fill(DataSet);
            UyeDGV.DataSource = DataSet.Tables[0];
            baglanti.Close();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            AdFiltrele();
            AraUyeTb.Text = "";

        }

        private void button3_Click(object sender, EventArgs e)
        {
            uyeler();
        }
    }
}
