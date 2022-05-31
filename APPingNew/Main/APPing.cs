using APPingNew.Settings;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;

namespace APPingNew
{
    class APPing
    {
        private static readonly byte[] buffer = Encoding.ASCII.GetBytes("aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa");

        private Ping ping = null;
        private PingOptions pingOptions = null;
        private int ttl = 64;
        private bool dontFragment = false;

        public int Timeout { get; set; } = 1000;
        public string Hostname { get; set; } = "127.0.0.1";
        public PingReply PingReplyResult { get; private set; } = null;

        public APPing()
        {
            pingOptions = new PingOptions(ttl, dontFragment);
        }

        public APPing(string hostName) : this()
        {
            Hostname = hostName;
        }

        public async Task SendPacket()
        {
            ping = new Ping();
            PingReplyResult = await ping.SendPingAsync(Hostname, Timeout, buffer, pingOptions);
        }

        public void CancelPingAsync()
        {
            ping.SendAsyncCancel();
        }

        public string PrintPingData()
        {
            string address = "", rtt = "", status = "";

            if (PingReplyResult.Status == IPStatus.Success)
            {
                address = PingReplyResult.Address.ToString();
                rtt = PingReplyResult.RoundtripTime.ToString();
                status = PingReplyResult.Status.ToString();
            }
            else
            {
                address = Hostname;
                rtt = "-";
                status = PingReplyResult.Status.ToString();
            }

            return address + TEXTEDIT.SEPARATOR + "RTT: " + rtt + TEXTEDIT.SEPARATOR + "STATUS: " + status;
        }
    }
}
