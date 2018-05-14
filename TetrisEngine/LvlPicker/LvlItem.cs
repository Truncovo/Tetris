using WindowsAndInput;

namespace TetrisEngine
{
    public class LvlItem
    {
        public string Title { get; set; }
        public bool Active { get; set; }
        public IWindowSetting WindowSetting { get; }

        public LvlItem(IWindowSetting windowSetting, string title, bool active = true)
        {
            WindowSetting = windowSetting;
            Title = title;
            Active = active;

        }
    }
}