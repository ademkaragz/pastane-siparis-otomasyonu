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
using System.Drawing.Printing;
using System.IO;
using System.Collections;

namespace pastane_siparis_uygulamasi
{
    public partial class ikinciekran : Form
    {
        public ikinciekran()
        {
            InitializeComponent();
        }

        SqlCommand komut;
        SqlDataReader read;
        SqlConnection baglanti;

        private StringReader myReader;

        void siparis()
        {
            baglanti = new SqlConnection(baglan.sqlconnection);
            komut = new SqlCommand("select *from sepet", baglanti);
            baglanti.Open();
            komut.Connection = baglanti;
            read = komut.ExecuteReader();
            while (read.Read())
            {
                listBox1.Items.Add(read["urun_ad"]);               
            }
            baglanti.Close();
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
        void rastgele()
        {
            int[] sayilar = new int[1];           
            
                Random rnd = new Random();
                for (int i = 0; i < 1; i++)
                {
                    sayilar[i] = rnd.Next(1, 999);
                    listBox1.Items.Add(sayilar[i]);                    
                }
        }
               
        void yazdir()
        {           
            printDialog1.Document = printDocument1;
            string strText = "";
            foreach (object x in listBox1.Items)
            {
                strText = strText + x.ToString() + "\n";
            }
            myReader = new StringReader(strText);
           
            this.printDocument1.Print();            
        }

        public void ikinciekran_Load(object sender, EventArgs e)
        {
            this.Location = Screen.AllScreens[1].Bounds.Location; //ikinci ekrana yansıtma kodu
            this.WindowState = FormWindowState.Maximized;          

            rastgele();
            siparis();            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            yazdir();
            this.Close();           
            KayitSil();
        }
      
        private void printDocument1_PrintPage_1(object sender, PrintPageEventArgs e)
        {
            this.printDocument1.PrintPage += new System.Drawing.Printing.PrintPageEventHandler(this.printDocument1_PrintPage_1);
            float linesPerPage = 0;
            float yPosition = 0;
            int count = 0;
            float leftMargin = e.MarginBounds.Left;
            float topMargin = e.MarginBounds.Top;
            string line = null;
            Font printFont = this.listBox1.Font;
            SolidBrush myBrush = new SolidBrush(Color.Black);
            
            linesPerPage = e.MarginBounds.Height / printFont.GetHeight(e.Graphics);
           
            while (count < linesPerPage && ((line = myReader.ReadLine()) != null))
            {
                // sonraki satırın konumunu ayarlama
                // yazıcıya göre yazı tipinin yüksekliği
                yPosition = topMargin + (count * printFont.GetHeight(e.Graphics));
                // sonraki satırı çiz
                e.Graphics.DrawString(line, printFont,myBrush, leftMargin,yPosition, new StringFormat());
                count++;
            }
            // fazla satır varsa başka bir sayfa yazdır
            if (line != null)
                e.HasMorePages = true;
            else
                e.HasMorePages = false;

            myBrush.Dispose();
        }   
        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}

