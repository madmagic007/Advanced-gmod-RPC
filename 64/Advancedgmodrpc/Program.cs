using System;
using System.Diagnostics;
using System.Windows.Forms;
using Flurl.Http;
using Memory;
using Microsoft.Win32;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Timer = System.Threading.Timer;

namespace Advancedgmodrpc {

    class Program {

        public static Mem m;
        public static Timer timer;
        private static bool assigned;

        static void Main(string[] args) {
            Registry.CurrentUser.OpenSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run", true)
                .SetValue("GmodRPC", Application.ExecutablePath + " bootStartup");

            Config.Init();
            if (args.Length > 0 && args[0].Equals("bootStartup") && !Config.config.startup) Application.Exit();

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            Application.Run(new SystemtrayHandler());
        }

        public static void StartTimer() {
            if (PresenceManager.addresses == null) {
                JObject o = JObject.Parse("https://raw.githubusercontent.com/madmagic007/Advanced-gmod-RPC/main/mapping.json".GetStringAsync().Result);

                if (!o.HasValues) return;
                PresenceManager.addresses = JsonConvert.DeserializeObject<AddressList>(o["64"].ToString());
                GamemodeConverter.gamemodes = (JObject) o["gamemodes"];
            }

            try {
                timer.Dispose();
            } catch (Exception) { }
            timer = new Timer(o => CheckGameAndUpdate(), null, 0, Config.config.updateDelay * 1000);
        }

        public static void CheckGameAndUpdate() {
            if (!IsRunning(out int id)) {
                if (assigned) {
                    assigned = false;
                    m.CloseProcess();
                    m = null;
                    PresenceManager.StopPresence();
                }
                return;
            }

            if (!assigned) {
                assigned = true;
                PresenceManager.Init();
            }

            if (m == null) m = new Mem();
            string gamemode = PresenceManager.ReadString(PresenceManager.addresses.gamemode);
            if (gamemode.Equals("")) {
                m = new Mem();
                m.OpenProcess(id);
                return;
            }

            PresenceManager.ReadAndUpdate(gamemode);
        }

        public static bool IsRunning(out int id) {
            Process[] procs = Process.GetProcessesByName("gmod");

            if (procs.Length != 0) {
                foreach (Process proc in procs) {
                    if (proc.MainWindowTitle.Equals("")) continue;
                    id = proc.Id;
                    return proc.MainWindowTitle.Contains("x64");
                }
            }
            id = 0;
            return false;
        }
    }
 }