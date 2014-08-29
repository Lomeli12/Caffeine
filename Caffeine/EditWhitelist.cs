using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;
using System.IO;

namespace Caffeine {
    public partial class EditWhitelist : Form {
        private List<string> processList;
        public EditWhitelist() {
            InitializeComponent();
            processList = new List<string>();
        }

        public EditWhitelist(List<string> list) {
            InitializeComponent();
            processList = new List<string>();
            if (list != null && list.Count > 0) {
                foreach (string process in list) {
                    whiteList.Items.Add(process);
                }
            }
        }

        void EditWhitelistLoad(object sender, EventArgs e) {
            Process[] processList = Process.GetProcesses();
            if (processList != null && processList.Length > 0) {
                foreach (Process process in processList) {
                    runningList.Items.Add(process.ProcessName);
                }
            }
        }

        public List<string> getProcessList() {
            if (processList == null)
                processList = new List<string>();
            return processList;
        }

        void OkBtnClick(object sender, EventArgs e) {
            if (whiteList.Items.Count > 0) {
                foreach (object obj in whiteList.Items) {
                    processList.Add(obj.ToString());
                }
            }
            this.Close();
        }

        void AddBtnClick(object sender, EventArgs e) {
            object item = runningList.SelectedItem;
            if (item != null && !whiteList.Items.Contains(item.ToString()))
                whiteList.Items.Add(item.ToString());
        }

        void RemoveBtnClick(object sender, EventArgs e) {
            int index = whiteList.SelectedIndex;
            if (index > -1 && index < whiteList.Items.Count)
                whiteList.Items.RemoveAt(index);
        }

        void CustomProcessBtnClick(object sender, EventArgs e) {
            ProcessInput input = new ProcessInput();
            input.ShowDialog();
            if (!string.IsNullOrWhiteSpace(input.ProcessName) && !whiteList.Items.Contains(input.ProcessName))
                whiteList.Items.Add(input.ProcessName);
            input.Dispose();
        }
    }
}
