using System.Net.Http;
using System.Reactive;
using System.Threading.Tasks;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using ReactiveUI;

namespace Avalonia.NETCoreApp {
    public class Main : UserControl {
        private readonly HttpClient _client;
        public ReactiveCommand<string, Unit> OpenCommand { get; }
        public Main() {
            OpenCommand = ReactiveCommand.Create<string>(Open);
            _client = new HttpClient {
                BaseAddress = new("https://api.warframe.market")
            };

            InitializeComponent();
        }

        private void InitializeComponent() {
            AvaloniaXamlLoader.Load(this);
            GetData();
        }

        private async Task GetData() {
            var data = await _client.AsJson<Items>("/v1/items", HttpMethods.Get, null, 
                ("Platform", "pc"), ("Language", "ru"));
            
            var control = this.FindControl<ListBox>("Box");
            
            control.Items = data.Payload.Items;
        }

        private void Open(string urlName) {
            throw new System.NotImplementedException();
        }
    }
}