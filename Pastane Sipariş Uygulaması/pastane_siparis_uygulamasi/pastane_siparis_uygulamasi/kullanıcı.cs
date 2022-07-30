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

namespace pastane_siparis_uygulamasi
{   
    public partial class kullanıcı : Form
    {
        public kullanıcı()
        {
            InitializeComponent();
        }

        private void kullanıcı_Load(object sender, EventArgs e)
        {
            verigetir();
        }

        SqlConnection baglanti;
        SqlCommand komut;
        
         void verigetir()
        {
            baglanti = new SqlConnection(baglan.sqlconnection);
            baglanti.Open();
            string kayit = "SELECT * from urunler";
            //urunler tablosundaki tüm kayıtları çekecek olan sql sorgusu.
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
        }

        void guncelle()
        {
            komut = new SqlCommand();
            baglanti.Open();
            komut.Connection = baglanti;
            komut.CommandText = "update urunler set urun_fyt='" + txtFYT.Text +  "' where ID=" + txtID.Text + "";
            komut.ExecuteNonQuery();
            baglanti.Close();
            verigetir();
        }

        
        private void button1_Click(object sender, EventArgs e)
        {        
            guncelle();            
        }
       
        private void dataGridView1_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            txtID.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            txtAD.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            txtFYT.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            this.Close();
            Application.Exit();
            Application.Restart();
        }
    }
}
