using APPingNew.Settings;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Net.NetworkInformation;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace APPingNew
{
    public partial class MainForm : Form
    {
        public string FirstIPAddressText { get => txtFirstIPAddress.Text; set { txtFirstIPAddress.Text = value; } }
        public string LastIPAddressText { get => txtLastIPAddress.Text; set { txtLastIPAddress.Text = value; } }

        private int pingRepetitions = 3;
        private APPing pingSend;

        public MainForm()
        {
            InitializeComponent();
            AcceptButton = btnPing;
        }

        private void APPing_Load(object sender, EventArgs e)
        {
            UserSettings.CreateDirectory();

            txtFirstIPAddress.Enabled = false;
            txtLastIPAddress.Enabled = false;

            FirstIPAddressText = UserSettings.IPAddressLocation.Keys.First();
            LastIPAddressText = UserSettings.IPAddressLocation.Keys.LastOrDefault();

            enabledButtons(true);

            Location = new Point(Location.X - Size.Width / 2, Location.Y);
        }

        //start the async ping
        private async Task startPingAsync()
        {
            string[] iPAddresses = UserSettings.IPAddressLocation.Keys.ToArray();

            enabledButtons(false);  //disable input from user while pinging

            for (int i = 0; i < iPAddresses.Count(); i++)
            {
                for (int pingSameIP = 0; pingSameIP < pingRepetitions; pingSameIP++)
                {
                    pingSend = new APPing();
                    pingSend.Hostname = iPAddresses[i];

                    try
                    {
                        await pingSend.SendPacket();   //black magic
                    }
                    catch (OperationCanceledException)   //catch only for when the user cancels task
                    {
                        //din du nuffin
                        enableControls();
                        return;
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "ERROR");   //print some other kind of error
                        enableControls();
                        return;
                    }

                    if (!(pingSend.PingReplyResult.Status == IPStatus.Success)) //highlight error
                        txtPrintPings.SelectionBackColor = Color.Red;

                    txtPrintPings.AppendText(pingSend.PrintPingData() + TEXTEDIT.SEPARATOR + PingMethods.PrintLocation(iPAddresses[i]) + Environment.NewLine);  //output
                }
                txtPrintPings.AppendText(TEXTEDIT.BREAKLINES);
            }
            enableControls();
        }

        private void enableControls()
        {
            printExceededMaximumIPAddress();
            enabledButtons(true);
        }

        private async void btnPing_Click(object sender, EventArgs e)
        {
            await startPingAsync();

            txtPrintPings.AppendText(TEXTEDIT.BREAKLINES);
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            pingSend.CancelPingAsync();
        }

        //highlight output error
        private void printExceededMaximumIPAddress()
        {
            txtPrintPings.SelectionBackColor = Color.Blue;
            txtPrintPings.SelectionColor = Color.White;
            txtPrintPings.AppendText(" GOTOVO " + Environment.NewLine);
        }

        //enable/disable text boxes
        //check all controls and disable all text boxes and maybe some buttons
        private void enabledButtons(bool enabled)
        {
            btnPing.Enabled = enabled;
            btnCancel.Enabled = !enabled;
        }

        private void txtPrintPings_TextChanged(object sender, EventArgs e)
        {
            txtPrintPings.ScrollToCaret();
        }

        private void btnExpand_Click(object sender, EventArgs e)
        {
            var iPConfig = new IPConfig();
            iPConfig.Owner = this;
            iPConfig.ShowDialog();
        }
    }
}
