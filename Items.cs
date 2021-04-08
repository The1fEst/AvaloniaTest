using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Avalonia.NETCoreApp {
    public class Items {
        public Payload Payload { get; set; } = null!;
    }

    public class Payload {
        public List<Item> Items { get; set; } = new();
    }

    public class Item {
        public string Id { get; set; } = "";
        
        [JsonPropertyName("url_name")]
        public string UrlName { get; set; } = "";
        
        [JsonPropertyName("item_name")]
        public string ItemName { get; set; } = "";
        
        public string Thumb { get; set; } = "";
    }
}