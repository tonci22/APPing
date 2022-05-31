using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace APPingNew.Settings
{
    static class UserSettings
    {
        public static string DirectoryPath { get; private set; } = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + @"\Access Point Ping";
        public static string SettingsPath { get; private set; } = DirectoryPath + @"\Settings.txt";

        public static Dictionary<string, string> IPAddressLocation { get; set; } = new Dictionary<string, string>() { { "127.0.0.1", "default" } };

        public static void CreateDirectory()
        {
            Directory.CreateDirectory(DirectoryPath);
            fileExistsDataFill();
        }

        private static void fileExistsDataFill()
        {
            if (File.Exists(SettingsPath))
            {
                if (new FileInfo(SettingsPath).Length > 1)
                    IPAddressLocation = readFromFileToDictionary();
            }
            else
            {
                IPAddressLocation = fillDefaultData();
                WriteToFile();
            }
        }

        private static Dictionary<string, string> fillDefaultData()
        {
            return new Dictionary<string, string>()
            {
                { "192.168.1.1", "Mala soba" },
                { "192.168.1.2", "Hodnik" },
                { "192.168.1.3", "Potkrovlje" },
                { "192.168.1.4", "Ap. S" },
                { "192.168.1.5", "Ap. A" },
                { "192.168.1.6", "Ap. Mu" },
                { "192.168.1.7", "1. kat Hodnik" },
                { "192.168.1.8", "Velika Taraca" },
                { "192.168.1.9", "Ap. 1C" },
                { "192.168.1.10", "Ap. 1B" }
                //{ "127.0.0.1", "default" }
             };
        }

        public static void WriteToFile()
        {
            List<string> keysToRemove = new List<string>();

            using (StreamWriter sw = new StreamWriter(SettingsPath))
            {
                foreach (KeyValuePair<string, string> keyValue in IPAddressLocation)
                {
                    try
                    {
                        if (PingMethods.IsValidIPAddress(keyValue.Key))
                            sw.WriteLine(keyValue.Key + TEXTEDIT.SPLITTER + keyValue.Value);
                        else
                            keysToRemove.Add(keyValue.Key);
                    }
                    catch {   }
                }
            }
            if (keysToRemove.Count != 0)    //remove invalid ip addresses and write to file
            {
                foreach (var item in keysToRemove)
                {
                    IPAddressLocation.Remove(item);
                }
                WriteToFile();
            }
        }

        public static void ResetSettings()
        {
            IPAddressLocation = fillDefaultData();
            WriteToFile();
        }

        private static Dictionary<string, string> readFromFileToDictionary()
        {
            string[] allText;
            try
            {
                allText = File.ReadAllLines(SettingsPath);
                return new Dictionary<string, string>(allText.ToDictionary(key => key.Split(TEXTEDIT.SPLITTER)[0], value => value.Split(TEXTEDIT.SPLITTER)[1]));
            }
            catch
            {
                ResetSettings();
                return fillDefaultData();
            }
        }
    }
}
