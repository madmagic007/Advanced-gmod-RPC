using DiscordRPC;
using Flurl;
using Flurl.Http;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;

namespace Advancedgmodrpc {

    class PresenceManager {

        public static AddressList addresses;

        private static DiscordRpcClient client;
        private static RichPresence presence;
        private static Timestamps timestamps;
        private static string lastServer = "";
        private static Assets assets;

        public static void Init() {
            client = new DiscordRpcClient("772853901396279376");
            client.Initialize();

            timestamps = GetTimestamps();
            assets = new Assets {
                LargeImageKey = "gmod",
                LargeImageText = "Garry's Mod RPC by MadMagic"
            };
            presence = new RichPresence {
                Details = "Just started playing"
            };
            UpdatePresence();
        }

        public static void UpdatePresence() {
            if (client == null || client.IsDisposed) Init();
            presence.Assets = assets;
            if (Config.config.time) presence.Timestamps = timestamps;
            else presence.Timestamps = null;
            client.SetPresence(presence);
        }

        public static void StopPresence() {
            if (client == null || client.IsDisposed) return;
            client.Dispose();
        }

        public static void ReadAndUpdate(string gamemode) {
            string map = ReadString(addresses.map);

            if (map.Equals("")) {
                if (!presence.Details.Equals("In menus") && Config.config.resetTime) timestamps = GetTimestamps();
                lastServer = "";
                presence = new RichPresence {
                    Details = "In menus"
                };
            } else {
                string niceGamemode = GamemodeConverter.GetNiceGameMode(gamemode);
                string serverName = ReadString(addresses.serverName);

                bool sameServer = serverName.Equals(lastServer);
                lastServer = serverName;

                if (!sameServer && Config.config.time && Config.config.resetTime) timestamps = GetTimestamps();

                presence.State = $"Playing {niceGamemode} on {map}";
                presence.Details = "Playing on " + serverName;

                assets = new Assets {
                    SmallImageKey = gamemode,
                    SmallImageText = niceGamemode,
                    LargeImageKey = "gmod",
                    LargeImageText = "Garry's Mod RPC by MadMagic"
                };
            }
            UpdatePresence();
        }

        private static Timestamps GetTimestamps() => new Timestamps {
            Start = DateTime.Now,
            StartUnixMilliseconds = (ulong) DateTimeOffset.Now.ToUnixTimeMilliseconds()
        };

        public static string ReadString(string address) => Program.m.ReadString(address, length: 100);
    }
}
