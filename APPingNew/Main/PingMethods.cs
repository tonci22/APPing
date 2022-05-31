using APPingNew.Settings;
using System;
using System.Net;

namespace APPingNew
{
    static class PingMethods
    {
        public static int LastOctet(string iPAddress)
        {
            if (!IsValidIPAddress(iPAddress))
                return 0;

            string[] separatedOctets = iPAddress.Split('.');
            int lastIPOctet = 0;

            int.TryParse(separatedOctets[3], out lastIPOctet);  //check for valid string

            return lastIPOctet;
        }

        public static bool IsValidIPAddress(string iPAddress)
        {
            IPAddress ipAddress;

            if (IPAddress.TryParse(iPAddress, out ipAddress))  //check for valid IPAddress
                return true;
            else
                return false;
        }

        public static string PrintLocation(string ipAddress)
        {
            if (UserSettings.IPAddressLocation.ContainsKey(ipAddress))
                return UserSettings.IPAddressLocation[ipAddress];

            return "NOT SPECIFIED";
        }

        public static string IncrementedOctet(string ipAddress, int number)
        {
            string[] octet = ipAddress.Split('.');
            return octet[0] + "." + octet[1] + "." + octet[2] + "." + (number + 1);
        }
    }
}
