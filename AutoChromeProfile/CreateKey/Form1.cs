using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CreateKey
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            string data = Secu.Base64Decode(textBox1.Text);
            if(string.IsNullOrEmpty(data))
            {

            }    
            else
            {
                data += "dhloc" + textBox3.Text + "dhloc" + RandomString(10);
                textBox2.Text = Secu.Base64Encode(data);
            }    
        }

        private static Random random = new Random();

        public static string RandomString(int length)
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            return new string(Enumerable.Repeat(chars, length)
                .Select(s => s[random.Next(s.Length)]).ToArray());
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            string data = Secu.Base64Decode(textBox1.Text);
            if (string.IsNullOrEmpty(data))
            {

            }
            else
            {
                data += "dhloc" + textBox3.Text + "dhloc" + RandomString(10);
                textBox2.Text = Secu.Base64Encode(data);
            }
        }

        private void textBox3_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
