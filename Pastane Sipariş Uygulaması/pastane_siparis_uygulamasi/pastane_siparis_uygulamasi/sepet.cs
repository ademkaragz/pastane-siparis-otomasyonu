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
    public partial class sepet : Form
    {
        public sepet()
        {
            InitializeComponent();
        }

        SqlConnection baglanti;       
        
        void kayitGetir()
        {
            baglanti = new SqlConnection(baglan.sqlconnection);
            baglanti.Open();
            string kayit = "SELECT * from sepet";
            //sepet tablosundaki tüm kayıtları çekecek olan sql sorgusu.
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

        void SatirSil(int ID)
        {     
            string sql = "DELETE FROM sepet WHERE ID=@ID";
            SqlCommand komut = new SqlCommand(sql, baglanti);
            komut.Parameters.AddWithValue("@ID", ID);
            baglanti.Open();
            komut.ExecuteNonQuery();
            baglanti.Close();
        }
       
        void topla()
        {
            int toplam = 0;

            for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {
                toplam += Convert.ToInt32(dataGridView1.Rows[i].Cells[2].Value); // Fiyat sütunu 
            }          
            label1.Text = Convert.ToString(toplam) +"TL";
        }

        void KayitSil()
         {
               baglanti = new SqlConnection(baglan.sqlconnection);
               baglanti.Open();
               SqlCommand sil = new SqlCommand
               ("DELETE from sepet", baglanti);           
               sil.ExecuteNonQuery();
               baglanti.Close();
         }
        
        private void sepet_Load(object sender, EventArgs e)
        {                      
            kayitGetir();
            topla();
        }
               
        private void button1_Click(object sender, EventArgs e)
        {  
            KayitSil();
            this.Close();
        }
        
        private void button2_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Siparişiniz Alınmıştır.");

            if (System.Windows.Forms.Screen.AllScreens.Length > 1)
            {
                ikinciekran ikinciekran = new ikinciekran();
                ikinciekran.Show();
                ikinciekran.TopMost = true;
            }          
           this.Close();           
        }  

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }
      
        private void button4_Click(object sender, EventArgs e)
        {           
            {
                foreach (DataGridViewRow drow in dataGridView1.SelectedRows)  //Seçili Satırları Silme Kodu
                {
                    int ID = Convert.ToInt32(drow.Cells[0].Value);
                    SatirSil(ID);
                }
                kayitGetir();               
            }
            topla();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}