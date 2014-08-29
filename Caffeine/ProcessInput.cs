
using System;
using System.Drawing;
using System.Windows.Forms;

namespace Caffeine {
    public partial class ProcessInput : Form {
        public ProcessInput() {
            InitializeComponent();
        }

        private string processName;

        void OkClick(object sender, EventArgs e) {
            if (!string.IsNullOrWhiteSpace(textBox1.Text))
                ProcessName = textBox1.Text;
            this.Close();
        }

        public string ProcessName {
            get {
                return processName;
            } set {
                processName = value;
            }
        }
    }
}
