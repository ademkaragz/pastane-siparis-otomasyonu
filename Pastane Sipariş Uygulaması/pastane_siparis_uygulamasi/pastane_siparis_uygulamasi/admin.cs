using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace pastane_siparis_uygulamasi
{
    public partial class admin : Form
    {
        public admin()
        {
            InitializeComponent();
        }

        private void textBox2_Click(object sender, EventArgs e)
        {
            textBox2.Text = "";
        }

        private void textBox1_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "" || textBox2.Text == "")
            {
                MessageBox.Show("Kullanıcı adı ve/veya şifre boş bırakılamaz", "Uyarı");
            }
            else
            {
                if (textBox1.Text == "admin" && textBox2.Text == "admin" || textBox1.Text == "admin" && textBox2.Text == "123") 
                {
                    kullanıcı kullanıcı = new kullanıcı();
                    kullanıcı.Show();
                    kullanıcı.TopMost = true;
                    this.Hide();
                }
                else
                {
                    MessageBox.Show("Kullanıcı adı ve/veya şifre yanlış", "Uyarı2");
                }
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
