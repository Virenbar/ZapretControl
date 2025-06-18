namespace ZapretControl.Model
{
    public class ControlSettings
    {
        public bool AutostartControl { get; set; }
        public bool GameFilter { get; set; }
        public bool LaunchMinimized { get; set; }
        public string ScriptName { get; set; }
        public string ScriptPath { get; set; }
        public bool StopDriver { get; set; }
        public string ZapretDirectory { get; set; }
        public string ZapretPath { get; set; }
    }
}