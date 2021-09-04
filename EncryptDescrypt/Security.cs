using System;
using System.Windows.Forms;

namespace EncryptDescrypt
{
    public partial class Security : Form
    {
        public Security()
        {
            InitializeComponent();
        }

        private void btnEncrypt_Click(object sender, EventArgs e)
        {
            txtDecrypt .Text = Encrypter.Encrypt(txtEncrypt.Text);
        }

        private void btnDecrypt_Click(object sender, EventArgs e)
        {
            txtEncrypt .Text =  Encrypter.Decrypt(txtDecrypt.Text);
        }
    }
}
