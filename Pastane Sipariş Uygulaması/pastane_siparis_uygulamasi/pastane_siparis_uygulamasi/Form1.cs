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
    public partial class Form1 : Form
    {

        public Form1()
        {
            InitializeComponent();
        }
              
        private void Form1_Load(object sender, EventArgs e)
        {
            timer1.Enabled = true;
            timer2.Enabled = true;
            verigetir();
            dataGridView1.Refresh();

            string ad = Convert.ToString(dataGridView1.Rows[0].Cells[1].Value);
            int fyt = Convert.ToInt32(dataGridView1.Rows[0].Cells[2].Value);
            label1.Text = ad + Environment.NewLine + fyt + "TL";

            string ad1 = Convert.ToString(dataGridView1.Rows[1].Cells[1].Value);
            int fyt1 = Convert.ToInt32(dataGridView1.Rows[1].Cells[2].Value);
            label2.Text = ad1 + Environment.NewLine + fyt1 + "TL";

            string ad2 = Convert.ToString(dataGridView1.Rows[2].Cells[1].Value);
            int fyt2 = Convert.ToInt32(dataGridView1.Rows[2].Cells[2].Value);
            label3.Text = ad2 + Environment.NewLine + fyt2 + "TL";

            string ad3 = Convert.ToString(dataGridView1.Rows[3].Cells[1].Value);
            int fyt3 = Convert.ToInt32(dataGridView1.Rows[3].Cells[2].Value);
            label4.Text = ad3 + Environment.NewLine + fyt3 + "TL";

            string ad4 = Convert.ToString(dataGridView1.Rows[4].Cells[1].Value);
            int fyt4 = Convert.ToInt32(dataGridView1.Rows[4].Cells[2].Value);
            label5.Text = ad4 + Environment.NewLine + fyt4 + "TL";

            string ad5 = Convert.ToString(dataGridView1.Rows[5].Cells[1].Value);
            int fyt5 = Convert.ToInt32(dataGridView1.Rows[5].Cells[2].Value);
            label6.Text = ad5 + Environment.NewLine + fyt5 + "TL";

            string ad6 = Convert.ToString(dataGridView1.Rows[6].Cells[1].Value);
            int fyt6 = Convert.ToInt32(dataGridView1.Rows[6].Cells[2].Value);
            label7.Text = ad6 + Environment.NewLine + fyt6 + "TL";

            string ad7 = Convert.ToString(dataGridView1.Rows[7].Cells[1].Value);
            int fyt7 = Convert.ToInt32(dataGridView1.Rows[7].Cells[2].Value);
            label8.Text = ad7 + Environment.NewLine + fyt7 + "TL";

            string ad8 = Convert.ToString(dataGridView1.Rows[8].Cells[1].Value);
            int fyt8 = Convert.ToInt32(dataGridView1.Rows[8].Cells[2].Value);
            label9.Text = ad8 + Environment.NewLine + fyt8 + "TL";

            string ad9 = Convert.ToString(dataGridView1.Rows[9].Cells[1].Value);
            int fyt9 = Convert.ToInt32(dataGridView1.Rows[9].Cells[2].Value);
            label10.Text = ad9 + Environment.NewLine + fyt9 + "TL";
            
            string ad10 = Convert.ToString(dataGridView1.Rows[10].Cells[1].Value);
            int fyt10 = Convert.ToInt32(dataGridView1.Rows[10].Cells[2].Value);
            label11.Text = ad10 + Environment.NewLine + fyt10 + "TL";

            string ad11 = Convert.ToString(dataGridView1.Rows[11].Cells[1].Value);
            int fyt11 = Convert.ToInt32(dataGridView1.Rows[11].Cells[2].Value);
            label12.Text = ad11 + Environment.NewLine + fyt11 + "TL";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            gazli_icecekler form2 = new gazli_icecekler(); //açılacak form
            form2.ShowDialog(); //açılıyor "gazlı içecekler"
            form2.TopMost = true;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            sutlu_tatlilar form3 = new sutlu_tatlilar(); //açılacak form
            form3.ShowDialog(); // açılıyor "sütlü tatlılar"
            form3.TopMost = true;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            sicak_icecekler form4 = new sicak_icecekler(); //açılacak form
            form4.ShowDialog(); // açılıyor "sıcak içecekler"
            form4.TopMost = true;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            serbetli_tatlilar form5 = new serbetli_tatlilar(); //açılacak form
            form5.ShowDialog(); //açılıyor "şerbetli tatlılar"
            form5.TopMost = true;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            meyve_sulari form6 = new meyve_sulari(); //açılacak form
            form6.ShowDialog(); // açılıyor "meyve suları"
            form6.TopMost = true;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            dogumgunu_pastalari form7 = new dogumgunu_pastalari(); //açılacak form
            form7.ShowDialog(); // açılıyor "doğum günü pastaları"
            form7.TopMost = true;           
        }
                    
        private void button7_Click(object sender, EventArgs e)
        {
            sepet sepet = new sepet(); //açılacak form
            sepet.ShowDialog(); // sepet açılıyor 
            sepet.TopMost = true;
        }
        private void button8_Click_1(object sender, EventArgs e)
        {
            admin admin = new admin(); //açılacak form
            admin.ShowDialog(); // admin açılıyor 
            admin.TopMost = true;
        }

        void verigetir()
        {
            SqlConnection baglanti = new SqlConnection(baglan.sqlconnection);
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

        void veri(string a, int b)
        {
            SqlConnection baglanti = new SqlConnection(baglan.sqlconnection);
            //bağlantı cümlemizi kullanarak bir SqlConnection bağlantısı oluşturuyoruz.
            {
                if (baglanti.State == ConnectionState.Closed)
                    baglanti.Open();
                
                //Bağlantımızı kontrol ediyoruz, eğer kapalıysa açıyoruz.
                string kayit = "insert into sepet(urun_ad,urun_fyt) values (@urun_ad,@urun_fyt)";
                //sepet tablomuzun ilgili alanlarına kayıt ekleme işlemini gerçekleştirecek sorgumuz.
                SqlCommand komut = new SqlCommand(kayit, baglanti);
                //Sorgumuzu ve baglantimızı parametre olarak alan bir SqlCommand nesnesi oluşturuyoruz.
                komut.Parameters.AddWithValue("@urun_ad", a);
                komut.Parameters.AddWithValue("@urun_fyt", b);               
                //Parametrelerimize veri tabanındaki verilerimizi aktarıyoruz.
                komut.ExecuteNonQuery();
                //Veritabanında değişiklik yapacak komut işlemi bu satırda gerçekleşiyor.
                baglanti.Close();
            }
        }
       
       
        private void pictureBox1_Click(object sender, EventArgs e)
        {
            string ad = Convert.ToString(dataGridView1.Rows[0].Cells[1].Value);
            int fyt = Convert.ToInt32(dataGridView1.Rows[0].Cells[2].Value);            
            veri(ad,fyt);
            MessageBox.Show("Çilekli Pasta Sepete Eklendi");             
        }
            
        private void pictureBox2_Click(object sender, EventArgs e)
        {
            string ad = Convert.ToString(dataGridView1.Rows[1].Cells[1].Value);
            int fyt = Convert.ToInt32(dataGridView1.Rows[1].Cells[2].Value);
            veri(ad, fyt);
            MessageBox.Show("Çikolatalı Pasta Sepete Eklendi");
            
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            string ad = Convert.ToString(dataGridView1.Rows[2].Cells[1].Value);
            int fyt = Convert.ToInt32(dataGridView1.Rows[2].Cells[2].Value);          
            veri(ad, fyt);
            MessageBox.Show("Vişneli Pasta Sepete Eklendi");
        }
        

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            string ad = Convert.ToString(dataGridView1.Rows[3].Cells[1].Value);
            int fyt = Convert.ToInt32(dataGridView1.Rows[3].Cells[2].Value);           
            veri(ad, fyt);
            MessageBox.Show("Frambuazlı Pasta Sepete Eklendi");           
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            string ad = Convert.ToString(dataGridView1.Rows[4].Cells[1].Value);
            int fyt = Convert.ToInt32(dataGridView1.Rows[4].Cells[2].Value);            
            veri(ad, fyt);
            MessageBox.Show("Frambuazlı Pasta Sepete Eklendi");
            
        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            string ad = Convert.ToString(dataGridView1.Rows[5].Cells[1].Value);
            int fyt = Convert.ToInt32(dataGridView1.Rows[5].Cells[2].Value);          
            veri(ad, fyt);
            MessageBox.Show("Cheesecake Sepete Eklendi");                    
        }

        private void pictureBox7_Click(object sender, EventArgs e)
        {
            string ad = Convert.ToString(dataGridView1.Rows[6].Cells[1].Value);
            int fyt = Convert.ToInt32(dataGridView1.Rows[6].Cells[2].Value);           
            veri(ad, fyt);
            MessageBox.Show("Çikolatalı Pasta Sepete Eklendi");           
        }

        private void pictureBox8_Click(object sender, EventArgs e)
        {
            string ad = Convert.ToString(dataGridView1.Rows[7].Cells[1].Value);
            int fyt = Convert.ToInt32(dataGridView1.Rows[7].Cells[2].Value);           
            veri(ad, fyt);
            MessageBox.Show("Muzlu Pasta Sepete Eklendi");            
        }

        private void pictureBox9_Click(object sender, EventArgs e)
        {
            string ad = Convert.ToString(dataGridView1.Rows[8].Cells[1].Value);
            int fyt = Convert.ToInt32(dataGridView1.Rows[8].Cells[2].Value);            
            veri(ad, fyt);
            MessageBox.Show("Vişneli Pasta Sepete Eklendi");            
        }

        private void pictureBox10_Click(object sender, EventArgs e)
        {
            string ad = Convert.ToString(dataGridView1.Rows[9].Cells[1].Value);
            int fyt = Convert.ToInt32(dataGridView1.Rows[9].Cells[2].Value);         
            veri(ad, fyt);
            MessageBox.Show("Çilekli Pasta Sepete Eklendi");            
        }

        private void pictureBox11_Click(object sender, EventArgs e)
        {
            string ad = Convert.ToString(dataGridView1.Rows[10].Cells[1].Value);
            int fyt = Convert.ToInt32(dataGridView1.Rows[10].Cells[2].Value);            
            veri(ad, fyt);
            MessageBox.Show("Karışık Meyveli Pasta Sepete Eklendi");           
        }

        private void pictureBox12_Click(object sender, EventArgs e)
        {
            string ad = Convert.ToString(dataGridView1.Rows[11].Cells[1].Value);
            int fyt = Convert.ToInt32(dataGridView1.Rows[11].Cells[2].Value);          
            veri(ad, fyt);
            MessageBox.Show("Karışık Meyveli Pasta Sepete Eklendi");            
        }
      
        private void timer1_Tick(object sender, EventArgs e)
        {
            label14.Text = label14.Text.Substring(1) + label14.Text.Substring(0, 1);
        }

        private void timer2_Tick(object sender, EventArgs e)
        {           
            saat.Text = DateTime.Now.ToLongTimeString();
        }       
    }
}