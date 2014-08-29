using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using System.IO;

namespace Caffeine {
    static class Program {
        static string configName = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + @"\caffine";
        static bool enableWhiteList;
        [STAThread]
        static void Main() {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Caffeine cafe = new Caffeine();
            loadConfig(cafe);
            cafe.whiteListItem.Checked = enableWhiteList;
            cafe.EnabledWhiteList = enableWhiteList;
            Application.Run(cafe);
            saveConfig(cafe);
        }

        static void loadConfig(Caffeine cafe) {
            StreamReader reader;
            if (File.Exists(configName + ".ini")) {
                reader = new StreamReader(configName + ".ini");
                string readLine = reader.ReadLine();
                if (!string.IsNullOrWhiteSpace(readLine)) {
                    string[] option = readLine.Split('=');
                    if (option != null && option.Length > 1)  {
                        string tag = option[0];
                        if (tag.Equals("enableWhiteList"))
                            enableWhiteList = bool.Parse(option[1]);
                    }
                }
                reader.Close();
            }
            if (File.Exists(configName + ".conf")) {
                reader = new StreamReader(configName + ".conf");
                string line;
                while (!string.IsNullOrWhiteSpace(line = reader.ReadLine())) {
                    if (!cafe.ProcessWhiteList.Contains(line))
                        cafe.ProcessWhiteList.Add(line);
                }
                cafe.ProcessWhiteList.Sort();
                reader.Close();
            }
        }

        static void saveConfig(Caffeine cafe) {
            enableWhiteList = cafe.EnabledWhiteList;
            StreamWriter writer;
            // Config
            writer = new StreamWriter(configName + ".ini");
            writer.WriteLine("enableWhiteList=" + enableWhiteList);
            writer.Flush();
            writer.Close();
            // WhiteList
            writer = new StreamWriter(configName + ".conf");
            foreach (string processName in cafe.ProcessWhiteList) {
                writer.WriteLine(processName);
            }
            writer.Flush();
            writer.Close();
        }
    }
}
