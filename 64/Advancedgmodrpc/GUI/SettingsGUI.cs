using System;
using System.Windows.Forms;

namespace Advancedgmodrpc {

    public partial class SettingsGUI : Form {

        public SettingsGUI() {
            InitializeComponent();

            numericDelay.Value = Config.config.updateDelay;
            checkTime.Checked = Config.config.time;
            checkResetTime.Checked = Config.config.resetTime;
            checkBoot.Checked = Config.config.startup;
        }

        private void BtnSave_Click(object sender, EventArgs e) {
            Config.config.updateDelay = Convert.ToInt32(numericDelay.Value);
            Config.config.time = checkTime.Checked;
            Config.config.resetTime = checkResetTime.Checked;
            Config.config.startup = checkBoot.Checked;
            Config.Update();
            Dispose(true);
            PresenceManager.UpdatePresence();
            Program.StartTimer();
        }
    }
}
