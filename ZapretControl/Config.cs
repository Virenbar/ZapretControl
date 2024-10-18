using System;
using System.IO;
using System.Xml.Serialization;
using ZapretControl.Model;

namespace ZapretControl
{
    internal static class Config
    {
        public static ControlSettings Current { get; set; }

        private static ControlSettings Default => new()
        {
            StopDriver = true
        };

        public static void Load()
        {
            if (File.Exists(Constants.ConfigPath))
            {
                try
                {
                    var XS = new XmlSerializer(typeof(ControlSettings));
                    using var SR = new StreamReader(Constants.ConfigPath);
                    Current = (ControlSettings)XS.Deserialize(SR);

                    var def = Default;
                }
                catch (Exception)
                {
                    Current = Default;
                }
            }
            else
            {
                Current = Default;
            }
        }

        public static void Save()
        {
            var XS = new XmlSerializer(typeof(ControlSettings));
            using var SW = new StreamWriter(Constants.ConfigPath);
            XS.Serialize(SW, Current);
        }
    }
}