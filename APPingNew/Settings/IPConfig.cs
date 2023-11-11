using System;
using System.Windows.Forms;
using System.Linq;

namespace APPingNew.Settings
{
    public partial class IPConfig : Form
    {
        public IPConfig()
        {
            InitializeComponent();
            AcceptButton = btnOK;
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            UserSettings.IPAddressLocation.Clear();
            bool rightInput = true;

            for (int i = 0; i < pnIPConfig.Controls.Count; i++)
            {
                if (((IPAddressLocation)pnIPConfig.Controls[i]).GetIPAddress.Length == 0)
                    continue;

                try
                {
                    UserSettings.IPAddressLocation.Add(((IPAddressLocation)pnIPConfig.Controls[i]).GetIPAddress, ((IPAddressLocation)pnIPConfig.Controls[i]).GetLocation);
                }
                catch(Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error");
                    rightInput = false;
                }
            }

            UserSettings.WriteToFile();

            if(rightInput)
                Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void IPConfig_Load(object sender, EventArgs e)
        {
            Location = new System.Drawing.Point(Owner.Location.X + Owner.Size.Width, Location.Y);
            UserSettings.LoadDataFromFile();

            for (int i = 0;  i < UserSettings.IPAddressLocation.Count; i++)
            {
                ((IPAddressLocation)pnIPConfig.Controls[i]).GetIPAddress = UserSettings.IPAddressLocation.ElementAt(i).Key;
                ((IPAddressLocation)pnIPConfig.Controls[i]).GetLocation = UserSettings.IPAddressLocation.ElementAt(i).Value;
            }
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            UserSettings.ResetSettings();
            Close();
        }

        private void IPConfig_FormClosed(object sender, FormClosedEventArgs e)
        {
            ((MainForm)Owner).FirstIPAddressText = UserSettings.FindSmallestIPAddress();
            ((MainForm)Owner).LastIPAddressText = UserSettings.FindLargestIPAddress();
        }
    }
}
