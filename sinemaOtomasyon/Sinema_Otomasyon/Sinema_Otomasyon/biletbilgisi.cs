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

namespace Sinema_Otomasyon
{
    public partial class biletbilgisi : Form
    {
        public biletbilgisi()
        {
            InitializeComponent();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            //inner join kullanıldı
            SqlConnection con = new SqlConnection("Data Source=.\\SQLEXPRESS;Initial Catalog=sinema;Integrated Security=True");//sql bağlantı stringi
            DataTable dt = new DataTable();
            string sql = "Select satis_id, kisi_adi,kisi_soyadi,seans_adi,seans_tarih,seans_saat, film_adi from satis join seans on seans.seans_id = satis.seans_id join filmler on filmler.film_id=satis.film_id";
            con.Open();
            SqlDataAdapter da = new SqlDataAdapter(sql, con);
            da.Fill(dt);
            dataGridView1.DataSource = dt;
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            //inner join kullanıldı
            SqlConnection con = new SqlConnection("Data Source=.\\SQLEXPRESS;Initial Catalog=sinema;Integrated Security=True");//sql bağlantı stringi
            DataTable dt = new DataTable();
            string sql = "Select * from filmler join seans on seans.seans_id = filmler.seans_id";
            con.Open();
            SqlDataAdapter da = new SqlDataAdapter(sql, con);
            da.Fill(dt);
            dataGridView1.DataSource = dt;
        }
    }
}
