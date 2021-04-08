using System.Collections.Generic;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;

namespace Avalonia.NETCoreApp {
    public class MainWindow : NavigationWindow {
        public MainWindow() {
            InitializeComponent();
#if DEBUG
            this.AttachDevTools();
#endif
        }

        private void InitializeComponent() {
            AvaloniaXamlLoader.Load(this);
            
            var defaultPage = new Main();
            var navigation = new List<(string, Control)> {
                ("Main", defaultPage),
                ("Settings", new Settings())
            };
            
            base.InitializeComponent(navigation);
            NavigateTo(defaultPage);
        }
    }
}