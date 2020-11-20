using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace Advancedgmodrpc {

    [Serializable]
    class Config {

        private static FileInfo configFile;
        public static Config config;

        private static FileInfo unmappedFile;
        private static string unmappedGamemodes;

        public bool time = true;
        public bool startup = true;
        public int updateDelay = 10;
        public bool resetTime = true;

        public static void Init() {
            DirectoryInfo dir = Directory.CreateDirectory(Environment.GetEnvironmentVariable("APPDATA") + "/MadMagic/Advanced gmod RPC (x64)");

            configFile = new FileInfo(dir.FullName + "/GmodRPC.mccfg");
            if (!configFile.Exists) configFile.Create();

            try {
                byte[] data = File.ReadAllBytes(configFile.FullName);
                MemoryStream ms = new MemoryStream(data);
                config = (Config)new BinaryFormatter().Deserialize(ms);
            } catch (Exception) { config = new Config(); }


            unmappedFile = new FileInfo(dir.FullName + "/unmappedGamemodes.txt");
            if (!unmappedFile.Exists) unmappedFile.Create();
            unmappedGamemodes = File.ReadAllText(unmappedFile.FullName);
        }

        public static void Update() {
            MemoryStream ms = new MemoryStream();
            new BinaryFormatter().Serialize(ms, config);
            byte[] data = ms.ToArray();

            if (!configFile.Exists) configFile.Create();
            File.WriteAllBytes(configFile.FullName, data);
        }

        public static void AppendGamemode(string gamemode) {
            if (unmappedGamemodes.Contains(gamemode)) return;
            unmappedGamemodes += gamemode + "\n";
            if (!unmappedFile.Exists) unmappedFile.Create();
            File.WriteAllText(unmappedFile.FullName, unmappedGamemodes);
        }
    }
}
