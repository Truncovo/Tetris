using System.Windows;
using System.Windows.Input;

namespace WindowsAndInput
{
    public class GeneralWindow : Window
    {
        private static GeneralWindow _singleton;

        private GeneralWindow()
        {

        }
        public static GeneralWindow Get
        {
            get
            {
                if (_singleton == null)
                    _singleton = new GeneralWindow();
                return _singleton;
            }
        }

        public void Run()
        {
            var app = new Application();
                app.Run(this);
        }

        private IWindowSetting _windowSetting;
        public IWindowSetting WindowSetting
        {
            get => _windowSetting;
            set
            {
                _windowSetting = value;

                this.ClearThisWindow();
                _windowSetting.SetWindow(this);
            }
        }

        private void ClearThisWindow()
        {
            this.Content = null;
            //TODO set default parameters of window
        }

        protected override void OnKeyDown(KeyEventArgs e)
        {
            _windowSetting.ProcesKeyDown(e);
            base.OnKeyDown(e);
        }

        protected override void OnMouseDown(MouseButtonEventArgs e)
        {
            _windowSetting.ProcesMouseDown(e);
            base.OnMouseDown(e);
        }
    }
}
