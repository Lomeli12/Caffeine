using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace Caffeine {
    public class Caffeine : ApplicationContext {
        Thread wakeThread;
        NotifyIcon trayIcon;
        ContextMenu trayMenu;

        public MenuItem enableItem, whiteListItem;
        List<string> whiteList;

        public Caffeine() {
            whiteList = new List<string>();
            trayIcon = new NotifyIcon();

            MenuItem[] menu = new[] {
                enableItem = new MenuItem("Enable Caffeine", new EventHandler(ToggleClicked), Shortcut.None),
                whiteListItem = new MenuItem("Use Whitelist", new EventHandler(WhiteList), Shortcut.None),
                new MenuItem("Edit Whitelist", new EventHandler(EditList), Shortcut.None),
                new MenuItem("-"),
                new MenuItem("Quit", new EventHandler(Quit), Shortcut.None),
            };
            trayMenu = new ContextMenu(menu);

            enableItem.DefaultItem = true;

            trayIcon.ContextMenu = trayMenu;
            trayIcon.DoubleClick += (o, args) => enableItem.PerformClick();
            trayIcon.Text = "Caffeine";

            Enabled = false;

            Application.ApplicationExit += (o, args) => {
                // Hide the tray icon
                trayIcon.Visible = false;

                // This will quit the wake thread upon the next iteration of its loop.
                Running = false;

                // Interrupt the thread if it's sleeping so that it will quit.
                if (wakeThread.ThreadState == ThreadState.WaitSleepJoin)
                    wakeThread.Interrupt();
            };

            Start();
        }

        public void Start() {
            trayIcon.Visible = true;
            trayIcon.ShowBalloonTip(3000,
                                    Properties.Resources.StartupMessageTitle,
                                    Properties.Resources.StartupMessage,
                                    ToolTipIcon.Info);

            wakeThread = new Thread(new ThreadStart(CaffeineThreadStart));
            wakeThread.Start();
        }

        private void Quit(object sender, EventArgs e) {
            OnMainFormClosed(this, EventArgs.Empty);
        }

        private void ToggleClicked(object sender, EventArgs e) {
            Enabled = !Enabled;
        }

        private void WhiteList(object sender, EventArgs e) {
            EnabledWhiteList = !EnabledWhiteList;
        }

        private void EditList(object sender, EventArgs e) {
            EditWhitelist form = new EditWhitelist(whiteList);
            form.ShowDialog();
            whiteList.Clear();
            whiteList.AddRange(form.getProcessList());
            form.Dispose();
        }

        public void CaffeineThreadStart() {
            Running = true;
            while (Running) {
                if (Enabled) {
                    bool simulate = true;
                    if (EnabledWhiteList) {
                        simulate = isWhiteListedProcessRunning();
                        trayIcon.Icon = (simulate ? Properties.Resources.FullCup : Properties.Resources.EmptyCup);
                    }
                    if (simulate)
                        simulateF15();
                }
            }
        }

        public bool isWhiteListedProcessRunning() {
            System.Diagnostics.Process[] processList = System.Diagnostics.Process.GetProcesses();
            if (processList != null && processList.Length > 0) {
                foreach (System.Diagnostics.Process process in processList) {
                    if (process != null && whiteList.Contains(process.ProcessName))
                        return true;
                }
            }
            return false;
        }

        public void simulateF15() {
            SendKeys.SendWait("{F15}");
            try {
                Thread.Sleep(new TimeSpan(0, 0, 59));
            } catch (ThreadInterruptedException) { }
        }

        public bool Enabled {
            get {
                return _enabled;
            } set {
                _enabled = value;
                enableItem.Checked = value;
                trayIcon.Icon = (value ? Properties.Resources.FullCup : Properties.Resources.EmptyCup);
            }
        }

        public bool EnabledWhiteList {
            get {
                return _whiteList;
            } set {
                _whiteList = value;
                whiteListItem.Checked = value;
            }
        }
        bool _enabled;
        bool _whiteList;

        public bool Running {
            get;
            protected set;
        }

        public List<string> ProcessWhiteList {
            get {
                return whiteList;
            }
        }
    }
}
