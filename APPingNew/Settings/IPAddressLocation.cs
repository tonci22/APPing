using System;
using System.Drawing;
using System.Windows.Forms;

namespace APPingNew.Settings
{
    public partial class IPAddressLocation : UserControl
    {
        public string GetIPAddress { get => txtIPAddress.Text; set { txtIPAddress.Text = value; } }
        public string GetLocation { get => txtLocation.Text; set { txtLocation.Text = value; } }

        public IPAddressLocation()
        {
            InitializeComponent();
        }

        private void txtIPAddress_TextChanged(object sender, EventArgs e)
        {
            if (PingMethods.IsValidIPAddress(txtIPAddress.Text))
                txtIPAddress.BackColor = Color.White;
            else if (txtIPAddress.Text.Length == 0)
                txtIPAddress.BackColor = Color.White;
            else
                txtIPAddress.BackColor = Color.Red;
        }
    }
}
