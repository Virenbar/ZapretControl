namespace ZapretControl.Model
{
    public class ControlSettings
    {
        public bool AutostartControl { get; set; }
        public GameFilterMode GameFilterMode { get; set; } = new();
        public bool LaunchMinimized { get; set; }
        public string ScriptName { get; set; }
        public string ScriptPath { get; set; }
        public bool StopDriver { get; set; }
        public string ZapretDirectory { get; set; }
        public string ZapretPath { get; set; }
    }
    public class GameFilterMode
    {
        public bool TCP { get; set; }
        public string TCPRange { get; set; } = "1024-65535";

        public bool UDP { get; set; }
        public string UDPRange { get; set; } = "1024-65535";
    }
}