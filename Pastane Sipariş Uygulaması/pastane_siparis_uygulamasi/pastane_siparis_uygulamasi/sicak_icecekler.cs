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
    public partial class sicak_icecekler : Form
    {
        public sicak_icecekler()
        {
            InitializeComponent();
        }

        private void sicak_icecekler_Load(object sender, EventArgs e)
        {
            verigetir();
            dataGridView1.Refresh();

            string ad = Convert.ToString(dataGridView1.Rows[26].Cells[1].Value);
            int fyt = Convert.ToInt32(dataGridView1.Rows[26].Cells[2].Value);
            label1.Text = ad + Environment.NewLine + fyt + "TL";

            string ad1 = Convert.ToString(dataGridView1.Rows[27].Cells[1].Value);
            int fyt1 = Convert.ToInt32(dataGridView1.Rows[27].Cells[2].Value);
            label2.Text = ad1 + Environment.NewLine + fyt1 + "TL";

            string ad2 = Convert.ToString(dataGridView1.Rows[28].Cells[1].Value);
            int fyt2 = Convert.ToInt32(dataGridView1.Rows[28].Cells[2].Value);
            label3.Text = ad2 + Environment.NewLine + fyt2 + "TL";

            string ad3 = Convert.ToString(dataGridView1.Rows[29].Cells[1].Value);
            int fyt3 = Convert.ToInt32(dataGridView1.Rows[29].Cells[2].Value);
            label4.Text = ad3 + Environment.NewLine + fyt3 + "TL";

            string ad4 = Convert.ToString(dataGridView1.Rows[30].Cells[1].Value);
            int fyt4 = Convert.ToInt32(dataGridView1.Rows[30].Cells[2].Value);
            label5.Text = ad4 + Environment.NewLine + fyt4 + "TL";

            string ad5 = Convert.ToString(dataGridView1.Rows[31].Cells[1].Value);
            int fyt5 = Convert.ToInt32(dataGridView1.Rows[31].Cells[2].Value);
            label6.Text = ad5 + Environment.NewLine + fyt5 + "TL";
        }
        
        void veri(string a, int b)
        {
            SqlConnection baglanti = new SqlConnection(baglan.sqlconnection);            
            {
                if (baglanti.State == ConnectionState.Closed)
                    baglanti.Open();
                string kayit = "insert into sepet(urun_ad,urun_fyt) values (@urun_ad,@urun_fyt)";
                SqlCommand komut = new SqlCommand(kayit, baglanti);
                komut.Parameters.AddWithValue("@urun_ad", a);
                komut.Parameters.AddWithValue("@urun_fyt", b);
                komut.ExecuteNonQuery();
                baglanti.Close();
                MessageBox.Show("Ürün Sepete Eklendi");
            }
        }

        void verigetir()
        {
            SqlConnection baglanti = new SqlConnection(baglan.sqlconnection);
            baglanti = new SqlConnection(baglan.sqlconnection);
            baglanti.Open();
            string kayit = "SELECT * from urunler";
            SqlCommand komut = new SqlCommand(kayit, baglanti);
            SqlDataAdapter da = new SqlDataAdapter(komut);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
            baglanti.Close();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            string ad = Convert.ToString(dataGridView1.Rows[26].Cells[1].Value);
            int fyt = Convert.ToInt32(dataGridView1.Rows[26].Cells[2].Value);
            veri(ad, fyt); 
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            string ad = Convert.ToString(dataGridView1.Rows[27].Cells[1].Value);
            int fyt = Convert.ToInt32(dataGridView1.Rows[27].Cells[2].Value);
            veri(ad, fyt);
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            string ad = Convert.ToString(dataGridView1.Rows[28].Cells[1].Value);
            int fyt = Convert.ToInt32(dataGridView1.Rows[28].Cells[2].Value);
            veri(ad, fyt);
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            string ad = Convert.ToString(dataGridView1.Rows[29].Cells[1].Value);
            int fyt = Convert.ToInt32(dataGridView1.Rows[29].Cells[2].Value);
            veri(ad, fyt);
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            string ad = Convert.ToString(dataGridView1.Rows[30].Cells[1].Value);
            int fyt = Convert.ToInt32(dataGridView1.Rows[30].Cells[2].Value);
            veri(ad, fyt);
        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            string ad = Convert.ToString(dataGridView1.Rows[31].Cells[1].Value);
            int fyt = Convert.ToInt32(dataGridView1.Rows[31].Cells[2].Value);
            veri(ad, fyt);
        }      
    }
}
