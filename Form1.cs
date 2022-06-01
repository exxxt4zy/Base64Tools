using Gaylord;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Gaylord
{
    public partial class Form1 : Form
    {
        byte[] _res = null;

        public Form1()
        {
            InitializeComponent();
        }

        private byte[] FromBase64(string str)
        {
            if (string.IsNullOrEmpty(str))
            {
                MessageBox.Show("BASE64 string not set", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return null;
            }

            byte[] res = null;
            try
            {
                res = Convert.FromBase64String(str);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error reading BASE64: " + ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            return res;
        }

        private void encodeButton_Click(object sender, EventArgs e)
        {
            string textEncode = textBox1.Text;
            if (textEncode == null)
                return;

            var textBytes = Encoding.UTF8.GetBytes(textEncode);
            string _encode = Convert.ToBase64String(textBytes);
            textBox2.Text = _encode;
            label2.Text = "";
        }
        private void decode_Click(object sender, EventArgs e)
        {
            /*string textDecode = textBox1.Text;
            if (textDecode == null)
                return;

            _result = Convert.FromBase64String(textDecode);
            string encodedText = Encoding.UTF8.GetString(_result);
            textBox2.Text = encodedText;
            */
            _res = FromBase64(textBox1.Text);
            if (_res != null)
            {
                string encodedText = Encoding.UTF8.GetString(_res);
                textBox2.Text = encodedText;
                label2.Text = "";
            }
            else
                return;
        }

        private void exitButton_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Вы уверены, что хотите выйти?", Application.ProductName, MessageBoxButtons.YesNo) != DialogResult.No)
                Application.Exit();
        }

        

        

        private void label2_Click(object sender, EventArgs e)
        {
            
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start("https://t.me/qquade");
        }

        private void clipboardButton_Click(object sender, EventArgs e)
        {
            Clipboard.SetDataObject(textBox2.Text);
        }
    }
}
