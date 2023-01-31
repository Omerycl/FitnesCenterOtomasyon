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

namespace Fitnessotomasyon
{
    public partial class GuncelleSil : Form
    {
        public GuncelleSil()
        {
            InitializeComponent();
        }
        SqlConnection baglanti = new SqlConnection(@"Data Source=.\SQLEXPRESS;Initial Catalog=fitnessdb;Integrated Security=True");
        private void uyeler()
        {
            baglanti.Open();
            string query = "select *from UyeTbl";
            SqlDataAdapter sda = new SqlDataAdapter(query, baglanti);
            SqlCommandBuilder builder = new SqlCommandBuilder();
            var DataSet = new DataSet();
            sda.Fill(DataSet);
            UyeDGV.DataSource = DataSet.Tables[0];
            baglanti.Close();

        }

        private void GuncelleSil_Load(object sender, EventArgs e)
        {
            uyeler();
        }
        int key = 0;

        private void UyeDGV_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            key = Convert.ToInt32(AdSoyadTb.Text = UyeDGV.SelectedRows[0].Cells[0].Value.ToString());
            AdSoyadTb.Text = UyeDGV.SelectedRows[0].Cells[1].Value.ToString();
            TelefonTb.Text = UyeDGV.SelectedRows[0].Cells[2].Value.ToString();
            CinsiyetCb.Text = UyeDGV.SelectedRows[0].Cells[3].Value.ToString();
            YasTb.Text = UyeDGV.SelectedRows[0].Cells[4].Value.ToString();
            OdemeTb.Text = UyeDGV.SelectedRows[0].Cells[5].Value.ToString();
            ZamanCb.Text = UyeDGV.SelectedRows[0].Cells[6].Value.ToString();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            AdSoyadTb.Text = "";
            TelefonTb.Text = "";
            CinsiyetCb.Text = "";
            YasTb.Text = "";
            OdemeTb.Text = "";
            ZamanCb.Text = "";   
        }

        private void button1_Click(object sender, EventArgs e)
        {
            AnaSayfa anaSayfa= new AnaSayfa();
            anaSayfa.Show();
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if(key==0)
            {
                MessageBox.Show("Silinecek Üyeyi Seçiniz");

            }
            else
            {
                try
                {
                    baglanti.Open();
                    string query = "delete from UyeTbl where UId=" + key + ";";
                    SqlCommand komut = new SqlCommand(query,baglanti);
                    komut.ExecuteNonQuery();
                    MessageBox.Show("Üye Başarıyla Silindi");
                    baglanti.Close();
                    uyeler();
                }catch(Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (key == 0||AdSoyadTb.Text==""||TelefonTb.Text==""||CinsiyetCb.Text==""||YasTb.Text==""||OdemeTb.Text==""||ZamanCb.Text=="")
            {
                MessageBox.Show("Eksik Bilgi");

            }
            else
            {
                try
                {
                    baglanti.Open();
                    string query = "update UyeTbl set UAdSoyad='"+AdSoyadTb.Text+ "',UTelefon='"+TelefonTb.Text+ "',UCinsiyet='"+CinsiyetCb.Text+ "',Uyas='"+YasTb.Text+ "',UOdeme='"+OdemeTb.Text+ "',UZaman='"+ZamanCb.Text+"'where UId="+key+";";

                    SqlCommand komut = new SqlCommand(query, baglanti);
                    komut.ExecuteNonQuery();
                    MessageBox.Show("Üye Başarıyla Güncellendi");
                    baglanti.Close();
                    uyeler();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void label3_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
