using Newtonsoft.Json.Linq;
using System.Threading;

namespace Advancedgmodrpc {

    class GamemodeConverter {

        public static JObject gamemodes;

        public static string GetNiceGameMode(string gamemode) {
            if (!gamemodes.ContainsKey(gamemode)) {
                Config.AppendGamemode(gamemode);
                return Thread.CurrentThread.CurrentCulture.TextInfo.ToTitleCase(gamemode);
            }
            return (string) gamemodes[gamemode];
        }
    }
}
