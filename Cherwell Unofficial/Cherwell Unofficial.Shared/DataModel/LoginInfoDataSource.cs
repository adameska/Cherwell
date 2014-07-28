using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using Windows.Data.Json;
using Windows.Storage;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Imaging;

// The data model defined by this file serves as a representative example of a strongly-typed
// model.  The property names chosen coincide with data bindings in the standard item templates.
//
// Applications may use this model as a starting point and build on it, or discard it entirely and
// replace it with something appropriate to their needs. If using this model, you might improve app 
// responsiveness by initiating the data loading task in the code behind for App.xaml when the app 
// is first launched.

namespace Cherwell_Unofficial.Data
{
    /// <summary>
    /// Generic item data model.
    /// </summary>
    public class ServerInfo
    {
        public ServerInfo(String uniqueId, String name, String url)
        {
            this.UniqueId = uniqueId;
            this.ServerName = name;
            this.ServerUrl = url;
        }

        public string UniqueId { get; private set; }
        public string ServerName { get; private set; }
        public string ServerUrl { get; private set; }

        public override string ToString()
        {
            return this.ServerName;
        }
    }

    /// <summary>
    /// Creates a collection of groups and items with content read from a static json file.
    /// 
    /// SampleDataSource initializes with data read from a static json file included in the 
    /// project.  This provides sample data at both design-time and run-time.
    /// </summary>
    public sealed class LoginInfoDataSource
    {
        private static LoginInfoDataSource _loginInfoDataSource = new LoginInfoDataSource();

        private ObservableCollection<ServerInfo> _servers = new ObservableCollection<ServerInfo>();
        public ObservableCollection<ServerInfo> Servers
        {
            get { return this._servers; }
        }

        public static async Task<IEnumerable<ServerInfo>> GetServersAsync()
        {
            await _loginInfoDataSource.GetSampleDataAsync();

            return _loginInfoDataSource.Servers;
        }

        public static async Task<ServerInfo> GetServerAsync(string uniqueId)
        {
            await _loginInfoDataSource.GetSampleDataAsync();
            // Simple linear search is acceptable for small data sets
            var matches = _loginInfoDataSource.Servers.Where((group) => group.UniqueId.Equals(uniqueId));
            if (matches.Count() == 1) return matches.First();
            return null;
        }

        private async Task GetSampleDataAsync()
        {
            if (this._servers.Count != 0)
                return;

            Uri dataUri = new Uri("ms-appx:///DataModel/SampleData.json");

            StorageFile file = await StorageFile.GetFileFromApplicationUriAsync(dataUri);
            string jsonText = await FileIO.ReadTextAsync(file);
            JsonObject jsonObject = JsonObject.Parse(jsonText);
            JsonArray jsonArray = jsonObject["Servers"].GetArray();

            foreach (JsonValue groupValue in jsonArray)
            {
                JsonObject groupObject = groupValue.GetObject();
                ServerInfo server = new ServerInfo(groupObject["UniqueId"].GetString(),
                                                   groupObject["ServerName"].GetString(),
                                                   groupObject["ServerUrl"].GetString());

                this.Servers.Add(server);
            }
        }
    }
}