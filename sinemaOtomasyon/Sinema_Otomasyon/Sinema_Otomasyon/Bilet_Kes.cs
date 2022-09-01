using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
namespace Sinema_Otomasyon
{
    public partial class Bilet_Kes : Form
    {
        public Bilet_Kes()
        {
            InitializeComponent();
        }
        SqlConnection baglanti = new SqlConnection("Data Source=.\\SQLEXPRESS;Initial Catalog=sinema;Integrated Security=True");//sql bağlantı stringi
        int film_id, seans_id, salon_id;
        private void Bilet_Kes_Load(object sender, EventArgs e)
        {
            baglanti.Open();
            string kayit = "SELECT * from filmler";
            SqlCommand komut = new SqlCommand(kayit, baglanti);
            //Sorgumuzu ve baglantimizi parametre olarak alan bir SqlCommand nesnesi oluşturuyoruz.
            SqlDataAdapter da = new SqlDataAdapter(komut);
            //SqlDataAdapter sınıfı verilerin databaseden aktarılması işlemini gerçekleştirir.
            DataTable dt = new DataTable();
            da.Fill(dt);
            //Bir DataTable oluşturarak DataAdapter ile getirilen verileri tablo içerisine dolduruyoruz.
            dataGridView1.DataSource = dt;
            //Formumuzdaki DataGridViewin veri kaynağını oluşturduğumuz tablo olarak gösteriyoruz.
            baglanti.Close();
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView1.Columns[0].Visible = false;
            dataGridView1.Columns[1].Visible = false;
            dataGridView1.Columns[2].Visible = false;
            dataGridView1.Columns[3].HeaderText = "Film ADI";
            dataGridView1.Columns[4].HeaderText = "Film Türü";
            dataGridView1.Columns[5].HeaderText = "Yönetmen";
            dataGridView1.Columns[6].HeaderText = "Afiş";

           
           
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            textBox1.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
            textBox2.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();
            textBox3.Text = dataGridView1.CurrentRow.Cells[5].Value.ToString();
            film_id = int.Parse(dataGridView1.CurrentRow.Cells[0].Value.ToString());
            seans_id = int.Parse(dataGridView1.CurrentRow.Cells[1].Value.ToString());
            salon_id = int.Parse(dataGridView1.CurrentRow.Cells[2].Value.ToString());
            pictureBox1.ImageLocation= dataGridView1.CurrentRow.Cells[6].Value.ToString();
            baglanti.Open();
            SqlCommand listeleseans = new SqlCommand("select * from seans where seans_id='" + int.Parse(dataGridView1.CurrentRow.Cells[1].Value.ToString()) + "'", baglanti);
            SqlDataReader drs = listeleseans.ExecuteReader();
            if (drs.Read())
            {
                textBox4.Text = drs["seans_tarih"].ToString();
                textBox5.Text = drs["seans_saat"].ToString();
                textBox6.Text = drs["seans_adi"].ToString();
            }
            baglanti.Close();

            baglanti.Open();
            SqlCommand listele = new SqlCommand("select * from salon where salon_id='"+ int.Parse(dataGridView1.CurrentRow.Cells[2].Value.ToString()) + "'", baglanti);
            SqlDataReader dr = listele.ExecuteReader();
            while (dr.Read())
            {
             
           textBox7.Text= dr["salon_adi"].ToString();
            }
            baglanti.Close();

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

      

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            anasayfa frm1 = new anasayfa();
            frm1.Show();
            this.Hide();
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand ekle = new SqlCommand("insert into satis(film_id,seans_id,salon_id,kisi_adi,kisi_soyadi) values ('" + film_id + "','" + seans_id + "','" + salon_id + "','" + textBox8.Text + "','" + textBox9.Text + "')", baglanti);
            ekle.ExecuteNonQuery();
            ekle.Dispose();
            MessageBox.Show("Bilet Kesme  İşleminiz Başarıyla Gerçekleşmiştir.");
       
           
            baglanti.Close();

            for (int i = 0; i < this.Controls.Count; i++)
            {
                if (this.Controls[i] is TextBox) this.Controls[i].Text = "";
            }
        }
    }
}
