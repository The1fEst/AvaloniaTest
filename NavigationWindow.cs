using System;
using System.Collections.Generic;
using Avalonia.Controls;
using Avalonia.Layout;
using Button = Avalonia.Controls.Button;
using Window = Avalonia.Controls.Window;

namespace Avalonia.NETCoreApp {
    public class NavigationWindow : Window {
        private Grid? _workspace;

        protected void InitializeComponent(IEnumerable<(string Name, Control Control)> controls) {
            var grid = new Grid {
                Margin = new(0),
                RowDefinitions = new() {
                    new() {
                        Height = new(30)
                    },
                    new(),
                    new() {
                        Height = new(50)
                    }
                }
            };

            var controlPanel = new StackPanel {
                Orientation = Orientation.Horizontal,
                HorizontalAlignment = HorizontalAlignment.Right,
            };

            var close = new Button {
                Content = "X",
            };
            close.Click += (_, _) => Close();

            controlPanel.Children.Add(close);
            grid.Children.Add(controlPanel);
            Grid.SetRow(controlPanel, 0);

            var navigationPanel = new StackPanel {
                Orientation = Orientation.Horizontal
            };

            foreach (var control in controls) {
                var navigationButton = new Button {
                    Content = control.Name,
                };

                navigationButton.Click += (_, _) => NavigateTo(control.Control);
                navigationPanel.Children.Add(navigationButton);
            }

            grid.Children.Add(navigationPanel);
            Grid.SetRow(navigationPanel, 2);

            _workspace = new() {
                Margin = new(20),
            };
            grid.Children.Add(_workspace);
            Grid.SetRow(_workspace, 1);

            Content = grid;
        }

        protected void NavigateTo(Control control) {
            _workspace?.Children.Clear();
            _workspace?.Children.Add(control);
        }
    }
}