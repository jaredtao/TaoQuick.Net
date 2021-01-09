using Newtonsoft.Json;

using Qml.Net;

using System;
using System.Collections.Generic;
using System.IO;
namespace TaoQuick
{
    public struct TransPair
    {
        public string key;
        public string value;
    }
    public struct TransData
    {
        public string lang;
        public List<TransPair> trans;
    }
    public class Trans
    {
        readonly public static string sEn = "English";
        readonly public static string sZh = "简体中文";
        //<"English", <"key", "value">>
        private Dictionary<string, Dictionary<string, string>> map = new Dictionary<string, Dictionary<string, string>>();

        [NotifySignal("currentLangChanged")]
        public string currentLang { get; set; } = "English";

        [NotifySignal("transStringChanged")]
        public string transString { get; set; } = "";

        [NotifySignal("languagesChanged")]
        public List<string> languages { get; set; }

        public void loadFolder(string folder)
        {
            Console.WriteLine("Trans loadFolder " + folder);
            var dirInfo = new DirectoryInfo(folder);
            if (!dirInfo.Exists)
            {
                Console.WriteLine("Folder not exist");
                return;
            }
            var langs = new List<string>();
            langs.Add(sEn);
            var files = dirInfo.GetFiles("language_*.json");
            foreach (var file in files)
            {
                var lang = load(file.FullName);
                langs.Add(lang);
            }
            languages = langs;
            if (langs.Contains(sZh))
            {
                currentLang = sZh;
            }
            else
            {
                currentLang = sEn;
            }
            this.ActivateSignal("transStringChanged", "");
        }
        public string load(string filePath)
        {
            var reader = new StreamReader(filePath);
            var str = reader.ReadToEnd();
            var data = JsonConvert.DeserializeObject<TransData>(str);

            var pairs = new Dictionary<string, string>();
            foreach (var tran in data.trans)
            {
                bool ok1 = pairs.TryAdd(tran.key, tran.value);
                if (!ok1) {
                    Console.WriteLine("TryAdd key " + tran.key + " failed");
                }
            }
            Console.WriteLine("Added key count " + pairs.Count);
            bool ok = map.TryAdd(data.lang, pairs);
            if (!ok)
            {
                Console.WriteLine("TryAdd lang " + data.lang + " failed");
            }
            return data.lang;
        }

        public string tr(string source)
        {
            var value = "";
            try
            {
                value = map[currentLang][source];
            }
            catch
            {
                return value;
            }
            return value;

        }


    }
}
