using Advancedgmodrpc.Properties;
using System.Windows.Forms;
using static System.Windows.Forms.Menu;

namespace Advancedgmodrpc {

    class SystemtrayHandler : ApplicationContext {

        private static NotifyIcon trayIcon;

        public SystemtrayHandler() {

            trayIcon = new NotifyIcon {
                Text = "Garry's mod presence",
                ContextMenu = new ContextMenu(),
                Icon = Resources.AppIcon,
                Visible = true
            };

            MenuItemCollection items = trayIcon.ContextMenu.MenuItems;

            items.Add("Force restart", (s, e) => {
                PresenceManager.StopPresence();
                Program.StartTimer();
            });
            items.Add("Open settings", (s, e) => new SettingsGUI().Show());
            items.Add("Exit", (s, e) => Exit());

            Program.StartTimer();
        }

        private void Exit() {
            trayIcon.Visible = false;
            Application.Exit();
        }
    }
}
